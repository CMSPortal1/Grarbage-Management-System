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
    public class AssignedDumpedService : IAssignedDumped
    {
        public List<AssignDumpedAreaDTO> Assignedumped(int id)
        {
            return HttpHelper.DownloadSerializedJsonViaGET<AssignDumpedAreaDTO>(AppConstant.baseURL + "DumpedAreaAssigedAPI/DumpedAssign?ID=" + id + "");
        }

        public List<AssignDumpedAreaDTO> GetAllAreas()
        {
            return HttpHelper.DownloadSerializedJsonViaGET<AssignDumpedAreaDTO>(AppConstant.baseURL + "GetAllDumpedAPI/GetAll" + "");
        }
    }
}
