using Garbage.Common;
using Garbage.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Services.Interface
{
   public interface IComplaintService
    {
        List<ComplaintDTO> GetAllStatus();
        List<ComplaintDTO> GetUserStatus(int id);
        Response<ComplaintDTO> Approve(int id);
        Response<ComplaintDTO> Approved(ComplaintDTO User, int id);
       
    }
}
