using Microsoft.AspNetCore.Identity;

namespace Vineeth.Models
{
	public class ApplicationUser:IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime? DateofBirth { get; set; }
	}
}
