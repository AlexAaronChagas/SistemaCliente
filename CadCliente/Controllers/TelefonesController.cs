using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadCliente.Context;
using CadCliente.Models;

namespace CadCliente.Controllers
{
    public class TelefonesController : Controller
    {
        private TelefoneContext db = new TelefoneContext();

        // GET: Telefones
        public ActionResult Index()
        {
            var telefones = db.Telefone.Include(t => t.Cliente);
            return View(telefones.ToList());
        }

        // GET: Telefones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefones telefones = db.Telefone.Find(id);
            if (telefones == null)
            {
                return HttpNotFound();
            }
            return View(telefones);
        }

        // GET: Telefones/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            return View();
        }

        // POST: Telefones/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Telefone,ClienteId")] Telefones telefones)
        {
            if (ModelState.IsValid)
            {
                //telefones.TelefoneId = 1;
                db.Telefone.Add(telefones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", telefones.ClienteId);
            return View(telefones);
        }

        // GET: Telefones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefones telefones = db.Telefone.Find(id);
            if (telefones == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", telefones.ClienteId);
            return View(telefones);
        }

        // POST: Telefones/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Telefone,ClienteId")] Telefones telefones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", telefones.ClienteId);
            return View(telefones);
        }

        // GET: Telefones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefones telefones = db.Telefone.Find(id);
            if (telefones == null)
            {
                return HttpNotFound();
            }
            return View(telefones);
        }

        // POST: Telefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefones telefones = db.Telefone.Find(id);
            db.Telefone.Remove(telefones);
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
