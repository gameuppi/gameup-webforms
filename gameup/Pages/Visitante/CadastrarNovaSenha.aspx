<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadastrarNovaSenha.aspx.cs" Inherits="Pages_Visitante_CadastrarNovaSenha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Assets/Vendor/bootstrap/css/bootstrap.css" rel="stylesheet" />
</head>
<body class="bg-info">
    <form id="form1" runat="server">
        <div class="container">
            <div class="card o-hidden border-0 shadow-lg my-5">
                <div class="card-body p-0">
                    <!-- Nested Row within Card Body -->
                    <div class="row">
                        <div class="col-lg-5 d-lg-block bg-register-image">
                            <center><img src="../../Assets/Imagens/fgt.jpg" class="img-fluid" /></center>
                        </div>
                        <div class="col-lg-7">
                            <div class="p-5">
                                <div class="text-left ml-3">
                                    <h1 class="h4 text-gray-900 mb-4 font-weight-bold">Falta pouco, basta cadastrar a nova senha abaixo</h1>
                                    <p>Mas lembre-se de seguir as regras de segurança</p>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12 mb-3 mb-sm-0 col-md-12">
                                        <asp:TextBox runat="server" ID="txtSenha" placeholder="Senha" type="password" required="required" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12 mb-3 mb-sm-0 col-md-12">
                                        <asp:TextBox runat="server" ID="TextBox1" placeholder="Confirmar senha" type="password" required="required" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="col-md-12">
                                    <asp:Button runat="server" ID="btnLogin" Text="Concluir redefinição" CssClass="btn btn-primary btn-block" />
                                </div>
                                <div class="col-md-12 text-danger">
                                    <asp:Literal runat="server" ID="ltlMsg"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <!-- Modal -->
            <div class="modal fade" id="modalEmailNaoEncontrado" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content p-4">
                        <div class="modal-header">
                            <h4 class="modal-title text-dark font-weight-bold" id="exampleModalLongTitle">Vish, e-mail não encontrado</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <p>Ao checar o e-mail informado, não encontramos nada cadastrado em nossa base. Tenha certeza que o e-mail informado é o mesmo que foi cadastrado em nosso sistema.</p>
                        </div>
                    </div>
                </div>
            </div>

            <script src="../../Assets/Vendor/jquery/jquery.min.js"></script>
            <script src="../../Assets/Vendor/bootstrap/js/bootstrap.min.js"></script>
            <script src="../../Assets/Custom/Js/sb-admin-2.js"></script>
            <asp:ScriptManager runat="server"></asp:ScriptManager>
    </form>
</body>
</html>
