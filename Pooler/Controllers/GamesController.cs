using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pooler.Domain.Entities;
using Pooler.Models;
using Pooler.Persistence;

namespace Pooler.Controllers
{
    public class GamesController : Controller
    {
        private readonly PoolerContext _dbContext;

        public GamesController(PoolerContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Games
        public ActionResult Index()
        {
            return View();
        }

        // GET: Games/GamesList
        public async Task<ActionResult> GameList()
        {
            var data = _dbContext.PoolGames
                .Include(b => b.PlayerOne)
                .Include(p2 => p2.PlayerTwo)
                .Include(w => w.Winner)
                .ToList();

            return View(data);
        }


        // GET: Games/Details/5
        public ActionResult Details(int id)
        {
            return View(_dbContext.PoolGames.Find(id));
        }

        // GET: Games/Create
        public ActionResult NewGame()
        {
            var mpvm = new CreatePoolGameModel
            {
                AllPlayers = _dbContext.Players.ToList()
            };

            return View(mpvm);
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewGame([FromForm]CreatePoolGameModel collection) //IFormCollection collection)
        {
            try
            {
                
                var postObj = collection.poolGame;
                postObj.PlayerOne = _dbContext.Players.Find(collection.poolGame.PlayerOne.Id);
                postObj.PlayerTwo = _dbContext.Players.Find(collection.poolGame.PlayerTwo.Id);
                postObj.Winner = _dbContext.Players.Find(collection.poolGame.Winner.Id);

                _dbContext.PoolGames.Add(postObj);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(NewGame));
            }
            catch
            {
                return View();
            }
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm]PoolGame collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Games/Delete/5
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
    }
}