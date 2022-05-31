using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace AppListaSupermercado.Model
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Valor_Estimado { get; set; }
        public string Valor_Pago { get; set; }
    }
}
