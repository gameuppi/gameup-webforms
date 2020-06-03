<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RedefinirSenha.aspx.cs" Inherits="Pages_Visitante_RedefinirSenha" %>


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
                                    <h1 class="h4 text-gray-900 mb-4 font-weight-bold">Vish, parece que você esqueceu sua senha</h1>
                                    <p>Mas não tem problema, é só preencher os campos abaixo e seguir as instruções para redefini-la.</p>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-12 mb-3 mb-sm-0 col-md-12">
                                        <asp:TextBox runat="server" ID="txtEmail" placeholder="E-mail" type="email" required="required" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="col-md-12">
                                    <asp:Button runat="server" ID="btnLogin" Text="Enviar e-mail de redefinição" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click" />
                                </div>
                                <br />
                                <div class="col-md-12">
                                    <a href="Login.aspx" class="float-right">Voltar a página anterior</a>
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
                                <asp:TextBox runat="server" ID="txtCodigo" MaxLength="5" placeholder="Código de segurança" CssClass="form-control" onkeyup="this.value = this.value.toUpperCase();" />
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

            <script src="../../Assets/Vendor/jquery/jquery.min.js"></script>
            <script src="../../Assets/Vendor/bootstrap/js/bootstrap.min.js"></script>
            <script src="../../Assets/Custom/Js/sb-admin-2.js"></script>
            <script type="text/javascript">
                $(document).ready(function () {
                    $('#btnConfirmar').click(function () {
                        var email = $('#txtEmail').val();
                        var codigo = $('#txtCodigo').val();
                        $.ajax({
                            type: 'POST',
                            contentType: "application/json; charset=utf-8",
                            url: 'RedefinirSenha.aspx/verificarCodigo',
                            data: "{'codigoDigitado':'" + codigo + "', 'email':'" + email + "'}",
                            async: false,
                            success: function (response) {
                                $('#txtCodigo').val('');
                                if (response.d) {
                                    $('#txtEmail').attr("class", "d-none");
                                    $('#txtCodigo').attr("class", "d-none");
                                    $('#lblMensagem').html("");
                                    $('#btnConfirmar').attr("class", "d-none");
                                    $('#inputSpace').append("<input type='password' placeholder='Nova senha' id='txtSenha' class='form-control' /> <br />");
                                    $('#inputSpace').append("<input type='password' placeholder='Confirmar nova senha' id='txtSenhaConfirma' class='form-control' />");
                                    $('#btnSalvar').attr("class", "form-control btn btn-primary");
                                } else {
                                    $('#lblMensagem').append("<br /> <p class='text-danger'>Vish, código expirado, já validado ou inválido.</p>");
                                }
                            },
                            error: function (response) {
                                alert("Erro");
                                console.log(response);
                            }
                        });
                    });

                    $('#btnSalvar').click(function () {
                        var senha = $('#txtSenha').val();
                        var confirmaSenha = $('#txtSenhaConfirma').val();
                        var email = $('#txtEmail').val();
                        $.ajax({
                            type: 'POST',
                            contentType: "application/json; charset=utf-8",
                            url: 'RedefinirSenha.aspx/salvarNovaSenha',
                            data: "{'senha':'" + senha + "', 'confirmaSenha':'" + confirmaSenha + "', 'email':' " + email + "'}",
                            async: false,
                            success: function (response) {
                                $('#txtCodigo').val('');
                                if (response.d) {
                                    alert("Tudo pronto! Senha redefinida com sucesso!");
                                    window.location.href = "Login.aspx";
                                } else {
                                    $('#lblMensagem').append("<br /> <p class='text-danger'>As senhas precisam coincidir e atender as regras de segurança</p>");
                                }
                            },
                            error: function (response) {
                                $('#lblMensagem').append("<br /> <p class='text-danger'>As senhas precisam coincidir e atender as regras de segurança</p>");
                            }
                        });
                    });
                })
            </script>
            <asp:ScriptManager runat="server"></asp:ScriptManager>
    </form>
</body>
</html>
