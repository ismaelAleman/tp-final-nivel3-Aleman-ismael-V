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
    public partial class Descripcion : System.Web.UI.Page
    {

        ArticuloNegocio negocio = new ArticuloNegocio();
       
        Articulo art;
      
        String idArt;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {
                    if (Request.QueryString["Id"] != null)
                    {
                        idArt = Request.QueryString["Id"];
                        ViewState["IdUsuario"] = idArt;
                    }
                    

                }
                else if (ViewState["IdUsuario"] != null)
                {
                  idArt = (String)ViewState["IdUsuario"];

                }
               

                art = negocio.traerArticulo(idArt);
    
                    if (art != null)
                    {
                        

                        txtDescripcion.Text = art.Descripcion;
                        lblPrecio.Text = art.Precio.ToString();
                        //lblMar.Text = art.IdMarca.Descripcion;

                        if (!string.IsNullOrEmpty(art.IdMarca.Descripcion))
                        {
                            lblMar.Text = art.IdMarca.Descripcion;
                        }
                        else
                        {
                            lblMar.Text = "Sin informar";
                        }



                        if (!string.IsNullOrEmpty(art.UrlImagen))
                        {

                            imgDescrip.ImageUrl = art.UrlImagen;
                        }
                        else
                        {
                            imgDescrip.ImageUrl = ResolveUrl("~/img/imagen_no_encontrada.jpg");
                        }

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

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            FavoritoNegocio negofav = new FavoritoNegocio();

            string idUsu = ((Usuario)Session["usuarioActivo"]).Id.ToString();
          
            negofav.agregarFav(idUsu, idArt);
            String Url = "Descripcion.aspx?Id=" + ViewState["IdUsuario"];

            ScriptManager.RegisterStartupScript(this, this.GetType(), "FavoritoAlerta", "alert('El artículo se agregó a favorito correctamente.'); window.location.href = '"+Url+"';", true);


        }
    }
}