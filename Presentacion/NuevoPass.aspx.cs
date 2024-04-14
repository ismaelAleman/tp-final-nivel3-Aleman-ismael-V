using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace Presentacion
{
    public partial class NuevoPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarUsuario.aspx", false);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtpassActual.Text.ToUpper() == ((Usuario)Session["usuarioActivo"]).Pass.ToUpper())
            {
                if (sonIguales())
                {
                    //String passnuevo = txtpass1.Text;
                    Session.Add("temporalpass", txtpass1.Text);
                    Response.Redirect("EditarUsuario.aspx", false);

                }
                else
                {
                    lblpass2.Text = "la nueva contraseña deben ser iguales";
                    return;
                }

            }
            else
            {
                lblpassActial.Text = "la contraseña es incorrecta";
                return;

            }




        }
        public bool sonIguales()
        {
            return txtpass1.Text.Equals(txtpass2.Text, StringComparison.OrdinalIgnoreCase);

        }
    }
}