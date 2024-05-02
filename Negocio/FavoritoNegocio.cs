using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FavoritoNegocio
    {

        AccesoDato dato = new AccesoDato();

        public FavoritoNegocio() { }

        public List<Articulo> traerFavoritos(string Id)
        {
            List<Articulo> listafav= new List<Articulo>();
            try
            {
                dato.hacerConsulta("select a.Id as IdArt, Codigo,a.Nombre as nombreArt, a.Descripcion as artDescripcion,m.Descripcion as desMarca,c.Descripcion as desCategoria  , idMarca, IdCategoria, ImagenUrl, precio from ARTICULOS a, USERS u, FAVORITOS, MARCAS m, CATEGORIAS c where u.Id = @Id and a.Id = IdArticulo and a.IdMarca = m.Id and a.IdCategoria = c.Id ");
                dato.setearParametros("@Id", Id);
                dato.ejecutarLectura();


                while(dato.Lector.Read())
                {
                    Articulo artfav = new Articulo();

                    artfav.Id = (int)dato.Lector["IdArt"];
                    artfav.Codigo = (String) dato.Lector["Codigo"];
                    artfav.Nombre = (String)dato.Lector["nombreArt"];
                    artfav.Descripcion = (String)dato.Lector["artDescripcion"];
                    artfav.Precio = double.Parse(dato.Lector["precio"].ToString());
                    
                    artfav.IdMarca = new Marca();
                    artfav.IdMarca.Id = (int)dato.Lector["idMarca"];
                    artfav.IdMarca.Descripcion = (String)dato.Lector["desMarca"];

                    artfav.IdCategoria= new Categoria();
                    artfav.IdCategoria.Id = (int)dato.Lector["idCategoria"];
                    artfav.IdCategoria.Descripcion=(String)dato.Lector["desCategoria"];

                    artfav.UrlImagen = !String.IsNullOrEmpty((String)dato.Lector["ImagenUrl"]) ? (String)dato.Lector["ImagenUrl"] : null ;                
                 

                    listafav.Add(artfav);

                }

                return listafav;
  
                
            }
            
            catch (Exception ex)
            {

                throw ex;
            }

            finally { dato.cerrarConexion(); }


        }

        public void agregarFav(string IdUsuario, string IdArt)
        {

            try
            {
                dato.hacerConsulta("insert into FAVORITOS (IdUser, IdArticulo) values (@idUser, @idArt)");
                dato.setearParametros("@idUser", IdUsuario);
                dato.setearParametros("@idArt", IdArt);
                dato.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dato.cerrarConexion(); }
        }


        public void eliminarfav(string id)
        {
            try
            {
                dato.hacerConsulta("delete from FAVORITOS where Id= @Id");
                dato.setearParametros("@Id", id);
                dato.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { dato.cerrarConexion(); }

        }


    }
}
