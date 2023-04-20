using AssetManagementWebAPI.Data_Access_Layer.Context;
using AssetManagementWebAPI.Data_Access_Layer.Interfaces;
using AssetManagementWebAPI.Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Data_Access_Layer.Repositories
{
    public class HardwareRepository : IHardwareRepository
    {
        private readonly AssetDBContext _assetContext;
        public HardwareRepository(AssetDBContext assetContext)
        {
            _assetContext = assetContext;
        }
        public async Task<Hardware> AddHardware(Hardware hardware)
        {
            var addHardware = await _assetContext.AddAsync(hardware);
            await _assetContext.SaveChangesAsync();
            return addHardware.Entity;
        }

        public async Task<Hardware> Assign(int id, string userName)
        {
            var findHardware = await _assetContext.Hardwares.FindAsync(id);
            if (findHardware.AssignTo == null)
            {
                findHardware.AssignTo = userName;
                await _assetContext.SaveChangesAsync();
                return findHardware;
            }
            return findHardware;
        }

        public async Task<Hardware> Delete(int id)
        {
            var findHardware = await _assetContext.Hardwares.FindAsync(id);
            _assetContext.Remove(findHardware);
            await _assetContext.SaveChangesAsync();
            return findHardware;
        }

        public async Task<List<Hardware>> Display()
        {
            var hardwares = await _assetContext.Hardwares.ToListAsync();
            return hardwares;
        }

        public async Task<Hardware> Search(int id)
        {
            var findHardware = await _assetContext.Hardwares.FindAsync(id);
            return findHardware;
        }

        public async Task<Hardware> UnAssign(int id)
        {
            var findHardware = await _assetContext.Hardwares.FindAsync(id);
            findHardware.AssignTo = null;
            await _assetContext.SaveChangesAsync();
            return findHardware;
        }

        public async Task<Hardware> Update(int id, Hardware hardware)
        {
            var findHardware = await _assetContext.Hardwares.FindAsync(id);
            findHardware.HardwareName = hardware.HardwareName;
            findHardware.HardwareCompany = hardware.HardwareCompany;
            findHardware.DateOfManufacture = hardware.DateOfManufacture;
            findHardware.AssignTo = hardware.AssignTo;

            await _assetContext.SaveChangesAsync();
            return findHardware;
        }
    }
}
