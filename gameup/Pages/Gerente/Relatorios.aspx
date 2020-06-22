<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageGerente.master" AutoEventWireup="true" CodeFile="Relatorios.aspx.cs" Inherits="Pages_Gerente_Relatorios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var data = google.visualization.arrayToDataTable(<%=ObterDadosDoUsuario()%>);


            var options = {
                title: 'Company Performance',
                curveType: 'function',
                legend: { position: 'bottom' }
            };

            var chart = new google.visualization.LineChart(document.getElementById('curve_chart'));


            chart.draw(data, options);
        }
    </script>
    <div class="card shadow mb-7 col-8">
        <!-- Card Header - Accordion -->
        <a href="#collapseCardExample5" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample">
            <h6 class="m-0 font-weight-bold text-center">GRAFIFICO SEMESTRAL DE DESEMPENHO DO SETOR</h6>
        </a>
        <!-- Card Content - Collapse -->
        <div class="collapse show" id="collapseCardExample5">

            <div id="curve_chart" style="min-height: 400px;"></div>

        </div>
        
    </div>
    <div class="card shadow mb-3 col-4"></div>
</asp:Content>

