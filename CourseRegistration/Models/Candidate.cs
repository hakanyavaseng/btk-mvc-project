using System.ComponentModel.DataAnnotations;

namespace CourseRegistration.Models
{
    public class Candidate
    {
        [Required(ErrorMessage = "Please enter your email address")]
        public string? Email { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; } = String.Empty;     

        [Required(ErrorMessage = "Please enter your last name")]  
        public string LastName { get; set; } = String.Empty;
        public string? FullName => $"{FirstName} {LastName}";

        [Required(ErrorMessage = "Please select your age")]
        public int? Age { get; set; } = 0;

        [Required(ErrorMessage = "Please select your course")]
        public string? SelectedCourse { get; set; } = String.Empty;
        public DateTime AppliedAt { get; set; }

        public Candidate()
        {
            AppliedAt = DateTime.Now;
        }
    }
}
