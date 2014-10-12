using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassesConexao;
namespace ClassesBanco
{
    interface IMetodosPadroes
    {
         bool Inserir(ref Conexao objConexao);
         bool Alterar(ref Conexao objConexao);
         bool Excluir(ref Conexao objConexao);
    }
}
