using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftLineTest.Models.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("StatusID")]
        public virtual Status Status { get; set; }
    }
}
