﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageColaborador.master" AutoEventWireup="true" CodeFile="Missoes.aspx.cs" Inherits="Pages_Colaborador_Missoes" %>

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
            <asp:LinkButton runat="server" CssClass="nav-item nav-link active" ID="navVisualizarTab" data-toggle="tab" href="#nav-visualizar" role="tab" aria-controls="nav-visualizar" aria-selected="true">Visualizar missões</asp:LinkButton>
            <asp:LinkButton runat="server" CssClass="nav-item nav-link" ID="navMissoesEnviadas" data-toggle="tab" href="#nav-enviadas" role="tab" aria-controls="nav-enviadas" aria-selected="true">Missões enviadas</asp:LinkButton>
        </div>
    </nav>
    <!-- Missoes a fazer -->
    <div class="tab-content card shadow border-top-0" id="nav-tabContent">
        <div class="tab-pane fade show active p-4" id="nav-visualizar" role="tabpanel" aria-labelledby="nav-visualizar">
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
            <asp:Panel runat="server" ID="pnlMissoesVisualizar" CssClass="row mt-4">
            </asp:Panel>

        </div>
        <div class="tab-pane fade p-4" id="nav-enviadas" role="tabpanel" aria-labelledby="nav-enviadas">
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

            <asp:Panel runat="server" ID="pnlMissoesEnviadas" CssClass="row mt-4">
            </asp:Panel>






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



    </div>
</asp:Content>

