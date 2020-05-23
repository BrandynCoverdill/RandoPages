using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RandoPages.Data;
using RandoPages.Models;
using PagedList;
using PagedList.Mvc;

namespace RandoPages.Controllers
{
    public class FlashCardController : Controller
    {
        private RandoPagesContext db = new RandoPagesContext();

        // GET: FlashCard
        public ActionResult Index(string searchString, int? page, string currentFilter)
        {

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var flashCards = from f in db.FlashCards select f; // Select all flashCards

            // Ability to search through a list of questions.
            if (!String.IsNullOrEmpty(searchString))
            {
                flashCards = flashCards.Where(f => f.CardType.Contains(searchString));
            }

            // Getting a list of each Card Category: Will do later to fix
            ViewBag.Card = new SelectList(db.FlashCards.Select(c => c.CardType).Distinct(), "Card", "Card");

            return View(flashCards.OrderBy(f => f.CardType).ToPagedList(page ?? 1, 3));
        }

        // GET: FlashCard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlashCard flashCard = db.FlashCards.Find(id);
            if (flashCard == null)
            {
                return HttpNotFound();
            }
            return View(flashCard);
        }

        // GET: FlashCard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlashCard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardId,CardType,Question,Answer")] FlashCard flashCard)
        {
            if (ModelState.IsValid)
            {
                db.FlashCards.Add(flashCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flashCard);
        }

        // GET: FlashCard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlashCard flashCard = db.FlashCards.Find(id);
            if (flashCard == null)
            {
                return HttpNotFound();
            }
            return View(flashCard);
        }

        // POST: FlashCard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CardId,CardType,Question,Answer")] FlashCard flashCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flashCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flashCard);
        }

        // GET: FlashCard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlashCard flashCard = db.FlashCards.Find(id);
            if (flashCard == null)
            {
                return HttpNotFound();
            }
            return View(flashCard);
        }

        // POST: FlashCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlashCard flashCard = db.FlashCards.Find(id);
            db.FlashCards.Remove(flashCard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StudyCards(string questionType)
        {
            var flashCards = from f in db.FlashCards select f;

            if (questionType == null)
            {
                return View(flashCards.ToList());
            }
            else
            {
                flashCards = flashCards.Where(f => f.CardType.Contains(questionType));
                return View(flashCards.ToList());
            }

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
