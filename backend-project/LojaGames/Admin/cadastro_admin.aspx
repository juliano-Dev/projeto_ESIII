<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastro_admin.aspx.cs" Inherits="LojaGames.cadastro_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="Styles/global.css">
    <title></title>
</head>
<body>
    <div>
        <%--Menu do administrador--%>
        <ul class="menu">
            <li><a href="./home.aspx">Início</a></li>
            <li><a href="#">Administradores</a></li>
            <li><a href="#">Olá, ADMINISTRADOR</a>
                <ul class="submenu">
                    <li><a href="perfil.aspx">Perfil</a></li>
                    <li><a href="../Default.aspx?sair=true">Sair</a></li>
                </ul>
            </li>
        </ul>
        <h1>Cadastrar administrador</h1>
        <form id="form1" runat="server">
            <div>
                <fieldset>
                    <%--Nome--%>
                    <asp:Label for="txbNome" runat="server">Nome:</asp:Label><br />
                    <asp:TextBox ID="txbNome" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbNome" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    <%--Data de nascimento--%>
                    <asp:Label for="txbDataNasc" runat="server">Data de nasc.:</asp:Label><br />
                    <asp:TextBox ID="txbDataNasc" type="date" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbDataNasc" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    <%--Email--%>
                    <asp:Label for="txbEmail" runat="server">E-mail:</asp:Label><br />
                    <asp:TextBox ID="txbEmail" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txbEmail" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    <%--CPF--%>
                    <asp:Label for="txbCpf" runat="server">CPF:</asp:Label><br />
                    <asp:TextBox ID="txbCpf" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txbCpf" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    <%--Telefone--%>
                    <asp:Label for="txbTelefone" runat="server">Telefone:</asp:Label><br />
                    <asp:TextBox ID="txbTelefone" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txbTelefone" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    <%--Login--%>
                    <asp:Label for="txbLogin" runat="server">Login:</asp:Label><br />
                    <asp:TextBox ID="txbLogin" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txbLogin" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    <%--Senha--%>
                    <asp:Label for="txbSenha" runat="server">Senha:</asp:Label><br />
                    <asp:TextBox ID="txbSenha" runat="server" TextMode="Password"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txbSenha" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator><br />
                    <%--Botão cadastrar--%>
                    <asp:Button Text="Cadastrar" OnClick="Btn_Cadastrar_Admin" runat="server" />
                </fieldset>
                <asp:LinkButton href="admins.aspx" runat="server">&larr; Voltar</asp:LinkButton>
            </div>
        </form>
    </div>
</body>
</html>
