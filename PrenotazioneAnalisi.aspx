<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrenotazioneAnalisi.aspx.cs" Inherits="PrenotazioneAnalisi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Analisi Prenotazioni</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Arial">
          <asp:Label runat="server" Text="ANALISI FATTURATO" Font-Bold="True" Font-Underline="True"></asp:Label><br /><br />
          <table border="1">
            <tr>
              <td><br />
                <asp:Label runat="server" Text="CERCA PER DATA" Font-Underline="True" ></asp:Label><br /><br />
                <asp:Label runat="server" Text="DATA ARRIVO: "></asp:Label>
                <asp:TextBox runat="server" ID="txtDataArrivo"></asp:TextBox>
                <asp:Label runat="server" Text="ORA ARRIVO: "></asp:Label>
                <asp:TextBox runat="server" ID="txtOraArrivo"></asp:TextBox>
                <asp:Label runat="server" Text="DATA USCITA: "></asp:Label>
                <asp:TextBox runat="server" ID="txtDataUscita"></asp:TextBox>
                <asp:Label runat="server" Text="ORA USCITA: "></asp:Label>
                <asp:TextBox runat="server" ID="txtOraUscita"></asp:TextBox>
                <asp:Button runat="server" ID="btnCercaRisultati" Text="CERCA RISULTATI" OnClick="btnCercaRisultati_Click" />
                <br /><br />
                <asp:Label runat="server" Text="Prenotazioni trovate: "></asp:Label>
                <asp:TextBox runat="server" ID="txtPrenotazioniTrovate" Enabled="false" Width="35px" ></asp:TextBox><br /><br />
                <asp:GridView runat="server" ID="gvPrenotazioneElenco"  CellPadding="4" ForeColor="#333333" GridLines="None">
									<AlternatingRowStyle BackColor="White"  />
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
								</asp:GridView><br />
            </td>
            </tr>
          </table><br />
          <asp:Button runat="server" ID="btnHome" Text="Home" Height="47px" Width="293px" Font-Bold="True" OnClick="btnHome_Click" />
        </div>
    </form>
</body>
</html>
