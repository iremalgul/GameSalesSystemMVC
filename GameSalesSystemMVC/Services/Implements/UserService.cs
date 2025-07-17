using AutoMapper;
using GameSalesSystemMVC.Contexts;
using GameSalesSystemMVC.Dtos;
using GameSalesSystemMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static Unity.Storage.RegistrationSet;

namespace GameSalesSystemMVC.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userrepository;

        public UserService(IRepository<User> userrepository)
        {
            _userrepository = userrepository;
        }

        public int InsertUser(UserDto userDto)
        {
            try
            {
                var user = Mapper.Map<User>(userDto);
                _userrepository.Insert(user);
                return user.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var user = _userrepository.FindById(userId);
                _userrepository.Delete(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<UserDto> GetUsers()
        {
            var users = _userrepository.Table.ToList();
            var userDtos = Mapper.Map<List<UserDto>>(users);
            return userDtos;
        }

        public bool UpdateUser(UserDto userDto)
        {
            try
            {
                var entity = _userrepository.FindById(userDto.Id);
                var user = Mapper.Map(userDto, entity);
                _userrepository.Update(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public UserDto GetUserById(int userId)
        {
            try
            {
                var entity = _userrepository.FindById(userId);
                var user = Mapper.Map<UserDto>(entity);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public UserDto GetUserFromSession()
        {
            var user = (User)HttpContext.Current.Session["user"];
            var userDto = Mapper.Map<UserDto>(user);
            return userDto;
        }

      
    }
}
