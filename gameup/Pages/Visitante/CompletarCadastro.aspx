<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompletarCadastro.aspx.cs" Inherits="Pages_Visitante_CompletarCadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>GameUP - Plataforma de Gamificação Empresarial</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <link href="../../Assets/Vendor/bootstrap/css/bootstrap.css" rel="stylesheet" />
</head>
<body class="bg-info">
    <form id="form1" runat="server">
        <div>
            <div class="container">

                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-5 d-lg-block">
                                <center><img src="../../Assets/Imagens/fgt.jpg" class="img-fluid" /></center>
                            </div>
                            <div class="col-lg-7 p-5">
                                <div class="row">
                                    <div class="container">
                                        <div class="col-12">
                                            <div class="text-left ml-3">
                                                <h1 class="h4 text-gray-900 mb-4 font-weight-bold">Olá, seja muito bem vindo!</h1>
                                                <p>Sua empresa te cadastrou na nossa plataforma, preencha os campos abaixo e acesse para ver como ela funciona.</p>
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div class="col-12 mb-2">
                                                <asp:TextBox ID="txtEmail" runat="server" type="email" placeholder="E-mail" CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="col-12 mb-2">
                                                <asp:TextBox ID="txtDataNascimento" runat="server" type="text" onfocus="(this.type='date')" onblur="(this.type='text')" placeholder="Data de nascimento" CssClass="form-control" required="required"></asp:TextBox>
                                            </div>

                                            <div class="col-12 mb-2">
                                                <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha" type="password" CssClass="form-control"  data-toggle="popover" title="Para sua segurança"  data-trigger="focus"  data-content="A senha de conter entre 6 e 12 caracteres, incluindo um número e um caracter especial."></asp:TextBox>
                                            </div>
                                            <div class="col-12 mb-2">
                                                <asp:TextBox ID="txtConfirmarSenha" runat="server" placeholder="Confirme sua senha" type="password" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-12">
                                            <div class="col-md-12">
                                                <asp:CheckBox ID="checkConcordo" runat="server" />
                                                <label>Li e concordo com os <a href="#">termos de uso</a></label>
                                            </div>
                                            <div class="col-md-12">
                                                <asp:CheckBox ID="checkNovidades" runat="server" />
                                                <label>Desejo receber novidades por e-mail</label>
                                            </div>
                                            <br />
                                            <div class="col-md-12">
                                                <asp:Button ID="btnSalvar" runat="server" Text="Salvar e acessar a plataforma" CssClass="btn btn-block btn-primary" OnClick="btnSalvar_Click" />
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
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
    </form>

    
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script><script src="../../Assets/Vendor/jquery/jquery.min.js"></script>
    <script src="../../Assets/Vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="../../Assets/Custom/Js/main.js"></script>
</body>
</html>
