using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesBanco
{
    public class Candidato : IMetodosPadroes
    {
        public int candidatoid { get; set; }
        public string nome { get; set; }
        public int numero { get; set; }
        public string vice { get; set; }
        public string cargo { get; set; }
        public string foto { get; set; }
        public int partidoid { get; set; }


        bool IMetodosPadroes.Inserir(ref ClassesConexao.Conexao objConexao)
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();
                SQL.AppendLine("INSERT INTO CANDIDATO");
                SQL.AppendLine("( NOME");
                SQL.AppendLine(", NUMERO");
                SQL.AppendLine(", VICE");
                SQL.AppendLine(", CARGO");
                SQL.AppendLine(", FOTO");
                SQL.AppendLine(", PARTIDOID )");
                SQL.AppendLine("VALUES");
                SQL.AppendLine(string.Format("('{0}'", this.nome));
                SQL.AppendLine(string.Format("{0}", this.numero));
                SQL.AppendLine(string.Format("'{0}'", this.vice));
                SQL.AppendLine(string.Format("'{0}'", this.cargo));
                SQL.AppendLine(string.Format("'{0}'", this.foto));
                SQL.AppendLine(string.Format("{0})", this.partidoid));

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


                SQL.AppendLine("UPDATE CANDIDATO");
                SQL.AppendLine(string.Format("SET NOME = '{0}'", this.nome));
                SQL.AppendLine(string.Format(", NUMERO  = {0}", this.numero));
                SQL.AppendLine(string.Format(", VICE = '{0}'", this.vice));
                SQL.AppendLine(string.Format(", CARGO = '{0}'", this.cargo));
                SQL.AppendLine(string.Format(", FOTO = '{0}'", this.foto));
                SQL.AppendLine(string.Format(", PARTIDOID = {0}", this.partidoid));
                SQL.AppendLine(string.Format("WHERE CANDIDATOID = {0}", this.candidatoid));
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

                SQL.AppendLine("DELETE FROM CANDIDATO");
                SQL.AppendLine(string.Format("WHERE CANDIDATOID={0}", this.candidatoid));

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
