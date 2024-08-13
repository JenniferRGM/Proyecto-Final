<%@ Page Title="" Language="C#" MasterPageFile="~/CAPA VISTAS/Site1.Master" AutoEventWireup="true" CodeBehind="Candidatos.aspx.cs" Inherits="EXAMENPARTIDOS.CAPA_VISTAS.Candidatos" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Candidatos</h1>
    <asp:Label ID="lmensaje" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lmensaje2" runat="server" Text="Label"></asp:Label>
<br />
    &nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" BorderColor="Black">
    </asp:GridView>
    
    <br />
    ID
    <asp:TextBox ID="TID" runat="server"></asp:TextBox>
    <br />
    NOMBRE 
    <asp:TextBox ID="TNOMBRE" runat="server"></asp:TextBox>
    <br />
    <br />
APELLIDO
<asp:TextBox ID="TAPELLIDO" runat="server"></asp:TextBox>
<br />
    <br />
APELLIDO2
<asp:TextBox ID="TAPELLIDO2" runat="server"></asp:TextBox>
<br />
    NOMBRE PARTIDO
    <asp:TextBox ID="TNOMBREPARTIDO" runat="server"></asp:TextBox>
    <br />
 
    
    <asp:Button ID="BAGREGAR" runat="server" Text="AGREGAR" OnClick="BAGREGAR_Click" />
    <br />
    <asp:Button ID="BELIMINAR" runat="server" Text="BORRAR" OnClick="BELIMINAR_Click" />
    <br />
    <asp:Button ID="BMODIFICAR" runat="server" Text="MODIFICAR" OnClick="BMODIFICAR_Click" />
    <asp:Panel ID="Panel1" runat="server" CssClass="fondo">
    
</asp:Panel>

</asp:Content>
