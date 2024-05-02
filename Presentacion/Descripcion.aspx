<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Descripcion.aspx.cs" Inherits="Presentacion.Descripcion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .contenedor {
            margin-top: 60px;
            padding: 40px 50px 50px 50px;
            max-width: 800px;
            max-height: 470px;
            background-color: cadetblue;
            display: grid;
            grid-template-columns: 1fr 1fr;
        }


        .imgDes {
            max-width: 250px;
            height: 200px;
            margin: 52px ;
            object-fit: contain;
        }

        .imagen {
        }


        @media only screen and (max-width: 773px) {

            .contenedor {
                grid-template-columns: 1fr;
            }


            .imgDes {
                max-width: 300px;
                height: 200px;
                margin: 52px 52px 32px 52px;
                object-fit: contain;
            }





        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="container-fluid contenedor">

        <div class="row">
            <div class="col-12 text-center">
                <div class="mb-3 imagen">


                    <asp:Image CssClass="imgDes" ID="imgDescrip" runat="server" />

                </div>
                <div class="mb-3 lblmarcatitulo w-100 text-center">
                    <asp:Label Text="Marca: " runat="server" Style="font-size: 30Px;" />
                    <asp:Label ID="lblMar" runat="server" Style="font-size: 35Px;" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-11 text-center">
                <div class="mb-3 mt-3">
                    <asp:Label Text="Descripcion" Style="font-size: 20px;" runat="server" />
                    <asp:TextBox runat="server" CssClass="mb-3 mt-3" ID="txtDescripcion" TextMode="MultiLine" Rows="6" Width="100%" Style="resize: none;" />
                </div>

                <div class="mb-3">
                    <asp:Label Text="Precio: " runat="server" Style="font-size: 22px;" />
                    <asp:Label Text="0000.00" ID="lblPrecio" Style="font-size: 26px;" runat="server" />
                </div>

                <div class="mb-3 mt-3">
                    <asp:Button Text="Agregar favorito" ID="btnFavorito" OnClick="btnFavorito_Click" CssClass="btn btn-primary" runat="server" />
                    <asp:Button Text="Cancelar" CssClass="btn btn-danger m-3" ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" />
                </div>


            </div>



        </div>
    </div>








</asp:Content>
