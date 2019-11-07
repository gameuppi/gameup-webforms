<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageColaborador.master" AutoEventWireup="true" CodeFile="Missoes.aspx.cs" Inherits="Pages_Colaborador_Missoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Missões</h1>
    </div>
    <div class="row">
        <div class="col-md-12">

            <div class="card mb-4 py-1 border-bottom-info">
                <div class="card-body py-1">
                    Complete suas missões e ganhe pontos, experiência e moedas. Se esforce e vá mais longe!
                </div>
            </div>
        </div>
    </div>

    <nav>
        <div class="nav nav-tabs" id="nav-tab" role="tablist">
            <a class="nav-item nav-link active" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">Missões a fazer</a>
            <a class="nav-item nav-link" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">Missões enviadas</a>
        </div>
    </nav>
    <!-- Missoes a fazer -->
    <div class="tab-content card shadow border-top-0" id="nav-tabContent">
        <div class="tab-pane fade show active p-4" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
            <div class="row">

                <div class="col-12 col-md-4">
                    <div class="input-group">
                        <input type="text" class="form-control bg-light border-0 small" placeholder="Procure suas missões" aria-label="Search" aria-describedby="basic-addon2">
                        <div class="input-group-append">
                            <button class="btn btn-info" type="button">
                                <i class="fas fa-search fa-sm"></i>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-12 col-md-4 mb-4">
                    <div class="card border-left-info shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-sm font-weight-bold text-info text-uppercase mb-1">Entregar relatório técnico</div>
                                    <div class="h6 mb-0 text-gray-800">Você precisa terminar o relatório técnico para entrega-lo a diretoria.</div>
                                    <div class="mt-4">
                                        <i class="fas fa-calendar-check fa-2x text-info"></i>
                                        &nbsp; 12/06/2019
                                    <br />
                                        <br />
                                        <button type="button" class="btn btn-info btn-block" data-toggle="modal" data-target="#exampleModalCenter">Detalhes</button>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <a href="#"><i class="fas fa-check fa-2x text-gray-300 icon-change"></i></a>
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
                                        <i class="fas fa-calendar-check fa-2x text-info"></i>
                                        &nbsp; 12/06/2019
                                    <br />
                                        <br />
                                        <button type="button" class="btn btn-info btn-block" data-toggle="modal" data-target="#exampleModalCenter">Detalhes</button>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <a href="#"><i class="fas fa-check fa-2x text-gray-300 icon-change"></i></a>
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
                                        <i class="fas fa-calendar-check fa-2x text-info"></i>
                                        &nbsp; 12/06/2019
                                    <br />
                                        <br />
                                        <button type="button" class="btn btn-info btn-block" data-toggle="modal" data-target="#exampleModalCenter">Detalhes</button>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <a href="#"><i class="fas fa-check fa-2x text-gray-300 icon-change"></i></a>
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
                                        <i class="fas fa-calendar-check fa-2x text-info"></i>
                                        &nbsp; 12/06/2019
                                    <br />
                                        <br />
                                        <button type="button" class="btn btn-info btn-block" data-toggle="modal" data-target="#exampleModalCenter">Detalhes</button>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <a href="#"><i class="fas fa-check fa-2x text-gray-300 icon-change"></i></a>
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
                                        <i class="fas fa-calendar-check fa-2x text-info"></i>
                                        &nbsp; 12/06/2019
                                    <br />
                                        <br />
                                        <button type="button" class="btn btn-info btn-block" data-toggle="modal" data-target="#exampleModalCenter">Detalhes</button>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <a href="#"><i class="fas fa-check fa-2x text-gray-300 icon-change"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>

        </div>
        <div class="tab-pane fade p-4" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
            <div class="row">
                 <div class="col-12 col-md-4 mb-3">
                    <div class="input-group">
                        <input type="text" class="form-control bg-light border-0 small" placeholder="Procure suas concluídas ou aguardando validação" aria-label="Search" aria-describedby="basic-addon2">
                        <div class="input-group-append">
                            <button class="btn btn-info" type="button">
                                <i class="fas fa-search fa-sm"></i>
                            </button>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-8 text-right">
                    <button type="button" class="btn btn-dark">Todas</button>
                    <button type="button" class="btn btn-success">Aceitas</button>
                    <button type="button" class="btn btn-warning">Pendentes</button>
                </div>
            </div>
            <div class="row pt-3">
                <div class="col-12 col-md-4 mb-4">
                    <div class="card border-left-success shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-sm font-weight-bold text-success text-uppercase mb-1">Entregar relatório técnico</div>
                                    <div class="h6 mb-0 text-gray-800">Você precisa terminar o relatório técnico para entrega-lo a diretoria.</div>
                                    <div class="mt-4">
                                        <i class="fas fa-calendar-check fa-2x text-success"></i>
                                        &nbsp; 12/06/2019
                                    <br />
                                        <br />
                                        <button type="button" class="btn btn-success btn-block" data-toggle="modal" data-target="#exampleModalCenter">Detalhes</button>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <a href="#"><i class="fas fa-check fa-2x text-success"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-12 col-md-4 mb-4">
                    <div class="card border-left-warning shadow h-100 py-2">
                        <div class="card-body">
                            <div class="row no-gutters align-items-center">
                                <div class="col mr-2">
                                    <div class="text-sm font-weight-bold text-warning text-uppercase mb-1">Entregar relatório técnico</div>
                                    <div class="h6 mb-0 text-gray-800">Você precisa terminar o relatório técnico para entrega-lo a diretoria.</div>
                                    <div class="mt-4">
                                        <i class="fas fa-calendar-check fa-2x text-warning"></i>
                                        &nbsp; 12/06/2019
                                    <br />
                                        <br />
                                        <button type="button" class="btn btn-warning btn-block" data-toggle="modal" data-target="#exampleModalCenter">Detalhes</button>
                                    </div>
                                </div>
                                <div class="col-auto">
                                    <a href="#"><i class="fas fa-clock fa-2x text-warning"></i></a>
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
                    </div>
                </div>
            </div>
        </div>



    </div>
</asp:Content>

