using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using static System.Net.Mime.MediaTypeNames;


namespace Negocio

{
    public class UsuarioNegocio
    {
        AccesoDato datos = new AccesoDato();

        public void crearUsuario(Usuario usu)
        {

            try
            {
                datos.hacerConsulta("insert into USERS ( email, pass,nombre, apellido, urlImagenPerfil, admin) values ( @Email, @Pass,@Nombre,@Apellido,@urlImagenPerfil,@Admin) ");

                datos.setearParametros("@Email", usu.Email);
                datos.setearParametros("@Pass", usu.Pass);
                datos.setearParametros("Nombre", usu.Nombre);
                datos.setearParametros("Apellido", (object)usu.Apellido ?? DBNull.Value);
                datos.setearParametros("@urlImagenPerfil", (object)usu.UrlImagenPerfil ?? DBNull.Value);
                datos.setearParametros("@Admin", 0);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }


        }

        public Usuario traerUsuario(int id)
        {
            try
            {
                datos.hacerConsulta("select id, email, pass, nombre, apellido, urlImagenPerfil,admin from Users where id = @Id");
                datos.setearParametros("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario usu = new Usuario();
                    usu.Id = (int)datos.Lector["id"];
                    usu.Email = (String)datos.Lector["email"];
                    usu.Pass = (String)datos.Lector["pass"];
                    usu.Nombre = (String)datos.Lector["nombre"];
                    usu.Apellido = datos.Lector.IsDBNull(datos.Lector.GetOrdinal("apellido")) ? "" : (String)datos.Lector["apellido"];
                    usu.UrlImagenPerfil = datos.Lector.IsDBNull(datos.Lector.GetOrdinal("urlImagenPerfil")) ? "https://media.istockphoto.com/id/1300845620/es/vector/icono-de-usuario-plano-aislado-sobre-fondo-blanco-s%C3%ADmbolo-de-usuario-ilustraci%C3%B3n-vectorial.jpg?s=612x612&w=0&k=20&c=grBa1KTwfoWBOqu1n0ewyRXQnx59bNHtHjvbsFc82gk=" : (string)datos.Lector["urlImagenPerfil"];
                    usu.Admin = (bool)datos.Lector["admin"];

                    return usu;
                }
                else
                {
                    return null;

                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { datos.cerrarConexion(); }


        }

        public List<Usuario> traerListaUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                datos.hacerConsulta("select id,email, pass, nombre, apellido,urlImagenPerfil, admin from Users ");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.Email = (String)datos.Lector["email"];
                    usuario.Pass = (String)datos.Lector["pass"];
                    usuario.Nombre = datos.Lector.IsDBNull(datos.Lector.GetOrdinal("nombre")) ? "" : (String)datos.Lector["nombre"];
                    usuario.Apellido = datos.Lector.IsDBNull(datos.Lector.GetOrdinal("apellido")) ? "" : (String)datos.Lector["apellido"];
                    usuario.UrlImagenPerfil = datos.Lector.IsDBNull(datos.Lector.GetOrdinal("urlImagenPerfil")) ? "ruta_por_defecto.jpg" : (String)datos.Lector["urlImagenPerfil"];
                    usuario.Admin = (bool)datos.Lector["admin"];

                    listaUsuarios.Add(usuario);

                }

                return listaUsuarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }


        public void eliminarUsuario(int id)
        {
            try
            {
                datos.hacerConsulta(" delete from Users where id = @Id");
                datos.setearParametros("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        public void modificarUsuario(Usuario usu)
        {
            try
            {
                datos.hacerConsulta("update Users set nombre = @Nombre, apellido = @Apellido, pass = @Pass,urlImagenPerfil =@UrlImagenPerfil, admin = @Admin where id = @Id  ");

                datos.setearParametros("@Nombre", (object)usu.Nombre ?? DBNull.Value);
                datos.setearParametros("@Apellido", (object)usu.Apellido ?? DBNull.Value);
                datos.setearParametros("@Pass", usu.Pass);
                datos.setearParametros("@UrlImagenPerfil", (object)usu.UrlImagenPerfil ?? DBNull.Value);
                datos.setearParametros("@Admin", usu.Admin);
                datos.setearParametros("@Id", usu.Id);

                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { datos.cerrarConexion(); }


        }

        public Usuario login(Usuario usu)
        {
            try
            {
                datos.hacerConsulta("select id,email, pass, nombre, apellido,urlImagenPerfil, admin FROM Users  WHERE pass = @Pass AND email=@Email");
                
                datos.setearParametros("@Pass", usu.Pass);
                
                datos.setearParametros("@Email", usu.Email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario usuOk = new Usuario();
                    usuOk.Id = (int)datos.Lector["id"];
                    usuOk.Email = (String)datos.Lector["email"];
                    usuOk.Pass = (String)datos.Lector["pass"];
                    usuOk.Nombre = (String)datos.Lector["nombre"];
                    usuOk.Apellido = datos.Lector.IsDBNull(datos.Lector.GetOrdinal("apellido")) ? "" : (String)datos.Lector["apellido"];
                    usuOk.UrlImagenPerfil = datos.Lector.IsDBNull(datos.Lector.GetOrdinal("urlImagenPerfil")) ? "ruta_por_defecto.jpg" : (string)datos.Lector["urlImagenPerfil"];
                    usuOk.Admin = (bool)datos.Lector["admin"];

                    return usuOk;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}