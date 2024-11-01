using System.ComponentModel.DataAnnotations;

namespace Ministery_of_Education.Models.Entities
{
    public class School
    {
        [Key]
        public int SchoolID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string District { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }


    }

}
