<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<style type="text/css">
		.auto-style1 {
			margin-top: 0px;
		}
  </style>
</head>
<body>
	<form id="form1" runat="server">
		<div style="font-family: Arial">
			<asp:Label runat="server" ID="lblIndex" Text="BENVENUTI NELL'AREA PARCHEGGIO DI CAMOGLI" Font-Bold="True"
				Font-Underline="True"></asp:Label><br />
			<br />
			<%--<asp:Image ID="Image1" runat="server" ImageUrl="https://www.google.com/search?q=parcheggio&rlz=1C1CHBF_itIT902IT902&source=lnms&tbm=isch&sa=X&ved=2ahUKEwjjl6Khxp3rAhXNyqQKHYh_DywQ_AUoAnoECA0QBA&biw=1536&bih=630#imgrc=CtsH5UmjDyhKtM"
            width="300px" Height="300px"/><br /><br />--%>
			<table border="0">
				<tr>
					<td colspan="5">
						<img runat="server" src="image.jpg" align="center" />
						<asp:Label runat="server" Text="I nostri prezzi:" Font-Underline="True"></asp:Label>
						<asp:Label runat="server" Text="Tariffa oraria: EUR 2.50 || " ForeColor="#00CC66"></asp:Label>
						<asp:Label runat="server" Text="Tariffa giornaliera: EUR 45.00 || "></asp:Label>
						<asp:Label runat="server" Text="Tariffa settimanale: EUR 300.00" ForeColor="#6600FF"></asp:Label>
					</td>
				</tr>
			</table>
			<br /><br />
			<table border="0">
				<tr>
					<td colspan="3">
						<asp:Button runat="server" ID="btnCercaIlTuoParcheggio" OnClick="btnCercaIlTuoParcheggio_Click"
							Text="CERCA IL TUO PARCHEGGIO" Font-Bold="True" Height="66px" Width="344px" BackColor="#6666FF" ForeColor="White" />
						<asp:Button runat="server" ID="btnVaiPrenotazioniElenco" Text="VAI A ELENCO PRENOTAZIONI" 
							OnClick="btnVaiPrenotazioniElenco_Click" Font-Bold="True" Height="66px" Width="344px" BackColor="#6666FF" ForeColor="White" />
						<asp:Button runat="server" ID="btnAnalisiPrenotazioni" Text="ANALISI PRENOTAZIONI" Height="66px" Width="344px" BackColor="#00FF99" Font-Bold="True" OnClick="btnAnalisiPrenotazioni_Click" />
					</td>
				</tr>
			</table>
		</div>
	</form>
</body>
</html>
