﻿using System;
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
    public partial class Clientes : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("llenartabla2 "))
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
            SqlCommand cmd = new SqlCommand("IngresarClientes", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@Nombre", TNombre.Text));
            cmd.Parameters.Add(new SqlParameter("@Apellido", TApellido.Text));
            cmd.Parameters.Add(new SqlParameter("@Telefono", TTelefono.Text));
            cmd.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();
        }

        protected void BModificar_Click(object sender, EventArgs e)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["GimnasioConnectionString1"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("ActualizarClientes", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ID_Cliente", TIDCliente.Text));
            cmd.Parameters.Add(new SqlParameter("@Nombre", TNombre.Text));
            cmd.Parameters.Add(new SqlParameter("@Apellido", TApellido.Text));
            cmd.Parameters.Add(new SqlParameter("@Telefono", TTelefono.Text));
            cmd.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();
        }

        protected void BBorrar_Click(object sender, EventArgs e)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["GimnasioConnectionString1"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("BorrarCliente", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ID_Cliente", TIDCliente.Text));
            cmd.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();
        }
     

        protected void BConsultar_Click1(object sender, EventArgs e)
        {

            String s = System.Configuration.ConfigurationManager.ConnectionStrings["GimnasioConnectionString1"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand cmd = new SqlCommand("ConsultarClientes", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@ID_Cliente", TIDCliente.Text));

            cmd.ExecuteNonQuery();
            conexion.Close();
            LlenarGrid();
        }
    }
}