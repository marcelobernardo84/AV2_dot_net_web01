using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroProdutos_.Models
{
    public enum Status
    {
        Solicitado,
        Enviado,
        Entregue,
        Cancelado
    }

    public class Pedido
    {
        public int PedidoId { get; set; }
        public Status? Status { get; set; }
        public DateTime DataPedido { get; set; }
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual ItemPedido ItemPedido { get; set; }
    }
}