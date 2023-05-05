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
    public class GarbageTypeInfoService : IGarbageTypeService
    {
        public Response<GarbageTypeInfoDTO> AddType(GarbageTypeInfoDTO User)
        {
            Response<GarbageTypeInfoDTO> UserData = new Response<GarbageTypeInfoDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<GarbageTypeInfoDTO>(AppConstant.baseURL + "GarbageTypeAPI/AddType" + "", User);
        }

        public Response<GarbageTypeInfoDTO> ConfirmedDel(GarbageTypeInfoDTO User)
        {
            Response<GarbageTypeInfoDTO> UserData = new Response<GarbageTypeInfoDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<GarbageTypeInfoDTO>(AppConstant.baseURL + "GarbageTypeAPI/DelType" + "", User);
        }

        public Response<GarbageTypeInfoDTO> EditType(int id)
        {
            return HttpHelper.GetRequest<GarbageTypeInfoDTO>(AppConstant.baseURL + "GarbageTypeAPI/Edit?ID=" + id, "");
        }

        public List<GarbageTypeInfoDTO> GetAllTypes()
        {
            return HttpHelper.DownloadSerializedJsonViaGET<GarbageTypeInfoDTO>(AppConstant.baseURL + "GetAllGarbageTypeAPI/GetAll" + "");
        }

        public Response<GarbageTypeInfoDTO> SaveType(GarbageTypeInfoDTO User)
        {
            Response<GarbageTypeInfoDTO> UserData = new Response<GarbageTypeInfoDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<GarbageTypeInfoDTO>(AppConstant.baseURL + "GarbageTypeAPI/SaveData" + "", User);
        }
    }
}
