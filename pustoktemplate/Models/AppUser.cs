using Microsoft.AspNetCore.Identity;

namespace pustoktemplate.Models
{
	public class AppUser : IdentityUser
	{
		public string FullName { get; set; }
	}
}
