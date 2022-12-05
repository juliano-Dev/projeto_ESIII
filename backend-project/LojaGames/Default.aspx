<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LojaGames._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <link rel="stylesheet" href="Styles/global.css">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <fieldset>
                    <asp:Label runat="server">Login</asp:Label>
                    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                    <asp:Label runat="server">Senha</asp:Label>
                    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:Button runat="server" Text="Entrar" OnClick="Btn_Entrar" />
                    <asp:LinkButton href="cadastro_cliente.aspx" runat="server">Cadastrar-se</asp:LinkButton>
                </fieldset>
            </div>
        </form>
    </body>

</asp:Content>
