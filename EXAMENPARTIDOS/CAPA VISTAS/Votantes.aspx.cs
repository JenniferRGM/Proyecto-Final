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
    public partial class Votantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                
                LlenarGrid();
                lmensaje.Text="FAVOR PARA AGREGUE LOS VOTANTES";
            }
        }
        protected void Ingresar()
        {
            // Verificar si el votante ya existe
            if (VerificarVotanteExistente(Tidcedula.Text))
            {
                lmensaje.Text = "El votante con cédula " + Tidcedula.Text + " ya está registrado.";
                return;
            }
            /*Se ingresa el votante*/
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand(" INSERT INTO VOTANTES VALUES('" + Tidcedula.Text + "','" + Tnombre.Text + "' ,'" + TAPELLIDO.Text + "' ,'" + TAPELLIDO2.Text + "' ,'" + Temail.Text + " '  )", conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();
        }

        protected bool VerificarVotanteExistente(string idCedula)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand(" SELECT COUNT(*) FROM VOTANTES WHERE IDCEDULA = @IDCEDULA ", conexion);
            comando.Parameters.AddWithValue("@IDCEDULA", idCedula);
            int count = (int)comando.ExecuteScalar();
            conexion.Close();
            return count > 0;
        }

        protected void Modificar()
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();

            // Comando para actualizar un votante existente
            SqlCommand comando = new SqlCommand(" UPDATE VOTANTES SET NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, APELLIDO2 = @APELLIDO2, EMAIL = @EMAIL WHERE IDCEDULA = @IDCEDULA ", conexion);

            // Asignar los valores a los parámetros del comando
            comando.Parameters.AddWithValue("@IDCEDULA", Tidcedula.Text);
            comando.Parameters.AddWithValue("@NOMBRE", Tnombre.Text);
            comando.Parameters.AddWithValue("@APELLIDO", TAPELLIDO.Text);
            comando.Parameters.AddWithValue("@APELLIDO2", TAPELLIDO2.Text);
            comando.Parameters.AddWithValue("@EMAIL", Temail.Text);
            comando.ExecuteNonQuery();
            conexion.Close();

            // Volver a cargar el GridView después de la modificación
            LlenarGrid();
        }
        protected void Modificar(object sender, EventArgs e)
        {
            // Obtener el ID del votante seleccionado en el GridView
            int idVotante = Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text);

            // Realizar una consulta para obtener los datos actuales del votante
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();

            SqlCommand comando = new SqlCommand(" SELECT * FROM VOTANTES WHERE IDCEDULA = @IDCEDULA ", conexion);
            comando.Parameters.AddWithValue("@IDCEDULA", idVotante);

            SqlDataReader registro = comando.ExecuteReader();

            if (registro.Read())
            {
                // Asignar los valores actuales a los controles de la página
                Tidcedula.Text = registro["IDCEDULA"].ToString();
                Tnombre.Text = registro["NOMBRE"].ToString();
                TAPELLIDO.Text = registro["APELLIDO"].ToString();
                TAPELLIDO2.Text = registro["APELLIDO2"].ToString();
                Temail.Text = registro["EMAIL"].ToString();
            }

            conexion.Close();
        }
       

       protected void Borrar()
{
    // Verificar si el votante ha emitido un voto
    if (VotanteHaEmitidoVoto(Tidcedula.Text))
    {
        lmensaje.Text = "No se puede eliminar al votante con cédula " + Tidcedula.Text + " porque ya ha emitido su voto.";
        return;
    }

    // Proceder a borrar el votante
    String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
    SqlConnection conexion = new SqlConnection(s);
    conexion.Open();
    SqlCommand comando = new SqlCommand("DELETE FROM VOTANTES WHERE IDCEDULA = @IDCEDULA", conexion);
    comando.Parameters.AddWithValue("@IDCEDULA", Tidcedula.Text);
    comando.ExecuteNonQuery();
    conexion.Close();
    LlenarGrid();
}

protected bool VotanteHaEmitidoVoto(string idCedula)
{
    String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
    SqlConnection conexion = new SqlConnection(s);
    conexion.Open();
    SqlCommand comando = new SqlCommand("SELECT COUNT(*) FROM REGISTROS_VOTOS WHERE IDVOTANTE1 = @IDCEDULA", conexion);
    comando.Parameters.AddWithValue("@IDCEDULA", idCedula);
    int count = (int)comando.ExecuteScalar();
    conexion.Close();
    return count > 0; // Retorna si el votante ha emitido un voto
}

        protected void LlenarGrid()
        {
            //SE LLAMA LA TABLA VOTANTES PARA QUE SE REFLEJEN LAS PERSONAS QUE VOTARON, ADEMAS EL ID SERA UNICO//
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM VOTANTES"))
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

        protected void BELIMINAR_Click(object sender, EventArgs e)
        {
            Borrar();
        }
        protected void BMODIFICAR_Click(object sender, EventArgs e)
        {
            Modificar();
        }
    }
}