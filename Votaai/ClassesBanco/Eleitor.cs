using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesBanco
{
    public class Eleitor : IMetodosPadroes
    {
        public int eleitorid { get; set; }
        public string nome { get; set; }
        public string tituloeleitor { get; set; }
        public int idade { get; set; }
        public char sexo { get; set; }
        public string estado { get; set; }
        public string zonaeleitoral { get; set; }
        public string secao { get; set; }
        public int votou { get; set; }


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
