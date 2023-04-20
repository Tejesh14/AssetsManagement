using AssetManagementWebAPI.Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Business_Logic_Layer.Interfaces
{
    public interface ISoftwareService
    {
        Task<List<Software>> Display();
        Task<Software> AddSoftware(Software software);
        Task<Software> Update(int id, Software software);
        Task<Software> Delete(int id);
        Task<Software> Search(int id);
        Task<Software> Assign(int id, string userName);
        Task<Software> UnAssign(int id);
    }
}
