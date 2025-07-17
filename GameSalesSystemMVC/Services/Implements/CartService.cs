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
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _cartrepository;
        private readonly IRepository<CartGame> _cartgamerepository;

        public CartService(IRepository<Cart> cartrepository, IRepository<CartGame> cartgamerepository)
        {
            _cartrepository = cartrepository;
            _cartgamerepository = cartgamerepository;
        }

        public bool AddCartGame(int game_id, int user_id)
        {
            try
            {
                CartGameDto cartGameDto = new CartGameDto()
                {
                    CartId = user_id,
                    GameId = game_id
                };
                
                var cartGame = Mapper.Map<CartGame>(cartGameDto);
                _cartgamerepository.Insert(cartGame);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool DeleteCart(int userId)
        {
            try
            {
                var cart = _cartrepository.FindById(userId);
                _cartrepository.Delete(cart);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCartGame(int cartgame_id)
        {
            try
            {
                var cartgame = _cartgamerepository.FindById(cartgame_id);
                _cartgamerepository.Delete(cartgame);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public CartGameDto GetCartGame(int cartgame_id)
        {
            var cartgame = _cartgamerepository.FindById(cartgame_id);
            var cartgamedto = Mapper.Map<CartGameDto>(cartgame);
            return cartgamedto;
        }

        public CartDto GetUserCart(int userId)
        {
            var cart = _cartrepository.FindById(userId);
            var cartdto = Mapper.Map<CartDto>(cart);
            return cartdto;
        }

        public List<CartGameDto> GetUserCartGames(int userId)
        {
            var allCartGames = _cartgamerepository.Table;
            var cartGames =allCartGames.Where(x => x.CartId== userId);
            var cartGamesDto = Mapper.Map<List<CartGameDto>>(cartGames)  ;
            return cartGamesDto;
        }

        public bool InsertCart(int userId)
        {
            try
            {
                CartDto cartDto = new CartDto();
                cartDto.Id = userId;
                cartDto.TotalCost = 0;
                var cart = Mapper.Map<Cart>(cartDto);
                _cartrepository.Insert(cart);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCart(CartDto cartDto)
        {
            try
            {
                var entity = _cartrepository.FindById(cartDto.Id);
                var cart = Mapper.Map(cartDto, entity);
                _cartrepository.Update(cart);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}