using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Pedido")]
        public DateTime DataPedido { get; set; }
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual ItemPedido ItemPedido { get; set; }
    }
}