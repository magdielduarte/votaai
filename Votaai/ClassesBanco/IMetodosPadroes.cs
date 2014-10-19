using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassesConexao;


namespace ClassesBanco
{
    /// <summary>
    /// Interface utilizada para padronizar métodos comuns de CRUD
    /// </summary>
    interface IMetodosPadroes
    {


         void Inserir();
         void Alterar();
         void Excluir();
         DataSet Busca();
    }
}
