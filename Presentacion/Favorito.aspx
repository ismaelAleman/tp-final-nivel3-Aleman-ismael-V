<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Favorito.aspx.cs" Inherits="Presentacion.Favorito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <h3>Favoritos</h3>


    <div class="favoritoProductos_container">

        <div class="listacard favoritos">

            <% foreach (Dominio.Articulo arti in listaFav)
                { %>
            <div class="col">
                <div class="card border-3" style="width: 170px; height: 295px;">

                    <img src="<%: string.IsNullOrEmpty(arti.UrlImagen) ? ResolveUrl("~/img/imagen_no_encontrada.jpg") :  arti.UrlImagen %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%: arti.Nombre %></h5>
                        <p class="card-text"><%: arti.Descripcion%></p>

                       <div class="flex btn-card">


                            <div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
            <% } %> 
        </div>
    </div>






</asp:Content>
