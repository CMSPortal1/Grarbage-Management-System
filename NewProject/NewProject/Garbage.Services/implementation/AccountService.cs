using Garbage.Common;
using Garbage.Common.DTO;
using Garbage.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Services.implementation
{
    public class AccountService : IAccountService
    {
      public List<UserDTO> GetAllUsers()
            {
                return HttpHelper.DownloadSerializedJsonViaGET<UserDTO>(AppConstant.baseURL + "ProfilePicAPI/GetUsers" + "");
            }

        public Response<UserDTO> GetUserProfile(int id)
        {
           // Response<UserDTO> UserData = new Response<UserDTO>();
            return HttpHelper.GetRequest <UserDTO>(AppConstant.baseURL + "signupsAPI/GetProfile?ID=" +id, "");
        }
        public Response<UserDTO> Login(UserDTO User)
        {
            Response<UserDTO> UserData = new Response<UserDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<UserDTO>(AppConstant.baseURL + "LoginAPI/UserLogin" + "", User);
        }
        public Response<UserDTO> ChangePic(UserDTO pic)
        {
            Response<UserDTO> UserData = new Response<UserDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<UserDTO>(AppConstant.baseURL + "ProfilePicAPI/ChangeUserPic" + "", pic);
        }

        public Response<UserDTO> SignIn(UserDTO User)
        {
            Response<UserDTO> UserData = new Response<UserDTO>();
            return HttpHelper.DownloadSerializedJsonViaPOST<UserDTO>(AppConstant.baseURL + "signupsAPI/AddUser" + "", User);
         
        }

        public Response<UserDTO> ChangePassword(string Email)
        {
              return HttpHelper.GetRequest<UserDTO>(AppConstant.baseURL + "ResetPasswordAPI/ChangePass?Email=" + Email , "" );
        }

        public Response<UserDTO> GetAdminEmail()
        {
            return HttpHelper.GetRequest<UserDTO>(AppConstant.baseURL + "ResetPasswordAPI/GetEmail" , "");
        }
        public Response<UserDTO> SendMail(UserDTO Mail)
        {
            Response<UserDTO> UserData = new Response<UserDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<UserDTO>(AppConstant.baseURL + "ResetPasswordAPI/SendEmail" + "", Mail);
        }
        public Response<UserDTO> ResetPassword(string id)
        {
            return HttpHelper.GetRequest<UserDTO>(AppConstant.baseURL + "SentResetLinkAPI/ResetPass?id=" + id, "");
        }
    }
}
