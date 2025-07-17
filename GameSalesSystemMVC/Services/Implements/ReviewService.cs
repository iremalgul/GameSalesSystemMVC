using AutoMapper;
using GameSalesSystemMVC.Contexts;
using GameSalesSystemMVC.Dtos;
using GameSalesSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameSalesSystemMVC.Services.Implements
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _reviewrepository;

        public ReviewService(IRepository<Review> reviewrepository)
        {
            _reviewrepository = reviewrepository;
        }

        public List<ReviewDto> GetGameReviews(int gameId)
        {

            var allReviews = _reviewrepository.Table;
            var reviews = allReviews.Where(x => x.GameId == gameId);
            var reviewdtos = Mapper.Map<List<ReviewDto>>(reviews);
            return reviewdtos;
        }

        public List<ReviewDto> GetUserReviews(int userId)
        {
            var allReviews = _reviewrepository.Table;
            var reviews = allReviews.Where(x => x.UserId == userId);
            var reviewdtos = Mapper.Map<List<ReviewDto>>(reviews);
            return reviewdtos;
        }

        public bool InsertReview(ReviewDto reviewDto)
        {
            try
            {
                var review = Mapper.Map<Review>(reviewDto);
                _reviewrepository.Insert(review);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}