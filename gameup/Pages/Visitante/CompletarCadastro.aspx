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
                                    <div class="text-left">
                                        <h1 class="h4 text-gray-900 mb-4 font-weight-bold">Completar Cadastro</h1>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-6 mb-3 mb-sm-0">
                                            <input type="text" class="form-control form-control-user" id="exampleFirstName" placeholder="Nome">
                                        </div>
                                        <div class="col-sm-6">
                                            <input type="text" class="form-control form-control-user" id="exampleLastName" placeholder="Sobrenome">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <input type="email" class="form-control form-control-user" id="exampleInputEmail" placeholder="Nome de usuário">
                                    </div>
                                    <div class="form-group">
                                        <input type="date" class="form-control form-control-user" id="exampleInputEmail" placeholder="Data de nascimento">
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-6 mb-3 mb-sm-0">
                                            <input type="password" class="form-control form-control-user" id="exampleInputPassword" placeholder="Senha">
                                        </div>
                                        <div class="col-sm-6">
                                            <input type="password" class="form-control form-control-user" id="exampleRepeatPassword" placeholder="Confirmar Senha">
                                        </div>
                                    </div>
                                    <div class="custom-control custom-checkbox my-1 mr-sm-2">
                                        <input type="checkbox" class="custom-control-input" id="customControlInline">
                                        <label class="custom-control-label" for="customControlInline">Li e concordo com os termos de uso</label>
                                    </div>
                                    <div class="custom-control custom-checkbox my-1 mr-sm-2">
                                        <input type="checkbox" class="custom-control-input" id="customControlInline2">
                                        <label class="custom-control-label">Desejo receber novidades por e-mail</label>
                                    </div>
                                    <a href="#" class="btn btn-info mt-4 btn-user btn-block">Salvar e acessar a plataforma
                                    </a>
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
