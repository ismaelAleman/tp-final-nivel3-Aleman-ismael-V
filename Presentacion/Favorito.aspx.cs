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
    public partial class Favorito : System.Web.UI.Page
    {
        public List<Articulo> listaFav;
        protected void Page_Load(object sender, EventArgs e)
        {

            FavoritoNegocio negocio = new FavoritoNegocio();
           

            try
            {
                if (Session["usuarioActivo"] !=null)
                {
                    String Id = ((Usuario)Session["usuarioActivo"]).Id.ToString();
                    listaFav = negocio.traerFavoritos(Id);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlerta", "alert('debes estar logueado para ver esta pagina...'); window.location.href = 'Login.aspx';", true);
                }
                                
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error",false);
                
            }

        }







    }
}