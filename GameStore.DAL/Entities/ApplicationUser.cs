using Microsoft.AspNetCore.Identity;

namespace GameStore.DAL.Entities
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhotoFileName { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public IEnumerable<Comment>? UserComments { get; set; }
    }
}
