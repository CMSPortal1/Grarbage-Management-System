using Garbage.Common;
using Garbage.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Services.Interface
{
   public interface ICityService
    {
        List<CityDTO> GetAllCities();
        Response<CityDTO> AddCities(CityDTO Parameters);
        Response<CityDTO> DelCity(int id);
        Response<CityDTO> ConfirmedDelCity(CityDTO Parameters);
    }
}
