using System;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using NPOI.HPSF;

namespace Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser { UserName = "Test1", Email = "administrator@localhost" };
            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Test123!");
            }

            var defaultSuperUserRole = new IdentityRole() { Name = "superuser", NormalizedName = "superuser", Id = Guid.NewGuid().ToString() };
            if (roleManager.Roles.All(u => u.Name != defaultSuperUserRole.Name))
            {
                await roleManager.CreateAsync(defaultSuperUserRole);
                await userManager.AddToRoleAsync(defaultUser, defaultSuperUserRole.NormalizedName);
            }
        }

        public static async Task SeedTranslationDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            //if (!context.TodoLists.Any())
            {
                /*
                context.TodoLists.Add(new TodoList
                {
                    Title = "Shopping",
                    Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" }
                    }
                });
                */
                await context.SaveChangesAsync();
            }
        }
    }
}
