<%@ Page Title="" Language="C#" MasterPageFile="~/CAPA VISTAS/Site1.Master" AutoEventWireup="true" CodeBehind="Votantes.aspx.cs" Inherits="EXAMENPARTIDOS.CAPA_VISTAS.Votantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Votantes</h1>
    <asp:Label ID="lmensaje" runat="server" Text="Label"></asp:Label>
    <br />
    &nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" BorderColor="Black">
        <Columns>
        </Columns>
    </asp:GridView>
     
     <br />
  
    ID CEDULA 
    <asp:TextBox ID="Tidcedula" runat="server"></asp:TextBox>
     <br />
    
    NOMBRE 
    <asp:TextBox ID="Tnombre" runat="server"></asp:TextBox>
     <br />
     
APELLIDO
<asp:TextBox ID="TAPELLIDO" runat="server"></asp:TextBox>
 <br />
     
APELLIDO2
<asp:TextBox ID="TAPELLIDO2" runat="server"></asp:TextBox>
 <br />
    EMAIL
    <asp:TextBox ID="Temail" runat="server"></asp:TextBox>
    
    <br />
    <asp:Button ID="BAGREGAR" runat="server" Text="AGREGAR" OnClick="BAGREGAR_Click" />
     <br />
    <asp:Button ID="BELIMINAR" runat="server" Text="BORRAR" OnClick="BELIMINAR_Click" />
    <br />
    <asp:Button ID="BMODIFICAR" runat="server" Text="MODIFICAR" OnClick="BMODIFICAR_Click" />

</asp:Content>
