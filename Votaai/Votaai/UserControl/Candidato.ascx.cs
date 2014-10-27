using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace Votaai.UserControl
{
    public partial class Candidato : System.Web.UI.UserControl
    {
        #region Ações Tela

        List<string> extensoes;

        /// <summary>
        /// Evento load de página, que carrega o combo de partido, caso seja a primeira vez a entrar na tela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaComboPartido();
            }

        }

        /// <summary>
        /// seleçao de cargo, validando tamanho do campo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void selectcargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidaDivs();
            switch (selectcargo.SelectedValue)
            {
                case "1":
                    //this.numero.MaxLength = 2;
                    this.numerocand.Visible = false;
                    LimpaDadosSuplentes();

                    break;
                case "2":
                    this.numerocand.MaxLength = 1;
                    this.numerocand.Width = 15;
                    this.numerocand.Visible = true;
                    LimpaDadosSuplentes();
                    break;
                case "3":
                    //this.numero.MaxLength = 2;
                    this.numerocand.Visible = false;
                    break;
                    LimpaDadosSuplentes();
                case "4":
                    this.numerocand.MaxLength = 2;
                    this.numerocand.Width = 30;
                    this.numerocand.Visible = true;
                    LimpaDadosSuplentes();
                    break;
                case "5":
                    this.numerocand.MaxLength = 3;
                    this.numerocand.Width = 45;
                    this.numerocand.Visible = true;
                    LimpaDadosSuplentes();
                    break;
                default:
                    this.numerocand.MaxLength = 3;
                    this.numerocand.Width = 45;
                    LimpaDadosSuplentes();
                    break;

            }
            this.numerocand.Text = "";
            this.numerocand.DataBind();
        }

        /// <summary>
        /// Limpeza de dados de suplentes
        /// </summary>
        private void LimpaDadosSuplentes()
        {
            this.txtsuplente1.Value = "";
            this.txtsuplente2.Value = "";
            this.txtvice.Value = "";
        }

        /// <summary>
        /// Método do botão de incluir candidato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCadCand_Click(object sender, EventArgs e)
        {
            try
            {
                ClassesBanco.Candidato cand = new ClassesBanco.Candidato();

                FileFotoCand.DataBind();
                if (this.hiddencand.Value == "")
                {
                    if (!VerificaCandExistente())
                    {
                        MontaValoresInclusao(cand);
                        ValidaOperacao(ref cand);
                    }
                    else
                    {
                        //Tratar Erro com mensagem para o usuário.
                        throw new Exception("Já existe com este número e cargo para este estado! Gentileza ir para a janela de candidato para continuar o cadastro!");
                    }
                }
                else
                {
                    MontaValoresInclusao(cand);
                    ValidaOperacao(ref cand);

                }

                RegistraAlerta("Seus Dados Foram Salvos Com Sucesso!", "le-sucess", "LblSucess");
                LimpaSessions();
                LimpaTela();
                SimulaClickLink();
            }
            catch (Exception ex)
            {
                ///Fazer o alert vermelho caso caia aqui!.
                if (ex.Message.Contains("formato incorreto"))
                {
                    RegistraAlerta("Dados informados incorretamente! Gentileza verificar!", "le-alert", "lbldanger");
                }
                else
                {
                    RegistraAlerta(ex.Message.ToString(), "le-alert", "lbldanger");
                }
                SimulaClickLink();
            }

        }

        private void LimpaSessions()
        {

            Session["FolderFoto"] = null;
            Session["MensagemFoto"] = null;
        }
        /// <summary>
        /// Método para simular click de link
        /// </summary>
        private void SimulaClickLink()
        {
            try
            {
                ((Cadastros)this.Page).ClicaLink();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método de alerta para mensagens ao usuário
        /// </summary>
        /// <param name="msgalerta"></param>
        /// <param name="nomediv"></param>
        /// <param name="nomelabel"></param>
        private void RegistraAlerta(string msgalerta, string nomediv, string nomelabel)
        {

            ((Cadastros)this.Page).RegistraAlerta(msgalerta, nomediv, nomelabel);
        }

        /// <summary>
        /// Verifica se existe algum candidato com o número informado, cargo, partido e estado
        /// </summary>
        /// <returns></returns>
        private bool VerificaCandExistente()
        {
            try
            {

                ClassesBanco.Candidato validacand = new ClassesBanco.Candidato();
                validacand.cargo = this.selectcargo.SelectedValue;
                if (validacand.cargo == "1" || validacand.cargo == "3" || validacand.cargo == "")
                {
                    if (this.numeropartido.Text == "")
                    {
                        throw new Exception("Partido não informado!");
                    }
                    else
                    {
                        validacand.numero = int.Parse(string.Format("{0}", this.numeropartido.Text));

                    }
                }
                else
                {
                    if (this.numeropartido.Text == "")
                    {
                        throw new Exception("Partido não informado!");
                    }
                    else
                    {
                        validacand.numero = int.Parse(string.Format("{0}{1}", this.numeropartido.Text, this.numerocand.Text));
                    }

                }

                validacand.partidoid = int.Parse(this.selectpartido.SelectedValue);

                if (validacand.cargo != "1")
                {
                    validacand.estadocandidato = this.selectestado.SelectedValue;
                }

                DataSet dados = validacand.BuscarDados(validacand);

                if (dados.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Monta os valores para inclusão e/ou alteração de candidato
        /// </summary>
        /// <param name="cand"></param>
        private void MontaValoresInclusao(ClassesBanco.Candidato cand)
        {
            try
            {

                cand.nome = nomecandidato.Text.ToString();
                cand.numero = int.Parse(string.Format("{0}{1}", this.numeropartido.Text, this.numerocand.Text));
                cand.cargo = this.selectcargo.SelectedValue;
                cand.estadocandidato = this.selectestado.SelectedValue;
                cand.partidoid = int.Parse(this.selectpartido.SelectedValue);

                ValidaFoto(ref cand);
                ValidarVice(ref cand);

                if (cand.nome == "")
                {
                    throw new Exception("O nome deve ser informado! Gentileza ir para a janela de candidato para continuar o cadastro!");
                }

                if (cand.numero == 0)
                {
                    throw new Exception("Número informado inválido! Gentileza ir para a janela de candidato para continuar o cadastro!");
                }

                if (cand.cargo == "")
                {
                    throw new Exception("O cargo deve ser informado! Gentileza ir para a janela de candidato para continuar o cadastro!");
                }
                if (cand.estadocandidato == "")
                {
                    throw new Exception("O estado deve ser informado! Gentileza ir para a janela de candidato para continuar o cadastro!");
                }
                if (this.hiddencand.Value != "")
                {
                    cand.candidatoid = int.Parse(this.hiddencand.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Verifica se tem alguma mensagem gravada na session, em caso afirmativo é gerado um erro, senão, é recuperado o path do arquivo para salvar no banco de Dados
        /// </summary>
        /// <param name="cand"></param>
        private void ValidaFoto(ref ClassesBanco.Candidato cand)
        {
            try
            {
                if (Session["MensagemFoto"] != null && Session["MensagemFoto"].ToString().Contains("Erro!"))
                {
                    throw new Exception(Session["MensagemFoto"].ToString());
                }
                else
                {
                    cand.foto = Session["FolderFoto"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Método do Botão de Cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCanCand_Click(object sender, EventArgs e)
        {
            LimpaTela();
        }

        /// <summary>
        /// Limpa os valores da tela após a inclusão ou ao cancelamento de inclusão
        /// </summary>
        private void LimpaTela()
        {
            this.pesnumero.Value = "";
            this.nomecandidato.Text = "";
            this.selectpartido.SelectedValue = "0";
            this.numerocand.Text = "";
            this.numeropartido.Text = "";
            this.selectcargo.SelectedValue = "";
            this.hiddencand.Value = "";
            this.txtvice.Value = "";
            this.txtsuplente1.Value = "";
            this.txtsuplente2.Value = "";
            this.selectestado.SelectedValue = "";

            ValidaDivs();
        }

        /// <summary>
        /// Método do botão de pesquisa de candidato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                ClassesBanco.Candidato cand = new ClassesBanco.Candidato();
                cand.numero = int.Parse(this.pesnumero.Value);

                DataSet dados = cand.BuscarDados(cand);

                this.nomecandidato.Text = dados.Tables[0].Rows[0]["nome"].ToString();
                this.selectpartido.SelectedValue = dados.Tables[0].Rows[0]["partidoid"].ToString();
                this.numeropartido.Text = dados.Tables[0].Rows[0]["numero"].ToString().Substring(0, 2);
                this.numerocand.Text = dados.Tables[0].Rows[0]["numero"].ToString().Substring(2, 5);
                this.selectcargo.SelectedValue = dados.Tables[0].Rows[0]["cargo"].ToString();
                this.selectestado.SelectedValue = dados.Tables[0].Rows[0]["estadocandidato"].ToString();
                this.hiddencand.Value = dados.Tables[0].Rows[0]["candidatoid"].ToString();

            }
            catch (Exception ex)
            {
                RegistraAlerta(ex.Message.ToString(), "le-alert", "lbldanger");
            }
        }

        /// <summary>
        /// Evento de combo de partido, para busca de número
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void selectpartido_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (selectpartido.DataSource == null)
                {
                    selectpartido.DataSource = Session["DadosCombo"];

                }
                DataSet valoratual = (DataSet)selectpartido.DataSource;

                if (this.selectpartido.SelectedIndex > 0)
                {
                    DataRow[] row = valoratual.Tables[0].Select(string.Format("partidoid={0}", this.selectpartido.SelectedValue));
                    this.numeropartido.Text = row[0].ItemArray[4].ToString();

                }
                else
                {
                    this.numeropartido.Text = "";
                }

                ValidaDivs();
            }
            catch (Exception ex)
            {
                RegistraAlerta(ex.Message.ToString(), "le-alert", "lbldanger");
            }

        }
        /// <summary>
        /// Valida se a div de vice ou de suplente será mostrada, ou se as duas ficarão ocultas;
        /// </summary>
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

        /// <summary>
        /// Inicio de montagem de combo de partido
        /// </summary>
        private void CarregaComboPartido()
        {
            ClassesBanco.Partido part = new ClassesBanco.Partido();
            DataSet dados = part.BuscarDados(part);

            MontaComboPartido(dados);
        }

        /// <summary>
        /// Popula o combo de partido, com os dados buscados
        /// </summary>
        /// <param name="dados"></param>
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

        /// <summary>
        /// Valida, se caso o cargo seja governador ou presidente, se o vice foi informado
        /// </summary>
        /// <param name="cand"></param>
        private void ValidarVice(ref ClassesBanco.Candidato cand)
        {
            try
            {
                if (cand.cargo == "1" || cand.cargo == "3")
                {
                    if (txtvice.Value == "")
                    {
                        throw new Exception("Vice não informado! Gentileza ir para a janela de candidato para continuar o cadastro!");
                    }
                    else
                    {
                        cand.vice = txtvice.Value;
                    }
                }
                else if (cand.cargo == "2")
                {
                    if (this.txtsuplente1.Value == "" || this.txtsuplente2.Value == "")
                    {
                        throw new Exception("Suplente(s) não informado(s) Gentileza ir para a janela de candidato para continuar o cadastro!");
                    }
                    else
                    {
                        cand.vice = this.txtsuplente1.Value + ";" + this.txtsuplente2.Value;

                    }
                }
                else
                {
                    cand.vice = null;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Lista as extensões permitidas de fotos
        /// </summary>
        private void ExtensoesPermitidas()
        {
            extensoes = new List<string>();
            extensoes.Add(".jpg");
            extensoes.Add(".jpeg");
        }

        /// <summary>
        /// Valida a operação que será disparada no banco de dados
        /// </summary>
        /// <param name="cand"></param>
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

        /// <summary>
        /// Verificação de Foto que foi feita o upload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FileFotoCand_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            string filepath = Server.MapPath("~/ImagensCandidatos/");
            string fullpath = filepath + FileFotoCand.FileName;
            bool achouerro = false;

            if (Session["FolderFoto"] != null && System.IO.File.Exists(Session["FolderFoto"].ToString()))
            {
                System.IO.File.Delete(Session["FolderFoto"].ToString());
            }

            Session["FolderFoto"] = null;

            ExtensoesPermitidas();
            string achou = extensoes.Find(x => x == Path.GetExtension(FileFotoCand.FileName));


            if ((achou == "" || achou == null) && !achouerro)
            {
                Session["MensagemFoto"] = "Erro! Extensão de arquivo não permitida! Por favor inclua um arquivo com as extensões JPG, JPEG. Gentileza ir para a janela de candidato para continuar o cadastro!";

            }

            if (((double)(FileFotoCand.PostedFile.ContentLength) > 4194304) && !achouerro)
            {
                Session["MensagemFoto"] = "Erro! Arquivo não deve ser maior do que 4 MB!";
            }

            if (!achouerro)
            {
                this.FileFotoCand.SaveAs(fullpath);
                Session["FolderFoto"] = fullpath;

            }

        }

    }
}