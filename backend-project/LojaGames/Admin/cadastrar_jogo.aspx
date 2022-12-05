<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastrar_jogo.aspx.cs" Inherits="LojaGames.Admin.cadastrar_jogo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
    </div>
    <h1>Cadastrar jogo</h1>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <%--Nome do jogo--%>
                <asp:Label for="txbNomeJogo" runat="server">Título:</asp:Label><br />
                <asp:TextBox ID="txbNomeJogo" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbNomeJogo" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator><br />
                <%--Gênero--%>
                <asp:Label for="txbGenero" runat="server">Gênero:</asp:Label><br />
                <asp:TextBox ID="txbGenero" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbGenero" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator><br />
                <%--Plataforma--%>
                <asp:Label for="txbPlataforma" runat="server">Plataforma:</asp:Label><br />
                <asp:TextBox ID="txbPlataforma" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txbPlataforma" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator><br />
                <%--Preço--%>
                <asp:Label for="txbPreco" runat="server">Preço:</asp:Label><br />
                <asp:TextBox ID="txbPreco" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txbPreco" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator><br />
                <%--Data de lancamento--%>
                <asp:Label for="txbDataLanc" runat="server">Data de lanç.:</asp:Label><br />
                <asp:TextBox ID="txbDataLanc" type="date" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txbDataLanc" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator><br />
                <asp:Button Text="Cadastrar" OnClick="Btn_Cadastrar_Jogo" runat="server" />
            </fieldset>
        </div>
    </form>
</body>
</html>
