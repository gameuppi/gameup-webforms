﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageColaborador.master" AutoEventWireup="true" CodeFile="LojaVirtual.aspx.cs" Inherits="Pages_Colaborador_LojaVirtual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Loja Virtual</h1>
    </div>

    <!-- Content Row -->
    <div class="row">

        <!-- Card superior - Regulamento -->
        <div class="col-xl-12 col-md-12 mb-4">
            <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                    <div class="row">
                        <div class="col-12 col-md-7">
                            <!--<img src="../../Assets/Imagens/store.png" class="img-fluid" />-->
                        </div>
                        <div class="col-12 col-md-5">
                            <h4 class="text-dark">Conclua missões, ganhe moedas e adquira benefícios...</h4>
                            <hr />
                            <h5>Cada missão concluída e validada irá te proporcionar moedas que poderão ser utilizadas para
                                adquirir benefícios e produtos na loja virtual.
                            </h5>
                            <button type="button" class="btn btn-info p-4 mt-5 btn-block">
                                Veja o regulamento
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Card de item -  -->
        <div class="col-12 col-md-12">
            <asp:Panel ID="painel1" runat="server"></asp:Panel>
        </div>

        <!-- Card de item -  -->
        <%--<div class="col-12 col-md-3">
            <div class="card-custom border-left-success shadow h-100">
                <div class="card-custom-image">
                    <img src="../../Assets/Imagens/jantar.jpg">
                    <span class="card-custom-title font-weight-bold">Bon appétit!
                        <br />
                        <small>1 disponíveis</small>
                    </span>
                    <a class="btn-floating btn-large halfway-fab btn-success">
                        <center>
                            <i class="fas fa-shopping-cart text-white"></i>
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
            <div class="card-custom border-left-success shadow h-100">
                <div class="card-custom-image">
                    <img src="../../Assets/Imagens/tempo.jpg">
                    <span class="card-custom-title font-weight-bold">O tempo voa
                        <br />
                        <small>2 disponíveis</small>
                    </span>
                    <a class="btn-floating btn-large halfway-fab btn-success">
                        <center>
                            <i class="fas fa-shopping-cart text-white"></i>
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
            <div class="card-custom border-left-success shadow h-100">
                <div class="card-custom-image">
                    <img src="../../Assets/Imagens/piscina.jpg">
                    <span class="card-custom-title font-weight-bold">Descanso merecido
                        <br />
                        <small>3 disponíveis</small>
                    </span>
                    <a class="btn-floating btn-large halfway-fab btn-success">
                        <center>
                            <i class="fas fa-shopping-cart text-white"></i>
                        </center>
                    </a>
                </div>
                <div class="card-custom-content">

                    <p>Consiga uma folga em um dia de sua escolha</p>
                </div>
            </div>
        </div>--%>

        <!-- /.container-fluid -->
</asp:Content>

