﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Votaai.UserControl
{
    public partial class Candidato : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaComboPartido();

        }

        private void CarregaComboPartido()
        {
            ClassesBanco.Partido part = new ClassesBanco.Partido();
            DataSet dados = part.BuscarDados(part);

            MontaComboPartido(dados);
        }

        private void MontaComboPartido(DataSet dados)
        {

            this.selectpartido.DataSource = dados;
            this.selectpartido.DataTextField = "sigla";
            this.selectpartido.DataValueField = "partidoid";
            this.selectpartido.DataBind();
        }

        protected void BtnCadCand_Click(object sender, EventArgs e)
        {
            ClassesBanco.Candidato cand = new ClassesBanco.Candidato();
            cand.nome = nomecandidato.Value.ToString();
            cand.numero = int.Parse(numero.Text);
            cand.cargo = this.selectcargo.Value;

            ValidarFoto(ref cand);
            ValidarVice(ref cand);

            cand.partidoid = int.Parse(this.selectpartido.SelectedValue);

            ValidaOperacao(ref cand);
        }

        private void ValidarVice(ref ClassesBanco.Candidato cand)
        {
            if (cand.cargo == "1" || cand.cargo == "3")
            {
                cand.vice = txtvice.Value;
            }
            else if (cand.cargo == "2")
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
            string filepath = Server.MapPath("~/ImagensCandidatos/");
            string fullpath = filepath + FileFotoCand.FileName;
            this.FileFotoCand.SaveAs(fullpath);
            cand.foto = fullpath;
        }

        protected void BtnCanCand_Click(object sender, EventArgs e)
        {

        }

        private void ValidaOperacao(ref ClassesBanco.Candidato cand)
        {
            if (this.hiddencand.Value == "")
            {
                cand.ExecutarMetodo('I', cand);
            }
            else
            {
                cand.ExecutarMetodo('A', cand);
            }
        }

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {

        }

        protected void selectpartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet valoratual = (DataSet)selectpartido.DataSource;
            DataRow[] row = valoratual.Tables[0].Select(string.Format("partidoid={0}", this.selectpartido.SelectedValue));
            this.numero.Text = row[0].ItemArray[4].ToString();
        }
    }
}