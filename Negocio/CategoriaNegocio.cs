using Dominio;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        AccesoDato dato = new AccesoDato();

        public CategoriaNegocio() { }

        public List<Categoria> listaCategoria()
        {
            List<Categoria> listacat = new List<Categoria>();



            try
            {
                dato.hacerConsulta("select Id, Descripcion from Categorias ");
                dato.ejecutarLectura();

                while (dato.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)dato.Lector["Id"];
                    aux.Descripcion = (String)dato.Lector["Descripcion"];

                    listacat.Add(aux);
                }

                return listacat;
            }
            catch (Exception)
            {

                throw;
            }

            finally { dato.cerrarConexion(); }




        }

        public void agregarCategoria(String categoria)
        {
            try
            {
                dato.hacerConsulta("insert into Categorias (Descripcion) Values (@Descripcion)");
                dato.setearParametros("@Descripcion", categoria);
                dato.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { dato.cerrarConexion(); }

        }

        public void eliminarCat(int id)
        {
            try
            {
                if (id != 0)
                {
                    dato.hacerConsulta("delete from Categorias where Id= @Id");
                    dato.setearParametros("@Id", id);
                    dato.ejecutarLectura();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { dato.cerrarConexion(); }

        }

        public void modificarCat(Categoria cat)
        {
            try
            {
                dato.hacerConsulta("Update Categorias set Descripcion= @Descripcion where id=@Id ");
                dato.setearParametros("@Descripcion", cat.Descripcion);
                dato.setearParametros("@Id", cat.Id);
                dato.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dato.cerrarConexion();
            }
        }

    }
}
