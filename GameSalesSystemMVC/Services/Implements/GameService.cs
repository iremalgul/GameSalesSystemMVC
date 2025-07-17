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
    public class GameService: IGameService
    {
        private readonly IRepository<Game> _gamerepository;

        public GameService(IRepository<Game> gamerepository)
        {
            _gamerepository = gamerepository;
        }
        public bool InsertGame(GameDto gameDto)
        {
            try
            {
                var game = Mapper.Map<Game>(gameDto);
                _gamerepository.Insert(game);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteGame(int gameId)
        {
            try
            {
                var game = _gamerepository.FindById(gameId);
                _gamerepository.Delete(game);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public GameDto GetGameById(int gameId)
        {
            try
            {
                var entity = _gamerepository.FindById(gameId);
                var game = Mapper.Map<GameDto>(entity);
                return game;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<GameDto> GetGames()
        {
            var games = _gamerepository.Table.ToList();
            var gameDtos = Mapper.Map<List<GameDto>>(games);
            return gameDtos;
        }

        

        public bool UpdateGame(GameDto gameDto)
        {
            try
            {
                var entity = _gamerepository.FindById(gameDto.Id);
                var game = Mapper.Map(gameDto, entity);
                _gamerepository.Update(game);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}