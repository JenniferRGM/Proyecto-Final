using EXAMENPARTIDOS.CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EXAMENPARTIDOS.CAPA_VISTAS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();


            }
        }
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = @"SELECT c.NOMBRE,c.APELLIDO,c.APELLIDO2, v.IDCANDIDATO, COUNT(*) AS TotalVotos
                                FROM VOTOS v
                                JOIN CANDIDATOS c ON v.IDCANDIDATO = c.ID
                                GROUP BY c.NOMBRE,c.APELLIDO,c.APELLIDO2, v.IDCANDIDATO";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            // Preparar datos para el gráfico
                            PrepararDatosGrafico(dt);

                            // Determinar el ganador
                            DeterminarGanador(dt);
                        }
                    }
                }
            }
        }

        private void PrepararDatosGrafico(DataTable dt)
        {
            string candidatosScript = "var candidatos = [";
            string votosScript = "var votos = [";

            foreach (DataRow row in dt.Rows)
            {
                candidatosScript += "'" + row["NOMBRE"].ToString() + " " + row["APELLIDO"].ToString() + " " + row["APELLIDO2"].ToString() + "',";
                votosScript += row["TotalVotos"].ToString() + ",";
            }


            candidatosScript = candidatosScript.TrimEnd(',') + "];";
            votosScript = votosScript.TrimEnd(',') + "];";

            // Registrar los scripts para que estén disponibles
            ClientScript.RegisterStartupScript(this.GetType(), "candidatos", candidatosScript, true);
            ClientScript.RegisterStartupScript(this.GetType(), "votos", votosScript, true);
        }

        protected void DeterminarGanador(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                int maxVotos = 0;
                string ganador = string.Empty;

                foreach (DataRow row in dt.Rows)
                {
                    int totalVotos = Convert.ToInt32(row["TotalVotos"]);
                    if (totalVotos > maxVotos)
                    {
                        maxVotos = totalVotos;
                        ganador = row["NOMBRE"].ToString() + " " + row["APELLIDO"].ToString() + " " + row["APELLIDO2"].ToString();
                    }
                }

                // Mostrar el ganador en la etiqueta
                lblGanador.Text = "El ganador es el candidato: " + ganador + " con " + maxVotos + " votos.";
            }
            else
            {
                lblGanador.Text = "No hay votos registrados.";
            }
        }
    }
}