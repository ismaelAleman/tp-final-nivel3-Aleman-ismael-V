using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Presentacion
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    visibilidadActivo(false);
                }

                if (Session["usuarioActivo"] !=null)
                {
                    Usuario usuarioActivo = (Usuario)Session["usuarioActivo"];
                  
                    lblUsuarioActivo.Text = usuarioActivo.Nombre;

                    botonesActivos(false);
                 
                    visibilidadActivo(true);
                    
                }                                         

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
                
            }
        }

        protected void botonesActivos(bool activar)
        {
            btnLogin.Visible = activar;
            btnRegistrar.Visible = activar;

        }
        protected void visibilidadActivo(bool activar)
        {
            btnSalirLogin.Visible = activar;
            lblUsuarioActivo.Visible = activar;
            lblMensaje.Visible = activar;
        }



        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx", false);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false );
        }

        protected void btnSalirLogin_Click(object sender, EventArgs e)
        {
        
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}