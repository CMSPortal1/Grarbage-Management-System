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
    public class AssignedVehicleService : IVehicleAssignService
    {
        public List<AssignVehcileDTO> AssignVehicle(int id)
        {
            return HttpHelper.DownloadSerializedJsonViaGET<AssignVehcileDTO>(AppConstant.baseURL + "AssignVehicleAPI/GetAssign?ID=" + id + "");
        }
    }
}
