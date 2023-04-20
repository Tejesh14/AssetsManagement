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
    public class HardwareService : IHardwareService
    {
        private readonly IHardwareRepository _hardwareRepository;
        public HardwareService(IHardwareRepository hardwareRepository)
        {
            _hardwareRepository = hardwareRepository;
        }
        public async Task<Hardware> AddHardware(Hardware hardware)
        {
            return await _hardwareRepository.AddHardware(hardware);
        }

        public async Task<Hardware> Assign(int id, string userName)
        {
            return await _hardwareRepository.Assign(id, userName);
        }

        public async Task<Hardware> Delete(int id)
        {
            return await _hardwareRepository.Delete(id);
        }

        public async Task<List<Hardware>> Display()
        {
            return await _hardwareRepository.Display();
        }

        public async Task<Hardware> Search(int id)
        {
            return await _hardwareRepository.Search(id);
        }

        public async Task<Hardware> UnAssign(int id)
        {
            return await _hardwareRepository.UnAssign(id);
        }

        public async Task<Hardware> Update(int id, Hardware hardware)
        {
            return await _hardwareRepository.Update(id, hardware);
        }
    }
}
