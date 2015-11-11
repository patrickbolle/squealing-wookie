﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ElectricPineapple;

namespace ElectricPineapple.Controllers
{
    public class GameController : Controller
    {
        private CVGSEntities db = new CVGSEntities();

        // GET: Game
        public ActionResult Index()
        {
            var games = db.Games.Include(g => g.ESRBRating1).Include(g => g.Publisher1).Include(g => g.Platform1).Include(g => g.Genre1);
            return View(games.ToList());
        }

        // GET: Game/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            ViewBag.ESRBRating = new SelectList(db.ESRBRatings, "ratingID", "rating");
            ViewBag.publisher = new SelectList(db.Publishers, "publisherID", "publisher1");
            ViewBag.platform = new SelectList(db.Platforms, "platformID", "platform1");
            ViewBag.genre = new SelectList(db.Genres, "genreID", "genre1");
            return View();
        }

        // POST: Game/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "gameID,title,genre,publisher,ESRBRating,releaseDate,price,description,platform")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ESRBRating = new SelectList(db.ESRBRatings, "ratingID", "rating", game.ESRBRating);
            ViewBag.publisher = new SelectList(db.Publishers, "publisherID", "publisher1", game.publisher);
            ViewBag.platform = new SelectList(db.Platforms, "platformID", "platform1", game.platform);
            ViewBag.genre = new SelectList(db.Genres, "genreID", "genre1", game.genre);
            return View(game);
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.ESRBRating = new SelectList(db.ESRBRatings, "ratingID", "rating", game.ESRBRating);
            ViewBag.publisher = new SelectList(db.Publishers, "publisherID", "publisher1", game.publisher);
            ViewBag.platform = new SelectList(db.Platforms, "platformID", "platform1", game.platform);
            ViewBag.genre = new SelectList(db.Genres, "genreID", "genre1", game.genre);
            return View(game);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gameID,title,genre,publisher,ESRBRating,releaseDate,price,description,platform")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ESRBRating = new SelectList(db.ESRBRatings, "ratingID", "rating", game.ESRBRating);
            ViewBag.publisher = new SelectList(db.Publishers, "publisherID", "publisher1", game.publisher);
            ViewBag.platform = new SelectList(db.Platforms, "platformID", "platform1", game.platform);
            ViewBag.genre = new SelectList(db.Genres, "genreID", "genre1", game.genre);
            return View(game);
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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