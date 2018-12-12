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
            var service = CreateGameService();
            var pService = GetPlayerService();
            var tService = GetTeamService();

            var unsortedPlayerList = new SelectList(pService.GetPlayers(), "PlayerId", "LastName");
            var playerList = unsortedPlayerList.OrderBy(o => o.Text);

            var unsortedTeamList = new SelectList(tService.GetTeams(), "TeamId", "TeamName");
            var teamList = unsortedTeamList.OrderBy(o => o.Text);

            ViewBag.PlayerId = playerList;
            ViewBag.HomeTeamId = teamList;
            ViewBag.AwayTeamId = teamList;


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
                TempData["SaveResult"] = "Your game was created.";

                return RedirectToAction("Index");
            }
            return View(model);
        }

        


        public ActionResult Details(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var service = CreateGameService();
            var pService = GetPlayerService();
            var tService = GetTeamService();

            var unsortedPlayerList = new SelectList(pService.GetPlayers(), "PlayerId", "LastName");
            var playerList = unsortedPlayerList.OrderBy(o => o.Text);

            var unsortedTeamList = new SelectList(tService.GetTeams(), "TeamId", "TeamName");
            var teamList = unsortedTeamList.OrderBy(o => o.Text);

            ViewBag.PlayerId = playerList;
            ViewBag.HomeTeamId = teamList;
            ViewBag.AwayTeamId = teamList;

            
            var detail = service.GetGameById(id);
            var model =
                new GameEdit
                {
                    //HomeTeam = detail.HomeTeam,
                    //AwayTeam = detail.AwayTeam,
                    GameId = detail.GameId,
                    HomeTeamId = detail.HomeTeamId,
                    AwayTeamId = detail.AwayTeamId,
                    PlayerId = detail.PlayerId,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GameId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGameService();

            if (service.UpdateGame(model))
            {
                TempData["SaveResult"] = "Your game was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your game could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGameService();

            service.DeleteGame(id);

            TempData["SaveResult"] = "Your game was deleted";

            return RedirectToAction("Index");
        }


        private GameService CreateGameService()
        {
            var gameId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(gameId);
            return service;
        }

        private PlayerService GetPlayerService()
        {
            var playerId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlayerService(playerId);
            return service;
        }

        private TeamService GetTeamService()
        {
            var teamId = Guid.Parse(User.Identity.GetUserId());
            var service = new TeamService(teamId);
            return service;
        }

    }       
}