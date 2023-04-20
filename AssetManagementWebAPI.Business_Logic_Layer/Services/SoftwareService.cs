using AssetManagementWebAPI.Business_Logic_Layer.Interfaces;
using AssetManagementWebAPI.Data_Access_Layer.Interfaces;
using AssetManagementWebAPI.Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Business_Logic_Layer.Services
{
    public class SoftwareService : ISoftwareService
    {
        private readonly ISoftwareRepository _softwareRepository;
        public SoftwareService(ISoftwareRepository softwareRepository)
        {
            _softwareRepository = softwareRepository;
        }
        public async Task<Software> AddSoftware(Software software)
        {
            return await _softwareRepository.AddSoftware(software);
        }

        public async Task<Software> Assign(int id, string userName)
        {
            return await _softwareRepository.Assign(id, userName);
        }

        public async Task<Software> Delete(int id)
        {
            return await _softwareRepository.Delete(id);
        }

        public async Task<List<Software>> Display()
        {
            return await _softwareRepository.Display();
        }

        public async Task<Software> Search(int id)
        {
            return await _softwareRepository.Search(id);
        }

        public async Task<Software> UnAssign(int id)
        {
            return await _softwareRepository.UnAssign(id);
        }

        public async Task<Software> Update(int id, Software software)
        {
            return await _softwareRepository.Update(id, software);
        }
    }
}
