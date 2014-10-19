using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using ClassesConexao;

namespace ClassesBanco
{
    public class Usuario : IMetodosPadroes
    {
        //Propriedades relacionadas com usuário
        public int usuarioid { get; set; }
        public string login { get; set; }
        public int senha { get; set; }

        //Declara um objeto do tipo conexão
        Conexao conexao;

        /// <summary>
        /// 
        /// </summary>
        void IMetodosPadroes.Inserir()
        {
            StringBuilder SQL;
               
            try
            {
                SQL = new StringBuilder();
                if (conexao == null)
                    conexao = new Conexao();

                SQL.AppendLine("INSERT INTO USUARIO");
                SQL.AppendLine("( LOGIN");
                SQL.AppendLine(", SENHA)");

                SQL.AppendLine("VALUES");
                SQL.AppendLine(string.Format("('{0}'", this.login));
                SQL.AppendLine(string.Format("'{0}')", this.senha));

                conexao.ExecutaComando(SQL.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Altera algum usuário
        /// </summary>
        void IMetodosPadroes.Alterar()
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();

                if (conexao == null)
                    conexao = new Conexao();

                SQL.AppendLine("UPDATE USUARIO");
                SQL.AppendLine(string.Format("SET LOGIN = '{0}'", this.login));
                SQL.AppendLine(string.Format(", SIGLA = '{0}'", this.senha));
                SQL.AppendLine(string.Format("WHERE USUARIOID = {0}", this.usuarioid));

                conexao.ExecutaComando(SQL.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Exclui algum usuário, passando o id dele como parametro
        /// </summary>
        void IMetodosPadroes.Excluir()
        {
            StringBuilder SQL;
            try
            {
                SQL = new StringBuilder();
                if (conexao == null)
                    conexao = new Conexao();

                SQL.AppendLine("DELETE FROM USUARIO");
                SQL.AppendLine(string.Format("WHERE USUARIOID={0}", this.usuarioid));

                conexao.ExecutaComando(SQL.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Cria uma lista com todos os usuários disponíveis
        /// </summary>
        DataSet IMetodosPadroes.Busca()
        {
            StringBuilder SQL;

            try
            {
                SQL = new StringBuilder();

                if (conexao == null)
                    conexao = new Conexao();

                SQL.AppendLine("SELECT * FROM usuario");
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
        public void ExecutarMetodo(char option)
        {
            //Usuário implementa a interface de metodos padrões
            IMetodosPadroes metodos = new Usuario();

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
            IMetodosPadroes metodos = new Usuario();

            if (conexao == null)
                conexao = new Conexao();

            return metodos.Busca();
        }

        /// <summary>
        /// Retorna verdadeiro ou falso para o login do usuário
        /// </summary>
        /// <returns>True se o usuário existe, false se não voltar</returns>
        public bool LogarUsuario()
        {
            StringBuilder SQL;
            try
            {
                if (conexao == null)
                    conexao = new Conexao();

                SQL = new StringBuilder();

                SQL.AppendLine("SELECT * FROM");
                SQL.AppendLine(string.Format("WHERE login = {0} AND senha = {1}", this.login, this.senha));

                if (conexao.BuscaDados(SQL.ToString()).Tables[0].Rows.Count > 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
