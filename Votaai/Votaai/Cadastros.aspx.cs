﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Votaai
{
    public partial class Cadastros : System.Web.UI.Page
    {
        /// <summary>
        /// Evento de load da página, colocando o nome do usuário logado, na barra inicial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuLogin"] != null)
            {
                this.IdUsuLogado.InnerText = Session["UsuLogin"].ToString();
            }
        }


        public void ClicaLink()
        {
            System.Text.StringBuilder txt = new System.Text.StringBuilder();
            txt.Append(string.Format("\ndocument.getElementById('candform').click();"));
            ScriptManager.RegisterStartupScript(this, GetType(), "clickfunc", txt.ToString(), true);
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

            ScriptManager.RegisterStartupScript(this, GetType(), "sucess", string.Format("ativadiv('{0}');", nomediv), true);

        }

    }
}