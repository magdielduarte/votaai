using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesBanco
{
    public class Partido : IMetodosPadroes
    {
        public int partidoid { get; set; }
        public string cnpj { get; set; }
        public int nome { get; set; }
        public string sigla { get; set; }
        public int prefixo { get; set; }

        bool IMetodosPadroes.Inserir(ref ClassesConexao.Conexao objConexao)
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();

                SQL.AppendLine("INSERT INTO PARTIDO");
                SQL.AppendLine("( CNPJ");
                SQL.AppendLine(", NOME");
                SQL.AppendLine(", SIGLA");
                SQL.AppendLine(", PREFIXO");

                SQL.AppendLine("VALUES");
                SQL.AppendLine(string.Format("('{0}'", this.cnpj));
                SQL.AppendLine(string.Format("'{0}'", this.nome));
                SQL.AppendLine(string.Format("'{0}'", this.sigla));
                SQL.AppendLine(string.Format("{0})", this.prefixo));
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            return true;
        }

        bool IMetodosPadroes.Alterar(ref ClassesConexao.Conexao objConexao)
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();

                SQL.AppendLine("UPDATE PARTIDO");
                SQL.AppendLine(string.Format("SET CNPJ = '{0}'", this.cnpj));
                SQL.AppendLine(string.Format(", NOME  = '{0}'", this.nome));
                SQL.AppendLine(string.Format(", SIGLA = '{0}'", this.sigla));
                SQL.AppendLine(string.Format(", PREFIXO = {0}", this.prefixo));
                SQL.AppendLine(string.Format("WHERE PARTIDOID = {0}", this.partidoid));

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            return true;
        }

        bool IMetodosPadroes.Excluir(ref ClassesConexao.Conexao objConexao)
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();

                SQL.AppendLine("DELETE FROM PARTIDO");
                SQL.AppendLine(string.Format("WHERE PARTIDOID={0}", this.partidoid));
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            return true;
        }
    }
}
