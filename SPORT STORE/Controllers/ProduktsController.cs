using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SPORT_STORE.DAL;
using SPORT_STORE.Models;

namespace SPORT_STORE.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ProduktsController : Controller
    {
        private StoreContext db = new StoreContext();
        private string strCart = "cart";

        public ActionResult Index2()
        {
            StoreContext entities = new StoreContext();
            return View(entities.Produkts.ToList());

        }
        [HttpPost]
        public JsonResult SearchProduct(string Emri)
        {
            var produkt = from c in db.Produkts
                          where c.Emri.Contains(Emri)
                          select c;
            return Json(produkt.ToList().Take(10));
        }
        private bool ValidateFile(HttpPostedFileBase imazh)
        {
            string fileExtension = System.IO.Path.GetExtension(imazh.FileName).ToLower();
            string[] allowedFileTypes = { ".gif", ".png", ".jpeg", ".jpg" };
            if ((imazh.ContentLength > 0 && imazh.ContentLength < 2097152) && allowedFileTypes.Contains(fileExtension))
            {
                return true;

            }
            return false;
        }

        private void RuajFile(HttpPostedFileBase imazh)
        {
            WebImage img = new WebImage(imazh.InputStream);
            if (img.Width > 190)
            {
                img.Resize(190, img.Height);
            }
            img.Save(Konstante.PathImazh + imazh.FileName);
        }

        // GET: Produkts
        //[AllowAnonymous]
        public ActionResult Index(string kerko, string category)
        {
            var produkts = db.Produkts.Include(p => p.Inventar).Include(p => p.Kategori);

            if (!string.IsNullOrEmpty(kerko))
            {
                produkts = produkts.Where(p => p.Emri.Contains(kerko) ||
                  p.Pershkrimi.Contains(kerko) || p.Kategori.Emri.Contains(kerko));
                //ViewBag.Search = kerko;
            }
            var categories = produkts.OrderBy(p => p.Kategori.Emri).Select(p => p.Kategori.Emri).Distinct();
            if (!String.IsNullOrEmpty(category))
            {
                produkts = produkts.Where(p => p.Kategori.Emri == category);
            }
            ViewBag.Category = new SelectList(categories);

            return View(produkts.ToList());
        }

        // GET: Produkts/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkts.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }
        [Authorize(Roles = "Admin")]
        // GET: Produkts/Create
        public ActionResult Create()
        {
            ViewBag.InventarID = new SelectList(db.Inventars, "ID", "Sasia");
            ViewBag.KategoriID = new SelectList(db.Kategoris, "Id", "Emri");
            return View();
        }

        // POST: Produkts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Emri,Pershkrimi,Cmimi,imazh,KategoriID,InventarID")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Produkts.Add(produkt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InventarID = new SelectList(db.Inventars, "ID", "Sasia", produkt.InventarID);
            ViewBag.KategoriID = new SelectList(db.Kategoris, "Id", "Emri", produkt.KategoriID);
            return View(produkt);
        }

        // GET: Produkts/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkts.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            ViewBag.InventarID = new SelectList(db.Inventars, "ID", "Sasia", produkt.InventarID);
            ViewBag.KategoriID = new SelectList(db.Kategoris, "Id", "Emri", produkt.KategoriID);
            return View(produkt);
        }

        // POST: Produkts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ID,Emri,Pershkrimi,Cmimi,imazh,KategoriID,InventarID")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produkt).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.InventarID = new SelectList(db.Inventars, "ID", "Sasia", produkt.InventarID);
            ViewBag.KategoriID = new SelectList(db.Kategoris, "Id", "Emri", produkt.KategoriID);
            return View(produkt);
        }

        // GET: Produkts/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkts.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // POST: Produkts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Produkt produkt = db.Produkts.Find(id);
            db.Produkts.Remove(produkt);
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


        public string Perdorues()
        {
            if (Request.IsAuthenticated)
            {
                return User.Identity.GetUserId();
            }
            else
            {
                if (Session["user"] == null)
                {
                    Session["user"] = Guid.NewGuid().ToString();
                }
                return Session["user"].ToString();

            }
        }

        [AllowAnonymous]
        public ActionResult ShtoShport(int? id)
        {
            string UserId = Perdorues();
            if (id != null)
            {

                Shporta kart = db.Shportas.FirstOrDefault(x => x.IdPerdorues == UserId && x.ProduktID == id);
                if (kart == null)
                {
                    Shporta kartaa = new Shporta()
                    {
                        IdPerdorues = UserId,
                        ProduktID = (int)id,
                        Sasia = 1
                    };
                    db.Shportas.Add(kartaa);
                }
                else
                {
                    kart.Sasia += 1;
                }
                db.SaveChanges();
                UpdateProducts(id, 1);
            }
            List<Shporta> karta = db.Shportas.Include("Produkt").Where(k => k.IdPerdorues == UserId).ToList();
            ViewBag.Totali = karta.Sum(k => k.Produkt.Cmimi * k.Sasia);
            return View(karta);

        }

        public void UpdateProducts(int? idProduct, int sasia)
        {
            var product = db.Produkts.Where(p => p.ID == idProduct).FirstOrDefault().Inventar;
           
            product.Sasia = (Convert.ToInt32(product.Sasia) - sasia).ToString();
            db.SaveChanges();
            
         
        }
        public void UpdateProductsIncrease(int? idProduct, int sasia)
        {
            var product = db.Produkts.Where(p => p.ID == idProduct).FirstOrDefault().Inventar;
            product.Sasia = (Convert.ToInt32(product.Sasia) + sasia).ToString();
            db.SaveChanges();
        }


        public ActionResult FshiProdukt(int? id)
        {
            string UserId = Perdorues();
            var fshiKarte = db.Shportas.FirstOrDefault(k => k.IdPerdorues == UserId && k.ProduktID == id);
            if (fshiKarte != null)
            {
                db.Shportas.Remove(fshiKarte);
            }
            db.SaveChanges();
            UpdateProductsIncrease(id, 1);
            return RedirectToAction("ShtoShport");
        }
        
        public ActionResult ZbritSasi(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                string UserId = Perdorues();
                Shporta kartaP = db.Shportas.Where(k => k.IdPerdorues == UserId && k.ProduktID == id).FirstOrDefault();
                if (kartaP.Sasia == 1)
                {
                    return FshiProdukt((int)id);
                }
                else
                {
                    kartaP.Sasia -= 1;
                   
                    db.SaveChanges();
                    UpdateProductsIncrease(id, 1);
                    return RedirectToAction("ShtoShport"); 
                }
            }
        }
        public ActionResult CheckOut()
        {
            return View("CheckOut");
        }
        public ActionResult ProcesoPorosin(FormCollection frc)
        {
            List<Porosi> porosis = (List<Porosi>)Session["porosis"];
            //1.ruaj porosin ne tabeln Porosi
            string perdId = Perdorues();
            Porosi porosi = new Porosi();
            porosi.Sasia =Convert.ToInt32(frc["sasia"]);
            porosi.Telefon = frc["telefon"];
            porosi.Adresa = frc["adresa"];
            porosi.UserId = Convert.ToInt32(frc["userid"]);
           
            db.Porosis.Add(porosi);
            db.SaveChanges();

            var rows = from o in db.Shportas
                       select o;
            foreach( var row in rows)
            {
                db.Shportas.Remove(row);
            }
            db.SaveChanges();
            //2.ruaj porosin ne tabelen Detaje_Porosi
            //foreach(Porosi porosia in Porosi)
            //{
                
                //Detaje_Porosi porosit = new Detaje_Porosi();
                //porosit.Sasia = Convert.ToInt32(frc["sasia"]);
                //porosit.PorosiID = porosi.Id;
                //porosit.ProduktID = porosit.Produkt.ID;
                //db.Detaje_Porosis.Add(porosit);
                //db.SaveChanges();
            //}
            //Fshirjes se kartes
            
            return View("PorosiaSukses");
        }
    }
}
