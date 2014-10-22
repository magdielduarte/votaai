using System;
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
        #region Ações Tela

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaComboPartido();
            }

        }

        protected void BtnCadCand_Click(object sender, EventArgs e)
        {
            ClassesBanco.Candidato cand = new ClassesBanco.Candidato();
            cand.nome = nomecandidato.Value.ToString();
            cand.numero = int.Parse(numero.Text);
            cand.cargo = this.selectcargo.SelectedValue;

            ValidarFoto(ref cand);
            ValidarVice(ref cand);

            cand.partidoid = int.Parse(this.selectpartido.SelectedValue);

            ValidaOperacao(ref cand);
        }

        protected void BtnCanCand_Click(object sender, EventArgs e)
        {

        }

        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                ClassesBanco.Candidato cand = new ClassesBanco.Candidato();
                cand.numero = int.Parse(this.pesnumero.Value);

                DataSet dados = cand.BuscarDados(cand);

                this.nomecandidato.Value = dados.Tables[0].Rows[0]["nome"].ToString();
                this.selectpartido.SelectedValue = dados.Tables[0].Rows[0]["partidoid"].ToString();
                this.numero.Text = dados.Tables[0].Rows[0]["numero"].ToString();
                this.selectcargo.SelectedValue = dados.Tables[0].Rows[0]["cargo"].ToString();
                this.hiddencand.Value = dados.Tables[0].Rows[0]["candidatoid"].ToString();

            }
            catch (Exception ex)
            { }
        }

        protected void selectpartido_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (selectpartido.DataSource == null)
            {
                selectpartido.DataSource = Session["DadosCombo"];

            }
            DataSet valoratual = (DataSet)selectpartido.DataSource;

            if (this.selectpartido.SelectedIndex > 0)
            {
                DataRow[] row = valoratual.Tables[0].Select(string.Format("partidoid={0}", this.selectpartido.SelectedValue));
                this.numero.Text = row[0].ItemArray[4].ToString();

            }
            else
            {
                this.numero.Text = "";
            }

            ValidaDivs();

        }

        private void ValidaDivs()
        {
            switch (this.selectcargo.SelectedValue)
            {
                case "1":
                    this.vice.Style["display"] = "block";
                    this.suplente.Style["display"] = "none";
                    break;
                case "2":
                    this.vice.Style["display"] = "none";
                    this.suplente.Style["display"] = "block";
                    break;
                case "3":
                    this.vice.Style["display"] = "block";
                    this.suplente.Style["display"] = "none";
                    break;
                default:
                    this.vice.Style["display"] = "none";
                    this.suplente.Style["display"] = "none";
                    break;
            }

        }

        #endregion

        #region Montagem de Combo

        private void CarregaComboPartido()
        {
            ClassesBanco.Partido part = new ClassesBanco.Partido();
            DataSet dados = part.BuscarDados(part);

            MontaComboPartido(dados);
        }

        private void MontaComboPartido(DataSet dados)
        {
            DataRow row = dados.Tables[0].NewRow();

            row[0] = 0;
            row[4] = "";
            dados.Tables[0].Rows.InsertAt(row, 0);

            this.selectpartido.DataSource = dados;
            this.selectpartido.DataTextField = "sigla";
            this.selectpartido.DataValueField = "partidoid";
            this.selectpartido.DataBind();
            Session["DadosCombo"] = dados;
        }
        #endregion

        #region Validações para Cadastro

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
        #endregion

        protected void selectcargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidaDivs();
            switch (selectcargo.SelectedValue)
            {
                case "1":
                    this.numero.MaxLength = 2;
                    break;
                case "2":
                    this.numero.MaxLength = 3;
                    break;
                case "3":
                    this.numero.MaxLength = 2;
                    break;
                case "4":
                    this.numero.MaxLength = 4;
                    break;
                case "5":
                    this.numero.MaxLength = 5;
                    break;
                default:
                    this.numero.MaxLength = 5;
                    break;

            }
            this.numero.DataBind();
        }

    }
}