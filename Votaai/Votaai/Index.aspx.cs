using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Votaai
{
    public partial class Index : System.Web.UI.Page
    {
        private int qtdvotos = 0;
        private int qtdcadastro = 0;
        private int percent = 0;
        protected void Page_Unload(object sender, EventArgs e)
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            Increment();
            MontaGrafico();
        }

        private void MontaGrafico()
        {
            ClassesBanco.Voto voto = new ClassesBanco.Voto();
            DataSet dados = voto.BuscarDadosAlteracao(voto, this.selectcargo.SelectedValue);
            dados.Tables[0].NewRow();
            this.bar_chart.DataSource = dados;
            this.bar_chart.DataBind();
        }
        private void Increment()
        {

            System.Text.StringBuilder txt = new System.Text.StringBuilder();

            txt.AppendLine("$({ numberValue: 0 }).animate({ numberValue:" + this.qtdcadastro.ToString() + "}, {");
            txt.AppendLine("                duration: 2000,");
            txt.AppendLine("                easing: 'linear',");
            txt.AppendLine("                step: function () {");
            txt.AppendLine("                    $('#qtd-cadastro').text(parseInt(this.numberValue));");
            txt.AppendLine("                }");
            txt.AppendLine("            });");

            txt.AppendLine("$({ numberValue: 0 }).animate({ numberValue:" + this.qtdvotos.ToString() + "}, {");
            txt.AppendLine("                duration: 2000,");
            txt.AppendLine("                easing: 'linear',");
            txt.AppendLine("                step: function () {");
            txt.AppendLine("                    $('#qtd-votos').text(parseInt(this.numberValue));");
            txt.AppendLine("                }");
            txt.AppendLine("            });");

            txt.AppendLine("$({ numberValue: 0 }).animate({ numberValue:" + this.percent.ToString() + "}, {");
            txt.AppendLine("                duration: 2000,");
            txt.AppendLine("                easing: 'linear',");
            txt.AppendLine("                step: function () {");
            txt.AppendLine("                    $('#qtd-percent').text(parseInt(this.numberValue));");
            txt.AppendLine("                }");
            txt.AppendLine("            });");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "increment", txt.ToString(), true);
        }
        protected void selectcargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MontaGrafico();
        }

        protected void bar_chart_Load(object sender, EventArgs e)
        {
            MontaGrafico();
        }
    }
}