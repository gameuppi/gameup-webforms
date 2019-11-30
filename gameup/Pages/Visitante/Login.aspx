<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Visitante_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../Assets/Vendor/bootstrap/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row mt-5 pt-5">
            <div class="col-4 offset-4 border border-dark">
                <div class="text-center">
                    <h3>Login</h3>
                </div>
                <hr />
                <label>E-mail:</label>
                <asp:TextBox runat="server" ID="txtEmail" type="email" required="required" CssClass="form-control"></asp:TextBox>
                <br />
                <label>Senha:</label>
                <asp:TextBox runat="server" ID="txtSenha" type="password" required="required" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Button runat="server" ID="btnLogin" Text="Entrar" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click" />
                <br />
                <asp:Literal runat="server" ID="ltlMsg"></asp:Literal>
            </div>
        </div>
    </form>
    <script src="../../Assets/Vendor/jquery/jquery.min.js"></script>
    <script src="../../Assets/Vendor/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
