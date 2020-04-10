using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pooler.Domain.Entities;
using Pooler.Models;
using Pooler.Persistence;

namespace Pooler.Controllers
{
    public class PlayersController : Controller
    {
        private readonly PoolerContext _dbContext;

        public PlayersController(PoolerContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Players
        public ActionResult Index()
        {
            var allplayers = _dbContext.Players.ToList();

            ManagePlayersViewModel mpvm = new ManagePlayersViewModel
            {
                AllPlayers = allplayers
            };

            return View(mpvm);
        }

        // GET: Players/Details/5
        public ActionResult Details(int id)
        {
            return View(_dbContext.Players.Find(id));
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm]Player collection)
        {
            try
            {
                _dbContext.Players.Add(collection);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Players/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Players/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult PlayerList()
        {
            return View(_dbContext.Players.ToList());
        }
    }
}