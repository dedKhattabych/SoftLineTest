using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftLineTest.Models.Models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        [Required]
        public string StatusName { get; set; }
    }
}
