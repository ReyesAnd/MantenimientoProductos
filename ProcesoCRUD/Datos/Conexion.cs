using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesoCRUD.Datos
{
    public class Conexion
    {
        private string DB;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private static Conexion Connection = null;

        private Conexion()
        {
            this.DB = "CRUD_DB";
            this.Servidor = "DELLREYES";
            this.Usuario = "user_vr";
            this.Clave = "Temporal00";
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor +
                                        "; Database=" + this.DB +
                                        "; User Id=" + this.Usuario +
                                        "; Password=" + this.Clave;
            }
            catch (Exception ex)
            {
                Cadena = null; 
                throw ex;
            }

            return Cadena;
        }

        public static Conexion getInstancia() //SI LA CONECCION ES NULL CREA UNA DE LO CONTRARIO RETORNA LA CONECCION CREADA.
        {
            if (Connection == null)
            {
                Connection = new Conexion();
            }
            
            return Connection;
        }
    }
}
