<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="pagDefault_container">

        <div class="buscadorAvanzado_container">buscador </div>
        <%--  --%>
        <div class="listaProductos_container">

            <%--<div class="row row-cols-1 row-cols-md-2 row-cols-lg-3  g-2 listacard">--%>
            <div class="listacard">

                <% foreach (Dominio.Articulo arti in articuloList)
                    { %>
                        <div class="col">
                            <div class="card border-3" style="width: 160px; height: 295px;">
                                <img src="<%:arti.UrlImagen %>" class="card-img-top" alt="...">
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


        <%--<div class="algoMas_container">algo mas </div>--%>
    </div>


</asp:Content>
