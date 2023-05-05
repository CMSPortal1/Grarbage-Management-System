using Garbage.Common;
using Garbage.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Services.Interface
{
  public interface IGarbageRequestService
    {
        List<GarabgeRequestServiceDTO> GetAllRequests();
        Response<GarabgeRequestServiceDTO> UserRequest(GarabgeRequestServiceDTO Parameters);
        Response<ComplaintDTO> UserComplaint(ComplaintDTO Parameters);
    }
}
