using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using ClassesConexao;

namespace ClassesBanco
{
    public class Candidato : IMetodosPadroes
    {
        //Propriedades relacionadas a candidatos
        public int candidatoid { get; set; }
        public string nome { get; set; }
        public int numero { get; set; }
        public string vice { get; set; }
        public string cargo { get; set; }
        public string foto { get; set; }
        public int partidoid { get; set; }

        Conexao conexao;

        /// <summary>
        /// Insere um candidato
        /// </summary>
        void IMetodosPadroes.Inserir()
        {
            StringBuilder SQL;
            try
            {
                if (conexao == null)
                    conexao = new Conexao();

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
                if (this.vice == null)
                {
                    SQL.AppendLine(string.Format("NULL"));

                }
                else
                {
                    SQL.AppendLine(string.Format("'{0}'", this.vice));

                }
                SQL.AppendLine(string.Format("'{0}'", this.cargo));
                SQL.AppendLine(string.Format("'{0}'", this.foto));
                SQL.AppendLine(string.Format("{0})", this.partidoid));

                conexao.ExecutaComando(SQL.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Altera um candidato
        /// </summary>
        void IMetodosPadroes.Alterar()
        {
            StringBuilder SQL;
            try
            {
                if (conexao == null)
                    conexao = new Conexao();

                SQL = new StringBuilder();
                SQL.AppendLine("UPDATE CANDIDATO");
                SQL.AppendLine(string.Format("SET NOME = '{0}'", this.nome));
                SQL.AppendLine(string.Format(", NUMERO  = {0}", this.numero));
                SQL.AppendLine(string.Format(", VICE = '{0}'", this.vice));
                SQL.AppendLine(string.Format(", CARGO = '{0}'", this.cargo));
                SQL.AppendLine(string.Format(", FOTO = '{0}'", this.foto));
                SQL.AppendLine(string.Format(", PARTIDOID = {0}", this.partidoid));
                SQL.AppendLine(string.Format("WHERE CANDIDATOID = {0}", this.candidatoid));

                conexao.ExecutaComando(SQL.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Titulo auto-explicativo
        /// </summary>
        void IMetodosPadroes.Excluir()
        {
            StringBuilder SQL;
            try
            {
                if (conexao == null)
                    conexao = new Conexao();

                SQL = new StringBuilder();
                SQL.AppendLine("DELETE FROM CANDIDATO");
                SQL.AppendLine(string.Format("WHERE CANDIDATOID={0}", this.candidatoid));

                conexao.ExecutaComando(SQL.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca dados, de acordo com os dados passados pelo usuário
        /// </summary>
        /// <returns>Um dataset com os usuários</returns>
        DataSet IMetodosPadroes.Busca()
        {
            StringBuilder sql;
            try
            {
                if (conexao == null)
                    conexao = new Conexao();

                sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM CANDIDATO");

                sql.AppendLine("WHERE (1 = 1)");

                if (this.candidatoid != null)
                    sql.AppendLine(string.Format("AND candidatoid = {0}", this.candidatoid));
                if (this.cargo != null)
                    sql.AppendLine(string.Format("AND cargo = {0}", this.cargo));
                if (this.nome != null)
                    sql.AppendLine(string.Format("AND nome = {0}", this.nome));
                if (this.partidoid != null)
                    sql.AppendLine(string.Format("AND partidoid = {0}", this.partidoid));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return conexao.BuscaDados(sql.ToString());
        }

        /// <summary>
        /// Método que da acesso a parte visual do software, ao passar alguma opção:
        /// I - Inserir, E - Excluir, A - Alterar
        /// </summary>
        /// <param name="option">Opção passada pelo usuário</param>
        public void ExecutarMetodo(char option)
        {
            //Usuário implementa a interface de metodos padrões
            IMetodosPadroes metodos = new Candidato();

            switch (option)
            {
                case 'I':
                    metodos.Inserir();
                    break;
                case 'E':
                    metodos.Excluir();
                    break;
                case 'A':
                    metodos.Alterar();
                    break;
                default:
                    throw new Exception("Opção inválida!");
            }
        }

        /// <summary>
        /// Retorna o DataSet da busca
        /// </summary>
        /// <returns>o dataset</returns>
        public DataSet BuscarDados()
        {
            IMetodosPadroes metodos = new Candidato();

            if (conexao == null)
                conexao = new Conexao();

            return metodos.Busca();
        }

    }
}
