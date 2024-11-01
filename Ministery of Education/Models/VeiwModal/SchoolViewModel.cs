namespace Ministery_of_Education.Models.ViewModel
{
    public class SchoolViewModel
    {
        public int SchoolID { get; set; } // This may be optional for creation
        public string Name { get; set; }
        public string Location { get; set; }
        public string District { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
    }
}
