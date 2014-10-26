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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!clicklgn)
            {
                Session["UsuLogin"] = null;
            }
        }

        public void RegistraAlerta(string msgalerta, string nomediv)
        {
            lbldanger.Text = msgalerta;
            ScriptManager.RegisterStartupScript(this, GetType(), "sucess", string.Format("ativadiv('{0}')", nomediv), true);
        }

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