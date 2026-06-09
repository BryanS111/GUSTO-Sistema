using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace SistemaInventarioWF
{
    public static class FacturaCorreoService
    {
        public static bool EnviarFactura(string destinatario, string nombreCliente, string rutaPdf, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(destinatario))
            {
                error = "El cliente no tiene correo electronico registrado.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(rutaPdf) || !File.Exists(rutaPdf))
            {
                error = "No se encontro el archivo PDF de la factura.";
                return false;
            }

            string host = ObtenerConfiguracion("SmtpHost");
            string usuario = ObtenerConfiguracion("SmtpUser");
            string password = ObtenerConfiguracion("SmtpPassword");
            string fromAddress = ObtenerConfiguracion("SmtpFromAddress");
            string fromName = ObtenerConfiguracion("SmtpFromName", "G.U.S.T.O");
            string asunto = ObtenerConfiguracion("FacturaSubject", "FACTURA - G.U.S.T.O");
            string cuerpoBase = ObtenerConfiguracion("FacturaBody", "Factura emitida por el sistema G.U.S.T.O, gracias por su compra.");

            if (string.IsNullOrWhiteSpace(host))
            {
                error = "Falta configurar SmtpHost en App.config.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(usuario))
            {
                error = "Falta configurar SmtpUser en App.config.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                error = "Falta configurar SmtpPassword en App.config.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(fromAddress))
                fromAddress = usuario;

            int puerto = 587;
            int.TryParse(ObtenerConfiguracion("SmtpPort", "587"), out puerto);

            bool ssl = true;
            bool.TryParse(ObtenerConfiguracion("SmtpEnableSsl", "true"), out ssl);

            string cuerpo = string.IsNullOrWhiteSpace(nombreCliente)
                ? cuerpoBase
                : cuerpoBase + Environment.NewLine + "Cliente: " + nombreCliente;

            try
            {
                using (MailMessage mensaje = new MailMessage())
                {
                    mensaje.From = new MailAddress(fromAddress, fromName);
                    mensaje.To.Add(destinatario.Trim());
                    mensaje.Subject = asunto;
                    mensaje.Body = cuerpo;
                    mensaje.IsBodyHtml = false;
                    mensaje.Attachments.Add(new Attachment(rutaPdf));

                    using (SmtpClient smtp = new SmtpClient(host, puerto))
                    {
                        smtp.EnableSsl = ssl;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(usuario, password);
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(mensaje);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        private static string ObtenerConfiguracion(string clave, string valorPorDefecto = "")
        {
            string valor = ConfigurationManager.AppSettings[clave];
            return string.IsNullOrWhiteSpace(valor) ? valorPorDefecto : valor.Trim();
        }
    }
}
