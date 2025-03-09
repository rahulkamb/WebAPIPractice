using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebAPI.Data.ViewModel
{
    public class EmployeeVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Enter valid email Id")]
        public string EmailId { get; set; }

        public string UserName { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
