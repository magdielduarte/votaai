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
        private decimal percent = 0;

        /// <summary>
        /// Evento de Load da página principal, montando os valores no contador, e o gráfico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuLogin"] != null)
            {
                this.IdUsuLogado.InnerHtml = Session["UsuLogin"].ToString();

                ValidaDivs();
                BuscaDadosCadastros();
                Increment();
                MontaGrafico();

            }
            else
            {
                Session["UsuLogin"] = null;
                Response.Redirect("Login.aspx");
            }
        }

        /// <summary>
        /// Busca os dados de cadastro de eleitores, quantidade de eleitores que votaram, e o percentual de eleitores que votaram
        /// </summary>
        private void BuscaDadosCadastros()
        {
            DataSet dados;

            ClassesBanco.Eleitor ele = new ClassesBanco.Eleitor();
            dados = ele.BuscarDados(ele);
            if (dados.Tables[0].Rows.Count > 0)
            {
                this.qtdcadastro = int.Parse(dados.Tables[0].Rows[0]["TotalCadastro"].ToString());
                this.qtdvotos = int.Parse(dados.Tables[0].Rows[1]["TotalCadastro"].ToString());
                
                if (this.qtdcadastro == 0 || this.qtdvotos == 0)
                {
                    this.percent = 0;
                }
                else
                {
                    this.percent = this.qtdvotos / this.qtdcadastro;
                }
            }
        }

        /// <summary>
        /// Montagem de gráfico, com os 10 mais votados para o cargo e estado escolhido na tela pelo usuário
        /// </summary>
        private void MontaGrafico()
        {
            ClassesBanco.Voto voto = new ClassesBanco.Voto();
            DataSet dados = voto.BuscarDadosAlteracao(voto, this.selectcargo.SelectedValue, this.selectestado.SelectedValue);
            dados.Tables[0].NewRow();
            GeraScriptGrafico(dados);

        }

        /// <summary>
        /// Geração de script de Gráfico com valores lidos dos candidatos
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
                    nomes = nomes + "'" + dados.Tables[0].Rows[i]["NomeCandidato"].ToString() + "'";
                    valores = valores + "" + dados.Tables[0].Rows[i]["QtdVotos"].ToString() + "";
                }
                else
                {
                    nomes = nomes + "'" + dados.Tables[0].Rows[i]["NomeCandidato"].ToString() + "',";
                    valores = valores + "" + dados.Tables[0].Rows[i]["QtdVotos"].ToString() + ",";

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
        /// Load do gráfico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bar_chart_Load(object sender, EventArgs e)
        {
            MontaGrafico();

        }

        /// <summary>
        /// Pesquisa para montagem de gráfico de acordo com critérios escolhidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnPesquisar_Click(object sender, EventArgs e)
        {
            MontaGrafico();
        }

        /// <summary>
        /// Validação de divs na tela, caso o cargo seja presidente, o combo de estado desaparecerá
        /// </summary>
        private void ValidaDivs()
        {
            switch (this.selectcargo.SelectedValue)
            {
                case "1":
                    this.divestado.Style["display"] = "none";
                    break;
                default:
                    this.divestado.Style["display"] = "block";
                    break;
            }

        }

        /// <summary>
        /// Evento de combo de cargo, para esconder os valores de presidente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void selectcargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.selectcargo.SelectedValue == "1")
            {
                this.selectestado.SelectedIndex = 0;
            }
            ValidaDivs();
        }
    }
}