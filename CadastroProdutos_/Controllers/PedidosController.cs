using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadastroProdutos_.DAL;
using CadastroProdutos_.Models;

namespace CadastroProdutos_.Controllers
{
    public class PedidosController : Controller
    {
        private ControleDePedidosDbContext db = new ControleDePedidosDbContext();

        // GET: Pedidos
        public ActionResult Index()
        {
            var pedidos = db.Pedidos.Include(p => p.Cliente).Include(p => p.Produto);
            return View(pedidos.ToList());
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            var quantidade = db.ItemPedidos.SingleOrDefault(i => i.PedidoId == id);
            ViewBag.ItemPedidoQuantidade = quantidade.Quantidade.ToString();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome");
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PedidoId,Status,DataPedido,ClienteId,ProdutoId")] Pedido pedido, string itemPedidoQuantidade)
        {
            if (ModelState.IsValid)
            {
                ItemPedido item = new ItemPedido();
                db.Pedidos.Add(pedido);
                db.SaveChanges();

                item.Quantidade = Convert.ToInt32(itemPedidoQuantidade);
                item.ClientId = pedido.ClienteId;
                item.ProdutoId = pedido.ProdutoId;
                var query = from p in db.Pedidos.OrderByDescending(p => p.PedidoId)
                            select new { Pedido = p.PedidoId };
                var result = query.ToList();
                foreach (var pedidoid in result)
                {
                    item.PedidoId = pedidoid.Pedido;
                    break;
                }

                db.ItemPedidos.Add(item);
                db.SaveChanges();
                
                return RedirectToAction("Index");
                
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", pedido.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome", pedido.ProdutoId);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            var quantidade = db.ItemPedidos.SingleOrDefault(i => i.PedidoId == id);
            ViewBag.ItemPedidoQuantidade = quantidade.Quantidade.ToString();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", pedido.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome", pedido.ProdutoId);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PedidoId,Status,DataPedido,ClienteId,ProdutoId")] Pedido pedido, string itemPedidoQuantidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                ItemPedido item = db.ItemPedidos.SingleOrDefault(i => i.PedidoId == pedido.PedidoId);
                item.Quantidade = Convert.ToInt32(itemPedidoQuantidade);
                item.ClientId = pedido.ClienteId;
                item.ProdutoId = pedido.ProdutoId;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Nome", pedido.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "ProdutoId", "Nome", pedido.ProdutoId);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            var quantidade = db.ItemPedidos.SingleOrDefault(i => i.PedidoId == id);
            ViewBag.ItemPedidoQuantidade = quantidade.Quantidade.ToString();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            ItemPedido item = db.ItemPedidos.SingleOrDefault(i => i.PedidoId == id);
            db.Pedidos.Remove(pedido);
            db.ItemPedidos.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
