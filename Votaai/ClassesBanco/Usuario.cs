using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesConexao;
using ClassesConexao;

namespace ClassesBanco
{
    public class Usuario : IMetodosPadroes
    {
        public int usuarioid { get; set; }
        public string login { get; set; }
        public int senha { get; set; }


        bool IMetodosPadroes.Inserir(ref ClassesConexao.Conexao objConexao)
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();

                SQL.AppendLine("INSERT INTO USUARIO");
                SQL.AppendLine("( LOGIN");
                SQL.AppendLine(", SENHA)");

                SQL.AppendLine("VALUES");
                SQL.AppendLine(string.Format("('{0}'", this.login));
                SQL.AppendLine(string.Format("'{0}')", this.senha));
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

                SQL.AppendLine("UPDATE USUARIO");
                SQL.AppendLine(string.Format("SET LOGIN = '{0}'", this.login));
                SQL.AppendLine(string.Format(", SIGLA = '{0}'", this.senha));
                SQL.AppendLine(string.Format("WHERE USUARIOID = {0}", this.usuarioid));
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

                SQL.AppendLine("DELETE FROM USUARIO");
                SQL.AppendLine(string.Format("WHERE ELEITORID={0}", this.usuarioid));
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
