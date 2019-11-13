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
            <asp:LinkButton runat="server" class="nav-item nav-link active" id="navCadastroTab" data-toggle="tab" href="#nav-cadastro" role="tab" aria-controls="nav-cadastro" aria-selected="true">Cadastrar</asp:LinkButton>
            <asp:LinkButton runat="server" class="nav-item nav-link" id="navVisualizacaoTab" data-toggle="tab" href="#nav-visualizacao" role="tab" aria-controls="nav-visualizacao" aria-selected="false">Visualizar</asp:LinkButton>
            <asp:LinkButton runat="server" class="nav-item nav-link" id="navConstrucaoTab" data-toggle="tab" href="#nav-construcao" role="tab" aria-controls="nav-construcao" aria-selected="false">Em construção</asp:LinkButton>
            <asp:LinkButton runat="server" class="nav-item nav-link" id="navValidacaoTab" data-toggle="tab" href="#nav-validacao" role="tab" aria-controls="nav-validacao" aria-selected="false">Aguardando validação</asp:LinkButton>
        </div>
    </nav>
    <!-- Missoes a fazer -->
    <div class="tab-content card shadow border-top-0 pb-4 mb-4" id="nav-tabContent">
        <div class="tab-pane fade show active p-4" id="nav-cadastro" role="tabpanel" aria-labelledby="nav-cadastro-tab">
            <div class="row">
                <div class="col-12">
                    <div class="row">
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
                        <div class="col-12 text-center mb-5">
                            <i class="fas fa-user-circle fa-10x"></i>
                            <br />
                        </div>
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
                                <div class="form-group col-12 col-md-6">
                                    <label for="inputPassword4">Participantes</label>
                                    <asp:TextBox type="text" CssClass="form-control" ID="txtParticipantes" runat="server" placeholder="Participantes" />
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
            <div class="row mt-4">
                <asp:Literal runat="server" ID="ltrCardsMissoes">

                </asp:Literal>
            </div>
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
            <div class="row mt-4">
                <asp:Literal runat="server" ID="ltrMissoesEmConstrucao">

                </asp:Literal>
            </div>
        </div>
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
            <div class="row mt-4">

                <div class="col-12 col-md-4 mb-4">
                    <div class="card border-left-info shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-sm font-weight-bold text-info text-uppercase mb-1">Entregar relatório técnico</div>
                                    <div class="h6 mb-0 text-gray-800">Você precisa terminar o relatório técnico para entrega-lo a diretoria.</div>
                                    <div class="mt-4">
                                        <i class="fas fa-user fa-2x text-info"></i>
                                        &nbsp; João Ricardo
                                   
                                        <br />
                                        <br />
                                        <button type="button" class="btn btn-info btn-block" data-toggle="modal" data-target="#exampleModalCenter">Detalhes</button>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <a href="#"><i class="fas fa-check fa-2x text-gray-500 icon-change"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-12 col-md-4 mb-4">
                    <div class="card border-left-info shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-sm font-weight-bold text-info text-uppercase mb-1">Entregar relatório técnico</div>
                                    <div class="h6 mb-0 text-gray-800">Você precisa terminar o relatório técnico para entrega-lo a diretoria.</div>
                                    <div class="mt-4">
                                        <i class="fas fa-users fa-2x text-info"></i>
                                        &nbsp; Financeiro 9/9
                                   
                                        <br />
                                        <br />
                                        <button type="button" class="btn btn-info btn-block" data-toggle="modal" data-target="#exampleModalCenter">Detalhes</button>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <a href="#"><i class="fas fa-check fa-2x text-gray-500 icon-change"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-12 col-md-4 mb-4">
                    <div class="card border-left-info shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-sm font-weight-bold text-info text-uppercase mb-1">Entregar relatório técnico</div>
                                    <div class="h6 mb-0 text-gray-800">Você precisa terminar o relatório técnico para entrega-lo a diretoria.</div>
                                    <div class="mt-4">
                                        <i class="fas fa-users fa-2x text-info"></i>
                                        &nbsp; Financeiro 9/9
                                   
                                        <br />
                                        <br />
                                        <button type="button" class="btn btn-info btn-block" data-toggle="modal" data-target="#exampleModalCenter">Detalhes</button>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <a href="#"><i class="fas fa-check fa-2x text-gray-500 icon-change"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="col-12 col-md-4 mb-4">
                    <div class="card border-left-info shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-sm font-weight-bold text-info text-uppercase mb-1">Entregar relatório técnico</div>
                                    <div class="h6 mb-0 text-gray-800">Você precisa terminar o relatório técnico para entrega-lo a diretoria.</div>
                                    <div class="mt-4">
                                        <i class="fas fa-users fa-2x text-info"></i>
                                        &nbsp; Financeiro 9/9
                                   
                                        <br />
                                        <br />
                                        <button type="button" class="btn btn-info btn-block" data-toggle="modal" data-target="#exampleModalCenter">Detalhes</button>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <a href="#"><i class="fas fa-check fa-2x text-gray-500 icon-change"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="col-12 col-md-4 mb-4">
                    <div class="card border-left-info shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-sm font-weight-bold text-info text-uppercase mb-1">Entregar relatório técnico</div>
                                    <div class="h6 mb-0 text-gray-800">Você precisa terminar o relatório técnico para entrega-lo a diretoria.</div>
                                    <div class="mt-4">
                                        <i class="fas fa-users fa-2x text-info"></i>
                                        &nbsp; Financeiro 9/9
                                   
                                        <br />
                                        <br />
                                        <button type="button" class="btn btn-info btn-block" data-toggle="modal" data-target="#exampleModalCenter">Detalhes</button>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <a href="#"><i class="fas fa-check fa-2x text-gray-500 icon-change"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="col-12 col-md-4 mb-4">
                    <div class="card border-left-info shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-sm font-weight-bold text-info text-uppercase mb-1">Entregar relatório técnico</div>
                                    <div class="h6 mb-0 text-gray-800">Você precisa terminar o relatório técnico para entrega-lo a diretoria.</div>
                                    <div class="mt-4">
                                        <i class="fas fa-users fa-2x text-info"></i>
                                        &nbsp; Financeiro 9/9
                                   
                                        <br />
                                        <br />
                                        <button type="button" class="btn btn-info btn-block" data-toggle="modal" data-target="#exampleModalCenter">Detalhes</button>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <a href="#"><i class="fas fa-check fa-2x text-gray-500 icon-change"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="col-12 col-md-4 mb-4">
                    <div class="card border-left-info shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-sm font-weight-bold text-info text-uppercase mb-1">Entregar relatório técnico</div>
                                    <div class="h6 mb-0 text-gray-800">Você precisa terminar o relatório técnico para entrega-lo a diretoria.</div>
                                    <div class="mt-4">
                                        <i class="fas fa-users fa-2x text-info"></i>
                                        &nbsp; Financeiro 9/9
                                   
                                        <br />
                                        <br />
                                        <button type="button" class="btn btn-info btn-block" data-toggle="modal" data-target="#exampleModalCenter">Detalhes</button>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <a href="#"><i class="fas fa-check fa-2x text-gray-500 icon-change"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>



    <!-- Modal -->
    <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content p-4">
                <div class="modal-header">
                    <h4 class="modal-title text-dark font-weight-bold" id="exampleModalLongTitle">Detalhes da Missão</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-12">
                            <h6>Recompensas</h6>
                            <div class="row mt-4">
                                <div class="col-4 text-center text-success">
                                    <i class="fas fa-coins fa-2x"></i>
                                    <p class="mt-3">50</p>
                                </div>
                                <div class="col-4 text-center text-warning">
                                    <i class="fas fa-star fa-2x"></i>
                                    <p class="mt-3">3</p>
                                </div>
                                <div class="col-4 text-center text-danger">
                                    <i class="fas fa-meteor fa-2x"></i>
                                    <p class="mt-3">35</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <p>Lorem Ipsum é simplesmente uma simulação de texto da indústria tipográfica e de impressos, e vem sendo utilizado desde o século XVI, quando um impressor desconhecido pegou uma bandeja de tipos e os embaralhou para fazer um livro de modelos de tipos. Lorem Ipsum sobreviveu não só a cinco séculos.</p>
                    </div>

                    <div class="row mt-4">
                        <h6>
                            <i class="fas fa-calendar-check"></i>
                            &nbsp;
                                Concluído em: 12/06/2019</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

