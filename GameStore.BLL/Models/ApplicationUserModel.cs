using System.ComponentModel.DataAnnotations;

namespace GameStore.BLL.Models
{
    public class ApplicationUserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
