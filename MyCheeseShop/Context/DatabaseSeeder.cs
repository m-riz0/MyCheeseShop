using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;
using System.Runtime.CompilerServices;

namespace MyCheeseShop.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if (!_context.Cheeses.Any())
            {
                var cheeses = GetCheeses();
                _context.Cheeses.AddRange(cheeses);
                await _context.SaveChangesAsync();
            }

            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

                var adminEmail = "admin@cheese.com";
                var adminPassword = "Cheese123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Admin Street",
                    City = "Adminville",
                    PostCode = "AD12 MIN"
                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }

        private List<Cheese> GetCheeses()
        {
            return
            [
                new Cheese { Name = "Cheddar", Type = "Hard", Description = "Sharp and tangy", Strength = "Strong", Price = 10.99m, ImageUrl="cheddar.png" },
                new Cheese { Name = "Brie", Type = "Soft", Description = "Creamy and mild", Strength = "Mild", Price = 12.99m, ImageUrl="brie.png" },
                new Cheese { Name = "Gouda", Type = "Semi-hard", Description = "Smooth and nutty", Strength = "Medium", Price = 9.99m, ImageUrl="gouda.png" },
                new Cheese { Name = "Blue Cheese", Type = "Soft", Description = "Sharp and tangy with blue mold veins", Strength = "Strong", Price = 15.99m, ImageUrl="blue.png" },
                new Cheese { Name = "Parmesan", Type = "Hard", Description = "Salty and nutty", Strength = "Strong", Price = 14.99m, ImageUrl="parmesan.png" },
                new Cheese { Name = "Mozzarella", Type = "Soft", Description = "Mild and creamy", Strength = "Mild", Price = 8.99m, ImageUrl="mozzarella.png" },
                new Cheese { Name = "Swiss", Type = "Semi-hard", Description = "Sweet and nutty with holes", Strength = "Medium", Price = 11.99m, ImageUrl="swiss.png" },
                new Cheese { Name = "Feta", Type = "Soft", Description = "Tangy and crumbly", Strength = "Medium", Price = 7.99m, ImageUrl="feta.png" },
                new Cheese { Name = "Provolone", Type = "Semi-hard", Description = "Smooth and slightly tangy", Strength = "Medium", Price = 13.99m, ImageUrl="provolone.png" },
                new Cheese { Name = "Havarti", Type = "Semi-soft", Description = "Buttery with a hint of sweetness", Strength = "Mild", Price = 10.49m, ImageUrl="havarti.png" },
                new Cheese { Name = "Colby Jack", Type = "Semi-hard", Description = "Mild and creamy with marbled colors", Strength = "Mild", Price = 9.49m, ImageUrl="colby jack.png" },
                new Cheese { Name = "Gruyère", Type = "Hard", Description = "Rich and nutty with a hint of sweetness", Strength = "Strong", Price = 17.49m, ImageUrl="gruyere.png" },
                new Cheese { Name = "Camembert", Type = "Soft", Description = "Creamy and mushroomy", Strength = "Medium", Price = 16.99m, ImageUrl="camembert.png" },
                new Cheese { Name = "Roquefort", Type = "Blue", Description = "Sharp and tangy with blue mold veins", Strength = "Strong", Price = 18.99m, ImageUrl="roquefort.png" },
                new Cheese { Name = "Monterey Jack", Type = "Semi-hard", Description = "Mild and buttery", Strength = "Mild", Price = 9.99m, ImageUrl="monterey jack.png" },
                new Cheese { Name = "Gorgonzola", Type = "Blue", Description = "Bold and creamy with blue mold veins", Strength = "Strong", Price = 19.99m, ImageUrl="gorgonzola.png" },
                new Cheese { Name = "Edam", Type = "Semi-hard", Description = "Mild and slightly salty", Strength = "Mild", Price = 12.49m, ImageUrl="edam.png" },
                new Cheese { Name = "Muenster", Type = "Semi-soft", Description = "Mild and tangy with an orange rind", Strength = "Mild", Price = 10.99m, ImageUrl="muenster.png" },
                new Cheese { Name = "Fontina", Type = "Semi-soft", Description = "Buttery and nutty", Strength = "Mild", Price = 14.49m, ImageUrl="fontina.png" },
                new Cheese { Name = "Pepper Jack", Type = "Semi-hard", Description = "Mild and creamy with spicy jalapeno peppers", Strength = "Mild", Price = 11.49m, ImageUrl="pepper jack.png" },
            ];
        }
    }
}