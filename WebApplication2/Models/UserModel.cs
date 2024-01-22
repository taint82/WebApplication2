namespace WebApplication2.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public String? FirstName { get; set; } = null;

        public String? LastName { get; set; }
        public String FullName => $"{FirstName} {LastName}";
        public String? Email { get; set; } = null;
        public int Phone { get; set; }
        public String? Gender { get; set; } = null;
    }
}
