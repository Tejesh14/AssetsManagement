using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Data_Access_Layer.Models
{
    public class Hardware
    {
        [Key]
        public int Id { get; set; }
        public string HardwareName { get; set; }
        public string HardwareCompany { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public string AssignTo { get; set; }
    }
}
