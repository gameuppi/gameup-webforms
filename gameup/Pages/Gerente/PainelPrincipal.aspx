<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageGerente.master" AutoEventWireup="true" CodeFile="PainelPrincipal.aspx.cs" Inherits="Pages_Gerente_PainelPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!-- PAINEL PRINCIPAL DE GERENTE -->

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Painel Principal</h1>
    </div>

    <!-- Content Row -->
    <div class="row">

        <!-- Placar Geral -->
        <div class="col-xl-4 col-lg-5 ">
            <div class="card shadow h-100">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-dark">Placar Geral</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">
                            <div class="row">
                                <div class="col-3 text-center">
                                    <i class="fas fa-user-circle fa-3x"></i>&nbsp;
                                </div>
                                <div class="col-6 text-left">
                                    <div class="mt-1 font-weight-bold">
                                        <asp:Label runat="server" ID="lbl1Posicao"></asp:Label>

                                    </div>
                                    <asp:Label runat="server" ID="txtApelido1"></asp:Label>
                                </div>
                                <div class="col-3 text-center">
                                    <div class="mt-1">
                                        <asp:Label runat="server" ID="lblPontos1Posicao"></asp:Label>

                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row">
                                <div class="col-3 text-center">
                                    <i class="fas fa-user-circle fa-3x"></i>&nbsp;
                                </div>
                                <div class="col-6 text-left">
                                    <div class="mt-1 font-weight-bold">
                                        <asp:Label runat="server" ID="lbl2Posicao"></asp:Label>
                                    </div>
                                    <asp:Label runat="server" ID="txtApelido2"></asp:Label>
                                </div>
                                <div class="col-3 text-center">
                                    <div class="mt-1">
                                        <asp:Label runat="server" ID="lblPontos2Posicao"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row">
                                <div class="col-3 text-center">
                                    <i class="fas fa-user-circle fa-3x"></i>&nbsp;
                                </div>
                                <div class="col-6 text-left">
                                    <div class="mt-1 font-weight-bold">
                                        <asp:Label runat="server" ID="lbl3Posicao"></asp:Label>
                                    </div>
                                    <asp:Label runat="server" ID="txtApelido3"></asp:Label>
                                </div>
                                <div class="col-3 text-center">
                                    <div class="mt-1">
                                        <asp:Label runat="server" ID="lblPontos3Posicao"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </li>
                        <br />
                    </ul>
                </div>
            </div>
        </div>

        <!-- Gráfico semanal  -->
        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
        <script type="text/javascript">
            google.charts.load('current', { 'packages': ['corechart'] });
            google.charts.setOnLoadCallback(drawChart);

            function drawChart() {
                var data = google.visualization.arrayToDataTable(<%=ObterDadosDoUsuarioSema()%>);


                var options = {
                    title: 'Grafico de desempenho semanal pessoal',
                    curveType: 'function',
                    legend: { position: 'bottom' }
                };

                var chart = new google.visualization.LineChart(document.getElementById('curve_chart_Sema'));


                chart.draw(data, options);
            }
        </script>

        <!-- Desempenho -->
        <div class="col-xl-8 col-lg-7  ">
            <div class="card shadow h-100">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-dark">Desenvolvimento </h6>

                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div id='curve_chart_Sema' style='min-height: 290px;'></div>
                </div>
            </div>
        </div>

        <!-- Novidades -->
        <div class="col-xl-4 col-lg-5 d-flex align-items-stretch">
            <div class="card shadow mb-4 mt-3">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-dark">Nossa Loja Virtual</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <p class="text-justify">
                        &nbsp &nbsp Com a Loja virtual fica mais fácil obter itens exclusivos, mas corra, os itens são limitados.
                        Complete novas missões obtenha muito mais moedas e aproveite..
                    </p>
                    <img src="https://image.freepik.com/vetores-gratis/e-commerce-infografico_23-2147494118.jpg" class="img-fluid" alt="Imagem responsiva">
                </div>
            </div>
        </div>
        <!-- Missoes -->
        <div class="col-xl-4 col-lg-5 d-flex align-items-stretch">
            <div class="card shadow mb-4 mt-3">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-dark">Nosso Processo de Missões</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <p class="text-justify">
                        &nbsp  Você já parou para pensar como o processo de missão é realizado?
                        <br />
                        Anteriormente se dava tarefas por meio de pedidos informais ou físicos, dando brechas 
                                            para o funcionário esquecer ou até fazer de maneira diferente do que o chefe queria. 
                                            Agora com o processo de missão ficou tudo mais fácil, voce consulta a tela de missões, 
                                            visualiza os detalhes de cada missão e as realiza e ainda por cima recebe recompensas 
                    </p>
                    <img src="https://image.freepik.com/vetores-gratis/ilustracao-de-missao-negocio_53876-37670.jpg" class="img-fluid" alt="Imagem responsiva" style='min-height: 60px;'>
                </div>
            </div>
        </div>


        <!-- Avisos -->
        <div class="col-xl-4 col-lg-5 d-flex align-items-stretch">
            <div class="card shadow mb-4 mt-3">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-dark">Nosso Placar de Líderes</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <p class="text-justify">
                        &nbsp &nbsp Você trabalha muito e o mínimo que podemos fazer é te colocar na posição que você faz jus ,
                        consulte as posições no nosso placar de líderes e veja os mais bem pontuados da empresa, não espero menos do que o primeiro
                        lugar de voce! Corre lá!
                    </p>
                    <img src="https://image.freepik.com/vetores-gratis/trofeus-e-conquistas_23-2147499035.jpg" class="img-fluid" alt="Imagem responsiva">
                </div>
            </div>
        </div>

    </div>

    <script src="../../Assets/Custom/Js/textzoom.js"></script>
    <!-- /.container-fluid -->



</asp:Content>

