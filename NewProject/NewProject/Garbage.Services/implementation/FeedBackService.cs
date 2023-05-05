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
   public class FeedBackService: IFeedBackService
    {
        public Response<FeedbackDTO> UserFeedback(FeedbackDTO User)
        {
            Response<FeedbackDTO> UserData = new Response<FeedbackDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<FeedbackDTO>(AppConstant.baseURL + "FeedbackAPI/UserFeedback" + "", User);

        }
    }
}
