namespace Shop.Web.Data
{
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Shop.Web.Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();
            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Customer");

            var user = await this.userHelper.GetUserByEmailAsync("yusiel.re@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Yusiel",
                    LastName = "Rodríguez",
                    Email = "yusiel.re@gmail.com",
                    UserName = "yusiel.re@gmail.com",
                    PhoneNumber = "093370777",
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isInRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var user2 = await this.userHelper.GetUserByEmailAsync("fiorella@gmail.com");
            if (user2 == null)
            {
                user2 = new User
                {
                    FirstName = "Fiorella",
                    LastName = "Fornesi",
                    Email = "fiorella@gmail.com",
                    UserName = "fiorella@gmail.com",
                    PhoneNumber = "095370777",
                };

                var result = await this.userHelper.AddUserAsync(user2, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await this.userHelper.AddUserToRoleAsync(user2, "Customer");
            }

            var isInRole2 = await this.userHelper.IsUserInRoleAsync(user2, "Customer");
            if (!isInRole2)
            {
                await this.userHelper.AddUserToRoleAsync(user2, "Customer");
            }

            var user3 = await this.userHelper.GetUserByEmailAsync("mario@gmail.com");
            if (user3 == null)
            {
                user3 = new User
                {
                    FirstName = "Mario",
                    LastName = "Rodriguez",
                    Email = "mario@gmail.com",
                    UserName = "mario@gmail.com",
                    PhoneNumber = "053112080",
                };

                var result = await this.userHelper.AddUserAsync(user3, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await this.userHelper.AddUserToRoleAsync(user3, "Customer");
            }

            var isInRole3 = await this.userHelper.IsUserInRoleAsync(user3, "Customer");
            if (!isInRole3)
            {
                await this.userHelper.AddUserToRoleAsync(user3, "Customer");
            }


            if (!this.context.Products.Any())
            {
                this.AddProduct("Mouse", user, "~/images/Products/mouse.png");
                this.AddProduct("Laptop", user, "~/images/Products/laptop.png");
                this.AddProduct("Audífonos", user, "~/images/Products/audifonos.png");
                this.AddProduct("Pantalones", user, "~/images/Products/pantalon.png");
                this.AddProduct("TV", user, "~/images/Products/tv.png");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user, string image)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(50),
                User = user,
                ImageUrl = image
                
            });
        }
    }

}
