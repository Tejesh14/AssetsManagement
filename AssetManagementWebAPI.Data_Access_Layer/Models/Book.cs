using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementWebAPI.Data_Access_Layer.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public DateTime DateOfPublish { get; set; }
        public string AssignTo { get; set; }
    }
}
