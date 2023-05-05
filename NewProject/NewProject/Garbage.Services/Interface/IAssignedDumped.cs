using Garbage.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Services.Interface
{
   public interface IAssignedDumped
    {
        List<AssignDumpedAreaDTO> GetAllAreas();
        List<AssignDumpedAreaDTO> Assignedumped(int id);
    }
}
