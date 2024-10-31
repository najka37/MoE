using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ministery_of_Education.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign key for UserRole
        public int UserRoleId { get; set; } // Foreign key property
        public UserRole UserRole { get; set; } // Navigation property

    }
}