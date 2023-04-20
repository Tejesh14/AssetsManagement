using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Data_Access_Layer.Models
{
    public class Software
    {
        [Key]
        public int Id { get; set; }
        public string SoftwareName { get; set; }
        public string SoftwareCompany { get; set; }
        public string Version { get; set; }
        public string AssignTo { get; set; }
    }
}
