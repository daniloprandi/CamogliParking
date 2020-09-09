<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrenotazioneElenco.aspx.cs" Inherits="PrenotazioneElenco" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div style="font-family: Arial">
			<asp:Label ID="lblElencoPrenotazioni" runat="server" Text="ELENCO PRENOTAZIONI: " Font-Bold="True"
				Font-Underline="True"></asp:Label><br /><br />
			<asp:Label runat="server" Text="DATI CARICATI DALLA CACHE "></asp:Label>
			<asp:CheckBox runat="server" ID="ckbCache" Enabled="false" />
			<asp:Button runat="server" ID="btnPulisciCache" Text="ELIMINA CACHE" OnClick="btnPulisciCache_Click" />
			<asp:Label runat="server" ID="lblCache"></asp:Label> <br /><br />
			<asp:Label runat="server" ID="lblTotalePrenotazioni" Text="Totale prenotazioni: "></asp:Label>
			<asp:TextBox runat="server" ID="txtTotalePrenotazioni" Enabled="false" Width="15px"></asp:TextBox>
			<br />
			<br />
			<table border="1">
				<tr>
					<td>
						<br />
						<asp:Label runat="server" ID="lblFiltraPrenotazioni" Text="Filtra Prenotazioni" Font-Underline="True"></asp:Label><br />
						<br />
						<asp:Label runat="server" Text="DATA DI ARRIVO: "></asp:Label>
						<asp:TextBox runat="server" ID="txtDataArrivo" placeholder="formato: gg/mm/aaaa"></asp:TextBox>
						<asp:Label runat="server" Text="DATA DI USCITA: "></asp:Label>
						<asp:TextBox runat="server" ID="txtDataUscita" placeholder="formato: gg/mm/aaaa"></asp:TextBox>
						<asp:Label runat="server" Text="NOMINATIVO: "></asp:Label>
						<asp:TextBox runat="server" ID="txtCercaNominativo" placeholder="inserisci nominativo ..." Width="286px"></asp:TextBox>
						<asp:Button runat="server" ID="btnCercaRisultati" Text="CERCA RISULTATI" OnClick="btnCercaRisultati_Click" /><br />
						<br />
					</td>
				</tr>
			</table>
			<br />
			<br />
			<asp:GridView ID="gvPrenotazioneElenco" runat="server" AutoGenerateColumns="false" CellPadding="4"
				ForeColor="#333333" GridLines="None">
				<AlternatingRowStyle BackColor="White" />
				<Columns>
					<asp:BoundField DataField="id_Prenotazioni" HeaderText="CODICE PRENOTAZIONE" />
					<asp:BoundField DataField="data_entrata_Prenotazioni" HeaderText="DATA ENTRATA" />
					<asp:BoundField DataField="ora_entrata_Prenotazioni" HeaderText="ORA ENTRATA" />
					<asp:BoundField DataField="data_uscita_Prenotazioni" HeaderText="DATA USCITA" />
					<asp:BoundField DataField="ora_uscita_Prenotazioni" HeaderText="ORA USCITA" />
					<asp:BoundField DataField="nominativo_Prenotazioni" HeaderText="NOMINATIVO" />
					<asp:BoundField DataField="recapito_Prenotazioni" HeaderText="CELLULARE" />
					<asp:BoundField DataField="info_Prenotazioni" HeaderText="INFO PRENOTAZIONI" />
					<asp:TemplateField>
						<ItemTemplate>
							<asp:Button
								runat="server"
								ID="btnModifica"
								Text="MODIFICA"
								OnClick="btnModifica_Click"
								CommandArgument='<%#Eval("id_Prenotazioni") %>' />
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
				<EditRowStyle BackColor="#2461BF" />
				<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
				<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
				<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
				<RowStyle BackColor="#EFF3FB" />
				<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
				<SortedAscendingCellStyle BackColor="#F5F7FB" />
				<SortedAscendingHeaderStyle BackColor="#6D95E1" />
				<SortedDescendingCellStyle BackColor="#E9EBEF" />
				<SortedDescendingHeaderStyle BackColor="#4870BE" />
			</asp:GridView>
			<br />
			<table border="0">
				<tr>
					<td colspan="3">
						<asp:Button runat="server" ID="btnHome" Text="Home" Height="47px" Width="293px" Font-Bold="True" OnClick="btnHome_Click" />
						<asp:Button ID="btnPrenotazioneElenco" runat="server" Height="47px" Text="TUTTE LE PRENOTAZIONI" Width="293px"
							BackColor="#00FF99" Font-Bold="True" OnClick="btnPrenotazioneElenco_Click" />
						<asp:Button ID="btnNuovaPrenotazione" runat="server" Height="47px" Text="NUOVA PRENOTAZIONE" Width="293px"
							BackColor="#00FF99" Font-Bold="True" OnClick="btnNuovaPrenotazione_Click" />
					</td>
				</tr>
			</table>
			<br />
		</div>
	</form>
</body>
</html>
