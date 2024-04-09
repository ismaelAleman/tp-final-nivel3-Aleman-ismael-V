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
    public partial class EditarArticulo : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                CategoriaNegocio cateNego= new CategoriaNegocio();
                MarcaNegocio marcaNego = new MarcaNegocio();    

                ddlCategoria.DataSource = cateNego.listaCategoria();
                ddlCategoria.DataValueField = "id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();

                ddlMarca.DataSource= marcaNego.listaMarcas();
                ddlMarca.DataValueField= "id";
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataBind();    

            }


            if (Request.QueryString["id"] !=null && !IsPostBack)
            {
                ArticuloNegocio Negocio = new ArticuloNegocio();
                Articulo artiSelec = Negocio.traerArticulo(Request.QueryString["id"].ToString());

                Session.Add("articuloseleccionado", artiSelec);

                TxtId.Text= artiSelec.Id.ToString();
                TxtId.ReadOnly = true;
                txtCodigo.Text= artiSelec.Codigo.ToString();
                TxtNombre.Text = artiSelec.Nombre;
                TxtDescripcion.Text = artiSelec.Descripcion;

                ddlMarca.SelectedValue = artiSelec.IdMarca.Id.ToString(); ;

                ddlCategoria.SelectedValue= artiSelec.IdCategoria.Id.ToString();

           

                TxtPrecio.Text= artiSelec.Precio.ToString();

                imgArticulo.ImageUrl= artiSelec.UrlImagen;

            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrar.aspx", false);
        }

        protected void urlImagen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}