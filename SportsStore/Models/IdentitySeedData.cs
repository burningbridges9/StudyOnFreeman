using Microsoft.AspNetCore.Identity;

namespace SportsStore.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "12345";
        private const string adminPassword = "12345";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                UserManager<IdentityUser> userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                IdentityUser user = await userManager.FindByIdAsync(adminUser);
                if (user == null)
                {
                    user = new IdentityUser(adminUser);
                    await userManager.CreateAsync(user, adminPassword);
                }
            }
        }
    }
}
