using ProyectoProgramaciónLuisPérez.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoProgramaciónLuisPérez
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BIngresar_Click(object sender, EventArgs e)
        {
            ClsUsuarios.email = Tusuario.Text;
            ClsUsuarios.Clave = Tcontraseña.Text;

            if(ClsUsuarios.ValidarLogin(ClsUsuarios.email, ClsUsuarios.Clave)>0)
            {
                if (ClsUsuarios.Tipo.Equals("admin"))
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Redirect("HomeCliente.aspx");
                }

            }
            else
            {
                lmensaje.Text = " usuario o contraseña incorrecto";
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlrtBox", "alert('Usuario o Clave Incorrecta');",true);
            }
        }
    }
}