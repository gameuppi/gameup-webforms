<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageGerente.master" AutoEventWireup="true" CodeFile="LojaVirtual.aspx.cs" Inherits="Pages_Gerente_LojaVirtual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Loja Virtual</h1>
    </div>

    <!-- Content Row -->
    <div class="row">

        <div class="col-xl-12 col-md-12 mb-4">
            <div class="card border-left-warning shadow py-2">
                <div class="card-body">
                    <div class="row">
                        <div class="col-12">
                            <h6>Seja muito bem-vindo! Para saber mais como a loja virtual funciona, consulte o link ao lado. <a href="#">Acessar o regulamento</a></h6>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Card superior - Regulamento -->
        <div class="col-xl-12 col-md-12 mb-4">
            <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                    <div class="row">
                        <div class="col-12">
                            <h5>Recompensas adquiridas</h5>
                        </div>
                        <div class="col-12">
                            <div class="row">
                                <asp:Repeater ID="rptMeusProdutos" runat="server">
                                    <ItemTemplate>
                                        <div class='col-md-3 mt-4'>
                                            <div class='card-custom border-left-success shadow h-100'>
                                                <div class='card-custom-image'>
                                                    <img src='<%# Eval("pro_logo") %>'>
                                                    <span class='card-custom-title font-weight-bold'><%# Eval("pro_nome") %>
                                                    </span>
                                                </div>
                                                <div class='card-custom-content'>
                                                    <p><%# Eval("pro_descricao") %></p>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Card de item -  -->
        <div class="col-xl-12 col-md-12 mb-4">
            <div class="card border-left-primary shadow h-100 py-2">
                <div class="card-body">
                    <div class="row">
                        <div class="col-12">
                            <h5>Para adquirir</h5>
                        </div>
                        <div class="col-12 row">
                            <asp:Repeater ID="rptProdutos" runat="server" OnItemCommand="rptProdutos_ItemCommand">
                                <ItemTemplate>
                                    <div class='col-md-3 mt-3'>
                                        <div class='card-custom border-left-success shadow h-100'>
                                            <div class='card-custom-image'>
                                                <img src='<%# Eval("pro_logo") %>'>
                                                <span class='card-custom-title font-weight-bold'>
                                                    <%# Eval("pro_nome") %>
                                                    <br />
                                                    <small><%# Eval("mes_saldo") %> disponíveis</small>
                                                </span>
                                                <div class='text-center'>
                                                    <asp:LinkButton ID="btnComprar" runat="server" CssClass="btn-floating btn-large halfway-fab btn-success text-white" CommandName="Comprar" CommandArgument='<%# Bind("pro_id") %>'>
                                                        <span class="fas fa-shopping-cart mt-3 ml-2 mr-2 mb-2" style="font-size: 21px"></span>
                                                    </asp:LinkButton>
                                                </div>
                                            </div>
                                            <br />
                                            <div class='col-md-12 card-custom-content'>
                                                <p><%# Eval("pro_subtitulo") %></p>
                                                <p><%# Eval("pro_valorMoeda") %> Moedas</p>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-12 col-md-12">
        </div>

        <!-- Modal compra -->
        <div class="modal fade" id="modalCompra">
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

</asp:Content>

