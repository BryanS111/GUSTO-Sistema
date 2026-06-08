using DAO;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaInventarioWF
{
    public partial class frmConsultaStockInventario : Form
    {
        private InventarioDAO _inventarioDAO;
        private DataTable _dtInventarioCompleto;

        public frmConsultaStockInventario()
        {
            InitializeComponent();
            _inventarioDAO = new InventarioDAO();
            this.Load += new EventHandler(frmConsultaStockInventario_Load); // ← ESTA LÍNEA ES CLAVE
        }

        private void frmConsultaStockInventario_Load(object sender, EventArgs e)
        {
            CargarTiposInventario();
            CargarTodoInventario(); // Carga inicial sin filtros
        }

        private void CargarTiposInventario()
        {
            string error;
            DataTable dtTipos = _inventarioDAO.ObtenerTiposInventario(out error);
            if (dtTipos != null)
            {
                // Agregar opción "Todos"
                DataRow rowTodos = dtTipos.NewRow();
                rowTodos["Codigo"] = DBNull.Value;
                rowTodos["Tipo"] = "Todos";
                dtTipos.Rows.InsertAt(rowTodos, 0);

                cboTipoInventario.DataSource = dtTipos;
                cboTipoInventario.DisplayMember = "Tipo";
                cboTipoInventario.ValueMember = "Codigo";
                cboTipoInventario.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Error al cargar tipos de inventario: " + error);
            }
        }

        private void CargarTodoInventario()
        {
            string error;
            _dtInventarioCompleto = _inventarioDAO.ObtenerTodosDataTable(out error);
            if (_dtInventarioCompleto == null)
            {
                MessageBox.Show("Error al cargar inventario: " + error);
                return;
            }
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            if (_dtInventarioCompleto == null) return;

            string filtro = "";
            string textoBuscar = txtBuscarInsumo.Text.Trim();

            // Filtro por tipo de inventario
            if (cboTipoInventario.SelectedValue != null && cboTipoInventario.SelectedValue != DBNull.Value)
            {
                string tipoSeleccionado = ((DataRowView)cboTipoInventario.SelectedItem)["Tipo"].ToString().Replace("'", "''");
                filtro = $"[Tipo Inventario] = '{tipoSeleccionado}'";
            }

            // Filtro por texto (nombre o ID)
            if (!string.IsNullOrWhiteSpace(textoBuscar))
            {
                string filtroTexto = $"Producto LIKE '%{textoBuscar.Replace("'", "''")}%'";

                // Si el texto es un número, también buscamos por ID
                if (int.TryParse(textoBuscar, out int id))
                    filtroTexto += $" OR Codigo = {id}";

                if (!string.IsNullOrEmpty(filtro))
                    filtro += " AND (" + filtroTexto + ")";
                else
                    filtro = filtroTexto;
            }

            DataView dv = _dtInventarioCompleto.DefaultView;
            dv.RowFilter = filtro;
            dv.Sort = "Cantidad ASC";

            DataTable dtFiltrado = dv.ToTable();
            dgvInventarioStock.DataSource = dtFiltrado;

            // Ocultar columnas
            if (dgvInventarioStock.Columns["Codigo"] != null)
                dgvInventarioStock.Columns["Codigo"].Visible = false;
            if (dgvInventarioStock.Columns["EstadoId"] != null)
                dgvInventarioStock.Columns["EstadoId"].Visible = false;
            if (dgvInventarioStock.Columns["UsuarioRegistroId"] != null)
                dgvInventarioStock.Columns["UsuarioRegistroId"].Visible = false;
            if (dgvInventarioStock.Columns["UsuarioModificacionId"] != null)
                dgvInventarioStock.Columns["UsuarioModificacionId"].Visible = false;

            dgvInventarioStock.Refresh();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void txtBuscarInsumo_TextChanged(object sender, EventArgs e)
        {
            // Búsqueda en tiempo real al escribir
            AplicarFiltros();
        }

        private void cboTipoInventario_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        // Evento para pintar de rojo las filas con stock bajo
        private void dgvInventarioStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvInventarioStock.Columns[e.ColumnIndex].Name == "Cantidad" && e.Value != null)
            {
                double cantidad = Convert.ToDouble(e.Value);
                if (cantidad < 15)
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }

        // Eventos vacíos del diseñador
        private void label2_Click(object sender, EventArgs e) { }
        private void dgvInventarioStock_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}