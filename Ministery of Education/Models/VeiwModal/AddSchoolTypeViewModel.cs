using System.ComponentModel.DataAnnotations;

namespace Ministery_of_Education.Models.ViewModels
{
    public class AddSchoolTypeViewModel
    {
        [Required(ErrorMessage = "The School Type name is required.")]
        [Display(Name = "School Type Name")]
        public string Name { get; set; }
    }
}
