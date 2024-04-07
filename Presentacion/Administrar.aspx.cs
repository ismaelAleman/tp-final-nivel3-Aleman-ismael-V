using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Presentacion
{
    public partial class listarArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ArticuloNegocio negocio = new ArticuloNegocio();    

            dgvArticulos.DataSource = negocio.listaArticulos();
            dgvArticulos.DataBind();
        }
    }
}