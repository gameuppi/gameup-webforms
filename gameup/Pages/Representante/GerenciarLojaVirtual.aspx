﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageRepresentante.master" AutoEventWireup="true" CodeFile="GerenciarLojaVirtual.aspx.cs" Inherits="Pages_Representante_GerenciarLojaVirtual" %>

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
                            <h3>60%</h3>
                            <h5>em estoque</h5>
                        </div>
                        <div class="col-12 col-md-4">
                            <h3>16 itens ativos</h3>
                            <h3>9 disponíveis</h3>
                        </div>
                        <div class="col-12 col-md-4">
                            <h3>9450 moedas gastas</h3>
                            <h3>34 itens vendidos</h3>
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
                            <div class="h5 mb-0 font-weight-bold text-gray-800">12</div>
                        </div>
                        <div class="col-auto">
                            <i class="fas fa-shopping-cart fa-2x text-gray-300"></i>
                        </div>
                    </div>
                    <div class="row">
                        <div class=" text-center col-12 card p-4 mt-4">
                            <h4>"O tempo voa"</h4>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="col-12">
            <nav>
                <div class="nav nav-tabs text-center" id="nav-tab" role="tablist">
                    <a class="nav-item nav-link active" id="nav-cadastro-tab" data-toggle="tab" href="#nav-cadastro" role="tab" aria-controls="nav-cadastro" aria-selected="true">Adicionar</a>
                    <a class="nav-item nav-link" id="nav-visualizacao-tab" data-toggle="tab" href="#nav-visualizacao" role="tab" aria-controls="nav-visualizacao" aria-selected="false">Visualizar</a>
                </div>
            </nav>
            <div class="tab-content card shadow border-top-0 pb-4 mb-4" id="nav-tabContent">
                <!-- Cadastrar produtos -->
                <div class="tab-pane fade show active p-4" id="nav-cadastro" role="tabpanel" aria-labelledby="nav-cadastro-tab">
                    <div class="row mt-5">
                        <div class="col-12 col-md-3 text-center">
                            <i class="fas fa-user-circle fa-10x"></i>
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
                                            <input type="text" class="form-control" id="inputEmail4" placeholder="Nome da missão">
                                        </div>
                                        <div class="form-group col-12 col-md-6">
                                            <label for="inputPassword4">Subtítulo</label>
                                            <input type="text" class="form-control" id="inputPassword4" placeholder="Participantes">
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col-12">
                                            <label for="inputPassword4">Descrição</label>
                                            <textarea class="form-control" placeholder="Descrição da missão"></textarea>
                                        </div>
                                    </div>
                                    <div class="row mt-4">
                                        <div class="col-4">
                                            <div class="row">
                                                <div class="col-12 col-md-4 text-center">
                                                    <i class="fas fa-coins fa-2x text-success"></i>
                                                </div>
                                                <div class="col-12 col-md-6">
                                                    <input type="number" class="form-control" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-4">
                                            <div class="row">
                                                <div class="col-12 col-md-4 text-center">
                                                    <i class="fas fa-cart-plus fa-2x text-warning"></i>
                                                </div>
                                                <div class="col-12 col-md-6">
                                                    <input type="number" class="form-control" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-4">
                                            <div class="row">
                                                <div class="col-12 col-md-4 text-center">
                                                    <i class="fas fa-tag fa-2x text-danger"></i>
                                                </div>
                                                <div class="col-12 col-md-6">
                                                    <select class="form-control">
                                                        <option class="form-control">Selecione</option>
                                                        <option class="form-control">Físico</option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row mt-4">
                                        <div class="col-12">
                                            <button type="button" class="btn btn-success">Cadastrar</button>
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
                        <!-- Card de item -  -->
                        <div class="col-12 col-md-3">
                            <div class="card-custom border-left-success shadow">
                                <div class="card-custom-image">
                                    <img src="../../Assets/Imagens/piscina.jpg">
                                    <span class="card-custom-title font-weight-bold">Descanso merecido
                        <br />
                                        <small>3 disponíveis</small>
                                    </span>
                                    <a class="btn-floating btn-large halfway-fab btn-success">
                                        <center>
                            <i class="fas fa-info text-white"></i>
                        </center>
                                    </a>
                                </div>
                                <div class="card-custom-content">

                                    <p>Consiga uma folga em um dia de sua escolha</p>
                                </div>
                            </div>
                        </div>

                        <!-- Card de item -  -->
                        <div class="col-12 col-md-3">
                            <div class="card-custom border-left-success shadow">
                                <div class="card-custom-image">
                                    <img src="../../Assets/Imagens/jantar.jpg">
                                    <span class="card-custom-title font-weight-bold">Bon appétit!
                        <br />
                                        <small>1 disponíveis</small>
                                    </span>
                                    <a class="btn-floating btn-large halfway-fab btn-success">
                                        <center>
                            <i class="fas fa-info text-white"></i>
                        </center>
                                    </a>
                                </div>
                                <div class="card-custom-content">

                                    <p>Uma reserva de jantar para um ótimo fim de semana.</p>
                                </div>
                            </div>
                        </div>

                        <!-- Card de item -  -->
                        <div class="col-12 col-md-3">
                            <div class="card-custom border-left-success shadow">
                                <div class="card-custom-image">
                                    <img src="../../Assets/Imagens/tempo.jpg">
                                    <span class="card-custom-title font-weight-bold">O tempo voa
                        <br />
                                        <small>2 disponíveis</small>
                                    </span>
                                    <a class="btn-floating btn-large halfway-fab btn-success">
                                        <center>
                            <i class="fas fa-info text-white"></i>
                        </center>
                                    </a>
                                </div>
                                <div class="card-custom-content">

                                    <p>Acrescente +30 minutos na sua pausa de almoço</p>
                                </div>
                            </div>
                        </div>

                        <!-- Card de item -  -->
                        <div class="col-12 col-md-3">
                            <div class="card-custom border-left-success shadow">
                                <div class="card-custom-image">
                                    <img src="../../Assets/Imagens/piscina.jpg">
                                    <span class="card-custom-title font-weight-bold">Descanso merecido
                        <br />
                                        <small>3 disponíveis</small>
                                    </span>
                                    <a class="btn-floating btn-large halfway-fab btn-success">
                                        <center>
                            <i class="fas fa-info text-white"></i>
                        </center>
                                    </a>
                                </div>
                                <div class="card-custom-content">

                                    <p>Consiga uma folga em um dia de sua escolha</p>
                                </div>
                            </div>
                        </div>

                    </div>


                </div>
            </div>
        </div>
</asp:Content>

