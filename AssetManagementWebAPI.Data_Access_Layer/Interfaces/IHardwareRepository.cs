using AssetManagementWebAPI.Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Data_Access_Layer.Interfaces
{
    public interface IHardwareRepository
    {
        Task<List<Hardware>> Display();
        Task<Hardware> AddHardware(Hardware hardware);
        Task<Hardware> Update(int id, Hardware hardware);
        Task<Hardware> Delete(int id);
        Task<Hardware> Search(int id);
        Task<Hardware> Assign(int id, string userName);
        Task<Hardware> UnAssign(int id);
    }
}
