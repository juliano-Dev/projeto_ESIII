<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carteira.aspx.cs" Inherits="LojaGames.Cliente.carteira" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div>
        <%--Menu do cliente--%>
        <ul class="menu">
            <li><a href="home.aspx">Loja</a></li>
            <li><a href="biblioteca.aspx">Biblioteca</a></li>
            <li><a href="listaDesejo.aspx">Lista de desejos</a></li>
            <li><a href="#">Seu saldo</a>
                <ul class="submenu">
                    <li><a href="#">Adicionar fundos</a></li>
                </ul>
            </li>
            <li><a href="#">Olá, CLIENTE<?php echo $login ?></a>
                <ul class="submenu">
                    <li><a href="perfil.aspx">Perfil</a></li>
                    <li><a href="../Default.aspx?sair=true">Sair</a></li>
                </ul>
            </li>
        </ul>
        <h1>Minha carteira</h1>
        <form id="form1" runat="server">
            <asp:Label for="txbSaldo" runat="server">Saldo atual:</asp:Label><br />
            <asp:TextBox ID="txbSaldo" runat="server"></asp:TextBox><br />
            <asp:Label for="txbAdcFundos" runat="server">Adicionar fundos:</asp:Label><br />
            <asp:TextBox ID="txbAdcFundos" runat="server" placeholder="Insira um valor"></asp:TextBox>
            <asp:Button Text="Pagar" OnClick="Btn_Pagar" runat="server"/>
        </form>
    </div>
</body>
</html>
