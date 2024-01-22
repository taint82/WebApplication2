using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Entities
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public String? FirstName { get; set; } = null;
        public String? LastName { get; set; }
        public String FullName => $"{FirstName} {LastName}";
        public String? Email { get; set; } = null;
        public int Phone { get; set; }
        public String? Gender { get; set; } = null;


    }
}
