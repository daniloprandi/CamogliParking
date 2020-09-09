<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrenotazioneParcheggio.aspx.cs" Inherits="PrenotazioneParcheggio" EnableEventValidation="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div style="font-family: Arial">
			<asp:Label runat="server" ID="lblPrenotaParcheggio" Text="PRENOTA PARCHEGGIO" Font-Bold="True"
				Font-Underline="True"></asp:Label><br />
			<br />
			<asp:Label runat="server" id="lblErrori" ForeColor="Red" ></asp:Label>
			<br />
			<table border="1">
				<tr>
					<td>
						<br />
						<asp:Label runat="server" ID="lblVerificaDisponibilita" Text="VERIFICA DISPONIBILITA': " Font-Underline="True">
						</asp:Label><br />
						<br />
						<table runat="server" border="0" id="tblVerificaDisponibilita">
							<tr>
								<td>
									<asp:Label runat="server" ID="lblDataArrivo" Text="DATA ARRIVO: "></asp:Label>
									<asp:TextBox runat="server" ID="txtDataArrivo" placeholder="inserici data di arrivo..."></asp:TextBox>
									<asp:Label runat="server" ID="lblOraArrivo" Text="ORA ARRIVO: "></asp:Label>
									<asp:TextBox runat="server" ID="txtOraArrivo" placeholder="inserisci ora di arrivo..."></asp:TextBox>
									<asp:Label runat="server" ID="lblDataUscita" Text="DATA USCITA: "></asp:Label>
									<asp:TextBox runat="server" ID="txtDataUscita" placeholder="inserici data di uscita..."></asp:TextBox>
									<asp:Label runat="server" ID="lblOraUscita" Text="ORA USCITA: "></asp:Label>
									<asp:TextBox runat="server" ID="txtOraUscita" placeholder="inserisci ora di uscita..."></asp:TextBox>
									<asp:Button ID="btnVerificaDisponibilita" runat="server" Text="VERIFICA DISPONIBILITA'"
										OnClick="btnVerificaDisponibilita_Click" />
								</td>
							</tr>
						</table>
						<table border="0">
							<tr>
								<td colspan="2">
									<asp:Button runat="server" ID="btnProcediConPrenotazione" OnClick="btnProcediConPrenotazione_Click" 
										Text="PROCEDI CON PRENOTAZIONE" Height="54px" Width="358px" Enabled="false" />
									<asp:Label runat="server" ID="lblEsitoRicerca" Font-Bold="True"></asp:Label>
									<br />
									<table id="tblPrenotazione" runat="server" visible="false">
										<tr>
											<td>
												<asp:Label runat="server" ID="lblDataArrivoPrenotazione" Text="DATA ARRIVO: "></asp:Label>
												<asp:TextBox runat="server" ID="txtDataArrivoPrenotazione" Enabled="false"></asp:TextBox>
												<asp:Label runat="server" ID="lblOraArrivoPrenotazione" Text="ORA ARRIVO: "></asp:Label>
												<asp:TextBox runat="server" ID="txtOraArrivoPrenotazione" Enabled="false"></asp:TextBox>
												<asp:Label runat="server" ID="lblDataUscitaPrenotazione" Text="DATA USCITA: "></asp:Label>
												<asp:TextBox runat="server" ID="txtDataUscitaPrenotazione" Enabled="false"></asp:TextBox>
												<asp:Label runat="server" ID="lblOraUscitaPrenotazione" Text="ORA USCITA: "></asp:Label>
												<asp:TextBox runat="server" ID="txtOraUscitaPrenotazione" Enabled="false"></asp:TextBox><br /><br />
												<asp:Label runat="server" ID="lblNominativoPrenotazione" Text="NOMINATIVO: "></asp:Label>
												<asp:TextBox runat="server" ID="txtNominativoPrenotazione"></asp:TextBox>
												<asp:Label runat="server" ID="lblRecapitoPrenotazione" Text="RECAPITO"></asp:Label>
												<asp:TextBox runat="server" ID="txtRecapitoPrenotazione"></asp:TextBox><br /><br />
												<asp:Label runat="server" ID="lblInfoPrenotazione" Text="INFORMAZIONI AGGIUNTIVE: "></asp:Label><br />
												<asp:TextBox runat="server" ID="txtInfoPrenotazione" Height="175px" Width="385px"></asp:TextBox><br />
												<br />
												<asp:Button runat="server" ID="btnConfermaPrenotazione" BackColor="#00FF99" Font-Bold="True" Height="55px"
													OnClick="btnConfermaPrenotazione_Click" Text="CONFERMA PRENOTAZIONE" Width="325px" />
												<asp:Button runat="server" Height="55px" Width="325px" ID="brnAnnulla" BackColor="#FF0066" OnClick="brnAnnulla_Click" Text="Annulla" />
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<br />
			<br />
			<asp:Button runat="server" ID="btnHome" Text="Home" BackColor="#CCCCCC" Font-Bold="True" Height="42px" OnClick="btnHome_Click" Width="193px" />
		</div>
	</form>
</body>
</html>
