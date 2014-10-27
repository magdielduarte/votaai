using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Votaai.UserControl
{
    public partial class Usuario : System.Web.UI.UserControl
    {
        #region Operações tela

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento de botão de cadastro de usuário, para efetuar o cadastro de um usuário no sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCadUsu_Click(object sender, EventArgs e)
        {
            ClassesBanco.Usuario usu = new ClassesBanco.Usuario();
            try
            {
                if (this.hiddenusuario.Value == "")
                {
                    if (!ValidaUsuExistente())
                    {
                        MontaDadosInclusão(usu);
                        ValidaOperacao(ref usu);
                    }
                    else
                    {
                        throw new Exception("Já existe um usuário com esse login, favor escolha outro!");
                    }
                }
                else
                {
                    MontaDadosInclusão(usu);
                    ValidaOperacao(ref usu);

                }

                LimpaTela();
                RegistraAlerta("Seus Dados Foram Salvos Com Sucesso!", "le-sucess", "LblSucess");

            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("formato incorreto!"))
                {

                }
                else
                {
                    RegistraAlerta(ex.Message.ToString(), "le-alert", "lbldanger");
                }
            }
        }

        /// <summary>
        /// Registro de alerta, mandando a mensagem e qual div deverá ser exibida para a tela pai
        /// </summary>
        /// <param name="msgalerta"></param>
        /// <param name="nomediv"></param>
        /// <param name="nomelabel"></param>
        private void RegistraAlerta(string msgalerta, string nomediv, string nomelabel)
        {
            ((Cadastros)this.Page).RegistraAlerta(msgalerta, nomediv, nomelabel);
        }

        /// <summary>
        /// Limpa os campos da tela, caso o botão de cancelar seja clicado
        /// </summary>
        private void LimpaTela()
        {
            this.userlogin.Value = "";
            this.usersenha.Value = "";
            this.usersenharepitida.Value = "";
        }

        /// <summary>
        /// Verifica se existe algum usuário com o login informado
        /// </summary>
        /// <returns></returns>
        private bool ValidaUsuExistente()
        {
            ClassesBanco.Usuario pesusu = new ClassesBanco.Usuario();
            pesusu.login = this.userlogin.Value;
            DataSet dados = pesusu.BuscarDados(pesusu);
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
        /// Monta os dados para inclusão de usuário
        /// </summary>
        /// <param name="usu"></param>
        private void MontaDadosInclusão(ClassesBanco.Usuario usu)
        {
            try
            {
                usu.login = this.userlogin.Value;
                if (usu.login == "")
                {
                    throw new Exception("Usuário não informado!");
                }
                if (this.hiddenusuario.Value != "")
                {
                    usu.usuarioid = int.Parse(this.hiddenusuario.Value);
                }

                if (this.usersenha.Value == "")
                {
                    throw new Exception("Senha não informada!");
                }

                if (this.usersenharepitida.Value == "")
                {
                    throw new Exception("Repetição de Senha não informada");
                }
                ValidarSenha(ref usu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Evento de botão responsável por limpar os campos da tela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCanUsu_Click(object sender, EventArgs e)
        {
            LimpaTela();
        }
        #endregion

        /// <summary>
        /// Valida qual operação será executada no banco de dados
        /// </summary>
        /// <param name="usu"></param>
        private void ValidaOperacao(ref ClassesBanco.Usuario usu)
        {
            if (this.idhidden.Value == "")
            {
                usu.ExecutarMetodo('I', usu);
            }
            else
            {
                usu.ExecutarMetodo('A', usu);
            }
        }

        /// <summary>
        /// valida se as senhas informadas correspondem
        /// </summary>
        /// <param name="usu"></param>
        private void ValidarSenha(ref ClassesBanco.Usuario usu)
        {
            try
            {
                if (this.usersenha.Value.ToString().GetHashCode() != this.usersenharepitida.Value.ToString().GetHashCode())
                {
                    //Lançar exceção de senha diferente
                    throw new Exception("Senhas não correspondem!");

                }
                else
                {
                    usu.senha = this.usersenha.Value.ToString().GetHashCode();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Pesquisa um usuário cadastrado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            ClassesBanco.Usuario usu = new ClassesBanco.Usuario();
            usu.login = this.peslogin.Value;

            DataSet dados = usu.BuscarDados(usu);

            this.userlogin.Value = dados.Tables[0].Rows[0]["login"].ToString();
            this.hiddenusuario.Value = dados.Tables[0].Rows[0]["usuarioid"].ToString();
        }

    }
}