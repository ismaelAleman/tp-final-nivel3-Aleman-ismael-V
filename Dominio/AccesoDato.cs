using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class AccesoDato
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector { get {  return lector; } }


        public AccesoDato() 
        {
            conexion= new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated Security= true");
            comando= new SqlCommand();  
            
        }



        public void hacerConsulta(String consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText= consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public void cerrarConexion()
        {
            if(lector!= null)
            {
                lector.Close();
                conexion.Close();
            }
        }


        public void setearParametros(String nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }


    }
}
