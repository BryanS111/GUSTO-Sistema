using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    class Conexion
    {
        private readonly string connString = string.Empty;
        private readonly string configError = string.Empty;

        public SqlConnection conn;

        public Conexion()
        {
            conn = new SqlConnection();

            try
            {
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["connSQLServer"];
                if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
                {
                    configError = "No se encontro la cadena de conexion 'connSQLServer' en App.config.";
                    return;
                }

                connString = settings.ConnectionString;
                conn.ConnectionString = connString;
            }
            catch (ConfigurationErrorsException ex)
            {
                configError = ex.Message;
            }
        }

        public SqlConnection AbrirConexion(out string pError)
        {
            pError = string.Empty;

            if (!string.IsNullOrWhiteSpace(configError))
            {
                pError = configError;
                return null;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                return conn;
            }
            catch (SqlException ex)
            {
                pError = ex.Message;
                return null;
            }
            catch (InvalidOperationException ex)
            {
                pError = ex.Message;
                return null;
            }
        }

        public void CerrarConexion(out string pError)
        {
            pError = string.Empty;

            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                pError = ex.Message;
            }
            catch (InvalidOperationException ex)
            {
                pError = ex.Message;
            }
        }
    }
}
