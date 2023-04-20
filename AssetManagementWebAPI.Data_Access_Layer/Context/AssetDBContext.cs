using AssetManagementWebAPI.Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Data_Access_Layer.Context
{
    public class AssetDBContext : DbContext
    {
        public AssetDBContext(DbContextOptions<AssetDBContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Hardware> Hardwares { get; set; }
        public DbSet<Software> Softwares { get; set; }
    }
}
