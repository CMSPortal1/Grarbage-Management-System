using Garbage.Common;
using Garbage.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garbage.Services.Interface
{
    public interface IRolesService
    {
        Response<RolesDTO> AddRoles(RolesDTO Parameters);
        Response<RolesDTO> EditRole(int id);
        List<RolesDTO> AllRoles();
        Response<RolesDTO> SaveRoles(RolesDTO Parameters);
        Response<RolesDTO> DeleteRole(int id);
        Response<RolesDTO> ConfirmedDelRoles(RolesDTO Parameters);
    }
}
