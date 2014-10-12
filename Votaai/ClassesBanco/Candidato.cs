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
