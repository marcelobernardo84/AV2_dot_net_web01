using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroProdutos_.Models
{
    public class ItemPedido
    {
        public int ItemPedidoId { get; set; }
        public int PedidoId { get; set; }

        public int Quantidade { get; set; }
        [Display(Name = "Cliente")]
        public int ClientId { get; set; }
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}