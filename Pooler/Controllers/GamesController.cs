using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pooler.Domain.Entities;
using Pooler.Models;
using Pooler.Persistence;
using System.Linq;
using System.Threading.Tasks;

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
            var data = await _dbContext.PoolGames
                .Include(b => b.PlayerOne)
                .Include(p2 => p2.PlayerTwo)
                .Include(w => w.Winner)
                .ToListAsync();

            return View(data);
        }


        // GET: Games/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var gameDetails = await _dbContext.PoolGames
                  .Include(g => g.PlayerOne)
                  .Include(g => g.PlayerTwo)
                  .Include(g => g.Winner)
                  .Include(g => g.gameDetails)
                  .FirstOrDefaultAsync(g => g.Id.Equals(id));

            return View(gameDetails);
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
        public async Task<ActionResult> Edit(int id)
        {
            var editMode = new EditPoolGameModel
            {
                AllPlayers = await _dbContext.Players.ToListAsync(),
                PoolGame = await _dbContext.PoolGames
                .Include(g => g.PlayerOne)
                .Include(g => g.PlayerTwo)
                .Include(g => g.Winner)
                .Include(g => g.gameDetails)
                .FirstOrDefaultAsync(g => g.Id.Equals(id))
            };

            return View(editMode);
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