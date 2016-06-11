using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroProdutos_.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public Decimal Valor { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public int Estoque { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}