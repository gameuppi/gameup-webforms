<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageRepresentante.master" AutoEventWireup="true" CodeFile="GerenciarSetores.aspx.cs" Inherits="Pages_Representante_GerenciarSetores" %>

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
        <h1 class="h3 mb-0 text-gray-800">Setores</h1>
    </div>

    <div class="row">
        <div class="col-12 col-md-8">
            <!-- Resumo -->
            <div class="card shadow mb-4 h-100">
                <div class="card-header py-3">
                    <asp:Literal ID="lblNome" runat="server"></asp:Literal>
                </div>
                <div class="card-body">
                    <asp:Literal ID="lblSetor" runat="server"></asp:Literal>
                    <asp:Repeater runat="server" ID="rptSetor">
                        <ItemTemplate>
                            <div class='col-md-12 m-0 font-weight-normal'>
                                <div class='row'>
                                    <div class='col-md-4'>
                                        <div class='col-md-12'>
                                            <div class='card-custom border-left-success shadow'>
                                                <div class='card-custom-image'>
                                                    <img src="../../Assets/Imagens/building-setor.jpg" class="img-fluid">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class='col-md-8 mt-5 mb-5'>
                                        <div class='col-md-12'>
                                            <i class="fa fa-address-card" data-toggle="tooltip" title="Nome"></i>&nbsp;: <%# Eval("set_nome") %>
                                        </div>
                                        <div class='col-md-12'>
                                            <i class="fa fa-toggle-on" data-toggle="tooltip" title="Status"></i>&nbsp;: <%# Eval("set_status") %>
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
                    <h6 class="m-0 font-weight-bold text-dark">Cadastrar Novos Setores</h6>
                </div>
                <div class="card-body">
                    <asp:TextBox ID="txtNome" runat="server" placeholder="Digite o nome do novo Setor" CssClass="col-12 mb-1 form-control" type="text"></asp:TextBox>
                    <asp:Button ID="btnCadastroSetor" runat="server" CssClass="col-12 mt-2 btn btn-block btn-primary" Text="Cadastrar" OnClick="btnCadastroSetor_Click" />
                </div>
            </div>
        </div>
    </div>


    <div class="row">
        <div class="col-12 col-md-12 mt-3">
            <!-- Resumo -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-dark">Lista de Setores</h6>
                </div>
                <div class="card-body text-center">
                    <div class="table-responsive">
                        <div class="col-md-12">
                            <asp:GridView ID="gvSetores" runat="server" ClientIDMode="Static" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" CssClass="table table-striped table-hover tabela" OnRowCommand="gvSetores_RowCommand" OnRowDataBound="gvSetores_RowDataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Detalhes
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnSetor" runat="server" CssClass="btn btn-default btn-sm" CommandName="Editar" CommandArgument='<%# Bind("set_id") %>'>
                                        <span class="fas fa-search-plus"></span>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="set_nome" HeaderText="Setor" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Status
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnInativo" runat="server" Text='<%# Bind("set_status") %>' CommandName="Inativar" CommandArgument='<%# Bind("set_id") %>'></asp:LinkButton>
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
    <div class="modal fade" id="modalCadastraSetor">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">

                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Literal runat="server" ID="ltrTituloModal"></asp:Literal>
                    </h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>

                <div class="modal-body">
                    <asp:Literal runat="server" ID="msgModalCadastraSetor"></asp:Literal>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal">Pronto</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Update setor -->
    <div class="modal fade" id="modalUpdateSetor">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">                
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Literal runat="server" ID="lblUpdateSetTitle"></asp:Literal>
                    </h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <asp:Literal runat="server" ID="lblUpdateSetText"></asp:Literal>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal">Pronto</button>
                </div>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    

</asp:Content>

