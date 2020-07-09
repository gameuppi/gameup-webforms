<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageGerente.master" AutoEventWireup="true" CodeFile="Missoes.aspx.cs" Inherits="Pages_Gerente_Missoes" %>

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

                <div class="col-12 col-md-8 text-right">
                    <asp:Button runat="server" type="checkbox" class="btn btn-dark" Text="Todas" ID="btnTodas" OnClick="btnTodas_Click" />
                    <asp:Button runat="server" type="button" class="btn btn-success" Text="Concluídas" ID="btnConcluidas" OnClick="btnConcluidas_Click" />
                    <asp:Button runat="server" type="button" class="btn btn-info" Text="Em andamento" ID="btnEmAndamento" OnClick="btnEmAndamento_Click" />
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
                            <asp:Label runat="server" ID="lblIdMissaoUsuario" CssClass="d-none"></asp:Label>
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
                            <p>
                                <i class="fas fa-paperclip text-gray-600"></i>
                                <asp:HiddenField runat="server" ID="hfIdMissaoUsuario" />
                                <asp:Label runat="server" ID="lblTextoAnexo"></asp:Label>
                                &nbsp;
                                <asp:Panel runat="server" ID="pnlAnexo">
                                    <asp:LinkButton runat="server" ID="btnBaixarAnexo" OnClick="btnBaixarAnexo_Click">
                                    </asp:LinkButton>
                                </asp:Panel>
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

        <!-- Modal concluir missão -->
        <div class="modal fade" id="modalConcluirMissao" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <asp:HiddenField runat="server" ID="hfIdMissao" />
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content p-4">
                    <div class="modal-header">
                        <h4 class="modal-title text-dark font-weight-bold" id="exampleModalLongTitle">Muito bem!</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                            <asp:Label runat="server" ID="Label1" CssClass="d-none"></asp:Label>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <label class="col-12">
                                <p>
                                    Mas antes de efetivar essa conclusão, se você quiser, pode anexar um arquivo no campo abaixo.
                                </p>
                            </label>
                            <asp:Label runat="server" ID="lblTeste"></asp:Label>
                            <asp:Label runat="server" ID="lblUploadArquivo" CssClass="col-12">
                                <asp:FileUpload runat="server" ID="fuAnexo" CssClass="form-control-file" />
                            </asp:Label>
                            <br />
                            <br />
                            <div class="col-12 mt-2">
                                <asp:Button runat="server" ID="btnConfirmarConclusaoMissao" CssClass="btn btn-success form-control" Text="Confirmar conclusão" OnClick="btnConfirmarConclusaoMissao_Click" />
                            </div>
                            <asp:Panel runat="server" ID="Panel1"></asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </div>
</asp:Content>

