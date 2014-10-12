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
            return true;
        }

        bool IMetodosPadroes.Alterar(ref ClassesConexao.Conexao objConexao)
        {
            return true;
        }

        bool IMetodosPadroes.Excluir(ref ClassesConexao.Conexao objConexao)
        {
            return true;
        }
    }
}
