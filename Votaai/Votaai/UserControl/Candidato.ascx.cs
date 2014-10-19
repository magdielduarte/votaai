using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Votaai.UserControl
{
    public partial class Candidato : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCadCand_Click(object sender, EventArgs e)
        {
            ClassesBanco.Candidato cand = new ClassesBanco.Candidato();
            cand.nome = nomecandidato.Value.ToString();
            cand.numero = int.Parse(numero.Text);
            cand.cargo = this.selectcargo.Value;

            ValidarFoto(ref cand);
            ValidarVice(ref cand);

            cand.partidoid = int.Parse(this.selectpartido.Value);

            ValidaOperacao(ref cand);
        }

        private void ValidarVice(ref ClassesBanco.Candidato cand)
        {
            if (cand.cargo == "Presidente" || cand.cargo == "Governador")
            {
                cand.vice = txtvice.Value;
            }
            else if (cand.cargo == "Senador")
            {
                cand.vice = this.txtsuplente1.Value + ";" + this.txtsuplente2.Value;
            }
            else
            {
                cand.vice = null;
            }
        }


        private void ValidarFoto(ref ClassesBanco.Candidato cand)
        {

        }

        protected void BtnCanCand_Click(object sender, EventArgs e)
        {

        }

        private void ValidaOperacao(ref ClassesBanco.Candidato cand)
        {
            if (this.hiddencand.Value == "")
            {
                cand.ExecutarMetodo('I');
            }
            else
            {
                cand.ExecutarMetodo('A');
            }
        }
    }
}