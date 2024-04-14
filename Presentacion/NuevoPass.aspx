<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoPass.aspx.cs" Inherits="Presentacion.NuevoPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .principal {
            background-color: grey;
            
            max-width:400px;
            border-radius:20px;
            height: 400px;
            margin: 0 auto;
            display: grid;
        }

        .row1 {
            background-color: lightgrey;
            width: 100%;
            height: 20%;
            border-radius:20px 20px 0 0;
        }

        .row2 {
            background-color: lightgrey;
            width: 100%;
            height: 50%;
            
        }

        .grupo {
            margin: 15px auto 10px auto;
            display: grid;
            justify-items: center;
            justify-content:center;
        }
        .grid5{
            display: grid;
            justify-items: center;
            justify-content:center;
        }
        .cancelarbtn{
            margin-left:10px;
        }

         .titulo {
            text-align: center;
            margin:20px auto;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="titulo">   

        <h3>Cambio de contraseña</h3>

    </div>


    <div class="principal container-fluid ">

        <div>

            <div class="row1 ">
                <div class="col-6 container-fluid">
                    <div class="grupo">

                        <label class="mt-2" style="font-size: 16px;">ingrese contraseña actual</label>
                        <asp:TextBox runat="server" TextMode="Password" ID="txtpassActual" Style="width: 200px;" />
                        <asp:Label Text="" ID="lblpassActial" runat="server" />
                    </div>
                </div>
            </div>

            <div class="row2">
                <div class="col-6 container-fluid">
                    <div class="mb-3 grid5">

                        <label class="mt-2" style="font-size: 16px;">Nueva contraseña</label>
                        <asp:TextBox runat="server" ID="txtpass1" Style="width: 200px;"   />

                    </div>
                    <div class="mb-3 grid5">
                        <label class="mt-2" style="font-size: 16px;">Repita</label>
                        <asp:TextBox runat="server" ID="txtpass2" Style="width: 200px;" />
                        <asp:Label Text="" ID="lblpass2" runat="server" />
                    </div>
                </div>
            </div>

            <div class="row3">
                <div class="col-6">
                    <div class="mb-3 mt-3">

                        <asp:Button Text="Aceptar" CssClass="btn btn-primary" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />
                        <asp:Button Text="Cancelar" CssClass="btn btn-danger cancelarbtn" ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" />

                    </div>
                </div>
            </div>

        </div>
    </div>



</asp:Content>
