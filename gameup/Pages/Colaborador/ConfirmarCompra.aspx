<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageColaborador.master" AutoEventWireup="true" CodeFile="ConfirmarCompra.aspx.cs" Inherits="Pages_Colaborador_ConfirmarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                    <br /><br /><br /><hr class="border-dark"/>
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
</asp:Content>

