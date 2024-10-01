using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenPromerica
{
    public partial class Login : System.Web.UI.Page
    {

         
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Debe de ingresar un usuario');", true);
            }
            else if (txtPassword.Text.Length == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Debe de ingresar un password');", true);
            }
        }
    }
}