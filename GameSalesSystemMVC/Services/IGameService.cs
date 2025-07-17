using GameSalesSystemMVC.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSalesSystemMVC.Services
{
    public interface IGameService
    {
        List<GameDto> GetGames();
        bool InsertGame(GameDto gameDto);
        bool UpdateGame(GameDto gameDto);
        bool DeleteGame(int gameId);
        GameDto GetGameById(int gameId);
    }
}
