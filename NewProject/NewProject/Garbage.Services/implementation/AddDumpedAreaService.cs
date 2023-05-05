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
    public class AddDumpedAreaService : IAddDumpedAreaService
    {
        public Response<AddDumpedAreaDTO> AddDumpedArea(AddDumpedAreaDTO Create)
        {
            Response<AddDumpedAreaDTO> UserData = new Response<AddDumpedAreaDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<AddDumpedAreaDTO>(AppConstant.baseURL + "AddDumpedAPI/AddDumpedArea" + "", Create);
        }

        public List<AddDumpedAreaDTO> GetAllDumpedAreas()
        {
            return HttpHelper.DownloadSerializedJsonViaGET<AddDumpedAreaDTO>(AppConstant.baseURL + "AddDumpedAPI/GetAllDump" + "");
        }
    }
}
