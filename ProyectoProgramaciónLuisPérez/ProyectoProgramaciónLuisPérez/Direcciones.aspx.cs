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
    public partial class Direcciones : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("llenartabla3 "))
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
            SqlCommand cmd = new SqlCommand("IngresarDireccion", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@Codigo_Cliente", DCCliente.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("@Codigo_Provincia", DCProvincia.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("@Codigo_Canton", DCCanton.SelectedValue ));
            cmd.Parameters.Add(new SqlParameter("@Codigo_Distrito", DCDistrito.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("@Comentarios", TComentarios.Text));
            cmd.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();

        }

        protected void BModificar_Click(object sender, EventArgs e)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["GimnasioConnectionString1"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("ActualizarDireccion", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ID_Direcciones", TID_Direccion.Text));
            cmd.Parameters.Add(new SqlParameter("@Codigo_Cliente", DCCliente.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("@Codigo_Provincia", DCProvincia.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("@Codigo_Canton", DCCanton.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("@Codigo_Distrito", DCDistrito.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("@Comentarios", TComentarios.Text));
            cmd.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();


        }

        protected void BBorrar_Click(object sender, EventArgs e)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["GimnasioConnectionString1"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("BorrarDireccion", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ID_Direcciones", TID_Direccion.Text));
            cmd.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();

        }

        protected void BConsultar_Click1(object sender, EventArgs e)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["GimnasioConnectionString1"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("ConsultarDireccion", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ID_Direcciones", TID_Direccion));
            cmd.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();
        }
    }
}