using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        AccesoDato dato = new AccesoDato();

        public Articulo traerArticulo(String id)
        {
            try
            {
                                                
                    dato.hacerConsulta("select a.Id, Codigo, Nombre,a.Descripcion, m.Descripcion as descripcionMarca ,IdMarca,IdCategoria,ImagenUrl,Precio from ARTICULOS a,MARCAS m where a.Id =@id And m.Id=IdMarca");
                    dato.setearParametros("@id", id);
                    dato.ejecutarLectura();
                

                if(dato.Lector.Read())
                {
                    Articulo arti = new Articulo();

                    arti.Id = (int)dato.Lector["Id"];
                    arti.Codigo = (String)dato.Lector["Codigo"];
                    arti.Nombre = (String)dato.Lector["Nombre"];
                    arti.Descripcion = (String)dato.Lector["Descripcion"];
                    arti.Precio = Convert.ToDouble(dato.Lector["Precio"]);
                    
                    arti.IdMarca= new Marca();
                    arti.IdMarca.Id= (int)dato.Lector["IdMarca"];
                    arti.IdMarca.Descripcion = dato.Lector["descripcionMarca"].ToString();
                    
                
                    arti.IdCategoria= new Categoria();
                    arti.IdCategoria.Id = (int)dato.Lector["IdCategoria"];
                 

                    if (dato.Lector["imagenUrl"]  != null)
                    {
                        arti.UrlImagen = dato.Lector["ImagenUrl"].ToString();
                    }

                    return arti;

                }

                return null;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { dato.cerrarConexion();  }

        }

        public List<Articulo> listaArticulos()
        {

            List<Articulo> listaArt = new List<Articulo>();


            try
            {
                dato.hacerConsulta("SELECT a.Id ,Codigo, Nombre, a.Descripcion, m.Descripcion marca, c.Descripcion categoria, c.Id idCategoria,m.Id idMarca, Precio, ImagenUrl FROM ARTICULOS a , MARCAS m, CATEGORIAS c where a.IdMarca = m.Id and a.IdCategoria= c.Id ");
                dato.ejecutarLectura();

                while (dato.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)dato.Lector["Id"];
                    art.Codigo = (String)dato.Lector["Codigo"];
                    art.Nombre = (String)dato.Lector["Nombre"];
                    art.Descripcion = (String)dato.Lector["Descripcion"];
                   

                    art.IdMarca = new Marca();
                    art.IdMarca.Id= (int)dato.Lector["idMarca"];
                    art.IdMarca.Descripcion = (String)dato.Lector["marca"];
                    
                    art.IdCategoria = new Categoria();
                    art.IdCategoria.Id = (int)dato.Lector["idCategoria"];
                    art.IdCategoria.Descripcion = (String)dato.Lector["categoria"];
                    art.Precio = Convert.ToDouble(dato.Lector["Precio"]);


                    if (!(dato.Lector["ImagenUrl"] is DBNull))
                    {
                        art.UrlImagen = (String)dato.Lector["ImagenUrl"];

                    }

                    listaArt.Add(art);

                }

                return listaArt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { dato.cerrarConexion(); };


        }


        public void agregarArticulo(Articulo arti)
        {


            try
            {
                dato.hacerConsulta("Insert into ARTICULOS (Codigo,Nombre,Descripcion,Precio,ImagenUrl,IdMarca,IdCategoria) Values (@codigo,@nombre,@descripcion,@precio,@urlimagen,@idmarca,@idCategoria); ");

                dato.setearParametros("@codigo", arti.Codigo);
                dato.setearParametros("@nombre", arti.Nombre);
                dato.setearParametros("@descripcion", arti.Descripcion);
                dato.setearParametros("@precio", Convert.ToDouble(arti.Precio));
                dato.setearParametros("@urlimagen", (object)arti.UrlImagen ?? DBNull.Value);
                dato.setearParametros("@idmarca", arti.IdMarca.Id);
                dato.setearParametros("@idCategoria", arti.IdCategoria.Id);

                dato.ejecutarAccion();



            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { dato.cerrarConexion(); }



        }


        public void eliminarArticulo(int id)
        {
            try
            {
                Console.WriteLine("Iniciando eliminación del artículo con ID: " + id);

                dato.hacerConsulta("Delete from Articulos where id = @id");
                dato.setearParametros("@id", id);
                
                Console.WriteLine("@id: " + id);
                dato.ejecutarAccion();
                Console.WriteLine("Eliminación exitosa del artículo con ID: " + id);

            }
            catch (Exception ex)

            {
                Console.WriteLine("Excepción en eliminarArticulo: " + ex.ToString());
                Console.WriteLine("Error durante la eliminación del artículo. Detalles: " + ex.Message);
                
            }
            finally { dato.cerrarConexion(); };
           

        }


        public void modificarArt(Articulo art)
        {

            try
            {
                dato.hacerConsulta("UPDATE ARTICULOS SET Codigo=@codigo, Nombre=@nombre, Descripcion=@descripcion," +
                    " IdMarca=@idmarca, IdCategoria=@idcategoria, Precio=@precio, ImagenUrl=@imagen WHERE Id=@id");
                dato.setearParametros("@codigo", art.Codigo);
                dato.setearParametros("@nombre", art.Nombre);
                dato.setearParametros("@descripcion", art.Descripcion);
                dato.setearParametros("@idmarca", art.IdMarca.Id);
                dato.setearParametros("@idcategoria", art.IdCategoria.Id);
                dato.setearParametros("@precio", Convert.ToDouble(art.Precio));
                dato.setearParametros("@imagen",(object)art.UrlImagen ?? DBNull.Value);
                dato.setearParametros("@id", art.Id);


                dato.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            finally { dato.cerrarConexion(); }

        }

        public List<Articulo> filtrar(String campo, String criterio, String filtro)
        {
            
            List<Articulo> listafiltro= new List<Articulo> ();

            try
            {
                String consulta = "SELECT a.Id ,Codigo, Nombre, a.Descripcion, m.Descripcion marca, c.Descripcion categoria, c.Id idCategoria,m.Id idMarca, Precio, ImagenUrl FROM ARTICULOS a , MARCAS m, CATEGORIAS c where a.IdMarca = m.Id and a.IdCategoria= c.Id and ";

                if (campo == "precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a ":
                            consulta += "Precio > " + filtro;
                            break;
                        case "menor a ":
                            consulta += "Precio < " + filtro    ;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }

                }
                else if (campo == "nombre")
                {
                    switch (criterio)
                    {
                        case "comienza con":
                            consulta += "Nombre like ' " + filtro + "%'";
                            break;
                        case " termina con":
                            consulta += "Nombre like '%" + filtro + " ' ";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "comienza con":
                            consulta += "m.Descripcion like ' " +filtro+ "%'";
                            break;
                        case " termina con":
                            consulta += "m.Descripcion like '%" +filtro+ " ' ";
                            break;
                        default:
                            consulta += "m.Descripcion like '%" + filtro + "%'";
                            break;
                    }

                }
                Console.WriteLine(consulta);    

                dato.hacerConsulta(consulta);
                dato.ejecutarLectura();
                while (dato.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)dato.Lector["Id"];
                    art.Codigo = (String)dato.Lector["Codigo"];
                    art.Nombre = (String)dato.Lector["Nombre"];
                    art.Descripcion = (String)dato.Lector["Descripcion"];


                    art.IdMarca = new Marca();
                    art.IdMarca.Id = (int)dato.Lector["idMarca"];
                    art.IdMarca.Descripcion = (String)dato.Lector["marca"];

                    art.IdCategoria = new Categoria();
                    art.IdCategoria.Id = (int)dato.Lector["idCategoria"];
                    art.IdCategoria.Descripcion = (String)dato.Lector["categoria"];
                    art.Precio = Convert.ToDouble(dato.Lector["Precio"]);


                    if (!(dato.Lector["ImagenUrl"] is DBNull))
                    {
                        art.UrlImagen = (String)dato.Lector["ImagenUrl"];

                    }

                    listafiltro.Add(art);
                }
                return listafiltro;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { dato.cerrarConexion(); }
           
        }

    }
}

