using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Web.Services;
using System.Diagnostics;

namespace Presentacion
{
    public partial class Default : System.Web.UI.Page
    {
       
        public List<Articulo> articuloList;
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            articuloList = negocio.listaArticulos();

            


        }

        protected void btn_detalle_Click(object sender, EventArgs e)
        {


            // Verificar si el valor del ID se está pasando correctamente


        }
    }
}