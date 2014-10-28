using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Votaai.UserControl
{
    public partial class Partido : System.Web.UI.UserControl
    {
        #region Ações Tela

        /// <summary>
        /// Evento de load da página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento de botão de cancelar, limpando os campos da tela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCanPart_Click(object sender, EventArgs e)
        {
            LimpaTela();
        }

        /// <summary>
        /// Evento de botão de cadastro de partido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ValidaSigla()
        {
            try
            {
                if (this.siglapartido.Value.ToString().Length > 5 || this.pessigla.Value.ToString().Length > 5)
                {
                    throw new Exception("Campo de pesquisa de sigla ou cadastro de sigla está maior que o permitido! Máx: 5 caracteres!");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void BtnCadPart_Click(object sender, EventArgs e)
        {
            try
            {

                ClassesBanco.Partido part = new ClassesBanco.Partido();
                ValidaSigla();
                if (this.hiddenpartido.Value == "")
                {
                    if (!ValidaPartExistente())
                    {
                        MontaValoresInclusao(part);
                        ValidaOperacao(ref part);
                    }
                    else
                    {
                        throw new Exception("Já existe partido com os dados informados!");
                    }
                }
                else
                {
                    MontaValoresInclusao(part);
                    ValidaOperacao(ref part);
                }

                LimpaTela();
                RegistraAlerta("Seus Dados Foram Salvos Com Sucesso!", "le-sucess", "LblSucess");

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("formato incorreto"))
                {
                    RegistraAlerta("Dados informados incorretamente! Gentileza verificar!", "le-alert", "lbldanger");

                }

                else
                {
                    RegistraAlerta(ex.Message.ToString(), "le-alert", "lbldanger");

                }
            }
        }

        /// <summary>
        /// Evento de pesquisar partido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ValidaSigla();

                ClassesBanco.Partido part = new ClassesBanco.Partido();
                part.sigla = this.pessigla.Value;

                DataSet dados = part.BuscarDados(part);

                this.cpnjpartido.Value = dados.Tables[0].Rows[0]["cnpj"].ToString();
                this.nomepartido.Value = dados.Tables[0].Rows[0]["nome"].ToString();
                this.siglapartido.Value = dados.Tables[0].Rows[0]["sigla"].ToString();
                this.prefixopartido.Text = dados.Tables[0].Rows[0]["prefixo"].ToString();
                this.hiddenpartido.Value = dados.Tables[0].Rows[0]["partidoid"].ToString();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        /// <summary>
        /// Evento de registrar alerta para mensagens ao usuário
        /// </summary>
        /// <param name="msgalerta"></param>
        /// <param name="nomediv"></param>
        /// <param name="nomelabel"></param>
        private void RegistraAlerta(string msgalerta, string nomediv, string nomelabel)
        {
            ((Cadastros)this.Page).RegistraAlerta(msgalerta, nomediv, nomelabel);
        }

        /// <summary>
        /// Verifica se existe algum partido existente com o CNPJ, ou nome, ou prefixo ou a sigla
        /// </summary>
        /// <returns></returns>
        private bool ValidaPartExistente()
        {
            ClassesBanco.Partido validapart = new ClassesBanco.Partido();


            if (this.cpnjpartido.Value == "")
            {
                throw new Exception("CNPJ do partido não informado!");
            }
            else
            {
                if (IsCnpj(this.cpnjpartido.Value))
                {
                    validapart.cnpj = this.cpnjpartido.Value;
                }
                else
                {
                    throw new Exception("CNPJ do partido inválido, favor verificar!");
                }
            }

            if (this.nomepartido.Value == "")
            {
                throw new Exception("Nome do partido não informado!");
            }
            else
            {
                validapart.nome = this.nomepartido.Value;
            }

            if (this.prefixopartido.Text == "")
            {
                throw new Exception("Prefixo do partido não informado!");
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.prefixopartido.Text.ToString(), "^[0-9]"))
                {
                    throw new Exception("Prefixo Deve ser informado apenas com números!");
                }
                else
                {
                    validapart.prefixo = int.Parse(this.prefixopartido.Text);
                }
            }
            if (this.siglapartido.Value == "")
            {
                throw new Exception("Sigla do partido não informado!");
            }
            else
            {
                validapart.sigla = this.siglapartido.Value;
            }

            DataSet dados = validapart.BuscarDadosAlteracao(validapart);
            if (dados.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Método para validar se CNPF é válido
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        private bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        /// <summary>
        /// Monta os valores da tela no objeto para inclusão ou alteração
        /// </summary>
        /// <param name="part"></param>
        private void MontaValoresInclusao(ClassesBanco.Partido part)
        {
            try
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.cpnjpartido.Value.ToString(), "^[0-9]"))
                {
                    throw new Exception("CNPJ Deve ser informado apenas com números!");
                }

                part.cnpj = this.cpnjpartido.Value;
                part.nome = this.nomepartido.Value.ToString();
                part.sigla = this.siglapartido.Value;


                if (!System.Text.RegularExpressions.Regex.IsMatch(this.prefixopartido.Text.ToString(), "^[0-9]"))
                {
                    throw new Exception("Prefixo Deve ser informado apenas com números!");
                }
                else
                {
                    part.prefixo = int.Parse(this.prefixopartido.Text);
                }

                if (part.cnpj == "")
                {
                    throw new Exception("CNPJ não informado!");
                }
                else
                {
                    if (!IsCnpj(part.cnpj))
                    {
                        throw new Exception("CNPJ Deve ser informado apenas com números!");
                    }
                }
                if (part.nome == "")
                {
                    throw new Exception("Nome do partido não informado!");
                }

                if (part.sigla == "")
                {
                    throw new Exception("Sigla não informada!");
                }
                if (part.prefixo == 0)
                {
                    throw new Exception("Número do partido inválido ou não informado!");
                }
                if (this.hiddenpartido.Value != "")
                {
                    part.partidoid = int.Parse(this.hiddenpartido.Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Limpa os campos da tela
        /// </summary>
        private void LimpaTela()
        {
            this.cpnjpartido.Value = "";
            this.nomepartido.Value = "";
            this.siglapartido.Value = "";
            this.prefixopartido.Text = "";
            this.pessigla.Value = "";
        }

        /// <summary>
        /// Valida qual operação será executada no banco de dados, I - Inclusão, A - Alteração
        /// </summary>
        /// <param name="part"></param>
        private void ValidaOperacao(ref ClassesBanco.Partido part)
        {
            if (this.hiddenpartido.Value == "")
            {
                part.ExecutarMetodo('I', part);
            }
            else
            {
                part.ExecutarMetodo('A', part);
            }
        }

    }
}