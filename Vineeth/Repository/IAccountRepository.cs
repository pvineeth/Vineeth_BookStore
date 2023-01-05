using Microsoft.AspNetCore.Identity;
using Vineeth.Models;

namespace Vineeth.Repository
{
	public interface IAccountRepository
	{
		Task<IdentityResult> createuser(SignupUserModel user);
	   Task<SignInResult> passwordsignAsync(SignINModel user);
		Task signout();
	}
}