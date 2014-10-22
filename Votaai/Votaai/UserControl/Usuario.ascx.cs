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
            }
            catch (Exception ex)
            { 
            
            }
        }

        private void LimpaTela()
        {
            this.userlogin.Value = "";
            this.usersenha.Value = "";
            this.usersenharepitida.Value = "";
        }

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

        private void MontaDadosInclusão(ClassesBanco.Usuario usu)
        {
            usu.login = this.userlogin.Value;
            if (this.hiddenusuario.Value != "")
            {
                usu.usuarioid = int.Parse(this.hiddenusuario.Value);
            }
            ValidarSenha(ref usu);
        }

        protected void BtnCanUsu_Click(object sender, EventArgs e)
        {
            LimpaTela();
        }
        #endregion

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

        private void ValidarSenha(ref ClassesBanco.Usuario usu)
        {


            if (this.usersenha.Value.ToString().GetHashCode() != this.usersenharepitida.Value.ToString().GetHashCode())
            {
                //Lançar exceção de senha diferente

            }
            else
            {
                usu.senha = this.usersenha.Value.ToString().GetHashCode();
            }

        }

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