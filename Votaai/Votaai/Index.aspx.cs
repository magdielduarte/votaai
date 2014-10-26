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

        protected void Page_Load(object sender, EventArgs e)
        {
            this.IdUsuLogado.InnerText = Session["UsuLogin"].ToString();

            Increment();
            MontaGrafico();
        }

        private void MontaGrafico()
        {
            ClassesBanco.Voto voto = new ClassesBanco.Voto();
            DataSet dados = voto.BuscarDadosAlteracao(voto, this.selectcargo.SelectedValue);
            dados.Tables[0].NewRow();
            GeraScriptGrafico(dados);

        }

        /// <summary>
        /// Geração de Gráfico com valores lidos dos candidatos
        /// </summary>
        /// <param name="dados"></param>
        private void GeraScriptGrafico(DataSet dados)
        {
            string nomes = "";
            string valores = "";
            System.Text.StringBuilder txt = new System.Text.StringBuilder();
            for (int i = 0; i < dados.Tables[0].Rows.Count; i++)
            {
                if (i == dados.Tables[0].Rows.Count - 1)
                {
                    nomes = "'" + dados.Tables[0].Rows[i]["NomeCandidato"].ToString() + "'";
                    valores = "'" + dados.Tables[0].Rows[i]["QtdVotos"].ToString() + "'";
                }
                else
                {
                    nomes = "'" + dados.Tables[0].Rows[i]["NomeCandidato"].ToString() + "';";
                    valores = "'" + dados.Tables[0].Rows[i]["QtdVotos"].ToString() + "';";

                }
            }

            txt.AppendLine("var barChartData = {");
            txt.AppendLine("labels: [" + nomes + "],");
            txt.AppendLine("datasets: [");
            txt.AppendLine("{");
            txt.AppendLine("fillColor: 'rgba(151,187,205,0.5)',");
            txt.AppendLine("strokeColor: 'rgba(151,187,205,1)',");
            txt.AppendLine("data: [" + valores + "]");
            txt.AppendLine("}");
            txt.AppendLine("]");

            txt.AppendLine("}");
            txt.AppendLine("            var myLine = new Chart(document.getElementById('bar_chart').getContext('2d')).Bar(barChartData);");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "scriptchart", txt.ToString(), true);

        }
        /// <summary>
        /// Geração de contador de valores animado
        /// </summary>
        private void Increment()
        {

            System.Text.StringBuilder txt = new System.Text.StringBuilder();
            txt.AppendLine("var qtdcadastro = " + (this.qtdcadastro + 1).ToString() + ";");
            txt.AppendLine("var qtdvotos = " + (this.qtdvotos + 1).ToString() + ";");
            txt.AppendLine("var qtdpercent = " + (this.percent + 1).ToString() + ";");
            txt.AppendLine("");
            txt.AppendLine("");

            txt.AppendLine("$({ numberValue: 0 }).animate({ numberValue:qtdcadastro}, {");
            txt.AppendLine("                duration: 2000,");
            txt.AppendLine("                easing: 'linear',");
            txt.AppendLine("                step: function () {");
            txt.AppendLine("                    $('#qtd-cadastro').text(parseInt(this.numberValue));");
            txt.AppendLine("                }");
            txt.AppendLine("            });");

            txt.AppendLine("$({ numberValue: 0 }).animate({ numberValue:qtdvotos}, {");
            txt.AppendLine("                duration: 2000,");
            txt.AppendLine("                easing: 'linear',");
            txt.AppendLine("                step: function () {");
            txt.AppendLine("                    $('#qtd-votos').text(parseInt(this.numberValue));");
            txt.AppendLine("                }");
            txt.AppendLine("            });");

            txt.AppendLine("$({ numberValue: 0 }).animate({ numberValue:qtdpercent}, {");
            txt.AppendLine("                duration: 2000,");
            txt.AppendLine("                easing: 'linear',");
            txt.AppendLine("                step: function () {");
            txt.AppendLine("                    $('#qtd-percent').text(parseInt(this.numberValue));");
            txt.AppendLine("                }");
            txt.AppendLine("            });");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "increment", txt.ToString(), true);
        }
        /// <summary>
        /// Evento de Combo para gerar novo gráfico de novos candidato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void selectcargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MontaGrafico();
        }

        /// <summary>
        /// Load do gráfico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bar_chart_Load(object sender, EventArgs e)
        {
            MontaGrafico();

        }
    }
}