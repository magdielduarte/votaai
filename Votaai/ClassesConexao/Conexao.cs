using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using System.Configuration;

namespace ClassesConexao
{
    public class Conexao
    {
        /// <summary>
        /// Propriedade de string da conexão com o banco de dados
        /// </summary>
        private string ConnectionString
        {
            get
            {
                return @"Driver={SQL Server Native Client 10.0};
                        Server=tcp:td4cr1ttgv.database.windows.net,1433;
                        Database=Votaai;Uid=Votaailgn@td4cr1ttgv;
                        Pwd=VOTAai*1;
                        Encrypt=yes;
                        Connection Timeout=30;";
            }
        }

        /// <summary>
        /// Executa algum comando de inserção, exclusão ou edição
        /// </summary>
        /// <param name="sql">o sql a ser executado</param>
        public void ExecutaComando(string sql)
        { 
            //Usa a classe de conexão apenas nesse bloco
            using(OdbcConnection conn = new OdbcConnection(this.ConnectionString))
            {
                try
                {   
                    //Abre conexão com o servidor de banco
                    conn.Open();
                    //instancia um objeto de comando, passando como parametro o sql e a conexão para o construtor
                    OdbcCommand comm = new OdbcCommand(sql, conn);
                    //Executa o comando
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {   
                    //Atira uma nova excessão, caso dê algum erro
                    throw new Exception(ex.Message);
                }
                finally
                {   
                    //Sempre fechará conexão, independente se der erro ou não
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Executa uma query de busca com retorno de dados
        /// </summary>
        /// <param name="sql">comando sql para aquela ação</param>
        /// <returns>Um dataset contendo os dados buscados</returns>
        public DataSet BuscaDados(string sql)
        {   
            //Instancia um objeto de dataset para retornar
            DataSet dados = new DataSet();

            using(OdbcConnection conn = new OdbcConnection(this.ConnectionString))
            {
                try
                {               
                    //Abre a conexão com o servidor de banco
                    conn.Open();
                    //Cria um objeto de reader do odbc, para retornar dados
                    OdbcDataAdapter read = new OdbcDataAdapter(sql, conn);

                    //Preenche o DataSet instanciado no incio do codigo
                    read.Fill(dados);
                }
                catch (Exception ex)
                {
                    //Lança um erro, caso aconteça
                    throw new Exception(ex.Message);
                }
                finally
                {
                    //Fecha conexão
                    conn.Close();
                }
            }

            return dados;
        }
    }
}
