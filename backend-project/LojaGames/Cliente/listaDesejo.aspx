<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listaDesejo.aspx.cs" Inherits="LojaGames.Cliente.listaDesejo" %>

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
                    <li><a href="carteira.aspx">Adicionar fundos</a></li>
                </ul>
            </li>
            <li><a href="#">Olá, CLIENTE</a>
                <ul class="submenu">
                    <li><a href="perfil.aspx">Perfil</a></li>
                    <li><a href="../Default.aspx?sair=true">Sair</a></li>
                </ul>
            </li>
        </ul>
        <h1>Lista de desejos</h1>
        <div>
            <form id="form1" runat="server">
                <asp:Panel ID="panelListaDesejos" runat="server">
                    <asp:ScriptManager runat="server">
                        <Scripts>
                            <asp:ScriptReference Name="MsAjaxBundle" />
                            <asp:ScriptReference Name="jquery" />
                            <asp:ScriptReference Name="bootstrap" />
                            <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                            <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                            <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                            <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                            <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                            <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                            <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                            <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                            <asp:ScriptReference Name="WebFormsBundle" />
                        </Scripts>
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="updateListaDesejos" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gridListaDesejos" runat="server" AutoGenerateColumns="false" GridLines="None" AllowSorting="true" Width="100%" Font-Size="14px">
                                <Columns>
                                    <%--ID JOGO--%>
                                    <asp:TemplateField HeaderText="ID" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="labelIdJogo" runat="server" Text='<%#Eval("idJogo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--NOME JOGO--%>
                                    <asp:TemplateField HeaderText="Nome do Jogo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="40%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelNomeJogo" runat="server" Text='<%#Eval("nomeJogo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--GENERO--%>
                                    <asp:TemplateField HeaderText="Gênero" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelGenero" runat="server" Text='<%#Eval("genero") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--PLATAFORMA--%>
                                    <asp:TemplateField HeaderText="Plataforma" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelPlataforma" runat="server" Text='<%#Eval("plataforma") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--DATA DE LANÇAMENTO--%>
                                    <asp:TemplateField HeaderText="Data de Lanc." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelDataLanc" runat="server" Text='<%#Eval("dataLancamento") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--REMOVER JOGO LISTA DESEJO--%>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="remover" runat="server" Text="Remover" NavigateUrl='<%# Eval("idJogo", "listaDesejo.aspx?idJogo={0}&acao=RemoverJogo") %>' ToolTip="Remover Jogo" OnClick="if(confirm('Deseja remover este jogo da sua lista de desejos?')){ return true; } else { return false; }"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </form>
        </div>
    </div>
</body>
</html>
