using GameSalesSystemMVC.Filters;
using GameSalesSystemMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSalesSystemMVC.Areas.Admin.Controllers
{
    [IsAdmin]
    public class ReviewController : Controller
    {
        // GET: Admin/Review
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        public ActionResult ShowUserReviews(int id)
        {
            var reviews = _reviewService.GetUserReviews(id);
            return View(reviews);
        }
        public ActionResult ShowGameReviews(int id)
        {
            var reviews = _reviewService.GetGameReviews(id);
            return View(reviews);
        }
    }
}