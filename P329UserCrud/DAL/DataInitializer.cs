using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using P329UserCrud.DAL.Entities;
using P329UserCrud.Data;

namespace P329UserCrud.DAL
{
    public class DataInitializer
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private AppDbContext _dbContext;

        public DataInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public async Task SeedData()
        {
            await _dbContext.Database.MigrateAsync();

            var roles = new List<string> { RoleConstants.AdminRole, RoleConstants.ModeratorRole, RoleConstants.ViewerRole };

            foreach (var role in roles)
            {
                var existRole = await _roleManager.FindByNameAsync(role);

                if (existRole != null)
                    continue;

                var roleResult = await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = role
                });

                if (!roleResult.Succeeded)
                {
                    //logging
                }
            }

            var existUser = await _userManager.FindByNameAsync("Admin");

            if (existUser != null)
            {
                return;
            }

            var user = new AppUser
            {
                UserName = "Admin",
                Email = "admin@code",
            };

            var result = await _userManager.CreateAsync(user, "123456");

            if (!result.Succeeded)
            {
                //logging

                return;
            }

            result = await _userManager.AddToRoleAsync(user, RoleConstants.AdminRole);

            if (!result.Succeeded)
            {
                //logging
            }
        }
    }

}
