<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Visitante_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                                        <h1 class="h4 text-gray-900 mb-4 font-weight-bold">Bem vindo de volta!</h1>
                                        <p>Preencha os campos abaixo com suas credenciais e acesse a plataforma.</p>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-12 mb-3 mb-sm-0 col-md-12">
                                            <asp:TextBox runat="server" ID="txtEmail" placeholder="E-mail" type="email" required="required" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 form-group">
                                         <asp:TextBox runat="server" ID="txtSenha" type="password" placeholder="Senha" required="required" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <br />
                                    <div class="col-md-12">
                                        <asp:Button runat="server" ID="btnLogin" Text="Acessar a plataforma" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click" />
                                    </div>
                                    <br />
                                    <div class="col-md-12">
                                        <a href="RedefinirSenha.aspx" class="float-right">Esqueci minha senha</a>
                                    </div>
                                    <br />
                                    <div class="col-md-12 text-danger">
                                       <asp:Literal runat="server" ID="ltlMsg"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

    </form>
    <script src="../../Assets/Vendor/jquery/jquery.min.js"></script>
    <script src="../../Assets/Vendor/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
