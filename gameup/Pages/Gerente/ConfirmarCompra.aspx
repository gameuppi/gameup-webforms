<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageGerente.master" AutoEventWireup="true" CodeFile="ConfirmarCompra.aspx.cs" Inherits="Pages_Gerente_ConfirmarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Confimar Compra</h1>
    </div>

    <div class="col-12 col-md-12">
        <asp:Panel ID="painel1" runat="server" CssClass="row">
            <div class="col-md-6">
                <div class="card-custom-image">
                    <asp:Image ID="imgLogo" runat="server" CssClass="col-md-12" />
                </div>
            </div>
            <div class="col-md-6 row">
                <div class="col-md-4">
                    <asp:Label ID="txtNome" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="txtQtd" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="txtValor" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="col-md-12">
                    <asp:Label ID="txtSub" runat="server" CssClass="form-control"></asp:Label>
                </div>
                <div class="col-md-12">
                    <asp:Label ID="txtDescricao" runat="server" CssClass="form-control"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <hr class="border-dark" />
                </div>
                <div class="col-md-6">
                    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-block btn-primary" OnClick="btnConfirmar_Click" />
                </div>
                <div class="col-md-6">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-block btn-dark" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </asp:Panel>
    </div>

    <div class="col-12 col-md-12">
        <asp:Literal ID="lblMsg" runat="server"></asp:Literal>
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

