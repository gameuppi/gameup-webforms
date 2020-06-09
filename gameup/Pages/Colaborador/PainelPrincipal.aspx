<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageColaborador.master" AutoEventWireup="true" CodeFile="PainelPrincipal.aspx.cs" Inherits="Pages_Colaborador_PainelPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Painel Principal</h1>
    </div>

    <!-- Content Row -->
    <div class="row">

        <!-- Missoes -->
        <div class="col-xl-4 col-lg-5 d-flex align-items-stretch">
            <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-dark">Missões em andamento</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">Entregar o relatório da competência 07/2019</li>
                        <li class="list-group-item">Finalizar a planilha de custos</li>
                        <li class="list-group-item">Enviar os documentos de compra para o contador</li>
                        <li class="list-group-item">Revisar a planilha de vendas</li>
                    </ul>
                </div>
            </div>
        </div>


        <!-- Desempenho -->
        <div class="col-xl-8 col-lg-7 ">
            <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-dark">Desempenho - Conclusão de Missões</h6>
                    <div class="dropdown no-arrow">
                        <a class="dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i class="fas fa-ellipsis-v fa-sm fa-fw text-gray-400"></i>
                        </a>
                        <div class="dropdown-menu dropdown-menu-right shadow animated--fade-in" aria-labelledby="dropdownMenuLink">
                            <div class="dropdown-header">Dropdown Header:</div>
                            <a class="dropdown-item" href="#">Action</a>
                            <a class="dropdown-item" href="#">Another action</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="#">Something else here</a>
                        </div>
                    </div>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <div class="chart-area">
                        <canvas id="myAreaChart"></canvas>
                    </div>
                </div>
            </div>
        </div>

        <!-- Novidades -->
        <div class="col-xl-4 col-lg-5 d-flex align-items-stretch">
            <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-dark">Últimas novidades</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">João Ferraz alcançou a medalha de logar cinco dias consecutivos</li>
                        <li class="list-group-item">Gabriela Diniz completou todas as missões da semana</li>
                        <li class="list-group-item">Mariana Oliveria atingiu o nível 5</li>
                        <li class="list-group-item">Matheus Souza completou sua missão difícil</li>
                    </ul>
                </div>
            </div>
        </div>

        <!-- Placar Geral -->
        <div class="col-xl-4 col-lg-5 ">
            <div class="card shadow mb-4">
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
                    </ul>
                </div>
            </div>
        </div>

        <!-- Avisos -->
        <div class="col-xl-4 col-lg-5 d-flex align-items-stretch">
            <div class="card shadow mb-4">
                <!-- Card Header - Dropdown -->
                <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                    <h6 class="m-0 font-weight-bold text-dark">Avisos</h6>
                </div>
                <!-- Card Body -->
                <div class="card-body">
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">
                            <div class="row">
                                <div class="col-1 text-left text-danger">
                                    <i class="fas fa-exclamation fa-1x"></i>&nbsp;
                                </div>
                                <div class="col-11 text-left">
                                    Falta 1 dia para o fim do prazo da sua missão "Entregar relatório"
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row">
                                <div class="col-1 text-left text-warning">
                                    <i class="fas fa-exclamation fa-1x"></i>&nbsp;
                                </div>
                                <div class="col-11 text-left">
                                    O dia da entrega está chegando...
                                </div>
                            </div>
                        </li>

                        <li class="list-group-item">
                            <div class="row">
                                <div class="col-1 text-left text-success">
                                    <i class="fas fa-exclamation fa-1x"></i>&nbsp;
                                </div>
                                <div class="col-11 text-left">
                                    Existem novos itens na loja virtual
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>

    </div>

    <script src="../../Assets/Custom/Js/textzoom.js"></script>
    <!-- /.container-fluid -->
</asp:Content>

