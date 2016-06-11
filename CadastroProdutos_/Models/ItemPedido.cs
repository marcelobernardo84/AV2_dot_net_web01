using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroProdutos_.Models
{
    public class ItemPedido
    {
        public int ItemPedidoId { get; set; }
        public int PedidoId { get; set; }

        public int Quantidade { get; set; }
        public int ClientId { get; set; }
        public int ProdutoId { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}