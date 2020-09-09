using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class PrenotazioneElenco : System.Web.UI.Page
{
  string connString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      if (Cache["ElencoPrenotazioni"] == null)
      {
        using (SqlConnection conn = new SqlConnection(connString))
        {
          conn.Open();
          using (SqlCommand cmd = new SqlCommand("select count(id_Prenotazioni) from Prenotazioni", conn))
          {
            txtTotalePrenotazioni.Text = cmd.ExecuteScalar().ToString();
          }
          SqlDataAdapter da = new SqlDataAdapter("select * from Prenotazioni order by data_entrata_Prenotazioni, " +
            "ora_entrata_Prenotazioni, data_uscita_prenotazioni, ora_uscita_Prenotazioni", conn);
          DataSet ds = new DataSet();
          da.Fill(ds);
          //Cache["ElencoPrenotazioni"] = ds;
          Cache.Insert("ElencoPrenotazioni", ds, null, DateTime.Now.AddMinutes(15),
            System.Web.Caching.Cache.NoSlidingExpiration);
          gvPrenotazioneElenco.DataSource = ds;
          gvPrenotazioneElenco.DataBind();
          ckbCache.Checked = false;
          lblCache.Text = "";
          using (SqlCommand cmd = new SqlCommand("select count(*) from Prenotazioni", conn))
          {
            txtTotalePrenotazioni.Text = cmd.ExecuteScalar().ToString();
          }
        }
      }
      else
      {
        gvPrenotazioneElenco.DataSource = (DataSet)Cache["ElencoPrenotazioni"];
        gvPrenotazioneElenco.DataBind();
        ckbCache.Checked = true;
      }
    }
  }

  protected void btnModifica_Click(object sender, EventArgs e)
  {
    string idPrenotazioni = ((Button)sender).CommandArgument.ToString();
    Response.Redirect("PrenotazioneParcheggio.aspx?id_Prenotazioni=" + idPrenotazioni);
  }

  protected void btnNuovaPrenotazione_Click(object sender, EventArgs e)
  {
    Response.Redirect("PrenotazioneParcheggio.aspx");
  }

  protected void btnCercaRisultati_Click(object sender, EventArgs e)
  {
    using (SqlConnection conn = new SqlConnection(connString))
    {
      conn.Open();
      using (SqlCommand cmd = new SqlCommand("select * from Prenotazioni where " +
        "data_entrata_Prenotazioni like @data_entrata and data_uscita_Prenotazioni like @data_uscita " +
        "and nominativo_Prenotazioni like @nominativo", conn))
      {
        cmd.Parameters.Add("@data_entrata", SqlDbType.DateTime).Value = DateTime.Parse(txtDataArrivo.Text);
        cmd.Parameters.Add("@data_uscita", SqlDbType.DateTime).Value = DateTime.Parse(txtDataUscita.Text);
        cmd.Parameters.Add("@nominativo", SqlDbType.NVarChar, 255).Value = txtCercaNominativo.Text + "%";
        //cmd.Parameters.AddWithValue("@data_entrata", DateTime.Parse(txtDataArrivo.Text));
        //cmd.Parameters.AddWithValue("@data_uscita", DateTime.Parse(txtDataUscita.Text));
        //cmd.Parameters.AddWithValue("@nominativo", txtCercaNominativo.Text + "%");
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
          gvPrenotazioneElenco.DataSource = dr;
          gvPrenotazioneElenco.DataBind();
          lblTotalePrenotazioni.Text = "Prenotazioni trovate: ";
        }
      }
      using (SqlCommand cmd = new SqlCommand("select COUNT(*) from Prenotazioni where data_entrata_Prenotazioni " +
        "like @data_entrata and data_uscita_Prenotazioni like @data_uscita and nominativo_Prenotazioni " +
        "like @nominativo", conn))
      {
        cmd.Parameters.Add("@data_entrata", SqlDbType.DateTime).Value = DateTime.Parse(txtDataArrivo.Text);
        cmd.Parameters.Add("@data_uscita", SqlDbType.DateTime).Value = DateTime.Parse(txtDataUscita.Text);
        cmd.Parameters.Add("@nominativo", SqlDbType.NVarChar, 255).Value = txtCercaNominativo.Text + "%";
        //cmd.Parameters.AddWithValue("@data_entrata", DateTime.Parse(txtDataArrivo.Text));
        //cmd.Parameters.AddWithValue("@data_uscita", DateTime.Parse(txtDataUscita.Text));
        //cmd.Parameters.AddWithValue("@nominativo", txtCercaNominativo.Text + "%");
        txtTotalePrenotazioni.Text = cmd.ExecuteScalar().ToString();
      }
    }
  }

  protected void btnPrenotazioneElenco_Click(object sender, EventArgs e)
  {
    Response.Redirect("PrenotazioneElenco.aspx");
  }

  protected void btnPulisciCache_Click(object sender, EventArgs e)
  {
    if (Cache["ElencoPrenotazioni"] != null)
    {
      Cache.Remove("ElencoPrenotazioni");
      lblCache.Text = "Dati rimossi dalla cache con successo";
      lblCache.ForeColor = System.Drawing.Color.Red;
      ckbCache.Checked = false;
    }
    else
    {
      lblCache.Text = "Non ci sono dati da rimuovere nella cache";
      lblCache.ForeColor = System.Drawing.Color.Red;
      ckbCache.Checked = false;
    }
  }

  protected void btnHome_Click(object sender, EventArgs e)
  {
    Response.Redirect("Index.aspx");
  }
}