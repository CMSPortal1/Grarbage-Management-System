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
  public class GarbageRequestService: IGarbageRequestService
    {
        public List<GarabgeRequestServiceDTO> GetAllRequests()
        {
            return HttpHelper.DownloadSerializedJsonViaGET<GarabgeRequestServiceDTO>(AppConstant.baseURL + "GarbageRequestAPI/GetAllRequest" + "");
        }
        public Response<GarabgeRequestServiceDTO> UserRequest(GarabgeRequestServiceDTO User)
        {
            Response<GarabgeRequestServiceDTO> UserData = new Response<GarabgeRequestServiceDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<GarabgeRequestServiceDTO>(AppConstant.baseURL + "GarbageRequestAPI/GetRequest" + "", User);
        }
        public Response<ComplaintDTO> UserComplaint(ComplaintDTO Complaint)
        {
            Response<ComplaintDTO> UserData = new Response<ComplaintDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<ComplaintDTO>(AppConstant.baseURL + "ComplaintsAPI/GetComplaint" + "", Complaint);
        }

    }
}
