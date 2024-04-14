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
            try
            {
                if (!IsPostBack)
                {
                   
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


            Response.Redirect("EditarArticulo.aspx?Id=" + Id);
        }

        protected void cargarUsuarios()
        {
            dgvArticulos.Columns.Clear();
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Nombre", DataField = "nombre" });
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Apellido", DataField = "apellido" });
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "Email", DataField = "email" });
            dgvArticulos.Columns.Add(new BoundField() { HeaderText = "admin", DataField = "admin" });

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
        }


        protected void btnMarca_Click(object sender, EventArgs e)
        {
            cargarMarcas();
        }

        protected void btnCategoria_Click(object sender, EventArgs e)
        {
            cargarCategorias();
        }

        protected void btnUsuario_Click(object sender, EventArgs e)
        {
            cargarUsuarios();
        }
    }
    
}