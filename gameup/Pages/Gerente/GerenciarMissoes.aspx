<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageGerente.master" AutoEventWireup="true" CodeFile="GerenciarMissoes.aspx.cs" Inherits="Pages_Gerente_GerenciarMissoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Missões</h1>
    </div>
    <nav>
        <div class="nav nav-tabs text-center" id="nav-tab" role="tablist">
            <asp:LinkButton runat="server" class="nav-item nav-link active" ID="navCadastroTab" data-toggle="tab" href="#nav-cadastro" role="tab" aria-controls="nav-cadastro" aria-selected="true">Cadastrar</asp:LinkButton>
            <asp:LinkButton runat="server" class="nav-item nav-link" ID="navVisualizacaoTab" data-toggle="tab" href="#nav-visualizacao" role="tab" aria-controls="nav-visualizacao" aria-selected="false">Visualizar</asp:LinkButton>
            <asp:LinkButton runat="server" class="nav-item nav-link" ID="navConstrucaoTab" data-toggle="tab" href="#nav-construcao" role="tab" aria-controls="nav-construcao" aria-selected="false">Em construção</asp:LinkButton>
            <asp:LinkButton runat="server" class="nav-item nav-link" ID="navValidacaoTab" data-toggle="tab" href="#nav-validacao" role="tab" aria-controls="nav-validacao" aria-selected="false">Aguardando validação</asp:LinkButton>
        </div>
    </nav>
    <!-- Missoes a fazer -->
    <div class="tab-content card shadow border-top-0 pb-4 mb-4" id="nav-tabContent">
        <div class="tab-pane fade show active p-4" id="nav-cadastro" role="tabpanel" aria-labelledby="nav-cadastro-tab">
            <div class="row">
                <div class="col-12">
                    <div class="row">
                        <asp:Label runat="server" ID="idMissao" CssClass="d-none"></asp:Label>
                        <div class="col-7">
                            <div class="form-check form-check-inline btn btn-info">
                                <i class="fas fa-user"></i>&nbsp;
                                <asp:RadioButton runat="server" ID="rdbTipoIndividual" GroupName="tipo" Text="Individual" />
                            </div>
                            <div class="form-check form-check-inline btn btn-info">
                                <i class="fas fa-users"></i>&nbsp;                        
                                <asp:RadioButton runat="server" ID="rdbTipoGrupo" GroupName="tipo" Text="Grupo" />
                            </div>
                            <div class="form-check form-check-inline btn btn-info">
                                <i class="fas fa-users-cog"></i>&nbsp;                                                
                                <asp:RadioButton runat="server" ID="rdbTipoSetor" GroupName="tipo" Text="Setor" />
                            </div>
                        </div>
                        <div class="col-5">
                            <!-- <asp:Literal runat="server" ID="ltrInfo"></asp:Literal> -->
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mt-5">
                <div class="col-12 col-md-3">
                    <div class="row">
                        <div class="col-12 mt-4">
                            <img src="../../Assets/Imagens/astronauta3.png" class="img-fluid float-right" />
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-9">
                    <div class="row">
                        <div class="col-12">
                            <h5>Informações</h5>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-12">
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="txtNome">Nome</label>
                                    <asp:TextBox type="text" CssClass="form-control" ID="txtNome" runat="server" placeholder="Nome da missão" />
                                </div>
                                <div class="col-12 col-md-6">
                                    <label for="txtNome">Nome</label>
                                    <div class="input-group">
                                        <input type="text" class="form-control bg-light border-0 small" readonly placeholder="Procure por colaboradores ou setores" aria-label="Search" aria-describedby="basic-addon2">
                                        <div class="input-group-append">
                                            <asp:Button runat="server" ID="btnCarregarParticipantes" OnClick="btnCarregarParticipantes_Click" CssClass="btn btn-info" Text="Procurar" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-12 col-md-6">
                                    <label for="inputEmail4">Início</label>
                                    <asp:TextBox type="date" CssClass="form-control" ID="dtInicio" runat="server" placeholder="Data de início" />
                                </div>
                                <div class="form-group col-12 col-md-6">
                                    <label for="inputPassword4">Fim</label>
                                    <asp:TextBox type="date" CssClass="form-control" ID="dtFim" runat="server" placeholder="Data de fim" />
                                </div>
                                <div class="form-group col-12">
                                    <label for="inputPassword4">Descrição</label>
                                    <asp:TextBox multiline="true" class="form-control" placeholder="Descrição da missão" ID="txtDescricao" runat="server" />
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <h5>Recompensas</h5>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-4">
                            <div class="row">
                                <div class="col-12 col-md-4 text-center">
                                    <i class="fas fa-coins fa-2x text-success"></i>
                                </div>
                                <div class="col-12 col-md-6">
                                    <asp:TextBox type="number" CssClass="form-control" ID="txtQtdMoedas" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="col-4">
                            <div class="row">
                                <div class="col-12 col-md-4 text-center">
                                    <i class="fas fa-star fa-2x text-warning"></i>
                                </div>
                                <div class="col-12 col-md-6">
                                    <asp:TextBox type="number" CssClass="form-control" ID="txtQtdExp" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="col-4">
                            <div class="row">
                                <div class="col-12 col-md-4 text-center">
                                    <i class="fas fa-meteor fa-2x text-danger"></i>
                                </div>
                                <div class="col-12 col-md-6">
                                    <asp:TextBox type="number" CssClass="form-control" ID="txtQtdPontos" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row mt-5">
                        <div class="col-12">
                            <asp:Button runat="server" ID="cadastrarMissao" OnClick="cadastrarMissao_Click" CssClass="btn btn-success" Text="Cadastrar" />
                        </div>
                    </div>

                </div>



            </div>


    </div>

    <!-- Visualizar missoes -->
    <div class="tab-pane fade p-4" id="nav-visualizacao" role="tabpanel" aria-labelledby="nav-visualizacao-tab">
        <div class="row">
            <div class="col-12 col-md-4">
                <div class="input-group">
                    <input type="text" class="form-control bg-light border-0 small" placeholder="Procure por colaborador ou setor" aria-label="Search" aria-describedby="basic-addon2">
                    <div class="input-group-append">
                        <button class="btn btn-info" type="button">
                            <i class="fas fa-search fa-sm"></i>
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <asp:Panel runat="server" ID="pnlMissoesVisualizar" CssClass="row mt-4">
        </asp:Panel>
    </div>

    <!-- PAINEL DE MISSOES EM CONSTRUCAO -->
    <div class="tab-pane fade p-4 mb-4" id="nav-construcao" role="tabpanel" aria-labelledby="nav-construcao-tab">
        <div class="row">

            <div class="col-12 col-md-4">
                <div class="input-group">
                    <input type="text" class="form-control bg-light border-0 small" placeholder="Procure por missões" aria-label="Search" aria-describedby="basic-addon2">
                    <div class="input-group-append">
                        <button class="btn btn-info" type="button">
                            <i class="fas fa-search fa-sm"></i>
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <asp:Panel runat="server" ID="pnlMissoesEmConstrucao" CssClass="row mt-4"></asp:Panel>
    </div>

    <!-- PAINEL DE MISSOES AGUARDANDO VALIDACAO -->
    <div class="tab-pane fade p-4" id="nav-validacao" role="tabpanel" aria-labelledby="nav-validacao-tab">
        <div class="row">

            <div class="col-12 col-md-4">
                <div class="input-group">
                    <input type="text" class="form-control bg-light border-0 small" placeholder="Procure por missões" aria-label="Search" aria-describedby="basic-addon2">
                    <div class="input-group-append">
                        <button class="btn btn-info" type="button">
                            <i class="fas fa-search fa-sm"></i>
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <asp:Panel runat="server" ID="pnlMissaoAgValidacao" CssClass="row mt-4"></asp:Panel>
    </div>



    <!-- Modal -->
    <div class="modal fade" id="modalDetalhesMissao" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content p-4">
                <div class="modal-header">
                    <h4 class="modal-title text-dark font-weight-bold" id="exampleModalLongTitle">Detalhes da Missão</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:Literal runat="server" ID="Literal1"></asp:Literal>

                    <div class="row">
                        <div class="col-12">
                            <h6>Recompensas</h6>
                            <div class="row mt-4">
                                <div class="col-4 text-center text-success">
                                    <i class="fas fa-coins fa-2x"></i>
                                    <p class="mt-3">
                                        <asp:Literal runat="server" ID="ltrDetalhesMoedas">
                                        </asp:Literal>
                                    </p>
                                </div>
                                <div class="col-4 text-center text-warning">
                                    <i class="fas fa-star fa-2x"></i>
                                    <p class="mt-3">
                                        <asp:Literal runat="server" ID="ltrDetalhesEstrelas">
                                        </asp:Literal>
                                    </p>
                                </div>
                                <div class="col-4 text-center text-danger">
                                    <i class="fas fa-meteor fa-2x"></i>
                                    <p class="mt-3">
                                        <asp:Literal runat="server" ID="ltrDetalhesMeteoros">
                                        </asp:Literal>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <p>
                            <asp:Literal runat="server" ID="ltrDetalhesDescricao">
                            </asp:Literal>
                        </p>
                    </div>

                    <div class="row mt-4">
                        <h6>
                            <i class="fas fa-calendar-check"></i>
                            &nbsp;
                                Concluído em:
                            <asp:Literal runat="server" ID="ltrDataConclusao"></asp:Literal></h6>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!-- Modal cadastra missao -->
    <div class="modal fade" id="modalCadastraMissao">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">

                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Literal runat="server" ID="ltrTituloModal"></asp:Literal>
                    </h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <div class="modal-body">
                    <asp:Literal runat="server" ID="msgModalCadastraMissao"></asp:Literal>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal">Pronto</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal participantes -->
    <div class="modal fade" id="modalParticipantes">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">

                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Literal runat="server" ID="lblTituloParticipantes"></asp:Literal>
                    </h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <div class="modal-body">
                    <asp:ListBox runat="server" ID="ltbParticipantes" CssClass="form-control"></asp:ListBox>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal">Pronto</button>
                </div>
            </div>
        </div>
    </div>
    <!--
    <script>
        window.addEventListener('keydown', function (e) {
            var code = e.which || e.keyCode;
            if (code == 116) e.preventDefault();
            else return true;
            // fazer algo aqui para quando a tecla F5 for premida
        });
    </script>  -->
</asp:Content>

