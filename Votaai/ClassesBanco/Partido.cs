using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using ClassesConexao;

namespace ClassesBanco
{
    public class Partido : IMetodosPadroes
    {
        //Propriedades da classe de partido
        public int partidoid { get; set; }
        public string cnpj { get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }
        public int prefixo { get; set; }

        Conexao conexao = new Conexao();

        /// <summary>
        /// Insere um partido
        /// </summary>
        void IMetodosPadroes.Inserir()
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();

                SQL.AppendLine("INSERT INTO PARTIDO");
                SQL.AppendLine("( CNPJ");
                SQL.AppendLine(", NOME");
                SQL.AppendLine(", SIGLA");
                SQL.AppendLine(", PREFIXO)");

                SQL.AppendLine("VALUES");
                SQL.AppendLine(string.Format("('{0}'", this.cnpj));
                SQL.AppendLine(string.Format(",'{0}'", this.nome));
                SQL.AppendLine(string.Format(",'{0}'", this.sigla));
                SQL.AppendLine(string.Format(",{0})", this.prefixo));

                conexao.ExecutaComando(SQL.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Alterar partido
        /// </summary>
        void IMetodosPadroes.Alterar()
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

                conexao.ExecutaComando(SQL.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Excluir um partido
        /// </summary>
        void IMetodosPadroes.Excluir()
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();

                SQL.AppendLine("DELETE FROM PARTIDO");
                SQL.AppendLine(string.Format("WHERE PARTIDOID={0}", this.partidoid));

                conexao.ExecutaComando(SQL.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Buscas 
        /// </summary>
        /// <returns>um dataset</returns>
        DataSet IMetodosPadroes.Busca()
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();

                SQL.AppendLine("SELECT * FROM PARTIDO");

                SQL.AppendLine("WHERE (1 = 1)");

                if (this.cnpj != null)
                    SQL.AppendLine(string.Format(" AND cnpj = '{0}'", this.cnpj));
                if (this.nome != null)
                    SQL.AppendLine(string.Format(" AND nome = '{0}'", this.nome));
                if (this.prefixo != 0)
                    SQL.AppendLine(string.Format(" AND prefixo = {0}", this.prefixo));
                if (this.sigla != null)
                    SQL.AppendLine(string.Format(" AND sigla = '{0}'", this.sigla));
                if (this.partidoid != null && this.partidoid != 0)
                    SQL.AppendLine(string.Format(" AND partidoid = {0}", this.partidoid));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return conexao.BuscaDados(SQL.ToString());
        }

        DataSet BuscaDadosInsert()
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();

                SQL.AppendLine("SELECT * FROM PARTIDO");

                SQL.AppendLine("WHERE (1 = 1)");

                if (this.cnpj != null)
                    SQL.AppendLine(string.Format(" or cnpj = '{0}'", this.cnpj));
                if (this.nome != null)
                    SQL.AppendLine(string.Format(" or nome = '{0}'", this.nome));
                if (this.prefixo != 0)
                    SQL.AppendLine(string.Format(" or prefixo = {0}", this.prefixo));
                if (this.sigla != null)
                    SQL.AppendLine(string.Format(" or sigla = '{0}'", this.sigla));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return conexao.BuscaDados(SQL.ToString());
        }


        /// <summary>
        /// Método que da acesso a parte visual do software, ao passar alguma opção:
        /// I - Inserir, E - Excluir, A - Alterar
        /// </summary>
        /// <param name="option">Opção passada pelo usuário</param>
        public void ExecutarMetodo(char option, Partido part)
        {
            //Usuário implementa a interface de metodos padrões
            IMetodosPadroes metodos = part;

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
        public DataSet BuscarDados(Partido part)
        {
            IMetodosPadroes metodos = part;

            if (conexao == null)
                conexao = new Conexao();

            return metodos.Busca();
        }

        public DataSet BuscarDadosAlteracao(Partido part)
        {


            if (conexao == null)
                conexao = new Conexao();

            return part.BuscaDadosInsert();
        }

    }
}
