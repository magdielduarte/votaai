﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Votaai.UserControl
{
    public partial class Partido : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCanPart_Click(object sender, EventArgs e)
        {

        }

        protected void BtnCadPart_Click(object sender, EventArgs e)
        {
            ClassesBanco.Partido part = new ClassesBanco.Partido();
            part.cnpj = this.cpnjpartido.Value;
            part.nome = this.nomepartido.Value;
            part.sigla = this.siglapartido.Value;
            part.prefixo = int.Parse(this.prefixopartido.Text);
        }
    }
}