<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Visitante_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Assets/Vendor/bootstrap/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row mt-5 pt-5">
            <div class="col-4 offset-4 border border-dark">
                <div class="text-center">
                    <h3>Cadastre a Senha</h3>
                </div>
                <div class="col-md-6">
                    <label>Senha:</label>
                    <asp:TextBox runat="server" ID="txtSenha" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label>Confirmar Senha:</label>
                    <asp:TextBox runat="server" ID="txtConfirmarSenha" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-12">
                    <asp:Button runat="server" ID="btnSalvar" Text="Salvar" CssClass="btn btn-block btn-primary" OnClick="Salvar_Click"/>
                </div>
            </div>
        </div>
    </form>
    <script src="../../Assets/Vendor/jquery/jquery.min.js"></script>
    <script src="../../Assets/Vendor/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
