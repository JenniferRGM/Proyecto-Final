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
using System.Security.Cryptography;

namespace EXAMENPARTIDOS.CAPA_VISTAS
{
    public partial class Voto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
                lmensaje.Text="FAVOR ELIJA AL CANDIDATO";
            }
        }
        protected void Ingresar()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                // Verificar si el votante está registrado
                SqlCommand checkRegistroCmd = new SqlCommand("SELECT COUNT(*) FROM VOTANTES WHERE IDCEDULA = @IDVOTANTE", conexion);
                checkRegistroCmd.Parameters.AddWithValue("@IDVOTANTE", TIDVOTANTE.Text);

                int registroCount = (int)checkRegistroCmd.ExecuteScalar();

                if (registroCount == 0)
                {
                    // El votante no está registrado
                    lmensaje.Text = "Este votante no está registrado. Por favor, regístrese antes de votar.";
                    return;
                }

                // Verificar si el votante ya ha votado
                SqlCommand checkVotoCmd = new SqlCommand("SELECT COUNT(*) FROM VOTOS WHERE IDVOTANTE = @IDVOTANTE", conexion);
                checkVotoCmd.Parameters.AddWithValue("@IDVOTANTE", TIDVOTANTE.Text);

                int votoCount = (int)checkVotoCmd.ExecuteScalar();

                if (votoCount > 0)
                {
                    // El votante ya ha votado
                    lmensaje.Text = "Este votante ya ha emitido su voto.";
                    return;
                }

                // Si el votante está registrado y no ha votado, proceder a insertar el voto
                SqlCommand comando = new SqlCommand("INSERT INTO VOTOS (IDCANDIDATO, IDVOTANTE) VALUES (@IDCANDIDATO, @IDVOTANTE)", conexion);
                comando.Parameters.AddWithValue("@IDCANDIDATO", TIDCANDIDATO.Text);
                comando.Parameters.AddWithValue("@IDVOTANTE", TIDVOTANTE.Text);

                comando.ExecuteNonQuery();
                lmensaje.Text = "Voto emitido con éxito.";
            }

            LlenarGrid();
        }




        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM CANDIDATOS"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }

        protected void BAGREGAR_Click(object sender, EventArgs e)
        {
            Ingresar();
        }


    }
}