using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx",false);
        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio usunego= new UsuarioNegocio();   
                Usuario usu= new Usuario();

                usu.Email= txtEmail.Text;
                usu.Pass= txtPass.Text; 
                usu.Nombre= txtNombre.Text;
                usunego.crearUsuario(usu);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "usuarioNuevoAlert", "alert('usuario creado exitosamente'); window.location.href='Login.aspx';", true);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }


        }
    }
}