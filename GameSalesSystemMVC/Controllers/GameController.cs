using GameSalesSystemMVC.Dtos;
using GameSalesSystemMVC.Filters;
using GameSalesSystemMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSalesSystemMVC.Controllers
{
    [IsUser]
    public class GameController : Controller
    {
        // GET: Game
        private readonly IGameService _gameService;
        private readonly IReviewService _reviewService;
        public GameController(IGameService gameService, IReviewService reviewService)
        {
            _gameService = gameService;
            _reviewService = reviewService;
        }
        public ActionResult Index()
        {
            return View(_gameService.GetGames());
        }
        public ActionResult Details(int id)
        {
            var tupleModel = new Tuple<GameDto, List<ReviewDto>>(_gameService.GetGameById(id), _reviewService.GetGameReviews(id));
            return View(tupleModel);
        }
    }
}