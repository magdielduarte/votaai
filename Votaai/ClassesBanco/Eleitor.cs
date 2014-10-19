using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace ClassesBanco
{
    public class Eleitor : IMetodosPadroes
    {
        public int eleitorid { get; set; }
        public string nome { get; set; }
        public string tituloeleitor { get; set; }
        public int idade { get; set; }
        public char sexo { get; set; }
        public string estado { get; set; }
        public string zonaeleitoral { get; set; }
        public string secao { get; set; }
        public int votou { get; set; }


        void IMetodosPadroes.Inserir()
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();

                SQL.AppendLine("INSERT INTO ELEITOR");
                SQL.AppendLine("( NOME");
                SQL.AppendLine(", TITULOELEITOR");
                SQL.AppendLine(", IDADE");
                SQL.AppendLine(", SEXO");
                SQL.AppendLine(", ESTADO");
                SQL.AppendLine(", ZONAELEITORAL");
                SQL.AppendLine(", SECAO");
                SQL.AppendLine(", VOTOU )");
                SQL.AppendLine("VALUES");
                SQL.AppendLine(string.Format("('{0}'", this.nome));
                SQL.AppendLine(string.Format("'{0}'", this.tituloeleitor));
                SQL.AppendLine(string.Format("{0}", this.idade));
                SQL.AppendLine(string.Format("'{0}'", this.sexo));
                SQL.AppendLine(string.Format("'{0}'", this.estado));
                SQL.AppendLine(string.Format("'{0}'", this.zonaeleitoral));
                SQL.AppendLine(string.Format("'{0}'", this.secao));
                SQL.AppendLine(string.Format("{0})", this.votou));
            }
            catch (Exception ex)
            {

            }

        }

        void IMetodosPadroes.Alterar()
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();

                SQL.AppendLine("UPDATE ELEITOR");
                SQL.AppendLine(string.Format("SET NOME = '{0}'", this.nome));
                SQL.AppendLine(string.Format(", TITULOELEITOR  = '{0}'", this.tituloeleitor));
                SQL.AppendLine(string.Format(", IDADE = {0}", this.idade));
                SQL.AppendLine(string.Format(", SEXO = '{0}'", this.sexo));
                SQL.AppendLine(string.Format(", ESTADO = '{0}'", this.estado));
                SQL.AppendLine(string.Format(", ZONAELEITORAL = '{0}'", this.zonaeleitoral));
                SQL.AppendLine(string.Format(", SECAO = '{0}'", this.secao));
                SQL.AppendLine(string.Format(", VOTOU = {0}", this.votou));
                SQL.AppendLine(string.Format("WHERE ELEITORID = {0}", this.eleitorid));
            }
            catch (Exception ex)
            {

            }

        }

        void IMetodosPadroes.Excluir()
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();

                SQL.AppendLine("DELETE FROM ELEITOR");
                SQL.AppendLine(string.Format("WHERE ELEITORID={0}", this.eleitorid));
            }
            catch (Exception ex)
            {

            }
        }

        DataSet IMetodosPadroes.Busca()
        {
            DataSet puta = new DataSet();
            return puta;
        }
    }
}
