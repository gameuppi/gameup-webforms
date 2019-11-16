<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompletarCadastro.aspx.cs" Inherits="Pages_Visitante_AssinaturaDePacote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>GameUP - Plataforma de Gamificação Empresarial</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <!-- Fontes do template -->
    <link href="../../Assets/Vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link href="../../Assets/Vendor/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

    <!-- Estilos customizados do template -->
    <link href="../../Assets/Custom/Css/sb-admin-2.min.css" rel="stylesheet">
    <link href="../../Assets/Custom/Css/main.css" rel="stylesheet">
</head>
<body class="bg-gradient-info">
    <form id="form1" runat="server">
        <div>
            <div class="container">

                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-5 d-lg-block bg-register-image">
                            </div>
                            <div class="col-lg-7">
                                <div class="p-5">
                                    <div class="text-left ml-3">
                                        <h1 class="h4 text-gray-900 mb-4 font-weight-bold">Completar Cadastro</h1>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-12 mb-3 mb-sm-0 col-md-12">
                                            <asp:TextBox ID="txtEmail" runat="server" type="email" placeholder="Digite seu E-mail" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12 col-sm-12 form-group">
                                        <asp:TextBox ID="txtDataNascimento" runat="server" type="date" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-md-5 col-sm-12 ml-4">
                                            <asp:TextBox ID="txtSenha" runat="server" placeholder="Digite sua Senha" type="password" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6 col-sm-12">
                                            <asp:TextBox ID="txtConfirmarSenha" runat="server" placeholder="Digite sua Senha Novamente" type="password" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:CheckBox ID="checkConcordo" runat="server" required="required"/>
                                        <label> Li e concordo com os termos de uso</label>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:CheckBox ID="checkNovidades" runat="server" />
                                        <label>Desejo receber novidades por e-mail</label>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:Button ID="btnSalvar" runat="server" Text="Salvar e acessar a plataforma" CssClass="btn btn-block btn-info" OnClick="btnSalvar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>

    <!-- Bootstrap -->
    <script src="../../Assets/Vendor/jquery/jquery.min.js"></script>
    <script src="../../Assets/Vendor/bootstrap/js/bootstrap.min.js"></script>

    <!-- JavaScript -->
    <script src="../../Assets/Vendor/jquery-easing/jquery.easing.min.js"></script>
    <script src="../../Assets/Custom/Js/main.js"></script>

    <!-- Scripts customizados do template -->
    <script src="../../Assets/Custom/Js/sb-admin-2.min.js"></script>

    <!-- Plugins da página e gráficos -->
    <script src="../../Assets/Vendor/chart.js/Chart.min.js"></script>
</body>
</html>
