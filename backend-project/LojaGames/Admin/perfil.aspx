<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="LojaGames.Admin.perfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
        <h1>Meu perfil</h1>
        <div>
            <form id="form1" runat="server">
                <asp:Panel ID="panel" runat="server">
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
                    <asp:UpdatePanel ID="updateUsuario" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gridUsuario" runat="server" AutoGenerateColumns="false" GridLines="None" AllowSorting="true" Width="100%" Font-Size="14px" OnRowEditing="gridUsuario_RowEditing" OnRowUpdating="gridUsuario_RowUpdating">
                                <Columns>
                                    <%--ID USUÁRIO--%>
                                    <asp:TemplateField HeaderText="ID" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="labelIdUsuario" runat="server" Text='<%#Eval("idUsuario") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--LOGIN--%>
                                    <asp:TemplateField HeaderText="Login" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelLogin" runat="server" Text='<%#Eval("login") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="labelLoginAnt" runat="server" Text='<%#Eval("login") %>' Visible="false"></asp:Label>
                                            <asp:TextBox ID="txbLogin" runat="server" Width="40%" Text='<%#Eval("login") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <%--SENHA--%>
                                    <asp:TemplateField HeaderText="Senha" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelSenha" type="password" runat="server" Text='<%#Eval("senha") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="labelSenhaAnt" type="password" runat="server" Text='<%#Eval("senha") %>' Visible="false"></asp:Label>
                                            <asp:TextBox ID="txbSenha" type="password" runat="server" Width="40%" Text='<%#Eval("senha") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <%--NOME--%>
                                    <asp:TemplateField HeaderText="Nome" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelNome" runat="server" Text='<%#Eval("nomeUsuario") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="labelNomeUsuarioAnt" runat="server" Text='<%#Eval("nomeUsuario") %>' Visible="false"></asp:Label>
                                            <asp:TextBox ID="txbNomeUsuario" runat="server" Width="40%" Text='<%#Eval("nomeUsuario") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <%--EMAIL--%>
                                    <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelEmail" runat="server" Text='<%#Eval("email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="labelEmailAnt" runat="server" Text='<%#Eval("email") %>' Visible="false"></asp:Label>
                                            <asp:TextBox ID="txbEmail" runat="server" Width="30%" Text='<%#Eval("email") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <%--TELEFONE--%>
                                    <asp:TemplateField HeaderText="Telefone" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="labelTelefone" runat="server" Text='<%#Eval("telefone") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="labelTelefoneAnt" runat="server" Text='<%#Eval("telefone") %>' Visible="false"></asp:Label>
                                            <asp:TextBox ID="txbTelefone" runat="server" Width="30%" Text='<%#Eval("telefone") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <%--EDITAR--%>
                                    <asp:TemplateField HeaderText="Editar" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="editar" Text="Editar" runat="server" CommandName="Edit"></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="update" Text="Ok" runat="server" CommandName="Update"></asp:LinkButton>
                                        </EditItemTemplate>
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
