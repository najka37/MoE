using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ministery_of_Education.Models.Entities
{
    [Table("SchoolType")]  // Specify the table name
    public class SchoolType
    {
        [Key]
        public Int64 SchoolTypeID { get; set; } 

        [Required]
        public string Name { get; set; }

    }
}
