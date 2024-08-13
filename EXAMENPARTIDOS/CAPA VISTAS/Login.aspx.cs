using EXAMENPARTIDOS.CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EXAMENPARTIDOS.CAPA_VISTAS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Bingresar_Click(object sender, EventArgs e)
        {
            Validarusuario(Tusuario.Text, Tclave.Text);
        }

        protected void Validarusuario(string email, string clave)
        {
            //SE CREAN 2 USUARIOS mario@tribunal.com, CLAVE= 123 Y rebeca@tribunal.com, 456 SOLAMENTE XQ EL SISTEMA SE HIZO//
            //PENSANDO EN QUE SOLO ESTAS 2 PERSONAS LO MANIPULEN Y LOS VOTANTES SERAN ABORDADOS VIA TELEFONICA, EL EMAIL DEL USUARIO ES UNICO//
            ClsUsuario.emailusu = email;
            ClsUsuario.claveusu = clave;
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand("select email, clave, nombre from USUARIO where email = '" + email + "' " +
                "and clave = '" + clave + "'", conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                ClsUsuario.nombreusu=registro["nombre"].ToString();
                Response.Redirect("portada.aspx");
            }
            else
            {
                //SI DIGITA MAL ALGUN DATO NO PODRA INGRESAR Y VERA ESTE MENSAJE//
                lmensaje.Text = " usuario o contraseña incorrecto";
            }
            conexion.Close();
        }
    }
}