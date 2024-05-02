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
        protected String tipo;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    tipo = "articulo";
                    ViewState["Tipo"] = "articulo";

                }
                else
                {
                    tipo = ViewState["Tipo"] as string ?? "articulo";
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Id = dgvArticulos.SelectedDataKey.Value.ToString();
            Console.WriteLine(Id);


            switch (tipo)
            {
                case "articulo":
                        Response.Redirect("EditarArticulo.aspx?Id=" + Id + "&tipo=" + tipo);
                    break;
                case "marca":
                    Response.Redirect("EditarElementos.aspx?Id=" + Id + "&tipo=" + tipo);
                    break;
                case "categoria":
                    Response.Redirect("EditarElementos.aspx?Id=" + Id + "&tipo=" + tipo);
                    break;
                case "usuario":
                    Response.Redirect("EditarUsuario.aspx?Id="+ Id + "&tipo=" + tipo);
                    break;
                default:
                    break;
            }

        }

        protected void cargarUsuarios()
        {
            dgvArticulos.Columns.Clear();
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Id", DataField = "Id" });
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Nombre", DataField = "nombre" });
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Apellido", DataField = "apellido" });
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Email", DataField = "email" });
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "admin", DataField = "admin" });
            dgvArticulos.Columns.Add(new CommandField() { HeaderText = "Editar", ShowSelectButton = true, SelectText = "&#x270F" });

            UsuarioNegocio negocioUsu = new UsuarioNegocio();
            dgvArticulos.DataSource = negocioUsu.traerListaUsuarios();
            dgvArticulos.DataBind();

        }
        protected void cargarArticulos()

        {
            dgvArticulos.Columns.Clear();
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Codigo", DataField = "Codigo" });
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Nombre", DataField = "Nombre" });
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Marca", DataField = "IdMarca" });
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Categoria", DataField = "IdCategoria" });
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Precio", DataField = "Precio" });
            dgvArticulos.Columns.Add(new CommandField() { HeaderText = "Editar", ShowSelectButton = true, SelectText = "&#x270F" });

            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = negocio.listaArticulos();
            dgvArticulos.DataBind();
        }
        protected void cargarMarcas()
        {
            dgvArticulos.Columns.Clear();
            dgvArticulos.Columns.Add(new BoundField() { HeaderText="Id", DataField = "Id" });
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Marca", DataField = "Descripcion" });
            dgvArticulos.Columns.Add(new CommandField() { HeaderText = "Editar", ShowSelectButton = true, SelectText = "&#x270F" });

            MarcaNegocio negocioMar = new MarcaNegocio();
            dgvArticulos.DataSource = negocioMar.listaMarcas();
            dgvArticulos.DataBind();

        }
        protected void cargarCategorias()
        {
            dgvArticulos.Columns.Clear();
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Id", DataField = "Id" });
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Categoria", DataField = "Descripcion" });
            dgvArticulos.Columns.Add(new CommandField() { HeaderText = "Editar", ShowSelectButton = true, SelectText = "&#x270F" });

            CategoriaNegocio negociocat = new CategoriaNegocio();   
            dgvArticulos.DataSource= negociocat.listaCategoria();
            dgvArticulos.DataBind();


        }
        protected void dgvArticulos_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarArticulos();
            }


        }
        protected void btnArticulos_Click(object sender, EventArgs e)
        {
            cargarArticulos();
            ViewState["Tipo"] = "articulo";
        }
        protected void btnMarca_Click(object sender, EventArgs e)
        {
            cargarMarcas();
            ViewState["Tipo"] = "marca";
        }
        protected void btnCategoria_Click(object sender, EventArgs e)
        {
            cargarCategorias();
           
            ViewState["Tipo"] = "categoria";
        }
        protected void btnUsuario_Click(object sender, EventArgs e)
        {
            cargarUsuarios();
            ViewState["Tipo"] = "usuario";
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {

                switch (ViewState["Tipo"])
                {
                    case "articulo":
                        Response.Redirect("Agregar.aspx", false);
                        break;
                    case "marca":
                        Response.Redirect("Agregar2.aspx?tipo=marca",false);
                        break;
                    case "categoria":
                        Response.Redirect("Agregar2.aspx?tipo=categoria", false);
                        break;

                    default:
                        break;
                }





            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx",false);
            }

        }
    }
    
}