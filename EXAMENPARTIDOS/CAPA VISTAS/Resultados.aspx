<%@ Page Title="" Language="C#" MasterPageFile="~/CAPA VISTAS/Site1.Master" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="EXAMENPARTIDOS.CAPA_VISTAS.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        var candidatos = []; 
        var votos = [];

        function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Candidato');
            data.addColumn('number', 'Votos');

            // Agregar datos al DataTable
            for (var i = 0; i < candidatos.length; i++) {
                data.addRow([candidatos[i], votos[i]]);
            }

            var options = {
                title: 'Resultados de las Elecciones',
                is3D: true
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }

        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Resultados</h1>
   
    <asp:Label ID="lblGanador" runat="server" Text="" />
<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" BorderColor="Black">
        <Columns>
            <asp:BoundField DataField="NOMBRE" HeaderText="Nombre Completo" />
            <asp:BoundField DataField="APELLIDO" HeaderText="Apellido" />
            <asp:BoundField DataField="APELLIDO2" HeaderText="Apellido2" />
            <asp:BoundField DataField="IDCANDIDATO" HeaderText="ID Candidato" />
            <asp:BoundField DataField="TotalVotos" HeaderText="Total Votos" />
        </Columns>
    </asp:GridView>

<br />
<br />

    <div id="chart_div" style="width: 60%; height: 300px;">
        
        
        
    </div>
 
</asp:Content>