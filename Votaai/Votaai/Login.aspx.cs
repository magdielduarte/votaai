using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Votaai
{
    public partial class Login : System.Web.UI.Page
    {
        private bool clicklgn = false;
        
        /// <summary>
        /// Load da página de Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!clicklgn)
            {
                Session["UsuLogin"] = null;
            }
        }

        /// <summary>
        /// Função de alerta para mensagem ao usuário
        /// </summary>
        /// <param name="msgalerta"></param>
        /// <param name="nomediv"></param>
        public void RegistraAlerta(string msgalerta, string nomediv)
        {
            lbldanger.Text = msgalerta;
            ScriptManager.RegisterStartupScript(this, GetType(), "sucess", string.Format("ativadiv('{0}');", nomediv), true);
        }

        /// <summary>
        /// Click do botão de login, efetuando a entrada no sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.clicklgn = true;
                ClassesBanco.Usuario usu = new ClassesBanco.Usuario();
                MontarDadosBusca(usu);

                if (MontarDadosBusca(usu))
                {
                    Session["UsuLogin"] = usu.login;
                    Response.Redirect("Index.aspx");
                }
            }

            catch (Exception ex)
            {
                this.clicklgn = false;
                RegistraAlerta("Usuário ou senha inválida", "le-alert");
            }
        }

        /// <summary>
        /// Verifica se usuário existe no sistema, com a senha correta
        /// </summary>
        /// <param name="usu"></param>
        /// <returns></returns>
        private bool MontarDadosBusca(ClassesBanco.Usuario usu)
        {
            DataSet dados;

            usu.login = this.username.Value.ToString();
            usu.senha = this.password.Value.ToString().GetHashCode();

            dados = usu.BuscarDados(usu);

            if (dados.Tables[0].Rows.Count == 0)
            {
                throw new Exception("Usuário ou senha inválida!");
            }
            else
            {
                return true;
            }

        }
    }
}