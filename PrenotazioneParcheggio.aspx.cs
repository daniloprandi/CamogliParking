using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class PrenotazioneParcheggio : System.Web.UI.Page
{
  string connString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      using (SqlConnection conn = new SqlConnection(connString))
      {
        conn.Open();
        if (Request.QueryString["id_Prenotazioni"] != null)
        {
          btnProcediConPrenotazione.Text = "PROCEDI CON LA MODIFICA DELLA PRENOTAZIONE";
          lblVerificaDisponibilita.Text = "MODIFICA PRENOTAZIONE";
          btnConfermaPrenotazione.Text = "MODIFICA PRENOTAZIONE";
          int id = -1;
          if (Int32.TryParse(Request.QueryString["id_Prenotazioni"].ToString(), out id))
          {
            using (SqlCommand cmd = new SqlCommand("select * from Prenotazioni where id_Prenotazioni = @id", conn))
            {
              cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
              using (SqlDataReader dr = cmd.ExecuteReader())
              {
                if (dr.HasRows)
                {
                  dr.Read();
                  Convert.ToDateTime(txtDataArrivo.Text = dr["data_entrata_Prenotazioni"].ToString());
                  TimeSpan.Parse(txtOraArrivo.Text = dr["ora_entrata_Prenotazioni"].ToString());
                  Convert.ToDateTime(txtDataUscita.Text = dr["data_uscita_Prenotazioni"].ToString());
                  TimeSpan.Parse(txtOraUscita.Text = dr["ora_uscita_Prenotazioni"].ToString());
                  txtNominativoPrenotazione.Text = dr["nominativo_Prenotazioni"].ToString();
                  txtRecapitoPrenotazione.Text = dr["recapito_Prenotazioni"].ToString();
                  txtInfoPrenotazione.Text = dr["info_Prenotazioni"].ToString();
                }
              }
            }
          }
        }
      }
    }
  }

  protected void btnVerificaDisponibilita_Click(object sender, EventArgs e)
  {
    lblErrori.Text = "";
    if (txtDataArrivo.Text == "")
    {
      if (lblErrori.Text == "")
        lblErrori.Text = "<br>La DATA DI ARRIVO e' obbligatoria<br>";
      else
        lblErrori.Text = lblErrori.Text += "<br>La DATA DI ARRIVO e' obbligatoria<br>";
    }
    if (txtOraArrivo.Text == "")
    {
      if (lblErrori.Text == "")
        lblErrori.Text = "<br>L'ORARIO DI ARRIVO e' obbligatorio<br>";
      else
        lblErrori.Text = lblErrori.Text += "<br>L'ORARIO DI ARRIVO e' obbligatorio<br>"; ;
    }
    if (txtDataUscita.Text == "")
    {
      if (lblErrori.Text == "")
        lblErrori.Text = "<br>La DATA DI USCITA e' obbligatoria<br>";
      else
        lblErrori.Text = lblErrori.Text += "<br>La DATA DI USCITA e' obbligatoria<br>";
    }
    if (txtOraUscita.Text == "")
    {
      if (lblErrori.Text == "")
        lblErrori.Text = "<br>L'ORARIO DI USCITA e' obbligatorio<br>";
      else
        lblErrori.Text = lblErrori.Text += "<br>L'ORARIO DI USCITA e' obbligatorio<br>"; ;
    }
    if (lblErrori.Text != "")
      return;
    else
    {
      if (DateTime.Parse(txtDataArrivo.Text) < DateTime.Today)
      {
        if (lblErrori.Text == "")
          lblErrori.Text = "<br>La DATA DI ARRIVO e' precedente alla data odierna<br>";
        else
          lblErrori.Text = lblErrori.Text += "<br>La DATA DI ARRIVO e' precedente alla data odierna<br>";
      }
      if ((DateTime.Parse(txtDataUscita.Text) < DateTime.Today) ||
        (DateTime.Parse(txtDataUscita.Text)) < DateTime.Parse(txtDataArrivo.Text))
      {
        if (lblErrori.Text == "")
          lblErrori.Text = "<br>La DATA DI USCITA non e' corretta (controllare che non sia precedente alla data di arrivo " +
            "o alla data di oggi)<br>";
        else
          lblErrori.Text = lblErrori.Text += "<br>La DATA DI USCITA non e' corretta (controllare che non sia precedente alla data di arrivo " +
            "o alla data di oggi<br>";
      }
      if (lblErrori.Text != "")
        return;
    }
    using (SqlConnection conn = new SqlConnection(connString))
    {
      conn.Open();
      if (Request.QueryString["id_Prenotazioni"] != null)
      {
        using (SqlCommand cmd = new SqlCommand("select count(*) from Prenotazioni where " +
        "data_entrata_Prenotazioni >= @data_entrata and data_uscita_Prenotazioni <= @data_uscita and ( " +
        "ora_entrata_Prenotazioni >= @ora_entrata and ora_uscita_Prenotazioni <= @ora_uscita or " +
        "ora_entrata_Prenotazioni <= @ora_uscita and ora_uscita_Prenotazioni >= @ora_entrata and " +
        "ora_entrata_Prenotazioni < @ora_uscita and ora_uscita_Prenotazioni > @ora_entrata)", conn)) // verificare AND e OR nella query
        {
          cmd.Parameters.Add("@data_entrata", SqlDbType.DateTime).Value = DateTime.Parse(txtDataArrivo.Text);
          cmd.Parameters.Add("@ora_entrata", SqlDbType.Time).Value = TimeSpan.Parse(txtOraArrivo.Text);
          cmd.Parameters.Add("@data_uscita", SqlDbType.DateTime).Value = DateTime.Parse(txtDataUscita.Text);
          cmd.Parameters.Add("@ora_uscita", SqlDbType.Time).Value = TimeSpan.Parse(txtOraUscita.Text);
          int numRows = Convert.ToInt32(cmd.ExecuteScalar());
          if (numRows <= 8)
          {
            btnProcediConPrenotazione.Enabled = true;
            btnProcediConPrenotazione.BackColor = System.Drawing.Color.LightGreen;
            btnProcediConPrenotazione.Font.Bold = true;
            lblEsitoRicerca.Visible = false;
          }
        }
      }
      using (SqlCommand cmd = new SqlCommand("select count(*) from Prenotazioni where " +
      "data_entrata_Prenotazioni >= @data_entrata and data_uscita_Prenotazioni <= @data_uscita and ( " +
      "ora_entrata_Prenotazioni >= @ora_entrata and ora_uscita_Prenotazioni <= @ora_uscita or " +
      "ora_entrata_Prenotazioni <= @ora_uscita and ora_uscita_Prenotazioni >= @ora_entrata and " +
      "ora_entrata_Prenotazioni < @ora_uscita and ora_uscita_Prenotazioni > @ora_entrata)", conn)) // verificare AND e OR nella query
      {
        cmd.Parameters.Add("@data_entrata", SqlDbType.DateTime).Value = DateTime.Parse(txtDataArrivo.Text);
        cmd.Parameters.Add("@ora_entrata", SqlDbType.Time).Value = TimeSpan.Parse(txtOraArrivo.Text);
        cmd.Parameters.Add("@data_uscita", SqlDbType.DateTime).Value = DateTime.Parse(txtDataUscita.Text);
        cmd.Parameters.Add("@ora_uscita", SqlDbType.Time).Value = TimeSpan.Parse(txtOraUscita.Text);
        int numRows = Convert.ToInt32(cmd.ExecuteScalar());
        if (numRows < 8)
        {
          btnProcediConPrenotazione.Enabled = true;
          btnProcediConPrenotazione.BackColor = System.Drawing.Color.LightGreen;
          btnProcediConPrenotazione.Font.Bold = true;
          lblEsitoRicerca.Visible = false;
        }
        else
        {
          lblEsitoRicerca.Text = "NESSUN PARCHEGGIO DISPONIBILE PER IL PERIODO RICHIESTO";
          lblEsitoRicerca.ForeColor = System.Drawing.Color.Red;
          txtDataArrivo.Text = "";
          txtOraArrivo.Text = "";
          txtDataUscita.Text = "";
          txtOraUscita.Text = "";
          //if (lblErrori.Text != "")
          //  return;
        }
      }
    }
  }

  protected void btnProcediConPrenotazione_Click(object sender, EventArgs e)
  {
    btnProcediConPrenotazione.Visible = false;
    tblVerificaDisponibilita.Visible = false;
    lblVerificaDisponibilita.Text = "CONFERMA PRENOTAZIONE";
    tblPrenotazione.Visible = true;
    txtDataArrivoPrenotazione.Text = txtDataArrivo.Text;
    txtOraArrivoPrenotazione.Text = txtOraArrivo.Text;
    txtDataUscitaPrenotazione.Text = txtDataUscita.Text;
    txtOraUscitaPrenotazione.Text = txtOraUscita.Text;
  }

  protected void btnConfermaPrenotazione_Click(object sender, EventArgs e)
  {
    using (SqlConnection conn = new SqlConnection(connString))
    {
      conn.Open();
      if (Request.QueryString["id_Prenotazioni"] != null)
      {
        using (SqlCommand cmd = new SqlCommand("update Prenotazioni set data_entrata_Prenotazioni = @data_entrata, " +
        "ora_entrata_Prenotazioni = @ora_entrata, data_uscita_Prenotazioni = @data_uscita, ora_uscita_Prenotazioni = " +
        "@ora_uscita, nominativo_Prenotazioni = @nominativo, recapito_Prenotazioni = @recapito, info_Prenotazioni = @info" +
        "  where id_Prenotazioni = @id", conn))
        {
          cmd.Parameters.Add("@id", SqlDbType.Int).Value = Request.QueryString["id_Prenotazioni"].ToString();
          cmd.Parameters.Add("@data_entrata", SqlDbType.DateTime).Value = DateTime.Parse(txtDataArrivoPrenotazione.Text);
          cmd.Parameters.Add("@ora_entrata", SqlDbType.Time).Value = TimeSpan.Parse(txtOraArrivoPrenotazione.Text);
          cmd.Parameters.Add("@data_uscita", SqlDbType.DateTime).Value = DateTime.Parse(txtDataUscitaPrenotazione.Text);
          cmd.Parameters.Add("@ora_uscita", SqlDbType.Time).Value = TimeSpan.Parse(txtOraUscitaPrenotazione.Text);
          cmd.Parameters.Add("@nominativo", SqlDbType.NVarChar, 255).Value = txtNominativoPrenotazione.Text;
          cmd.Parameters.Add("@recapito", SqlDbType.NVarChar, 255).Value = txtRecapitoPrenotazione.Text;
          cmd.Parameters.Add("@info", SqlDbType.Text).Value = txtInfoPrenotazione.Text;
          cmd.ExecuteNonQuery();
          Response.Redirect("PrenotazioneElenco.aspx");
        }
      }
      else
      {
        using (SqlCommand cmd = new SqlCommand("DECLARE @id AS INT SELECT @id = ISNULL(MAX(id_Prenotazioni), 1000) + 1 " +
        "FROM Prenotazioni insert into Prenotazioni(id_Prenotazioni, data_entrata_Prenotazioni, ora_entrata_Prenotazioni, " +
        "data_uscita_Prenotazioni, ora_uscita_Prenotazioni, nominativo_Prenotazioni, recapito_Prenotazioni," +
        " info_Prenotazioni) values(@id, @data_entrata, @ora_entrata, @data_uscita, @ora_uscita, @nominativo, @recapito," +
        " @info)", conn))
        {
          cmd.Parameters.Add("@data_entrata", SqlDbType.DateTime).Value = DateTime.Parse(txtDataArrivoPrenotazione.Text);
          cmd.Parameters.Add("@ora_entrata", SqlDbType.Time).Value = TimeSpan.Parse(txtOraArrivoPrenotazione.Text);
          cmd.Parameters.Add("@data_uscita", SqlDbType.DateTime).Value = DateTime.Parse(txtDataUscitaPrenotazione.Text);
          cmd.Parameters.Add("@ora_uscita", SqlDbType.Time).Value = TimeSpan.Parse(txtOraUscitaPrenotazione.Text);
          cmd.Parameters.Add("@nominativo", SqlDbType.NVarChar, 255).Value = txtNominativoPrenotazione.Text;
          cmd.Parameters.Add("@recapito", SqlDbType.NVarChar, 255).Value = txtRecapitoPrenotazione.Text;
          cmd.Parameters.Add("@info", SqlDbType.Text).Value = txtInfoPrenotazione.Text;
          cmd.ExecuteNonQuery();
          Response.Redirect("PrenotazioneElenco.aspx");
        }
      }
    }
  }

  protected void btnHome_Click(object sender, EventArgs e)
  {
    Response.Redirect("Index.aspx");
  }

  protected void brnAnnulla_Click(object sender, EventArgs e)
  {
    tblPrenotazione.Visible = false;
  }
}