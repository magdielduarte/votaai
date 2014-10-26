using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Votaai
{
    public partial class Cadastros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.IdUsuLogado.InnerText = Session["UsuLogin"].ToString();
        }
/// <summary>
/// Registro de Alerta para o usuário
/// </summary>
/// <param name="msgalerta"></param>
/// <param name="nomediv"></param>
/// <param name="nomelabel"></param>
        public void RegistraAlerta(string msgalerta, string nomediv, string nomelabel)
        {
            if (nomelabel == "LblSucess")
            {
                LblSucess.Text = msgalerta;
            }
            else
            {
                lbldanger.Text = msgalerta;
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "sucess", string.Format("ativadiv('{0}')", nomediv), true);

        }

    }
}