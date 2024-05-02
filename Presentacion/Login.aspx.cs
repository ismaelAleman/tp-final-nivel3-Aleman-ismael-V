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
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {

                Usuario usu = new Usuario();
                UsuarioNegocio usunegocio = new UsuarioNegocio();

                usu.Email = txtemail.Text;
                usu.Pass = txtpass.Text;


                if ((usu=usunegocio.login(usu)) != null)
                {
                   Session.Add("usuarioActivo", usu);

                    // mensaje en el front y redireccion a pagina 
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "loginActivoAlert", "alert('Se ha ingresado correctamente'); window.location.href='Default.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorLoginAlert", "alert('Email y o contraseña incorrecto'); window.location.href='Login.aspx';", true);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}