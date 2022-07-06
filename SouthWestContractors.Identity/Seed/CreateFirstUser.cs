using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace SouthWestContractors.Identity.Seed
{
    public class UserCreator
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager)
        {
            var applicationUser = new IdentityUser
            {
                
                UserName = "johnsmith",
                Email = "john@test.com",
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(applicationUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(applicationUser, "Plural&01?");
            }
        }
    }
}
