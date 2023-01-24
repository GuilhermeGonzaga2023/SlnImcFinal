<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="medicos.aspx.cs" Inherits="PrjMicroImc.pages.pro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" href="../css/estilo.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <header class="cabecalho">
            <nav>
                <asp:LinkButton ID="lbkIMC" runat="server" OnClick="lbkIMC_Click">Avaliação</asp:LinkButton>
                <asp:LinkButton ID="lbkMedico" runat="server" OnClick="lbkMedico_Click">Medicos</asp:LinkButton>
                <asp:LinkButton ID="lbkUsuario" runat="server" OnClick="lbkUsuario_Click">Usuarios</asp:LinkButton>
                <asp:LinkButton ID="lbkSair" runat="server" OnClick="lbkSair_Click">Sair</asp:LinkButton>
            </nav>
    </header>
        <div class="GRID">
            <div class="quadrado1">

            <h2>Médicos</h2>
                <asp:TextBox ID="txtPesquisarMedico" runat="server" placeholder="Pesquisar medicos"></asp:TextBox>
                <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" />

                <%--<div class="txtMedicos">--%>
                    <asp:TextBox ID="txtIdMedico" runat="server" placeholder="id do medico" Enabled="False" Visible="False"></asp:TextBox>
                <p>
                    <asp:Label ID="Label2" runat="server" Text="credencial: "></asp:Label>
                    <asp:TextBox ID="txtCredencial" runat="server" placeholder="credencial do medico"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label3" runat="server" Text="nome: "></asp:Label>
                    <asp:TextBox ID="txtNomeMedico" runat="server" placeholder="nome do Medico"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label4" runat="server" Text="login: "></asp:Label>
                    <asp:TextBox ID="txtLoginMedico" runat="server" placeholder="login"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label5" runat="server" Text="senha: "></asp:Label>
                    <asp:TextBox ID="txtSenhaMedico" runat="server" placeholder="senha"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label6" runat="server" Text="data de nascimento: "></asp:Label>
                    <asp:TextBox ID="txtDataNascimentoMedico" runat="server" placeholder="data de nascimento" TextMode="Date"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label7" runat="server" Text="telefone: "></asp:Label>
                    <asp:TextBox ID="txtTelefoneMedico" runat="server" placeholder="telefone"></asp:TextBox>
                </p>
                <%--/div>--%>

            <div class="btnMedico">
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
                <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" OnClick="btnAtuaizar_Click" />
                <asp:Button ID="btnInserir" runat="server" Text="Inserir" OnClick="btnInserir_Click" />
                <asp:Button ID="btnListar" runat="server" Text="listar" OnClick="btnListar_Click" />
            </div>

            <p>
                <asp:Label ID="msgErro" runat="server" Text=""></asp:Label>
            </p>
             </div>
            <div class="quadrado2" style="overflow-y:auto; height:200px">
                <h2>Selecione o médico aqui: </h2>
                <asp:GridView ID="GridMedicos" runat="server" AutoGenerateSelectButton="true" OnSelectedIndexChanged="GridMedicos_SelectedIndexChanged" BorderColor="#47793B" BorderStyle="Solid" BorderWidth="3px" CellPadding="5" CellSpacing="1" GridLines="None" EnableTheming="True">
                    <HeaderStyle BackColor="#47793B" />
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
