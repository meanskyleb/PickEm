using Microsoft.AspNet.Identity;
using PickEm.Models.GameModels;
using PickEm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PickEm.WebMVC.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            var service = CreateGameService();
            var model = service.GetGames();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateGameService();

            if (service.CreateGame(model))
            {
                TempData["SaveResult"] = "Your game was updated.";

                return RedirectToAction("Index");
            }
            return View(model);
        }

        private GameService CreateGameService()
        {
            var gameId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(gameId);
            return service;
        }




    }       
}