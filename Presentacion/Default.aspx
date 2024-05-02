<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .no-underline {
            text-decoration: none;
        }

            .no-underline:hover {
                color: yellow;
            }

        .selected {
            color: yellow;
        }
    </style>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>


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
                            <h5 class="card-title" ><%: arti.Nombre %></h5>
                            <p class="card-text"><%: arti.Descripcion%></p>
                           
                                                    
                              
                               
                           
                            <div class="flex btn-card">
                                <%-- btncheck --%>

                                <%-- <label class="custom-checkbox" runat="server">
                                    <input type="checkbox" id="myCheckbox">
                                    <i class="fas fa-heart"></i>
                                </label>--%>
                                                                
                                <%--<asp:LinkButton ID="LinkFav" runat="server" CssClass="fas fa-heart no-underline" OnClick="LinkFav_Click" CommandArgument='<%# Eval("ItemId") %>' data-card-id='<%# Eval("CardId") %>' OnClientClick="toggleSelected(this);">
                                </asp:LinkButton>--%>




                                <div>
                                    <asp:HiddenField runat="server" ID="hiddenIdArticulo" />
                                    <%--<asp:Button Text="Detalle" runat="server" ID="btn_detalle" OnClick="btn_detalle_Click" CssClass="btn-card btn-secondary" />--%>
                                    <a href="Descripcion.aspx?Id=<%: arti.Id %>" class="btn btn-primary">Ver mas</a>

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
