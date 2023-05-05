using Garbage.Common;
using Garbage.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Services.Interface
{
   public interface IFeedBackService
    {
        Response<FeedbackDTO> UserFeedback(FeedbackDTO Parameters);
    }
}
