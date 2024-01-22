namespace WebApplication2.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; } = null;

        public string? LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string? Email { get; set; } = null;
        public int Phone { get; set; }
        public string? Gender { get; set; } = null;
    }
}
