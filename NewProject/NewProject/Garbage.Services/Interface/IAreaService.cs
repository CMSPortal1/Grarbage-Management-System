using Garbage.Common;
using Garbage.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Services.Interface
{
   public interface IAreaService
    {
        List<AreaDTO> GetAllAreas();
        Response<AreaDTO> AddArea(AreaDTO Parameters);
        List<AreaDTO> GetAreasbyCities(int id);

    }
}
