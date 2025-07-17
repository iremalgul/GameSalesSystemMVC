using GameSalesSystemMVC.Dtos;
using GameSalesSystemMVC.Filters;
using GameSalesSystemMVC.Models;
using GameSalesSystemMVC.Services;
using GameSalesSystemMVC.Services.Implements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSalesSystemMVC.Areas.Admin.Controllers
{
    [IsAdmin]
    public class GameController : Controller
    {
        // GET: Admin/Game
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }
        public ActionResult Index()
        {
            return View(_gameService.GetGames());
        }

        public ActionResult IndexPartialTable()
        {
            return PartialView(_gameService.GetGames());
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult InsertGame(GameCrudModel model, HttpPostedFileBase File)
        {
            var fileNameGuid = Guid.NewGuid().ToString();
            var fileExtension = Path.GetExtension(File.FileName);
            File.SaveAs(Path.Combine(Server.MapPath("~/Pictures"), fileNameGuid + fileExtension));
            var gameDto = new GameDto
            {
                Picture = fileNameGuid + fileExtension,
                Price = Convert.ToDecimal(model.Price.Replace(",", "").Replace(".", ",")),
                ReleaseDate = Convert.ToDateTime(model.ReleaseDate),
                Description = model.Description,
                Genre = model.Genre,
                Title = model.Title,
            };

            var result = _gameService.InsertGame(gameDto);
            if (result)
                return Json(new JsonModel(true, "New game Added"), JsonRequestBehavior.AllowGet);
            else return Json(new JsonModel(false, "New game Couldn't Add"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var game = _gameService.GetGameById(id);
            return View(game);
        }

        public ActionResult UpdateGame(GameCrudModel model, HttpPostedFileBase File)
        {
            var game = _gameService.GetGameById(model.Id);
            var gameDto = new GameDto
            {
                Picture = game.Picture,
                Id = model.Id,  
                Price = Convert.ToDecimal(model.Price.Replace(",", "").Replace(".", ",")),
                ReleaseDate = Convert.ToDateTime(model.ReleaseDate),
                Description = model.Description,
                Genre = model.Genre,
                Title = model.Title,
            };
           
            if (File != null)
            {
                var fileNameGuid = Guid.NewGuid().ToString();
                var fileExtension = Path.GetExtension(File.FileName);
                File.SaveAs(Path.Combine(Server.MapPath("~/Pictures"), fileNameGuid + fileExtension));
                gameDto.Picture = fileNameGuid + fileExtension;
            }

            var result = _gameService.UpdateGame(gameDto);
            if (result)
                return Json(new JsonModel(true, "Game Updated"), JsonRequestBehavior.AllowGet);
            else return Json(new JsonModel(false, "Game Couldn't Updated"), JsonRequestBehavior.AllowGet);

           
            
        }

        public ActionResult DeleteGame(int Id)
        {
            var result = _gameService.DeleteGame(Id);
            if (result)
                return Json(new JsonModel(true, "Game Deleted"), JsonRequestBehavior.AllowGet);
            else return Json(new JsonModel(false, "Game Couldn't Deleted"), JsonRequestBehavior.AllowGet);
        }
    }
}