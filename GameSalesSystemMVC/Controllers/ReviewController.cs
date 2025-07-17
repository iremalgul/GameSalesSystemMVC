using GameSalesSystemMVC.Dtos;
using GameSalesSystemMVC.Filters;
using GameSalesSystemMVC.Models;
using GameSalesSystemMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameSalesSystemMVC.Controllers
{
    [IsLogin]
    public class ReviewController : Controller
    {
        // GET: Review private readonly IUserService _userService;

        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;
        public ReviewController(IReviewService reviewService, IUserService userService)
        {
            _reviewService = reviewService;
            _userService = userService;
        }
       
        public ActionResult InsertReview(ReviewDto reviewDto)
        {
            reviewDto.UserId = _userService.GetUserFromSession().Id; 
            reviewDto.ReviewDate = DateTime.Now;
            var result = _reviewService.InsertReview(reviewDto);
           
            if (result)
                return Json(new JsonModel(true, "New review Added"), JsonRequestBehavior.AllowGet);
            else return Json(new JsonModel(false, "New review Couldn't Add"), JsonRequestBehavior.AllowGet);
        }
    }
}