using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Presentacion
{
    public partial class EditarArticulo : System.Web.UI.Page
    {
        ArticuloNegocio Negocio = new ArticuloNegocio();
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

                if (!String.IsNullOrEmpty(artiSelec.UrlImagen))
                {
                    imgArticulo.ImageUrl = artiSelec.UrlImagen;
                    
                    urlImagen.Text = artiSelec.UrlImagen;
                }
                else
                {
                    imgArticulo.ImageUrl = ResolveUrl("~/img/imagen_no_encontrada.jpg");
                }
                       

            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo Artmodificado = new Articulo();
                

                Artmodificado.Id =int.Parse(TxtId.Text);               
                Artmodificado.Codigo= txtCodigo.Text;
                Artmodificado.Nombre = TxtNombre.Text;
                Artmodificado.Precio = double.Parse(TxtPrecio.Text);
                Artmodificado.Descripcion= TxtDescripcion.Text;
                
                if(!string.IsNullOrEmpty(urlImagen.Text))
                {
                    Artmodificado.UrlImagen = urlImagen.Text;
                    

                }

                Artmodificado.IdCategoria = new Categoria();
                Artmodificado.IdCategoria.Id = int.Parse(ddlCategoria.SelectedItem.Value);

                Artmodificado.IdMarca = new Marca();
                Artmodificado.IdMarca.Id= int.Parse(ddlMarca.SelectedItem.Value);

                Negocio.modificarArt(Artmodificado);

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
            Response.Redirect("Administrar.aspx", false);
        }

        protected void urlImagen_TextChanged(object sender, EventArgs e)
        {

            imgArticulo.ImageUrl = urlImagen.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            Negocio.eliminarArticulo(id);

           

            Response.Redirect("Administrar.aspx", false);
        }
    }
}  