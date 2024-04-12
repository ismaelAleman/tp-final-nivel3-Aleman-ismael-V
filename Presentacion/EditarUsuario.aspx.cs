using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class UsuarioNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (IsPostBack)
                {

                }

                if (Session["usuarioActivo"] != null)
                {
                    Usuario usu = (Usuario)Session["usuarioActivo"];

                    txtId.Text = usu.Id.ToString();
                    txtId.ReadOnly = true;
                    txtEmail.Text = usu.Email.ToString();
                    txtEmail.ReadOnly = true;
                    txtPasword.Text = "************";
                    txtNombre.Text = usu.Nombre.ToString();
                    txtApellido.Text = usu.Apellido.ToString();


                    txtUrlImagen.Text=  !string.IsNullOrEmpty(txtUrlImagen.Text) ? usu.UrlImagenPerfil.ToString() : usu.UrlImagenPerfil = ResolveUrl("~/img/imagen_no_encontrada.jpg");

                    




                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx",false);
            }



        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            //string urlImagen = txtUrlImagen.Text;
            imgPerfil.ImageUrl = txtUrlImagen.Text;
        }
    }
}