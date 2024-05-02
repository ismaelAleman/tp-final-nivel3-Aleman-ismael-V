using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Presentacion
{
    public partial class Agregar2 : System.Web.UI.Page
    {
        string tipo;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!IsPostBack)
                {
                    if (Request.QueryString["tipo"] != null)
                    {
                        tipo = Request.QueryString["tipo"];
                        ViewState["Tipo"] = tipo;
                    }

                }
                else
                {
                    tipo = ViewState["Tipo"].ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }
            

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if(tipo == "marca")
            {
                MarcaNegocio negomar = new MarcaNegocio();  
                negomar.agregarMarca(txtDescripcion.Text);
                Response.Redirect("Administrar.aspx", false);

            }else if (tipo == "categoria")
            {
                CategoriaNegocio negocat = new CategoriaNegocio();  
                negocat.agregarCategoria(txtDescripcion.Text);
                Response.Redirect("Administrar.aspx", false);
            }
        }
    }
}