﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageRepresentante.master" AutoEventWireup="true" CodeFile="GerenciarColaboradores.aspx.cs" Inherits="Pages_Representante_GerenciarColaboradores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .dataTables_length {
            text-align: left !important;
        }

        .dataTables_info {
            text-align: left !important;
        }
    </style>

    <link href="../../Assets/Vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Colaboradores</h1>
    </div>

    <div class="row">
        <div class="col-12 col-md-8">
            <!-- Resumo -->
            <div class="card shadow mb-4 h-100">
                <div class="card-header py-3">
                    <asp:Literal ID="lblNome" runat="server"></asp:Literal>
                </div>
                <div class="card-body">
                    <asp:Literal ID="lblUsuario" runat="server"></asp:Literal>
                    <asp:Repeater runat="server" ID="rptColaborador" OnItemCommand="rptColaborador_ItemCommand">
                        <ItemTemplate>
                            <div class='col-md-12 m-0 font-weight-normal'>
                                <div class='row'>
                                    <div class='col-md-6'>
                                        <div class='col-md-12'>
                                            <div class='card-custom border-left-success shadow'>
                                                <div class='card-custom-image'>
                                                    <img src='http://localhost:62235/Assets/Imagens/astronautasentado.jpg' class='img-fluid'>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class='col-md-6'>
                                        <div class='col-md-12'>
                                            <b>Nome</b>: <%# Eval("usu_nome") %>
                                        </div>
                                        <div class='col-md-12'>
                                            <b>Apelido</b>: <%# Eval("usu_apelido") %>
                                        </div>
                                        <div class='col-md-12'>
                                            <b>Setor</b>: <%# Eval("set_id") %>
                                        </div>
                                        <div class='col-md-12'>
                                            <b>Cargo</b>: <%# Eval("tus_id") %>
                                        </div>
                                        <div class='col-md-12'>
                                            <b>E-mail</b>: <%# Eval("usu_email") %>
                                        </div>
                                        <div class='col-md-12'>
                                            <b>Pontos</b>: <%# Eval("usu_qtdPontos") %>
                                        </div>
                                        <div class='col-md-12'>
                                            <b>Experiência</b>: <%# Eval("usu_qtdXp") %>
                                        </div>
                                        <div class='col-md-12'>
                                            <b>Status</b>: <%# Eval("usu_statusUsuario") %>
                                        </div>
                                        <div class='col-md-12'>
                                            <b>Nivel</b>: <%# Eval("niv_id") %>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-4 mt-4"></div>
                                            <div class="col-md-4 mt-4"></div>
                                            <div class="col-md-4 mt-4">
                                                <asp:LinkButton ID="btnEditar" runat="server" CommandName="Edite" CommandArgument='<%# Bind("usu_id") %>' Text="Editar" CssClass="btn btn-block btn-primary"></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="col-12 col-md-4">
            <!-- Resumo -->
            <div class="card shadow mb-4 h-100">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-dark">Cadastrar Novos Colaboradores</h6>
                </div>
                <div class="card-body p-4">
                    <asp:TextBox ID="txtNome" runat="server" placeholder="Digite o nome do novo colaborador" CssClass="col-12 mb-1 form-control" type="text"></asp:TextBox>
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Digite o email do novo colaborador" CssClass="col-12 mb-1 form-control" type="e-mail"></asp:TextBox>
                    <div class="row">
                        <div class="col-8">
                            <asp:DropDownList ID="ddlSetor" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col pt-2">
                            <asp:CheckBox ID="cbGerente" runat="server" Text="&nbsp; Gerente" />
                        </div>
                    </div>
                    <asp:Button ID="btnCadastroColaborador" runat="server" CssClass="col-12 mt-2 btn btn-block btn-primary" Text="Cadastrar" OnClick="btnCadastroColaborador_Click" />
                </div>
            </div>
        </div>
    </div>


    <div class="row">
        <div class="col-12 col-md-12">
            <!-- Resumo -->
            <div class="card shadow mb-4 mt-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-dark">Lista de Colaboradores</h6>
                </div>
                <div class="card-body text-center">
                    <div class="table-responsive">
                        <div class="col-md-12">
                            <asp:GridView OnSelectedIndexChanged="gvColaboradores_SelectedIndexChanged" ID="gvColaboradores" runat="server" ClientIDMode="Static" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" CssClass="table table-striped table-hover tabela" OnRowCommand="gvColaboradores_RowCommand" OnRowDataBound="gvColaboradores_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Detalhes
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnColaborador" runat="server" CssClass="btn btn-default btn-sm btnDetalhes" CommandName="Editar" CommandArgument='<%# Bind("usu_id") %>'>
                                        <span class="fas fa-search-plus"></span>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="usu_nome" HeaderText="Usuario" />
                                    <asp:BoundField DataField="usu_email" HeaderText="E-mail" ItemStyle-CssClass="btnDetalhes" ItemStyle-Font-Size="Small" />
                                    <asp:BoundField DataField="tus_id" HeaderText="Cargo" />
                                    <asp:BoundField DataField="set_id" HeaderText="Setor" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Status
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnInativo" runat="server" Text='<%# Bind("usu_statususuario") %>' CommandName="Inativar" CommandArgument='<%# Bind("usu_id") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="#4e73df" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal cadastra colaborador -->
    <div class="modal fade" id="modalCadastraColaborador">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">

                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Literal runat="server" ID="ltrTituloModal"></asp:Literal>
                    </h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <div class="modal-body">
                    <asp:Literal runat="server" ID="msgModalCadastraColaborador"></asp:Literal>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal">Pronto</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Editar colaborador -->
    <div class="modal fade" id="modalEditaColaborador">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Literal runat="server" ID="lblTitulo"></asp:Literal>
                    </h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <asp:CheckBox ID="cbGerenteModal" runat="server" Text="&nbsp; Gerente" /><br />
                    <asp:CheckBox ID="cbInativoModal" runat="server" Text="&nbsp; Inativo" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnSalve" runat="server" CssClass="btn btn-success" OnClick="btnSalve_Click" Text="Salvar"/>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Redefinição -->
    <div class="modal fade" id="modalRedefinicaoEnviada" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content p-4">
                <div class="modal-header">
                    <h4 class="modal-title text-dark font-weight-bold" id="exampleModalLongTitle">E-mail enviado com sucesso!</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>Oba! Falta pouco para você recuperar seu acesso.</p>
                    <div id="inputSpace">
                        <asp:TextBox runat="server" ID="txtCodigo" MaxLength="8" placeholder="Código de segurança" CssClass="form-control" onkeyup="this.value = this.value.toUpperCase();" />
                    </div>
                    <br />
                    <div id="buttonSpace">
                        <input type="button" id="btnConfirmar" class="form-control btn btn-primary" value="Confirmar" />
                        <input type="button" id="btnSalvar" class="form-control btn btn-primary d-none" value="Salvar nova senha" />
                    </div>
                    <br />
                    <label id="lblMensagem"></label>
                </div>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.btnDetalhes').click(function () {
                var email = $('.btnDetalhes').html();
                $.ajax({
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    url: 'GerenciarColaboradores.aspx/ExibirDetalhesColaborador',
                    data: "{'email':'" + email + "'}",
                    async: false,
                    success: function (response) {
                        if (response) {

                        } else {
                            alert("erro")
                        }
                    },
                    error: function (response) {
                        alert("Erro");
                        console.log(response);
                    }
                });
            })
        });
    </script>

</asp:Content>
