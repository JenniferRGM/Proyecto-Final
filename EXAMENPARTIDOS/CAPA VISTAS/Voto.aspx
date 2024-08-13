<%@ Page Title="" Language="C#" MasterPageFile="~/CAPA VISTAS/Site1.Master" AutoEventWireup="true" CodeBehind="Voto.aspx.cs" Inherits="EXAMENPARTIDOS.CAPA_VISTAS.Voto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>VOTE AQUI</h1>
    <asp:Label ID="lmensaje" runat="server" Text="Label"></asp:Label>
    <br />
  <asp:GridView ID="GridView1" runat="server" BorderColor="Black">
 </asp:GridView>
  <br />
 
  <br />
 ID CANDIDATO
 <asp:TextBox ID="TIDCANDIDATO" runat="server"></asp:TextBox>
 
  <br />
 ID VOTANTE
 <asp:TextBox ID="TIDVOTANTE" runat="server"></asp:TextBox>
 <br />

 <asp:Button ID="BAGREGAR" runat="server" Text="AGREGAR" OnClick="BAGREGAR_Click" />
  <br />
 

</asp:Content>
