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
    public class ComplaintService : IComplaintService
    {
        public Response<ComplaintDTO> Approve(int id)
        {
            return HttpHelper.GetRequest<ComplaintDTO>(AppConstant.baseURL + "ApproveStatusAPI/ApproveStatus?ID=" + id, "");
        }

        public List<ComplaintDTO> GetUserStatus(int id)
        {
            return HttpHelper.DownloadSerializedJsonViaGET<ComplaintDTO>(AppConstant.baseURL + "ComplaintAPI/GetStatus?ID=" + id + "");
        }
        public Response<ComplaintDTO> Approved(ComplaintDTO User, int id)
        {
            Response<ComplaintDTO> UserData = new Response<ComplaintDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<ComplaintDTO>(AppConstant.baseURL + "ApproveStatusAPI/RequestApproved?ID="+id + "", User);

        }

        public List<ComplaintDTO> GetAllStatus()
        {
            return HttpHelper.DownloadSerializedJsonViaGET<ComplaintDTO>(AppConstant.baseURL + "GetAllUserStausAPI/GetAll" + "");
        }
    }
}
