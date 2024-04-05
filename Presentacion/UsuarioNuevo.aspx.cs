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

        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            string urlImagen = txtUrlImagen.Text;
            imgPerfil.ImageUrl = urlImagen;
        }
    }
}