<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageColaborador.master" AutoEventWireup="true" CodeFile="PlacarLideres.aspx.cs" Inherits="Pages_Colaborador_PlacarLideres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Placar de líderes</h1>
    </div>

    <div class="row">
        <!-- Card - noticia de placar -->
        <div class="col-12 col-md-6 ">
            <div class="row">
                <div class="col-12">
                    <div class="card mb-4 py-1 border-bottom-primary">
                        <div class="card-body py-1">
                            As conquistas define seus pontos fortes como funcionário, conquiste-as e mostre que é capaz

                        </div>
                    </div>

                    <!-- Card podium -->
                    <div class="row">
                        <div class="col-12">
                            <div class="card shadow mb-4">
                                <div class="card-header py-3">
                                    <h5 class="m-0 font-weight-bold text-dark">Líderes</h5>
                                </div>
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-12 ">
                                            <center>
                                                <div class="podium">
                                                    <table id="ladder">
                                                        <tr>
                                                            <td class="text-center">
                                                                <i class="fas fa-circle fa-4x " style=" color: #808080"></i>
                                                                <div class="mt-1 font-weight-bold">
                                                                    <asp:Label runat="server" ID="lbl2Posicao"></asp:Label>
                                                                </div>
                                                                <div class="mt-1">
                                                                    <asp:Label runat="server" ID="lblPontos2Posicao"></asp:Label>
                                                                </div>
                                                                <div class="mt-1" id="podium1"></div>
                                                            </td>
                                                            <td class="text-center">
                                                                <i class="fas fa-circle fa-4x " style=" color: #808080"></i>
                                                                <div class="mt-1 mt-1 font-weight-bold">
                                                                    <asp:Label runat="server" ID="lbl1Posicao"></asp:Label>
                                                                </div>
                                                                <div class="mt-1">
                                                                    <asp:Label runat="server" ID="lblPontos1Posicao"></asp:Label>
                                                                </div>
                                                                <div class="mt-1" id="podium0"></div>
                                                            </td>
                                                            <td class="text-center">
                                                                <i class="fas fa-circle fa-4x " style=" color: #808080"></i>
                                                                <div class="mt-1 mt-1 font-weight-bold">
                                                                    <asp:Label runat="server" ID="lbl3Posicao"></asp:Label>
                                                                </div>
                                                                <div class="mt-1">
                                                                    <asp:Label runat="server" ID="lblPontos3Posicao"></asp:Label>
                                                                </div>
                                                                <div class="mt-1" id="podium2"></div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </center>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>




                </div>



            </div>
        </div>
        <!-- Fim card noticia -->

        <div class=" col-12 col-md-6">
            <div class="col-12">
                <div class="card shadow ">
                    <!--Card Cabeça -->
                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                        <h5 class="m-0 font-weight-bold text-dark">Placar geral</h5>
                    </div>
                    <!--Card Corpo -->
                    <div class="card-body text-center">
                        <asp:Table runat="server" ID="tblPlacarGeral" class="table">
                            <asp:TableHeaderRow runat="server" CssClass="thead-dark">
                                <asp:TableHeaderCell>
                                    Posição
                                </asp:TableHeaderCell>
                                <asp:TableHeaderCell>
                                    Nome
                                </asp:TableHeaderCell>
                                <asp:TableHeaderCell>
                                    Pontos
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Fim row principal -->

</asp:Content>

