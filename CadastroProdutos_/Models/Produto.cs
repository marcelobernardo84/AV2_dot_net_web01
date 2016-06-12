using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroProdutos_.Models
{
    public class Produto
    {
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }

        public decimal Valor { get; set; }
        [Display(Name = "Produto")]
        public string Nome { get; set; }
        public string Marca { get; set; }
        public int Estoque { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}