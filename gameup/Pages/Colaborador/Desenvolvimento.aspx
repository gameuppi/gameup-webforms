<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageColaborador.master" AutoEventWireup="true" CodeFile="Desenvolvimento.aspx.cs" Inherits="Pages_Colaborador_Desenvolvimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Content Row -->
    <div class="row">

        <!-- Informacoes basicas do usuario ex: moeda, pontos, xp  -->

        <div class="col-md-4">
            <!-- Collapsable Card Example -->
            <div class="card shadow mb-4">
                <!-- Card Header - Accordion -->
                <a href="#collapseCardExample1" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample">
                    <h6 class="m-0 font-weight-bold text-center">PONTUAÇÕES</h6>
                </a>
                <!-- Card Content - Collapse -->
                <div class="collapse show" id="collapseCardExample1">
                    <div class="card-body">

                        <!-- Moedas -->
                        
                        <div class="list-group list-group-flush  ">
                            <div class="card-zoom border-left-success shadow h-100 py-0">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col-auto">
                                            <i class="fas fa-coins fa-2x text-gray-300"></i>
                                        </div>
                                        <div class="col mr-1 text-center">
                                            <a class="text-sm font-weight-bold text-success text-uppercase mb-1" href="MeuPerfil.aspx"> Moedas de ouro</a>
                                            <div class="h5 mb-0 font-weight-bold text-gray-800">
                                                <div class="text-sm font-weight-bold text-black-50 text-uppercase mb-1  text-right h6">
                                                    Total :
                                                <asp:Label runat="server" ID="lblMoedas" CssClass="h6 mb-0 font-weight-bold text-gray-800"></asp:Label>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <br />
                        <!-- Pontos de habilidade -->
                        <div class="list-group list-group-flush">
                            <div class="card-zoom border-left-success shadow h-100 py-0">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col-auto">
                                            <i class="fas fa-star fa-2x text-gray-300"></i>
                                        </div>
                                        <div class="col mr-1 text-right">
                                            <a class="text-sm font-weight-bold text-warning text-uppercase mb-1 " href="MeuPerfil.aspx">Pontos de habilidade</a>
                                            <div class="text-sm font-weight-bold text-black-50 text-uppercase mb-1">
                                                Total :
                                             <asp:Label runat="server" ID="lblPontos" CssClass="h6 mb-0 font-weight-bold text-gray-800 "></asp:Label>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <!-- Pontos de xp -->
                        <div class="list-group list-group-flush">
                            <div class="card-zoom border-left-success shadow h-100 py-0">
                                <div class="card-body">
                                    <div class="row no-gutters align-items-center">
                                        <div class="col-auto">
                                            <i class="fas fa-meteor fa-2x text-gray-300"></i>
                                        </div>
                                        <div class="col mr-1 text-right">
                                            <a class="text-sm font-weight-bold text-warning text-uppercase mb-1" href="MeuPerfil.aspx">Pontos de experiencia</a>
                                            <div class="text-sm font-weight-bold text-black-50 text-uppercase mb-1">
                                                Total :
                                             <asp:Label runat="server" ID="lblXp" CssClass="h6 mb-0 font-weight-bold text-gray-800 "></asp:Label>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
            </div>


            <!-- Informacoes basicas de missoes -->

            <!-- Collapsable Card Example -->
            <div class="card shadow mb-4">
                <!-- Card Header - Accordion -->
                <a href="#collapseCardExample2" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample">
                    <h6 class="m-0 font-weight-bold text-center">MISSÕES</h6>
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
                                            <div class="text-sm font-weight-bold text-success text-uppercase mb-1">Missões Aceitas</div>
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
                                            <div class="text-sm font-weight-bold text-warning text-uppercase mb-1">Missões Pendentes</div>
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

        <!-- grafico  Missoes -->

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
        <!-- script do grafico de pontuação -->
        <script type="text/javascript">
            google.charts.load('current', { 'packages': ['corechart'] });
            google.charts.setOnLoadCallback(drawChart);

            function drawChart() {

                var data = google.visualization.arrayToDataTable(<%=obterDadosPontos()%>);

                var options = {
                    title: 'Gráfico de desempenho mensal de Pontos, Experiência e Moedas'
                };

                var chart = new google.visualization.PieChart(document.getElementById('piechart2'));

                chart.draw(data, options);
            }
        </script>

        <div class="col-xl-8 col-lg-7">
            <div class="">





                <div class="card shadow mb-4">
                    <!-- Card Header - Accordion -->
                    <a href="#collapseCardExample5" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample">
                        <h6 class="m-0 font-weight-bold text-center">DESEMPENHO MENSAL DE PONTUAÇÃO</h6>
                    </a>
                    <!-- Card Content - Collapse -->
                    <div class="collapse show" id="collapseCardExample5">
                        <div class="card-body">

                            <div id="piechart2" style="min-height: 330px;"></div>

                        </div>
                    </div>
                </div>

                <div class="card shadow mb-4">
                    <!-- Card Header - Accordion -->
                    <a href="#collapseCardExample6" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample">
                        <h6 class="m-0 font-weight-bold text-center">DESEMPENHO ATUAL EM MISSÕES</h6>
                    </a>
                    <!-- Card Content - Collapse -->
                    <div class="collapse show" id="collapseCardExample6">
                        <div class="card-body">

                            <div id="piechart" style="min-height: 340px;"></div>

                        </div>
                    </div>
                </div>

            </div>
        </div>


    </div>

</asp:Content>

