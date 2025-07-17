using GameSalesSystemMVC.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSalesSystemMVC.Services
{
    public interface ICartService
    {
        bool InsertCart(int userId);
        bool DeleteCart(int userId);
        bool UpdateCart(CartDto cartDto);
        CartDto GetUserCart(int userId);
        List<CartGameDto> GetUserCartGames(int userId);
        bool AddCartGame(int game_id, int user_id);
        bool DeleteCartGame(int cartgame_id);
        CartGameDto GetCartGame(int cartgame_id);
    }
}
