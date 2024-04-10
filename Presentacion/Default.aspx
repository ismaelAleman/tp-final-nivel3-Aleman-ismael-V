<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="pagDefault_container">

        <div class="buscadorAvanzado_container">buscador </div>
    
        <div class="listaProductos_container">

         
            <div class="listacard">

                <% foreach (Dominio.Articulo arti in articuloList)
                    { %>
                        <div class="col">
                            <div class="card border-3" style="width: 170px; height: 295px;">
                               
                                <img src="<%: string.IsNullOrEmpty(arti.UrlImagen) ? ResolveUrl("~/img/imagen_no_encontrada.jpg") :  arti.UrlImagen %>" class="card-img-top" alt="...">
                                                   
                                <div class="card-body">
                                    <h5 class="card-title"><%: arti.Nombre %></h5>
                                    <p class="card-text"><%: arti.Descripcion%></p>

                                    <div class="flex btn-card">

                                        <label class="custom-checkbox">
                                            <input type="checkbox" id="myCheckbox">
                                            <i class="fas fa-heart"></i>
                                        </label>
                                        <div>

                                            <asp:Button Text="Detalle" runat="server" ID="btn_detalle" CssClass="btn-card btn-secondary" />

                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>
                <% } %>
            </div>
        </div>
    </div>


</asp:Content>
