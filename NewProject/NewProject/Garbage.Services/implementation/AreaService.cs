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
    public class AreaService : IAreaService
    {
        public Response<AreaDTO> AddArea(AreaDTO Add)
        {
            Response<AreaDTO> UserData = new Response<AreaDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<AreaDTO>(AppConstant.baseURL + "AreaAPI/AddNewArea" + "", Add);
        }

        public List<AreaDTO> GetAllAreas()
        {
            return HttpHelper.DownloadSerializedJsonViaGET<AreaDTO>(AppConstant.baseURL + "AreaAPI/GetAreas" + "");
        }

        public List<AreaDTO> GetAreasbyCities(int id)
        {
            return HttpHelper.DownloadSerializedJsonViaGET<AreaDTO>(AppConstant.baseURL + "AreaAPI/GetAreaByCities?ID=" + id + "");
        }
    }
}
