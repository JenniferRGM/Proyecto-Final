<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EXAMENPARTIDOS.CAPA_VISTAS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="CSS/Login.css" rel="stylesheet" />
    
</head>
<body>
               <style>
body {
  background-image: url('CSS/Isla-del-Coco-Costa-Rica-scaled.jpeg');/*Inserta la imagen como fondo*/
  background-position: center; /* Centra la imagen */
    background-repeat: no-repeat; /* Evita que la imagen se repita */
    font-weight: bold; /* Establece el texto en negrita */
     background-size: cover; /* Asegura que la imagen cubra toda la pantalla */
    height: 170vh; /* Asegura que el body tenga la altura completa de la ventana */
    margin: 0; /* Elimina márgenes por defecto */
}

  
                   .auto-style1 {
                       font-weight: normal;
                   }
                   .auto-style2 {
                       color: #000000;
                   }

  
  </style>
  <form id="form1" runat="server">
    <h3><strong class="auto-style2">Votaciones 2024</strong></h3>
    <label for="username"><span class="auto-style1"><strong class="auto-style2">Usuario</strong></span></label>
      <asp:TextBox ID="Tusuario" runat="server" ForeColor="Black"></asp:TextBox>
    <label for="password"><span class="auto-style1"><strong class="auto-style2">Password</strong></span></label>
      <asp:TextBox ID="Tclave" type="Password" runat="server" ForeColor="Black"></asp:TextBox>
      <asp:Button ID="Bingresar" class="button" runat="server" Text="Ingresar" OnClick="Bingresar_Click" ForeColor="Black" />
      <asp:Label ID="lmensaje" runat="server" ForeColor="Red"></asp:Label>
  </form>
</body>
</html>
