using Garbage.Common;
using Garbage.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Services.Interface
{
   public interface IAccountService
    {
        Response<UserDTO> SignIn(UserDTO Parameters);
        List<UserDTO> GetAllUsers();
        Response<UserDTO> Login(UserDTO Parameters);
        Response<UserDTO> GetUserProfile(int id);
        Response<UserDTO> ChangePic(UserDTO pic);
        Response<UserDTO> ChangePassword(string Parameters);
        Response<UserDTO> GetAdminEmail();
        Response<UserDTO> SendMail(UserDTO Parameters);
        Response<UserDTO> ResetPassword(string id);
    }
}
