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
    public partial class EditarElementos : System.Web.UI.Page
    {
        string id;
        MarcaNegocio negomarca = new MarcaNegocio();
        CategoriaNegocio catNego = new CategoriaNegocio();
        string tipo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    id = Request.QueryString["Id"];
                    txtId.Text = id;


                    if (Request.QueryString["tipo"] != null && Request.QueryString["tipo"] == "marca")
                    {
                        txtdesc.Text = negomarca.traerMarca(id).Descripcion;
                        tipo = "marca";
                        ViewState["Tipo"] = "marca";
                        

                    }
                    else if (Request.QueryString["tipo"] != null && Request.QueryString["tipo"] == "categoria")
                    {
                        txtdesc.Text = catNego.traerCategoria(id).Descripcion;
                        tipo = "categoria";
                        ViewState["Tipo"] = "categoria";
                    }
                }

            } else { 
                tipo = (String)ViewState["Tipo"];
               
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            volverAdmi();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (tipo != null && tipo == "marca")
            {
                Marca marca = new Marca();
                marca.Id = int.Parse(txtId.Text);
                marca.Descripcion = txtdesc.Text;
                negomarca.modificarMarca(marca);              
                volverAdmi();
            }
            else if (tipo != null && tipo == "categoria")
            {
                Categoria cat = new Categoria();
                cat.Id = int.Parse(txtId.Text);
                cat.Descripcion = txtdesc.Text;
                catNego.modificarCat(cat);            
                volverAdmi();
            }



        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tipo == "categoria")
                {
                    catNego.eliminarCat(int.Parse(txtId.Text));

                    volverAdmi();
                }
                else if(tipo == "marca")
                {
                    negomarca.eliminarMarca(int.Parse(txtId.Text));
                    volverAdmi();
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.spx", false);
               
            }
        }

        protected void volverAdmi()
        {
            Response.Redirect("administrar.aspx", false);
        }
    }
}