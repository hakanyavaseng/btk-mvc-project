namespace CourseRegistration.Models
{
    public class Candidate
    {
        public string? Email { get; set; } = String.Empty;
        public string FirstName { get; set; } = String.Empty;       
        public string LastName { get; set; } = String.Empty;
        public string? FullName => $"{FirstName} {LastName}";
        public int? Age { get; set; } = 0;
        public string? SelectedCourse { get; set; } = String.Empty;
        public DateTime AppliedAt { get; set; }

        public Candidate()
        {
            AppliedAt = DateTime.Now;
        }
    }
}
