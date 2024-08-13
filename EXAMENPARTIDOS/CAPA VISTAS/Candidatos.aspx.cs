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
    public partial class Candidatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SE ASIGNA UN MENSAJE PARA EL USUARIO DEL SISTEMA//
            if (!IsPostBack)
            {
                LlenarGrid();
                lmensaje.Text="FAVOR NO ASIGNE NUMERO DE ID EL SISTEMA LO HACE AUTOMATICO";
                lmensaje2.Text="ID SOLO SE UTILIZA PARA BORRAR UN CANDIDATO DE LA LISTA";
            }
        }
        protected void Ingresar()
        {

            // SE AGREGAN CANDIDATOS//
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand(" INSERT INTO CANDIDATOS VALUES ('" + TNOMBRE.Text + "' ,'" + TAPELLIDO.Text + "' ,'" + TAPELLIDO2.Text + "' ,'" + TNOMBREPARTIDO.Text + "' )", conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();
        }
        protected void Modificar()
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();

            // Comando para actualizar un candidato existente
            SqlCommand comando = new SqlCommand(" UPDATE CANDIDATOS SET NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, APELLIDO2 = @APELLIDO2, NOMBREPARTIDO = @NOMBREPARTIDO WHERE ID = @ID ", conexion);

            // Asignar los valores a los parámetros del comando
            comando.Parameters.AddWithValue("@ID", TID.Text);
            comando.Parameters.AddWithValue("@NOMBRE", TNOMBRE.Text);
            comando.Parameters.AddWithValue("@APELLIDO", TAPELLIDO.Text);
            comando.Parameters.AddWithValue("@APELLIDO2", TAPELLIDO2.Text);
            comando.Parameters.AddWithValue("@NOMBREPARTIDO", TNOMBREPARTIDO.Text);

            comando.ExecuteNonQuery();
            conexion.Close();

            // Volver a cargar el GridView después de la modificación
            LlenarGrid();
        }

        protected void Borrar()
        {
            //SE PUEDE ELIMINAR UN CANDIDATO A LA VEZ CON SOLO EL ID DE CANDIDATO//
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand(" Delete CANDIDATOS where ID = '" + TID.Text + "'  ", conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();
        }
        protected void LlenarGrid()
        {
            //SE LLAMA A LA TABLA CANDIDATOS PARA QUE APAREZCA EN EL GRID//
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