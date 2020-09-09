using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

  }

  protected void btnCercaIlTuoParcheggio_Click(object sender, EventArgs e)
  {
    Response.Redirect("PrenotazioneParcheggio.aspx");
  }

  protected void btnVaiPrenotazioniElenco_Click(object sender, EventArgs e)
  {
    Response.Redirect("PrenotazioneElenco.aspx");
  }

  protected void btnAnalisiPrenotazioni_Click(object sender, EventArgs e)
  {
    Response.Redirect("PrenotazioneAnalisi.aspx");
  }
}