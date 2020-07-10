<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageGerente.master" AutoEventWireup="true" CodeFile="Relatorios.aspx.cs" Inherits="Pages_Gerente_Relatorios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- RELATORIOS DE GERENTE  -->

    



    <div class="row">
        <div class="col-xl-8 col-lg-7 ">
            <div class="card shadow h-100">
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-center">GRÁFICO DE DESEMPENHO DO SETOR <asp:Label runat="server" ID="lblNomeSetor"></asp:Label></h6>
                </div>
                <!-- Card Content - Collapse -->
                <div class="card-body float-left text-left text-xl-left border-left left ">

                    <asp:Literal runat="server" ID="ltlGerarGrafico"> </asp:Literal>

                </div>
            </div>
        </div>

        <div class="col-xl-4 col-lg-5 ">
            <div class="card shadow h-100">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-center">Opções de Relatórios </h6>

                </div>
                <!-- Card Body -->
                <div class="card-body float-left text-left text-xl-left border-left left ">
                    <h3>Selecione o tipo do gráfico</h3>
                    <br />
                    <div class="row">
                        <div class="col-8">
                            <asp:DropDownList runat="server" class="btn btn-light dropdown-toggle form-control" ID="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">

                                <asp:ListItem Selected="True" Value="sem"> Semestral </asp:ListItem>
                                <asp:ListItem Value="tri"> Trimestral </asp:ListItem>
                                <asp:ListItem Value="sema"> Semanal </asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <div class="col-4">
                            <asp:Button runat="server" ID="btnGerarGrafico" CssClass="btn btn-info form-control" OnClick="btn1_Click" Text="Gerar gráfico " />
                        </div>

                    </div>
                    <img src="https://cdn.pixabay.com/photo/2016/12/22/13/35/analytics-1925495_960_720.png" class="img-fluid" alt="Responsive image" style="min-height: 50px;">
                </div>
            </div>
        </div>


        <div class="col-md-4 Col-lg-4">
            <!-- Informacoes basicas de missoes -->

            <!-- Collapsable Card Example -->
            <div class="card shadow mb-4 mt-4">
                <!-- Card Header - Accordion -->
                <a href="#collapseCardExample2" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample">
                    <h6 class="m-0 font-weight-bold text-center">MISSÕES DO SETOR</h6>
                </a>
                <!-- Card Content - Collapse -->
                <div class="collapse show" id="collapseCardExample2">
                    <div class="card-body">

                        <!-- Missões ja validadas e aceitas -->
                        <div class="list-group list-group-flush">
                            <div class="card-zoom border-left-success shadow h-100 py-0">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col-auto">
                                            <i class="fas fa-check fa-2x text-success"></i>
                                        </div>
                                        <div class="col mr-1 text-right">
                                            <div class="text-sm font-weight-bold text-success text-uppercase mb-1">Missões Realizadas</div>
                                            <div class="text-sm font-weight-bold text-black-50 text-uppercase mb-1">
                                                Total :
                                             <asp:Label runat="server" ID="lblVaAvalidacao" CssClass="h6 mb-0 font-weight-bold text-gray-800 "></asp:Label>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <!-- Missões pendentes -->
                        <div class="list-group list-group-flush">
                            <div class="card-zoom border-left-warning shadow h-100 py-0">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col-auto">
                                            <i class="fas fa-check fa-2x text-warning"></i>
                                        </div>
                                        <div class="col mr-1 text-right">
                                            <div class="text-sm font-weight-bold text-warning text-uppercase mb-1">Missões Aguardando validação</div>
                                            <div class="text-sm font-weight-bold text-black-50 text-uppercase mb-1">
                                                Total :
                                             <asp:Label runat="server" ID="lblAgAvalidacao" CssClass="h6 mb-0 font-weight-bold text-gray-800 "></asp:Label>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />

                        <!-- Missões a fazer  -->
                        <div class="list-group list-group-flush">
                            <div class="card-zoom border-left-dark shadow h-100 py-0">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col-auto">
                                            <i class="fas fa-check fa-2x text-dark "></i>
                                        </div>
                                        <div class="col mr-1 text-right">
                                            <div class="text-sm font-weight-bold text-dark text-uppercase mb-1">Missões a fazer</div>
                                            <div class="text-sm font-weight-bold text-black-50 text-uppercase mb-1">
                                                Total :
                                             <asp:Label runat="server" ID="lblEmAvalidacao" CssClass="h6 mb-0 font-weight-bold text-gray-800 "></asp:Label>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>
            </div>
        </div>



        
        <div class="col-md-8 Col-lg-8">
            <div class="card shadow mb-4 mt-4">
                    <!-- Card Header - Accordion -->
                    <a href="#collapseCardExample7" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample">
                        <h6 class="m-0 font-weight-bold text-center">GRÁFICO ATUAL DE MISSÕES DO SETOR</h6>
                    </a>
                    <!-- Card Content - Collapse -->
                    <div class="collapse show" id="collapseCardExample7">
                        <div class="card-body">

                        <div id="piechart" style="min-height: 360px;"></div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- grafico  Missoes  de setor-->
        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
        <!-- script do grafico de missoes -->
        <script type="text/javascript">
            google.charts.load('current', { 'packages': ['corechart'] });
            google.charts.setOnLoadCallback(drawChart);

            function drawChart() {

                var data = google.visualization.arrayToDataTable(<%=obterDados()%>);

                var options = {
                    title: 'Gráfico de status de missão'
                };

                var chart = new google.visualization.PieChart(document.getElementById('piechart'));

                chart.draw(data, options);
            }
        </script>

        <div class="col-md-8 Col-lg-8">
            <div class="card shadow mb-4">
                <!-- Card Header - Accordion -->
                <a href="#collapseCardExample7" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample">
                    <h6 class="m-0 font-weight-bold text-center">GRÁFICO ATUAL DE MISSÕES DO SETOR</h6>
                </a>
                <!-- Card Content - Collapse -->
                <div class="collapse show" id="collapseCardExample7">
                    <div class="card-body">

    <!-- Gráfico semestral  -->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var data = google.visualization.arrayToDataTable(<%=ObterDadosDoUsuarioSem()%>);


            var options = {
                title: 'Grafico de desempenho semestral',
                curveType: 'function',
                legend: { position: 'bottom' }
            };

            var chart = new google.visualization.LineChart(document.getElementById('curve_chart_Sem'));


            chart.draw(data, options);
        }
    </script>
    <!-- Gráfico trimestral  -->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var data = google.visualization.arrayToDataTable(<%=ObterDadosDoUsuarioTri()%>);


            var options = {
                title: 'Grafico de desempenho trimestral',
                curveType: 'function',
                legend: { position: 'bottom' }
            };

            var chart = new google.visualization.LineChart(document.getElementById('curve_chart_Tri'));


            chart.draw(data, options);
        }
    </script>

    <!-- Gráfico semanal  -->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var data = google.visualization.arrayToDataTable(<%=ObterDadosDoUsuarioSema()%>);


            var options = {
                title: 'Grafico de desempenho semanal',
                curveType: 'function',
                legend: { position: 'bottom' }
            };

            var chart = new google.visualization.LineChart(document.getElementById('curve_chart_Sema'));


            chart.draw(data, options);
        }
    </script>



</asp:Content>

