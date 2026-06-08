using DAO;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class MenuCombosView : Form
    {
        private InterfazPrincipal_Admin _abuelo;
        private MenuComboDAO _dao;
        private List<Modelos.Menu> _listaMenus;
        private List<Combo> _listaCombos;
        private List<DetalleCombo> _listaDetalle;
        private bool _modoEdicion;
        private int _idActual;
        private int _idInventarioSeleccionado;
        private int _idMenuSeleccionado;
        private string _modo; // "MENU" o "COMBO"

        public MenuCombosView(InterfazPrincipal_Admin abuelo)
        {
            InitializeComponent();
            _abuelo = abuelo;
            _dao = new MenuComboDAO();
            _modoEdicion = false;
            _idActual = 0;
            _idInventarioSeleccionado = 0;
            _idMenuSeleccionado = 0;
            _modo = "MENU";

            // Configuración visual
            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new Size(1298, 961);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            MoverDataGridViewFueraDelGroupBox();
            MoverControlesSeleccionFueraDelGroupBox();

            this.dgvInventario.CellClick += dgvInventario_CellClick;

            this.Load += new EventHandler(MenuCombosView_Load);
        }

        // -------------------------- CARGA INICIAL --------------------------
        private void MenuCombosView_Load(object sender, EventArgs e)
        {
            cboTipo.Items.Add("Menú");
            cboTipo.Items.Add("Combo");
            cboTipo.SelectedIndex = 0;
            CargarCombosBase();
            CambiarModo("MENU");
            ModoFormulario(false);
            if (this.Parent != null)
            {
                this.Location = new Point(
                    (this.Parent.Width - this.Width) / 2,
                    (this.Parent.Height - this.Height) / 2
                );
            }
        }

        // -------------------------- CAMBIO DE MODO --------------------------
        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == 0) CambiarModo("MENU");
            else CambiarModo("COMBO");
        }

        private void CambiarModo(string modo)
        {
            _modo = modo;
            _modoEdicion = false;
            _idActual = 0;
            _idInventarioSeleccionado = 0;
            _idMenuSeleccionado = 0;

            bool esMenu = (modo == "MENU");
            txtDescripcion.Visible = !esMenu;
            label11.Visible = !esMenu;
            dgvInventario.Visible = esMenu;
            label6.Visible = esMenu;
            dgvCombo.Visible = !esMenu;
            label9.Visible = !esMenu;
            btnAgregarMenu.Visible = !esMenu;
            btnQuitarMenu.Visible = !esMenu;
            numCantidad.Visible = !esMenu;
            txtBuscarInventarioMenu.Text = "";

            LimpiarCampos();
            ModoFormulario(false);

            if (esMenu)
            {
                CargarGrillaMenu();
            }
            else
            {
                CargarGrillaCombo();
            }
        }

        // -------------------------- CARGA DE COMBOS BASE --------------------------
        private void CargarCombosBase()
        {
            string error;
            DataTable dtCat = _dao.ObtenerCategorias(out error);
            if (dtCat != null)
            {
                cboCategoria.DataSource = dtCat;
                cboCategoria.DisplayMember = "Categoria";
                cboCategoria.ValueMember = "CategoriaId";
            }
            DataTable dtEst = _dao.ObtenerEstados("MENU", out error);
            if (dtEst != null)
            {
                cboEstado.DataSource = dtEst;
                cboEstado.DisplayMember = "Estado";
                cboEstado.ValueMember = "Id";
            }
        }

        // -------------------------- GRILLAS PRINCIPALES --------------------------
        private void CargarGrillaMenu()
        {
            string error;
            _listaMenus = _dao.ObtenerTodosMenus(out error);
            if (_listaMenus == null) { MessageBox.Show(error, "Error"); return; }
            dgvDatosComboMenu.DataSource = null;
            dgvDatosComboMenu.AutoGenerateColumns = true;
            dgvDatosComboMenu.DataSource = _listaMenus;

            // Ocultar columna de stock (no aplica para la mayoría de menús)
            if (dgvDatosComboMenu.Columns["Stock"] != null)
                dgvDatosComboMenu.Columns["Stock"].Visible = false;

            OcultarColumnasMenu();
        }

        private void CargarGrillaCombo()
        {
            string error;
            _listaCombos = _dao.ObtenerTodosCombos(out error);
            if (_listaCombos == null) { MessageBox.Show(error, "Error"); return; }
            dgvDatosComboMenu.DataSource = null;
            dgvDatosComboMenu.AutoGenerateColumns = true;
            dgvDatosComboMenu.DataSource = _listaCombos;
            OcultarColumnasCombo();
        }

        private void OcultarColumnasMenu()
        {
            if (dgvDatosComboMenu.Columns["MenuId"] != null) dgvDatosComboMenu.Columns["MenuId"].Visible = false;
            if (dgvDatosComboMenu.Columns["InventarioId"] != null) dgvDatosComboMenu.Columns["InventarioId"].Visible = false;
        }

        private void OcultarColumnasCombo()
        {
            if (dgvDatosComboMenu.Columns["ComboId"] != null) dgvDatosComboMenu.Columns["ComboId"].Visible = false;
        }

        // -------------------------- BUSCADOR DINÁMICO --------------------------
        private void txtBuscarInventarioMenu_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscarInventarioMenu.Text.Trim();
            if (string.IsNullOrEmpty(texto))
            {
                if (_modo == "MENU") dgvInventario.DataSource = null;
                else
                {
                    string error;
                    List<Modelos.Menu> todos = _dao.BuscarMenus("", out error);
                    dgvCombo.DataSource = todos;
                }
                return;
            }
            string errorBusq;
            if (_modo == "MENU")
            {
                DataTable dt = _dao.ObtenerInventarios(out errorBusq);
                if (dt != null)
                {
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = $"Producto LIKE '%{texto}%'";
                    dgvInventario.DataSource = dv;
                }
            }
            else
            {
                List<Modelos.Menu> menus = _dao.BuscarMenus(texto, out errorBusq);
                dgvCombo.DataSource = menus;
            }
        }

        // -------------------------- SELECCIÓN DE INVENTARIO (MODO MENÚ) --------------------------
        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInventario.SelectedRows.Count == 0) return;
            DataRowView drv = dgvInventario.SelectedRows[0].DataBoundItem as DataRowView;
            if (drv != null)
            {
                _idInventarioSeleccionado = Convert.ToInt32(drv["Codigo"]);
                string nombreProducto = drv["Producto"].ToString();
                MessageBox.Show($"Producto seleccionado: {nombreProducto} (ID: {_idInventarioSeleccionado})",
                                "Inventario seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // -------------------------- VALIDACIÓN CATEGORÍA BEBIDA --------------------------
        private bool EsCategoriaBebida()
        {
            if (cboCategoria.SelectedItem == null) return false;
            DataRowView drv = cboCategoria.SelectedItem as DataRowView;
            if (drv != null)
            {
                string categoria = drv["Categoria"].ToString().ToUpper();
                return categoria.Contains("BEBIDA");
            }
            return false;
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modo == "MENU" && EsCategoriaBebida())
            {
                string error;
                DataTable dt = _dao.ObtenerInventarios(out error);
                if (dt != null)
                {
                    dgvInventario.DataSource = dt;
                    dgvInventario.AutoGenerateColumns = true;
                    if (dgvInventario.Columns["Codigo"] != null)
                        dgvInventario.Columns["Codigo"].Visible = false;
                }
            }
            else if (_modo == "MENU")
            {
                dgvInventario.DataSource = null;
                _idInventarioSeleccionado = 0;
            }
        }

        // -------------------------- CRUD PRINCIPAL --------------------------
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _modoEdicion = false;
            _idActual = 0;
            _idInventarioSeleccionado = 0;
            _idMenuSeleccionado = 0;
            LimpiarCampos();
            ModoFormulario(true);

            if (_modo == "COMBO")
            {
                string error;
                List<Modelos.Menu> todosMenus = _dao.BuscarMenus("", out error);
                dgvCombo.DataSource = (todosMenus != null) ? todosMenus : null;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatosComboMenu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_modo == "MENU")
            {
                Modelos.Menu m = dgvDatosComboMenu.SelectedRows[0].DataBoundItem as Modelos.Menu;
                if (m == null) return;
                _idActual = m.MenuId;
                txtNombre.Text = m.Nombre;
                txtPrecio.Text = m.Precio.ToString("F2");
                cboCategoria.SelectedValue = m.CategoriaId;
                cboEstado.SelectedValue = m.EstadoId;
                _idInventarioSeleccionado = m.InventarioId ?? 0;
                txtDescripcion.Text = "";
                CargarDetalleCombo(0);
            }
            else
            {
                Combo c = dgvDatosComboMenu.SelectedRows[0].DataBoundItem as Combo;
                if (c == null) return;
                _idActual = c.ComboId;
                txtNombre.Text = c.Nombre;
                txtDescripcion.Text = c.Descripcion;
                txtPrecio.Text = c.Precio.ToString("F2");
                cboCategoria.SelectedValue = c.CategoriaId;
                cboEstado.SelectedValue = c.EstadoId;
                CargarDetalleCombo(c.ComboId);
            }
            _modoEdicion = true;
            ModoFormulario(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            string error;

            if (_modo == "MENU")
            {
                if (EsCategoriaBebida() && _idInventarioSeleccionado == 0)
                {
                    MessageBox.Show("Para categorías de bebidas debe seleccionar un producto del inventario.",
                                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Modelos.Menu m = new Modelos.Menu
                {
                    MenuId = _idActual,
                    Nombre = txtNombre.Text.Trim(),
                    Precio = decimal.Parse(txtPrecio.Text.Trim()),
                    InventarioId = _idInventarioSeleccionado > 0 ? _idInventarioSeleccionado : (int?)null,
                    CategoriaId = (int)cboCategoria.SelectedValue,
                    EstadoId = (int)cboEstado.SelectedValue
                };

                if (!_modoEdicion) _dao.GuardarMenu(m, out error);
                else _dao.ActualizarMenu(m, out error);
            }
            else // MODO COMBO
            {
                // Validar que el combo tenga al menos un detalle (menú agregado)
                if (dgvCombo.Rows.Count == 0 || _listaDetalle == null || _listaDetalle.Count == 0)
                {
                    MessageBox.Show("Debe agregar al menos un menú al combo antes de guardar.",
                                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Combo c = new Combo
                {
                    ComboId = _idActual,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Precio = decimal.Parse(txtPrecio.Text.Trim()),
                    CategoriaId = (int)cboCategoria.SelectedValue,
                    EstadoId = (int)cboEstado.SelectedValue
                };

                if (!_modoEdicion) _dao.GuardarCombo(c, out error);
                else _dao.ActualizarCombo(c, out error);
            }

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_modo == "MENU") CargarGrillaMenu(); else CargarGrillaCombo();
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatosComboMenu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("¿Desactivar este registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string error;
            if (_modo == "MENU")
            {
                Modelos.Menu m = dgvDatosComboMenu.SelectedRows[0].DataBoundItem as Modelos.Menu;
                _dao.EliminarLogicoMenu(m.MenuId, out error);
            }
            else
            {
                Combo c = dgvDatosComboMenu.SelectedRows[0].DataBoundItem as Combo;
                _dao.EliminarLogicoCombo(c.ComboId, out error);
            }
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Registro desactivado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (_modo == "MENU") CargarGrillaMenu(); else CargarGrillaCombo();
            LimpiarCampos();
            ModoFormulario(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ModoFormulario(false);
        }

        // -------------------------- DETALLE COMBO --------------------------
        private void btnAgregarMenu_Click(object sender, EventArgs e)
        {
            if (dgvCombo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un menú en la lista inferior.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_idActual == 0)
            {
                MessageBox.Show("Primero debe guardar el combo o seleccionar uno existente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Modelos.Menu menuSeleccionado = dgvCombo.SelectedRows[0].DataBoundItem as Modelos.Menu;
            if (menuSeleccionado == null) return;

            int cantidad = (int)numCantidad.Value;
            string error;
            _dao.AgregarDetalleCombo(_idActual, menuSeleccionado.MenuId, cantidad, (int)cboCategoria.SelectedValue, out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Se agregaron {cantidad} {menuSeleccionado.Nombre}", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarDetalleCombo(_idActual);
        }

        private void btnQuitarMenu_Click(object sender, EventArgs e)
        {
            if (dgvCombo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un detalle para quitar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DetalleCombo det = dgvCombo.SelectedRows[0].DataBoundItem as DetalleCombo;
            if (det == null) return;

            string error;
            _dao.QuitarDetalleCombo(det.DetalleComboId, out error);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CargarDetalleCombo(_idActual);
        }

        private void CargarDetalleCombo(int comboId)
        {
            if (comboId == 0) { dgvCombo.DataSource = null; _listaDetalle = null; return; }
            string error;
            _listaDetalle = _dao.ObtenerDetalleCombo(comboId, out error);
            dgvCombo.DataSource = _listaDetalle;
        }

        // -------------------------- BÚSQUEDA PRINCIPAL --------------------------
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string buscar = textBox1.Text.Trim();
            if (_modo == "MENU")
            {
                string error;
                _listaMenus = _dao.BuscarMenus(buscar, out error);
                if (_listaMenus == null) { MessageBox.Show(error, "Error"); return; }
                dgvDatosComboMenu.DataSource = _listaMenus;
                OcultarColumnasMenu();
            }
            else
            {
                string error;
                _listaCombos = _dao.BuscarCombos(buscar, out error);
                if (_listaCombos == null) { MessageBox.Show(error, "Error"); return; }
                dgvDatosComboMenu.DataSource = _listaCombos;
                OcultarColumnasCombo();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _abuelo.AbrirFormularioEnPanel(new frmMantenimientos_Menu(_abuelo));
            this.Close();
        }

        // -------------------------- MÉTODOS AUXILIARES --------------------------
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtDescripcion.Clear();
            if (cboCategoria.Items.Count > 0) cboCategoria.SelectedIndex = 0;
            if (cboEstado.Items.Count > 0) cboEstado.SelectedIndex = 0;
            txtBuscarInventarioMenu.Clear();
            dgvInventario.DataSource = null;
            dgvCombo.DataSource = null;
            numCantidad.Value = 1;
            _idInventarioSeleccionado = 0;
            _idMenuSeleccionado = 0;
            _listaDetalle = null;
        }

        private void ModoFormulario(bool habilitar)
        {
            grpBoxData.Enabled = habilitar;
            btnGuardar.Enabled = habilitar;
            btnCancelar.Enabled = habilitar;
            btnNuevo.Enabled = !habilitar;
            btnEditar.Enabled = !habilitar;
            btnEliminar.Enabled = !habilitar;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtPrecio.Text, out decimal p) || p <= 0)
            {
                MessageBox.Show("Precio inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // -------------------------- MOVER CONTROLES --------------------------
        private void MoverDataGridViewFueraDelGroupBox()
        {
            var dgv = this.dgvDatosComboMenu;
            var gbox = this.grpBoxData;
            int x = gbox.Left + dgv.Left;
            int y = gbox.Top + dgv.Top;
            int width = dgv.Width;
            int height = dgv.Height;
            gbox.Controls.Remove(dgv);
            this.Controls.Add(dgv);
            dgv.Location = new Point(x, y);
            dgv.Size = new Size(width, height);
            dgv.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgv.AllowUserToResizeColumns = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.BringToFront();
        }

        private void MoverControlesSeleccionFueraDelGroupBox()
        {
            Control[] encontrados = this.Controls.Find("gbxItems", true);
            if (encontrados.Length > 0 && encontrados[0] is GroupBox gbx)
            {
                Control[] controles = new Control[gbx.Controls.Count];
                gbx.Controls.CopyTo(controles, 0);
                for (int i = controles.Length - 1; i >= 0; i--)
                {
                    Control ctrl = controles[i];
                    int x = gbx.Left + ctrl.Left;
                    int y = gbx.Top + ctrl.Top;
                    gbx.Controls.Remove(ctrl);
                    this.Controls.Add(ctrl);
                    ctrl.Location = new Point(x, y);
                    ctrl.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    ctrl.BringToFront();
                }
                this.Controls.Remove(gbx);
                gbx.Dispose();
            }
            else
            {
                foreach (Control ctrl in new Control[] { dgvInventario, dgvCombo, btnAgregarMenu, btnQuitarMenu,
                                                         label6, label9, numCantidad })
                {
                    if (ctrl.Parent == grpBoxData)
                    {
                        int x = grpBoxData.Left + ctrl.Left;
                        int y = grpBoxData.Top + ctrl.Top;
                        grpBoxData.Controls.Remove(ctrl);
                        this.Controls.Add(ctrl);
                        ctrl.Location = new Point(x, y);
                        ctrl.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                        ctrl.BringToFront();
                    }
                }
            }
        }

        // -------------------------- EVENTOS VACÍOS --------------------------
        private void label11_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void txtDescripcion_TextChanged(object sender, EventArgs e) { }
        private void txtPrecio_TextChanged(object sender, EventArgs e) { }
        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvDatosComboMenu_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvCombo_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvCombo_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void dgvInventario_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void numCantidad_ValueChanged(object sender, EventArgs e) { }
    }
}