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
    public class SoftwareRepository : ISoftwareRepository
    {
        private readonly AssetDBContext _assetContext;
        public SoftwareRepository(AssetDBContext assetContext)
        {
            _assetContext = assetContext;
        }
        public async Task<Software> AddSoftware(Software software)
        {
            var addSoftware = await _assetContext.AddAsync(software);
            await _assetContext.SaveChangesAsync();
            return addSoftware.Entity;
        }

        public async Task<Software> Assign(int id, string userName)
        {
            var findSoftware = await _assetContext.Softwares.FindAsync(id);
            if (findSoftware.AssignTo == null)
            {
                findSoftware.AssignTo = userName;
                await _assetContext.SaveChangesAsync();
                return findSoftware;
            }
            return findSoftware;
        }

        public async Task<Software> Delete(int id)
        {
            var findSoftware = await _assetContext.Softwares.FindAsync(id);
            _assetContext.Remove(findSoftware);
            await _assetContext.SaveChangesAsync();
            return findSoftware;
        }

        public async Task<List<Software>> Display()
        {
            var softwares = await _assetContext.Softwares.ToListAsync();
            return softwares;
        }

        public async Task<Software> Search(int id)
        {
            var findSoftware = await _assetContext.Softwares.FindAsync(id);
            return findSoftware;
        }

        public async Task<Software> UnAssign(int id)
        {
            var findSoftware = await _assetContext.Softwares.FindAsync(id);
            findSoftware.AssignTo = null;
            await _assetContext.SaveChangesAsync();
            return findSoftware;
        }

        public async Task<Software> Update(int id, Software software)
        {
            var findSoftware = await _assetContext.Softwares.FindAsync(id);
            findSoftware.SoftwareName = software.SoftwareName;
            findSoftware.SoftwareCompany = software.SoftwareCompany;
            findSoftware.Version = software.Version;
            findSoftware.AssignTo = software.AssignTo;

            await _assetContext.SaveChangesAsync();
            return findSoftware;
        }
    }
}
