using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace ClassesBanco
{
    public class Voto : IMetodosPadroes
    {
        public int votoid { get; set; }
        public string estadoeleitor { get; set; }
        public int idadeeleitor { get; set; }
        public char sexoeleitor { get; set; }
        public string zonaeleitor { get; set; }
        public string secaoeleitor { get; set; }
        public int candidatoid { get; set; }

        void IMetodosPadroes.Inserir()
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();

                SQL.AppendLine("INSERT INTO VOTO");
                SQL.AppendLine("( ESTADOELEITOR");
                SQL.AppendLine(", IDADEELEITOR");
                SQL.AppendLine(", SEXOELEITOR");
                SQL.AppendLine(", ZONAELEITOR");
                SQL.AppendLine(", SECAOELEITOR");
                SQL.AppendLine(", CANDIDATOID");

                SQL.AppendLine("VALUES");
                SQL.AppendLine(string.Format("('{0}'", this.estadoeleitor));
                SQL.AppendLine(string.Format("{0}", this.idadeeleitor));
                SQL.AppendLine(string.Format("'{0}'", this.sexoeleitor));
                SQL.AppendLine(string.Format("{0})", this.zonaeleitor));
                SQL.AppendLine(string.Format("'{0}'", this.secaoeleitor));
                SQL.AppendLine(string.Format("{0}", this.candidatoid));
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

                SQL.AppendLine("UPDATE VOTO");
                SQL.AppendLine(string.Format("SET ESTADOELEITOR = '{0}'", this.estadoeleitor));
                SQL.AppendLine(string.Format(", IDADEELEITOR  = {0}", this.idadeeleitor));
                SQL.AppendLine(string.Format(", SEXOELEITOR = '{0}'", this.secaoeleitor));
                SQL.AppendLine(string.Format(", ZONAELEITOR = '{0}'", this.zonaeleitor));
                SQL.AppendLine(string.Format(", SECAOELEITOR = '{0}'", this.secaoeleitor));
                SQL.AppendLine(string.Format(", CANDIDATOID = {0}", this.candidatoid));
                SQL.AppendLine(string.Format("WHERE VOTOID = {0}", this.votoid));

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

                SQL.AppendLine("DELETE FROM VOTO");
                SQL.AppendLine(string.Format("WHERE VOTOID={0}", this.votoid));
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
