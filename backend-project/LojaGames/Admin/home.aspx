<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="LojaGames.Admin.home" %>

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
            <li><a href="./admins.aspx">Administradores</a></li>
            <li><a href="#">Olá, ADMINISTRADOR</a>
                <ul class="submenu">
                    <li><a href="perfil.aspx">Perfil</a></li>
                    <li><a href="../Default.aspx?sair=true">Sair</a></li>
                </ul>
            </li>
        </ul>
        <h1>Jogos</h1>
        <div>
            <form id="form1" runat="server">
                <asp:LinkButton href="cadastrar_jogo.aspx" runat="server">Cadastrar jogo</asp:LinkButton>
                <asp:Panel ID="panelJogos" runat="server">
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
                    <asp:UpdatePanel ID="updateJogos" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gridJogos" runat="server" AutoGenerateColumns="false" GridLines="None" AllowSorting="true" Width="100%" Font-Size="14px" OnRowEditing="gridJogos_RowEditing" OnRowUpdating="gridJogos_RowUpdating">
                                <Columns>
                                    <%--ID JOGO--%>
                                    <asp:TemplateField HeaderText="ID" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelIdJogo" runat="server" Text='<%#Eval("idJogo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--NOME JOGO--%>
                                    <asp:TemplateField HeaderText="Nome do Jogo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelNomeJogo" runat="server" Text='<%#Eval("nomeJogo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="labelNomeJogoAnt" runat="server" Text='<%#Eval("nomeJogo") %>' Visible="false"></asp:Label>
                                            <asp:TextBox ID="txbNomeJogo" runat="server" Width="40%" Text='<%#Eval("nomeJogo") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <%--GENERO--%>
                                    <asp:TemplateField HeaderText="Gênero" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelGenero" runat="server" Text='<%#Eval("genero") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="labelGeneroAnt" runat="server" Text='<%#Eval("genero") %>' Visible="false"></asp:Label>
                                            <asp:TextBox ID="txbGenero" runat="server" Width="40%" Text='<%#Eval("genero") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <%--PLATAFORMA--%>
                                    <asp:TemplateField HeaderText="Plataforma" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelPlataforma" runat="server" Text='<%#Eval("plataforma") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="labelPlataformaAnt" runat="server" Text='<%#Eval("plataforma") %>' Visible="false"></asp:Label>
                                            <asp:TextBox ID="txbPlataforma" runat="server" Width="30%" Text='<%#Eval("plataforma") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <%--PRECO--%>
                                    <asp:TemplateField HeaderText="Preço R$" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelPreco" runat="server" Text='<%#Eval("preco") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="labelPrecoAnt" runat="server" Text='<%#Eval("preco") %>' Visible="false"></asp:Label>
                                            <asp:TextBox ID="txbPreco" runat="server" Width="20%" Text='<%#Eval("preco") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <%--DATA DE LANÇAMENTO--%>
                                    <asp:TemplateField HeaderText="Data de Lanc." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelDataLanc" runat="server" Text='<%#Eval("dataLancamento") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--EDITAR--%>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="editar" Text="Editar" runat="server" CommandName="Edit"></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="update" Text="Ok" runat="server" CommandName="Update"></asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <%--EXCLUIR--%>
                                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="excluir" runat="server" Text="Excluir" NavigateUrl='<%# Eval("idJogo", "home.aspx?idJogo={0}&acao=ExcluirJogo") %>' ToolTip="Excluir Jogo" OnClick="if(confirm('Deseja excluir este jogo?')){ return true; } else { return false; }"></asp:HyperLink>
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
