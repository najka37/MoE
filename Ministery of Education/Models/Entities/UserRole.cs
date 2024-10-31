using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ministery_of_Education.Models.Entities
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }

        // Navigation property
        public User Users { get; set; }



    }
}