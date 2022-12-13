using ProyectoProgramaciónLuisPérez.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoProgramaciónLuisPérez
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            LlenarGrid();
        }


        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["GimnasioConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("llenartabla "))
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



        protected void BAgregar_Click(object sender, EventArgs e)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["GimnasioConnectionString1"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("IngresarUsuarios", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@Email", TEmail.Text));
            cmd.Parameters.Add(new SqlParameter("@Clave", TClave.Text));
            cmd.Parameters.Add(new SqlParameter("@Nombre", TNombre.Text));
            cmd.Parameters.Add(new SqlParameter("@TIPO", TTipo.Text));
            cmd.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();
        }

        protected void BModificar_Click(object sender, EventArgs e)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["GimnasioConnectionString1"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("ActualizarUsuarios", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ID_Usuarios", TIDUsuarios.Text));
            cmd.Parameters.Add(new SqlParameter("@Email", TEmail.Text));
            cmd.Parameters.Add(new SqlParameter("@Clave", TClave.Text));
            cmd.Parameters.Add(new SqlParameter("@Nombre", TNombre.Text));
            cmd.Parameters.Add(new SqlParameter("@TIPO", TTipo.Text));
            cmd.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();
        }

            protected void BBorrar_Click(object sender, EventArgs e)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["GimnasioConnectionString1"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("BorrarUsuario", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ID_Usuarios", TIDUsuarios.Text));
            cmd.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();

        }

        protected void BConsulta_Click(object sender, EventArgs e)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["GimnasioConnectionString1"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("ConsultaUsuario", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ID_Usuarios", TIDUsuarios.Text));
           
            cmd.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();
        }
    }
}




       



