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
    public partial class Agregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CategoriaNegocio catenego = new CategoriaNegocio();
                MarcaNegocio marcanego= new MarcaNegocio();

                List<Categoria> listacat = catenego.listaCategoria();
                List<Marca> listamarca= marcanego.listaMarcas();
            
                ddlCategoria.DataSource = listacat;
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();

                ddlMarca.DataSource = listamarca  ;
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataBind();    
            }


        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {

            try
            { Articulo arti = new Articulo();
              ArticuloNegocio negocio = new ArticuloNegocio();

                arti.Codigo= txtCodigo.Text;
                arti.Nombre= TxtNombre.Text;
                arti.Precio = double.Parse(TxtPrecio.Text);
                arti.Descripcion = TxtDescripcion.Text;
                
                arti.IdCategoria = new Categoria();
                arti.IdCategoria.Id = int.Parse(ddlCategoria.SelectedItem.Value);

                arti.IdMarca= new Marca();  
                arti.IdMarca.Id= int.Parse(ddlMarca.SelectedItem.Value);


                if(!string.IsNullOrEmpty(urlImagen.Text))
                {
                    arti.UrlImagen= urlImagen.Text;
                }

                negocio.agregarArticulo(arti);
                
                Response.Redirect("Administrar.aspx", false);



            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);

            }

        }



        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrar.aspx",false);
        }

        protected void urlImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(urlImagen.Text))
                {
                    imgArticulo.ImageUrl = urlImagen.Text;
                }
                else
                {
                    imgArticulo.ImageUrl = "https://static.vecteezy.com/system/resources/previews/005/720/408/non_2x/crossed-image-icon-picture-not-available-delete-picture-symbol-free-vector.jpg";
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}