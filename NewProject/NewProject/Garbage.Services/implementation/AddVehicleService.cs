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
    public class AddVehicleService : IAddVehicle
    {
        public Response<AddVehiclesDTO> AddVehicle(AddVehiclesDTO Add)
        {
            Response<AddVehiclesDTO> UserData = new Response<AddVehiclesDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<AddVehiclesDTO>(AppConstant.baseURL + "AddVehiclesAPI/AddNewVehicle" + "", Add);
        }

        public List<AddVehiclesDTO> GetAllVehicles()
        {
            return HttpHelper.DownloadSerializedJsonViaGET<AddVehiclesDTO>(AppConstant.baseURL + "AddVehiclesAPI/GetVehicles" + "");
        }
    }
}
