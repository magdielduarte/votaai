using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesBanco
{
    public class Voto : IMetodosPadroes
    {
        public int votoid { get; set; }
        public string estadoeleitor { get; set; }
        public int idadeeleitor { get; set; }
        public char sexoeleitor { get; set; }
        public string zonaeleitor { get; set; }
        public string secaoeleitor { get; set; }
        public int candidatoid { get; set; }

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
