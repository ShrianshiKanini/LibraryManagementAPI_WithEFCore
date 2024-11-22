using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Model
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
        public virtual ICollection<RequestedBooks> RequestedBooks { get; set; } = new List<RequestedBooks>();

        public virtual ICollection<UserHistory> UserHistories { get; set; } = new List<UserHistory>();


    }
}
