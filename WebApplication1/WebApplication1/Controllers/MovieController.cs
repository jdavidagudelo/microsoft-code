using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        private Database1Entities1 _db = new Database1Entities1(); 
        // GET: Movie
        public ActionResult Index()
        {

            return View(_db.Tables.ToList());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "Id")]Table movieToCreate)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                    return View(); 
                _db.Tables.Add(movieToCreate);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            var movieToEdit = (from m in _db.Tables

                               where m.Id == id

                               select m).First();

            return View(movieToEdit);
        }

        // POST: Movie/Edit/5
        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Edit(Table movieToEdit)
        {

            var originalMovie = (from m in _db.Tables

                                 where m.Id == movieToEdit.Id

                                 select m).First();

            if (!ModelState.IsValid)
                return View(originalMovie);
            _db.Entry(originalMovie).CurrentValues.SetValues(movieToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");
        } 
        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            var originalMovie = (from m in _db.Tables

                                 where m.Id == id

                                 select m).First();
            return View(originalMovie);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var originalMovie = (from m in _db.Tables

                                     where m.Id == id

                                     select m).First();
                _db.Tables.Remove(originalMovie);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
