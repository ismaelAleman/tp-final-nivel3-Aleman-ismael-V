<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="Presentacion.listarArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div> 
        <h3>Administrar</h3>
    </div>

   

        <asp:GridView runat="server" ID="dgvArticulos" AutoGenerateColumns="false" CssClass="table"  >

            <Columns>
                <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Marca" DataField="idMarca" />
                <asp:BoundField HeaderText="Categoria" DataField="idCategoria" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />

                
            </Columns>

           


        </asp:GridView>




    <a href="Agregar.aspx" class=" btn btn-primary">Agregar</a>


</asp:Content>
