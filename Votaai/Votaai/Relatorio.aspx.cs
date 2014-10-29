using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassesBanco;

namespace Votaai
{
    public partial class Relatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Irá pegar o parâmetro passado pela URL
            string parametro = Request.QueryString["filtro"];

            //Faz um switch 
            switch (parametro) 
            { 
                case "estado":
                    filtroEstado.Style["display"] = "block";
                    break;
                case "sexo":
                    filtroSexo.Style["display"] = "block";
                    break;
                case "secao":
                    filtroSecao.Style["display"] = "block";
                    break;
                case "zona":
                    filtroZona.Style["display"] = "block";
                    break;
                default:
                    filtroErro.Style["display"] = "block";
                    confirma.Style["display"] = "none";
                    break;
            }
        }

        protected void BtnGerarRelatorio_Click(object sender, EventArgs e)
        {
            DataSet dados = new DataSet();
            Voto votos = new Voto();
            string obj = "";

            //Irá pegar o parâmetro passado pela URL
            string parametro = Request.QueryString["filtro"];

            dynamic[] campos = {presidente, senador, governador, federal, estadual};

            switch (parametro)
            { 
                case "estado":
                   obj = selectestado.SelectedItem.Value;
                    break;
                case "sexo":
                    obj = selectsexo.SelectedItem.Value;
                    break;
                case "zona":
                    obj = txtZona.Text;
                    break;
                case "secao":
                    obj = txtSecao.Text;
                    break;
            }

            for (int i = 1; i <= 5; i++)
            {
                dados = votos.Relatorio(obj, i, parametro);

                for (int j = 0; j < dados.Tables[0].Rows.Count; j++)
                {
                    campos[i - 1].Text += dados.Tables[0].Rows[j]["nome"].ToString() + ": " + dados.Tables[0].Rows[j]["votos"].ToString() + " Votos";
                    if(i != 1)
                        campos[i - 1].Text += string.Format("- {0}", dados.Tables[0].Rows[j]["estado"].ToString());

                    campos[i - 1].Text += "<br />";
                }
            }

            resposta.Style["display"] = "block";
            confirma.Style["display"] = "none";
        }
    }
}