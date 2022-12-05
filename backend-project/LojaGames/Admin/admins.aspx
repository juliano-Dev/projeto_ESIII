<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admins.aspx.cs" Inherits="LojaGames.Admin.admins" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
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
    <h1>Administradores</h1>
    <div>
        <form id="form1" runat="server">
            <asp:LinkButton href="cadastro_admin.aspx" runat="server">Cadastrar administrador</asp:LinkButton>
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
                <asp:UpdatePanel ID="updateAdmins" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gridAdmins" runat="server" AutoGenerateColumns="false" GridLines="None" AllowSorting="true" Width="100%" Font-Size="14px" OnRowEditing="gridAdmins_RowEditing" OnRowUpdating="gridAdmins_RowUpdating">
                            <Columns>
                                <%--ID USUÁRIO--%>
                                <asp:TemplateField HeaderText="ID" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="labelIdUsuario" runat="server" Text='<%#Eval("idUsuario") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--NOME USUÁRIO--%>
                                <asp:TemplateField HeaderText="Nome" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="20%">
                                    <ItemTemplate>
                                        <asp:Label ID="labelNomeUsuario" runat="server" Text='<%#Eval("nomeUsuario") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="labelNomeUsuarioAnt" runat="server" Text='<%#Eval("nomeUsuario") %>' Visible="false"></asp:Label>
                                        <asp:TextBox ID="txbNomeUsuario" runat="server" Width="40%" Text='<%#Eval("nomeUsuario") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <%--DATA NASCIMENTO--%>
                                <asp:TemplateField HeaderText="Data Nasc." ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label ID="labelDataNasc" runat="server" Text='<%#Eval("dataNascimento") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--EMAIL--%>
                                <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label ID="labelEmail" runat="server" Text='<%#Eval("email") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="labelEmailAnt" runat="server" Text='<%#Eval("email") %>' Visible="false"></asp:Label>
                                        <asp:TextBox ID="txbEmail" runat="server" Width="40%" Text='<%#Eval("email") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <%--CPF--%>
                                <asp:TemplateField HeaderText="CPF" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="labelCpf" runat="server" Text='<%#Eval("cpf") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--TELEFONE--%>
                                <asp:TemplateField HeaderText="Telefone" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label ID="labelTelefone" runat="server" Text='<%#Eval("telefone") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="labelTelefoneAnt" runat="server" Text='<%#Eval("telefone") %>' Visible="false"></asp:Label>
                                        <asp:TextBox ID="txbTelefone" runat="server" Width="40%" Text='<%#Eval("telefone") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <%--DATA CADASTRO--%>
                                <asp:TemplateField HeaderText="Data Cadastro" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label ID="labelDataCadastro" runat="server" Text='<%#Eval("dataCadastro") %>'></asp:Label>
                                    </ItemTemplate>
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
                                <%--EXCLUIR--%>
                                <asp:TemplateField HeaderText="Excluir" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="excluir" runat="server" Text="Excluir" NavigateUrl='<%# Eval("idUsuario", "admins.aspx?idUsuario={0}&acao=ExcluirAdministrador") %>' ToolTip="Excluir Adminsitrador" OnClick="if(confirm('Deseja excluir este administrador?')){ return true; } else { return false; }"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </form>
    </div>
</body>
</html>
