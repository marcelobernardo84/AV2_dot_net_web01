using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroProdutos_.Models
{
    public class Cliente
    {
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "Cliente")]
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}