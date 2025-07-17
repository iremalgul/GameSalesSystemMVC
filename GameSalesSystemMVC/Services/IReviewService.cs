using GameSalesSystemMVC.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSalesSystemMVC.Services
{
    public interface IReviewService
    {
        List<ReviewDto> GetUserReviews(int userId);
        List<ReviewDto> GetGameReviews(int gameId);
        bool InsertReview(ReviewDto reviewDto);
    }
}
