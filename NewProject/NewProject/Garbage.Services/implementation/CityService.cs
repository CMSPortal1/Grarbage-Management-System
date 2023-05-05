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
   public class CityService : ICityService
    {
        public Response<CityDTO> AddCities(CityDTO City)
        {
            Response<CityDTO> UserData = new Response<CityDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<CityDTO>(AppConstant.baseURL + "CityAPI/AddCities" + "", City);
        }

        public Response<CityDTO> DelCity(int id)
        {
            return HttpHelper.GetRequest<CityDTO>(AppConstant.baseURL + "CityAPICrud/DeleteCity?ID=" + id, "");

        }

        public List<CityDTO> GetAllCities()
        {
            return HttpHelper.DownloadSerializedJsonViaGET<CityDTO>(AppConstant.baseURL + "CityAPI/GetCities" + "");
        }
        public Response<CityDTO> ConfirmedDelCity(CityDTO City)
        {
            Response<CityDTO> UserData = new Response<CityDTO>();

            return HttpHelper.DownloadSerializedJsonViaPOST<CityDTO>(AppConstant.baseURL + "CityAPICrud/CofirmedDel" + "", City);

        }
    }
}
