using ProyectoProgramaciónLuisPérez.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoProgramaciónLuisPérez
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(ClsUsuarios.ValidarLogin(ClsUsuarios.email,ClsUsuarios.Clave)>0)
            {
               
            }
        }
    }
}