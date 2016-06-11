using CadastroProdutos_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroProdutos_.DAL
{
    public class ControleDePedidosDbInitialize : System.Data.Entity.
        DropCreateDatabaseIfModelChanges<ControleDePedidosDbContext>
    {
        protected override void Seed(ControleDePedidosDbContext context)
        {
            var produtos = new List<Produto>
            {
                new Produto {Valor=15,Nome="Chinelo", Marca="Havaianas", Estoque=20 },
                new Produto {Valor=25,Nome="Bola de futebol", Marca="nike", Estoque=30 },
                new Produto {Valor=60,Nome="Bola de basquete", Marca="adidas", Estoque=50 },
                new Produto {Valor=30,Nome="Bola de Volei", Marca="rebook", Estoque=10 }
            };

            produtos.ForEach(s => context.Produtos.Add(s));
            context.SaveChanges();
        }
    }
}