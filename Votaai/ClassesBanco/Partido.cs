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
