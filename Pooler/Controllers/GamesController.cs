using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pooler.Domain.Entities;
using Pooler.Models;

namespace Pooler.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult Index()
        {
            return View();
        }

        // GET: Games/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Games/Create
        public ActionResult NewGame()
        {
            var allplayers = new List<Player>();
            allplayers.Add(new Player { Name = "Brad Davis", AccountNumber = "03189", Active = true, Email = "dvsxutact@gmail.com", Id = 1 });
            allplayers.Add(new Player { Name = "Chad Woods", AccountNumber = "03139", Active = true, Email = "Cw@gmail.com", Id = 2 });
            allplayers.Add(new Player { Name = "Gloria Woods", AccountNumber = "03529", Active = true, Email = "gw@gmail.com", Id = 3 });
            allplayers.Add(new Player { Name = "Sarah Davis", AccountNumber = "12459", Active = true, Email = "sd@gmail.com", Id = 4 });

            CreatePoolGameModel mpvm = new CreatePoolGameModel
            {
                AllPlayers = allplayers
            };

            return View(mpvm);
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewGame([FromForm]CreatePoolGameModel collection) //IFormCollection collection)
        {
            try
            {
                
                var postObj = collection.poolGame;

                //var obj = collection["gameDetails.PlayerOne"];

                //var tryGetResult = collection.TryGetValue("poolGame.PlayerOne", out var player);

                //var gameObj = new PoolGame
                //{
                //    PlayerOne = collection["gameDetails.PlayerOne"];  // ["gameDetails.PlayerOne"];
                //}

                return View();
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