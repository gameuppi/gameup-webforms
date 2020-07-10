<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageGerente.master" AutoEventWireup="true" CodeFile="PlacarLideres.aspx.cs" Inherits="Pages_Gerente_PlacarLideres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <style>
        .dataTables_length {
            text-align: left !important;
        }

        .dataTables_info {
            text-align: left !important;
        }
    </style>

    <%--TELA DE PLACAR DE LIDERES GERENTE--%>

    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <h1 class="h3 mb-0 text-gray-800">Placar de líderes</h1>
    </div>
    <div class="row">
        <!-- Card - noticia de placar -->
        <div class="col-12 col-md-5 ">
            <div class="row">
                <div class="col-12">
                    <div class="card mb-4 py-1 border-bottom-primary">
                        <div class="card-body py-1">
                            <p>O Painel de Lideres é baseado nos pontos obtidos durante todos os dias que está na empresa, obtenha mais pontos para conquistar a melhor pontuação.</p>
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
                                        <div class="col-12 p-0">
                                            <div class="podium">
                                                <table id="ladder">
                                                    <tr>
                                                        <td class="text-center">
                                                            <div class="">
                                                                <i class="fas fa-circle fa-4x text-info"></i>
                                                                <div class="mt-1 font-weight-bold">
                                                                    <asp:Label runat="server" ID="lbl2Posicao"></asp:Label>
                                                                </div>
                                                                <div class="mt-1">
                                                                    <asp:Label runat="server" ID="lblPontos2Posicao"></asp:Label>
                                                                </div>
                                                                <div class="mt-1 bg-info" id="podium1"></div>
                                                            </div>
                                                        </td>
                                                        <td class="text-center">
                                                            <i class="fas fa-circle fa-4x text-success"></i>
                                                            <div class="mt-1 mt-1 font-weight-bold">
                                                                <asp:Label runat="server" ID="lbl1Posicao"></asp:Label>
                                                            </div>
                                                            <div class="mt-1">
                                                                <asp:Label runat="server" ID="lblPontos1Posicao"></asp:Label>
                                                            </div>
                                                            <div class="mt-1 bg-success" id="podium0"></div>
                                                        </td>
                                                        <td class="text-center">
                                                            <div class="">
                                                                <i class="fas fa-circle fa-4x text-warning"></i>
                                                                <div class="mt-1 mt-1 font-weight-bold">
                                                                    <asp:Label runat="server" ID="lbl3Posicao"></asp:Label>
                                                                </div>
                                                                <div class="mt-1">
                                                                    <asp:Label runat="server" ID="lblPontos3Posicao"></asp:Label>
                                                                </div>
                                                                <div class="mt-1 bg-warning" id="podium2"></div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
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
        <div class=" col-12 col-md-7">
            <div class="col-12">
                <div class="card shadow ml-2">
                    <!--Card Cabeça -->
                    <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                        <asp:Literal ID="ltlPlacar" runat="server"></asp:Literal>
                        <asp:DropDownList ID="ddlPlacar" runat="server" CssClass="form-control col-md-4 mr-2">
                            <asp:ListItem Text="Geral" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Mensal" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnAlteraGv" runat="server" CssClass="btn btn-primary form-control col-md-2 ml-2" Text="Gerar" OnClick="btnAlteraGv_Click" />
                    </div>
                    <!--Card Corpo -->
                    <div class="card-body text-center">
                        <asp:GridView ID="gvPlacarLideres" runat="server" ClientIDMode="Static" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" CssClass="table table-striped table-hover tabela">
                            <Columns>
                                <asp:BoundField DataField="posicao" HeaderText="Posição" />
                                <asp:BoundField DataField="usu_nome" HeaderText="Usuario" />
                                <asp:BoundField DataField="usu_qtdPontos" HeaderText="Pontos" />
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
    <!-- Fim row principal -->
</asp:Content>

