using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage ="Enter valid email Id")]
        public string EmailId { get; set; }

        public string UserName { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
