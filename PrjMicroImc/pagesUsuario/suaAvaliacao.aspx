<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="suaAvaliacao.aspx.cs" Inherits="PrjMicroImc.pagesUsuario.suaAvaliacao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link rel="stylesheet" href="../css/estilo.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="AvaPaciente">
            <h2>Consulte sua avaliação: </h2>
            <p>        
                <asp:Label ID="Label1" runat="server" Text="Nome Do Paciente: "></asp:Label>
                <asp:TextBox ID="txtNomeUsu" runat="server" ReadOnly="True"></asp:TextBox>
            </p>

            <p>
                <asp:Label ID="Label2" runat="server" Text="Nome do Médico: "></asp:Label>
                <asp:TextBox ID="txtNomeMedico" runat="server" ReadOnly="True"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="Peso dò Paciente: "></asp:Label>
                <asp:TextBox ID="txtPeso" runat="server" ReadOnly="True"></asp:TextBox>
            </p>

            <p>
                <asp:Label ID="Label4" runat="server" Text="altura do Paciente: "></asp:Label>
                <asp:TextBox ID="txtAltura" runat="server" ReadOnly="True"></asp:TextBox>
            </p>

            <p>
                <asp:Label ID="Label5" runat="server" Text="dieta do paciente: "></asp:Label>
                <asp:TextBox ID="txtDieta" runat="server" ReadOnly="True"></asp:TextBox>
            </p>

            <p>
                <asp:Label ID="Label6" runat="server" Text="Restrições alimentares: "></asp:Label>
                <asp:TextBox ID="txtRestricoesDieta" runat="server" ReadOnly="True"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label7" runat="server" Text="Data da avaliação: "></asp:Label>
                <asp:TextBox ID="txtDataAva" runat="server" ReadOnly="True"></asp:TextBox>
            </p>
            
                <asp:Button ID="btnCalcular" runat="server" Text="Calcular Imc" OnClick="btnCalcular_Click" />
                <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            
            <p class="lblAva">
                <asp:Label ID="lblIMC" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
            </p>
            
            <asp:Label ID="msgErro" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
