using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ddiscourse.Data;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var roles = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var users = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        await db.Database.MigrateAsync();   // applies pending migrations automatically

        foreach (var role in new[] { "Admin", "Moderator", "Contributor" })
            if (!await roles.RoleExistsAsync(role))
                await roles.CreateAsync(new IdentityRole(role));

        const string adminEmail = "admin@discourse.local";
        if (await users.FindByEmailAsync(adminEmail) is null)
        {
            var admin = new ApplicationUser
            {
                UserName = "admin",
                Email = adminEmail,
                EmailConfirmed = true,
                FirstName = "Site",
                LastName = "Admin"
            };
            var result = await users.CreateAsync(admin, "Admin#12345");   // change before deploying
            if (result.Succeeded) await users.AddToRoleAsync(admin, "Admin");
        }

        if (!await db.Boards.AnyAsync())
        {
            db.Boards.AddRange(
                new Board { Name = "Technology" },
                new Board { Name = "Faith & Life" },
                new Board { Name = "Education" },
                new Board { Name = "Personal Growth" },
                new Board { Name = "Health & Wellness" },
                new Board { Name = "Careers" });
            await db.SaveChangesAsync();
        }
    }
}