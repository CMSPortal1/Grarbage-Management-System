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
   public class RolesService: IRolesService
    {
        public Response<RolesDTO> AddRoles(RolesDTO User)
        {
            Response<RolesDTO> UserData = new Response<RolesDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<RolesDTO>(AppConstant.baseURL + "RolesAPI/AddRoles" + "", User);

        }
        public Response<RolesDTO> EditRole(int id)
        {
           
            return HttpHelper.GetRequest<RolesDTO>(AppConstant.baseURL + "RolesAPI/Edit?ID=" + id, "");
        }
        public Response<RolesDTO> SaveRoles(RolesDTO User)
        {
            Response<RolesDTO> UserData = new Response<RolesDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<RolesDTO>(AppConstant.baseURL + "AllRolesAPI/SaveUserRoles" + "", User);

        }
        public List<RolesDTO> AllRoles()
        {
            return HttpHelper.DownloadSerializedJsonViaGET<RolesDTO>(AppConstant.baseURL + "AllRolesAPI/AllUserRoles" + "");
        }
        public Response<RolesDTO> DeleteRole(int id)
        {

            return HttpHelper.GetRequest<RolesDTO>(AppConstant.baseURL + "AllRolesAPI/DeleteRoles?ID=" + id, "");
        }
        public Response<RolesDTO> ConfirmedDelRoles(RolesDTO User)
        {
            Response<RolesDTO> UserData = new Response<RolesDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<RolesDTO>(AppConstant.baseURL + "AllRolesAPI/DelRoles" + "", User);

        }
    }
}
