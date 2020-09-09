using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class PrenotazioneAnalisi : System.Web.UI.Page
{
  string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      //using (SqlConnection conn = new SqlConnection(connStr))
      //{
      //  conn.Open();
      //}
    }
  }

  protected void btnCercaRisultati_Click(object sender, EventArgs e)
  {

    using (SqlConnection conn = new SqlConnection(connStr))
    {
      conn.Open();
      using (SqlCommand cmd = new SqlCommand("select count(id_Prenotazioni) from Prenotazioni where " +
        "data_entrata_Prenotazioni >= @data_entrata and data_uscita_Prenotazioni <= @data_uscita and " +
        "ora_entrata_Prenotazioni >= @ora_entrata and ora_uscita_Prenotazioni <= @ora_uscita", conn))
      {
        cmd.Parameters.Add("@data_entrata", SqlDbType.DateTime).Value = DateTime.Parse(txtDataArrivo.Text);
        cmd.Parameters.Add("@ora_entrata", SqlDbType.Time).Value = TimeSpan.Parse(txtOraArrivo.Text);
        cmd.Parameters.Add("@data_uscita", SqlDbType.DateTime).Value = DateTime.Parse(txtDataUscita.Text);
        cmd.Parameters.Add("@ora_uscita", SqlDbType.Time).Value = TimeSpan.Parse(txtOraUscita.Text);
        txtPrenotazioniTrovate.Text = cmd.ExecuteScalar().ToString();
      }
      using (SqlCommand cmd = new SqlCommand("select id_Prenotazioni, data_entrata_Prenotazioni, ora_entrata_Prenotazioni, " +
        "data_uscita_Prenotazioni, ora_uscita_Prenotazioni, nominativo_Prenotazioni, info_Prenotazioni, " +
        "recapito_Prenotazioni, datediff(hour, data_entrata_Prenotazioni, data_uscita_Prenotazioni) + " +
        "datediff(hour, ora_entrata_Prenotazioni, ora_uscita_Prenotazioni) * 2.50 as Importo  " +
        "from Prenotazioni where data_entrata_Prenotazioni >= @data_entrata and " +
        "data_uscita_Prenotazioni <= @data_uscita and ora_entrata_Prenotazioni >= @ora_entrata and " +
        "ora_uscita_Prenotazioni <= @ora_uscita order by data_entrata_Prenotazioni, ora_entrata_Prenotazioni, " +
        "data_uscita_prenotazioni, ora_uscita_Prenotazioni", conn))
      {
        cmd.Parameters.Add("@data_entrata", SqlDbType.DateTime).Value = DateTime.Parse(txtDataArrivo.Text);
        cmd.Parameters.Add("@ora_entrata", SqlDbType.Time).Value = TimeSpan.Parse(txtOraArrivo.Text);
        cmd.Parameters.Add("@data_uscita", SqlDbType.DateTime).Value = DateTime.Parse(txtDataUscita.Text);
        cmd.Parameters.Add("@ora_uscita", SqlDbType.Time).Value = TimeSpan.Parse(txtOraUscita.Text);
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
          gvPrenotazioneElenco.DataSource = dr;
          gvPrenotazioneElenco.DataBind();
        }
      }
    }
  }

  protected void btnHome_Click(object sender, EventArgs e)
  {
    Response.Redirect("Index.aspx");
  }
}