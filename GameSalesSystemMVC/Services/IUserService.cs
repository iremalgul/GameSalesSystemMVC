using GameSalesSystemMVC.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GameSalesSystemMVC.Services
{
    public interface IUserService
    {
        int InsertUser(UserDto userDto);
        List<UserDto> GetUsers();
        bool UpdateUser(UserDto userDto);
        bool DeleteUser(int userId);
        UserDto GetUserById(int userId);
        UserDto GetUserFromSession();
    }
}
