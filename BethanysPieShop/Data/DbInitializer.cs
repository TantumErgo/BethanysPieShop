using BethanysPieShop.Auth;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(AppDbContext context,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            //if (!context.Roles.Any())
            //{
                var roleList = new List<IdentityRole> {
                    new IdentityRole { Name = "Administrators" },
                    new IdentityRole { Name = "Users" },
                    new IdentityRole { Name = "Test role" } };

                foreach (var role in roleList) { await roleManager.CreateAsync(role); }
            //}

            //if (!context.Users.Any())
            //{
                var userList = new List<ApplicationUser> {
                    new ApplicationUser { UserName = "Nik", Email = "miscends@gmail.com", Country = "United States", City = "", Birthdate = DateTime.Parse("1992/06/28") },
                    new ApplicationUser { UserName = "Test", Email = "test@snowball.be", Country = "", City = "", Birthdate = DateTime.Parse("1987/01/1") },
                    new ApplicationUser { UserName = "Demo", Email = "demo@snowball.be", Country = "", City = "", Birthdate = DateTime.Parse("2000/01/15") } };

                foreach (var user2 in userList) { await userManager.CreateAsync(user2, "P@$$w0rd"); }
            //}

            //if (!context.UserRoles.Any())
            //{
                var adminUser = await userManager.FindByEmailAsync("miscends@gmail.com");
                await userManager.AddToRoleAsync(adminUser, "Administrators");
                //adminUser = await userManager.FindByEmailAsync("john@snowball.be");
                //await userManager.AddToRoleAsync(adminUser, "Administrators");
            //}

            //if (!context.UserClaims.Any())
            //{
              //  var user = await userManager.FindByEmailAsync("miscends@gmail.com");
              //  var claim = new IdentityUserClaim<string> { ClaimType = "Delete Pie", ClaimValue = "Delete Pie" };
              //  var adminUser2 = await userManager.FindByEmailAsync("miscends@gmail.com");
              //  user.Claims.Add(claim);
              //  await userManager.UpdateAsync(user);
           // }           

            await context.SaveChangesAsync();
            //context.SaveChanges();

        }

        

                
    }
}
    

