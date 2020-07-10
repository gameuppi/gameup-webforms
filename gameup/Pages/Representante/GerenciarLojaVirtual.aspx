<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageRepresentante.master" AutoEventWireup="true" CodeFile="GerenciarLojaVirtual.aspx.cs" Inherits="Pages_Representante_GerenciarLojaVirtual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Gerenciar Loja Virtual</h1>
    </div>

    <div class="row">
        <div class="col-12 col-md-9">
            <!-- Resumo -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-dark">Resumo</h6>
                </div>
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col-12 col-md-2">
                            <i class="fas fa-chart-pie text-info fa-8x"></i>
                        </div>
                        <div class="col-12 col-md-2">
                            <h3>
                                <asp:Label runat="server" ID="lblPorcentagemEmEstoque"></asp:Label>
                            </h3>
                        </div>
                        <div class="col-12 col-md-4">
                            <h4>
                                <strong>
                                    <asp:Label runat="server" ID="lblIQtdItensAtivos"></asp:Label>
                                </strong>
                                itens ativos
                            </h4>
                            <h4>
                                <strong>
                                    <asp:Label runat="server" ID="lblQtdItensDisponiveis"></asp:Label>
                                </strong>
                                disponíveis
                            </h4>
                        </div>
                        <div class="col-12 col-md-4">
                            <h4>
                                <strong>
                                    <asp:Label runat="server" ID="lblQtdMoedasGastas"></asp:Label>
                                </strong>
                                moedas gastas
                            </h4>
                            <h4>
                                <strong>
                                    <asp:Label runat="server" ID="lblQtdItensVendidos"></asp:Label>
                                </strong>
                                itens vendidos
                            </h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Item mais vendido -->
        <div class="col-12 col-md-3 mb-4">
            <div class="card border-left-success h-100 shadow py-2">
                <div class="card-body">
                    <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                            <div class="text-sm font-weight-bold text-success text-uppercase mb-1">Item mais vendido</div>
                            <asp:Label runat="server" ID="lblQtdItemMaisVendido" CssClass="h5 mb-0 font-weight-bold text-gray-800"></asp:Label>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-shopping-cart fa-2x text-gray-300"></i>
                        </div>
                    </div>
                    <div class="row">
                        <div class=" text-center col-12 card p-4 mt-4">
                            <h4>
                                <asp:Label runat="server" ID="lblNomeItemMaisVendido"></asp:Label>
                            </h4>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="col-12">
            <nav>
                <div class="nav nav-tabs text-center" id="Tabs" role="tablist">
                    <a class="nav-item nav-link active" id="nav-cadastro-tab" data-toggle="tab" href="#nav-cadastro" role="tab" aria-controls="nav-cadastro" aria-selected="true">Adicionar</a>
                    <a class="nav-item nav-link" id="nav-visualizacao-tab" data-toggle="tab" href="#nav-visualizacao" role="tab" aria-controls="nav-visualizacao" aria-selected="false">Visualizar</a>
                </div>
            </nav>
            <div class="tab-content card shadow border-top-0 pb-4 mb-4" id="nav-tabContent">
                <!-- Cadastrar produtos -->
                <div class="tab-pane fade show active p-4" id="nav-cadastro" role="tabpanel" aria-labelledby="nav-cadastro-tab">
                    <div class="row mt-5">
                        <div class="col-12 col-md-3 text-center">
                            <img src="../../Assets/Imagens/astronauta2.png" class="img-fluid float-right" />
                        </div>
                        <div class="col-12 col-md-9">
                            <div class="row">
                                <div class="col-12">
                                    <h5>Informações</h5>
                                    <hr />

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <div class="form-row">
                                        <div class="form-group col-md-6">
                                            <label for="inputEmail4">Nome</label>
                                            <asp:TextBox runat="server" CssClass="form-control" placeholder="Nome do produto" ID="txtNome"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-12 col-md-6">
                                            <label for="inputPassword4">Subtítulo</label>
                                            <asp:TextBox runat="server" CssClass="form-control" placeholder="Subtítulo do produto" ID="txtSubtitulo"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-12">
                                            <label for="inputPassword4">Descrição</label>
                                            <asp:TextBox runat="server" CssClass="form-control" placeholder="Descrição do produto" ID="txtDescricao"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row mt-4">
                                        <div class="col-4">
                                            <div class="row">
                                                <div class="col-12 col-md-4 text-center">
                                                    <i class="fas fa-coins fa-2x text-success"></i>
                                                </div>
                                                <div class="col-12 col-md-6">
                                                    <asp:TextBox type="number" runat="server" CssClass="form-control" placeholder="Preço" ID="txtValorMoeda"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-4">
                                            <div class="row">
                                                <div class="col-12 col-md-4 text-center">
                                                    <i class="fas fa-cart-plus fa-2x text-warning"></i>
                                                </div>
                                                <div class="col-12 col-md-6">
                                                    <asp:TextBox type="number" runat="server" CssClass="form-control" placeholder="Quantidade" ID="txtQuantidade"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-4">
                                            <div class="row">
                                                <div class="col-12 col-md-4 text-center">
                                                    <i class="fas fa-tag fa-2x text-danger"></i>
                                                </div>
                                                <div class="col-12 col-md-6">
                                                    <asp:DropDownList runat="server" ID="drpCategoria" CssClass="form-control">
                                                        <asp:ListItem class="form-control" Value="FISICO">Físico</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row mt-4">
                                        <div class="col-12">
                                            <asp:Button runat="server" ID="btnCadastrar" CssClass="btn btn-success" OnClick="btnCadastrar_Click" Text="Cadastrar" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Visualizar itens -->
                <div class="tab-pane fade show p-4" id="nav-visualizacao" role="tabpanel" aria-labelledby="nav-visualizacao-tab">

                    <div class="row mt-4">
                        
                    <div class="col-12 text-right">
                        <asp:Button runat="server" type="checkbox" class="btn btn-dark" Text="Todos" ID="btnTodas" OnClick="btnTodas_Click" />
                        <asp:Button runat="server" type="checkbox" class="btn btn-success" Text="Ativados" ID="btnAtivados" OnClick="btnAtivados_Click" />
                        <asp:Button runat="server" type="button" class="btn btn-danger" Text="Desativados" ID="btnDesativados" OnClick="btnDesativados_Click" />
                    </div>

                        <asp:Panel runat="server" ID="pnlVisualizarProdutos" CssClass="row mt-4"></asp:Panel>
                        <!-- Card de item -  -->
                        <!-- <div class="col-12 col-md-3">
                            <div class="card-custom border-left-success shadow">
                                <div class="card-custom-image">
                                    <img src="../../Assets/Imagens/piscina.jpg">
                                    <span class="card-custom-title font-weight-bold">Descanso merecido
                                        <br />
                                        <small>3 disponíveis</small>
                                    </span>
                                    <a class="btn-floating btn-large halfway-fab btn-info">
                                        <center>
                                            <i class="fas fa-info text-white"></i>
                                        </center>
                                    </a>
                                </div>
                                <div class="card-custom-content">
                                    <p>Consiga uma folga em um dia de sua escolha</p>
                                    <div class="row mt-3">
                                        <button class="btn btn-success col">Ativar</button>
                                        &nbsp;
                                        <button class="btn btn-danger col">Desativar</button>
                                    </div>
                                </div>
                            </div>
                        </div> -->
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal lista de compradores -->
        <div class="modal fade" id="modalParticipantes">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">

                    <div class="modal-header">
                        <h5 class="modal-title">Veja quem já adquiriu esse prêmio
                        </h5>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <div class="modal-body">
                        <asp:ListBox runat="server" ID="ltbCompradores" CssClass="form-control table-responsive"></asp:ListBox>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-success" data-dismiss="modal">Pronto</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal generico -->
        <div class="modal fade" id="modalGenerico">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">

                    <div class="modal-header">
                        <h5 class="modal-title">
                            <asp:Label runat="server" ID="lblTitulo"></asp:Label>
                        </h5>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <div class="modal-body">
                        <asp:Label runat="server" ID="lblCorpo"></asp:Label>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-success" data-dismiss="modal">Pronto</button>
                    </div>
                </div>
            </div>
        </div>

        

    <script src="../../Assets/Vendor/jquery/jquery.min.js"></script>

    <asp:HiddenField ID="TabName" runat="server" />
    <script type="text/javascript">
        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "nav-cadastro";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });
    </script>

</asp:Content>

