using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Votaai.UserControl
{
    public partial class Usuario : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCadUsu_Click(object sender, EventArgs e)
        {
            ClassesBanco.Usuario usu = new ClassesBanco.Usuario();
            usu.login = this.userlogin.Value;

            ValidarSenha(ref usu);

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

        protected void BtnCanUsu_Click(object sender, EventArgs e)
        {

        }
    }
}