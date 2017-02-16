using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TourData;
using WebAppTours.Models;

namespace WebAppTours.Controllers
{
    public class PassengersController : Controller
    {
        private ToursDBEntities db = new ToursDBEntities();

        // GET: Passengers
        public async Task<ActionResult> Index()
        {
            var passenger = db.Passenger.Include(p => p.Tour);
            return View(await passenger.ToListAsync());
        }

        // GET: Passengers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = await db.Passenger.FindAsync(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }

        // GET: Passengers/Create
        public ActionResult Create()
        {
            ViewBag.Id_Tour = new SelectList(db.Tour, "Id_Tour", "Route");
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Passenger,LastName,Name,Age,Id_Tour")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                db.Passenger.Add(passenger);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Tour = new SelectList(db.Tour, "Id_Tour", "Route", passenger.Id_Tour);
            return View(passenger);
        }


        // GET: Passengers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = await db.Passenger.FindAsync(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Tour = new SelectList(db.Tour, "Id_Tour", "Route", passenger.Id_Tour);
            return View(passenger);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Passenger,LastName,Name,Age,Id_Tour")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passenger).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Tour = new SelectList(db.Tour, "Id_Tour", "Route", passenger.Id_Tour);
            return View(passenger);
        }

        // GET: Passengers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = await db.Passenger.FindAsync(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Passenger passenger = await db.Passenger.FindAsync(id);
            db.Passenger.Remove(passenger);
            await db.SaveChangesAsync();
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
