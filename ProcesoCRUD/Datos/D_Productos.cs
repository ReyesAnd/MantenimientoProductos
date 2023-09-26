using ProcesoCRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesoCRUD.Datos
{
    public class D_Productos
    {
        public DataTable Listado_Productos(string cTexto)
        {
            SqlDataReader Resultado;
            DataTable Table = new DataTable();
            SqlConnection Connection = new SqlConnection();

            try
            {
                Connection = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Listado_Producto", Connection);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@cTexto", SqlDbType.VarChar).Value = cTexto;

                Connection.Open();
                Resultado = Comando.ExecuteReader();
                
                Table.Load(Resultado);
                return Table;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally { if (Connection.State == ConnectionState.Open) Connection.Close(); }   // SI LA CONECCION EN ESTE PUNTO ESTA ABIERTA LA CIERRA
        }

        public string Guardar_Producto(int nOpcion, E_Productos oPro)
        {
            string respuesta = "";
            SqlConnection SqlConnection = new SqlConnection();

            try 
            {
                SqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Guardar_Producto", SqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@Opcion", SqlDbType.Int).Value = nOpcion;
                Comando.Parameters.Add("@nCodigo_Producto", SqlDbType.Int).Value = oPro.Codigo_Producto;
                Comando.Parameters.Add("@cDescripcion_Producto", SqlDbType.VarChar).Value = oPro.Descripcion_Producto;
                Comando.Parameters.Add("@cMarca_Producto", SqlDbType.VarChar).Value = oPro.Marca_Producto;
                Comando.Parameters.Add("@nCodigo_Medida", SqlDbType.Int).Value = oPro.Codigo_Medida;
                Comando.Parameters.Add("@nCodigo_Categoria", SqlDbType.Int).Value = oPro.Codigo_Categoria;
                Comando.Parameters.Add("@nStock_Actual", SqlDbType.Decimal).Value = oPro.Stock_Actual;

                SqlConnection.Open();
                respuesta = Comando.ExecuteNonQuery()>=1 ? "OK" : "NO SE PUDO REGISTRAR LOS DATOS";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open) SqlConnection.Close();
            }

            return respuesta;
        }

        public string Activo_Producto(int nCodigo_Producto, bool bEstado_Activo)
        {
            string respuesta = "";
            SqlConnection SqlConnection = new SqlConnection();

            try
            {
                SqlConnection = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Activo_Producto", SqlConnection);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nCodigo_Producto", SqlDbType.Int).Value = nCodigo_Producto;
                Comando.Parameters.Add("@bEstado_Activo", SqlDbType.Bit).Value = bEstado_Activo;

                SqlConnection.Open();
                respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "NO SE PUDO CAMBIAR EL ESTADO ACTIVO DEL PRODUCTO";
            }
            catch(Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlConnection.State == ConnectionState.Open) SqlConnection.Close();
            }

            return respuesta;
        }

        public DataTable Listado_Medidas()
        {
            SqlDataReader Resultado;
            DataTable Table = new DataTable();
            SqlConnection Connection = new SqlConnection();

            try
            {
                Connection = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Listado_Medida", Connection);
                Comando.CommandType = CommandType.StoredProcedure;

                Connection.Open();
                Resultado = Comando.ExecuteReader();

                Table.Load(Resultado);
                return Table;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally { if (Connection.State == ConnectionState.Open) Connection.Close(); }   // SI LA CONECCION EN ESTE PUNTO ESTA ABIERTA LA CIERRA
        }

        public DataTable Listado_Categorias()
        {
            SqlDataReader Resultado;
            DataTable Table = new DataTable();
            SqlConnection Connection = new SqlConnection();

            try
            {
                Connection = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("USP_Listado_Categoria", Connection);
                Comando.CommandType = CommandType.StoredProcedure;

                Connection.Open();
                Resultado = Comando.ExecuteReader();

                Table.Load(Resultado);
                return Table;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally { if (Connection.State == ConnectionState.Open) Connection.Close(); }   // SI LA CONECCION EN ESTE PUNTO ESTA ABIERTA LA CIERRA
        }
    }
}
