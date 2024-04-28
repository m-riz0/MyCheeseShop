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
                new Cheese { Name = "Cheddar", Type = "Hard", Description = "Sharp and tangy, Cheddar cheese is known for its rich flavor and smooth texture, perfect for sandwiches or melting on top of dishes.", Strength = "Strong", Price = 10.99m, ImageUrl="cheddar.png" },
                new Cheese { Name = "Brie", Type = "Soft", Description = "Brie cheese is a creamy delight with a mild flavor and soft texture. It pairs wonderfully with fruits and crackers for a sophisticated appetizer.", Strength = "Mild", Price = 12.99m, ImageUrl="brie.png" },
                new Cheese { Name = "Gouda", Type = "Semi-hard", Description = "Gouda cheese boasts a smooth and nutty flavor profile, making it a versatile option for sandwiches, cheese boards, and melting into sauces.", Strength = "Medium", Price = 9.99m, ImageUrl="gouda.png" },
                new Cheese { Name = "Blue Cheese", Type = "Soft", Description = "Bold and distinctive, Blue Cheese features a sharp and tangy taste with characteristic blue mold veins running throughout. It adds depth to salads and sauces.", Strength = "Strong", Price = 15.99m, ImageUrl="blue.png" },
                new Cheese { Name = "Parmesan", Type = "Hard", Description = "Salty and nutty, Parmesan cheese is aged to perfection, imparting a rich and savory flavor to pasta dishes, salads, and risottos.", Strength = "Strong", Price = 14.99m, ImageUrl="parmesan.png" },
                new Cheese { Name = "Mozzarella", Type = "Soft", Description = "Mild and creamy, Mozzarella cheese is the perfect addition to pizzas, caprese salads, and sandwiches, offering a delicate texture and subtle flavor.", Strength = "Mild", Price = 8.99m, ImageUrl="mozzarella.png" },
                new Cheese { Name = "Swiss", Type = "Semi-hard", Description = "Swiss cheese is sweet and nutty with characteristic holes. Its versatility makes it suitable for sandwiches, fondue, and pairing with fruits and wine.", Strength = "Medium", Price = 11.99m, ImageUrl="swiss.png" },
                new Cheese { Name = "Feta", Type = "Soft", Description = "Tangy and crumbly, Feta cheese adds a bold flavor to salads, pastas, and Mediterranean dishes. Its creamy texture complements olives and tomatoes perfectly.", Strength = "Medium", Price = 7.99m, ImageUrl="feta.png" },
                new Cheese { Name = "Provolone", Type = "Semi-hard", Description = "Smooth and slightly tangy, Provolone cheese is a popular choice for sandwiches and Italian dishes. It melts beautifully and enhances the flavor of any dish.", Strength = "Medium", Price = 13.99m, ImageUrl="provolone.png" },
                new Cheese { Name = "Havarti", Type = "Semi-soft", Description = "Buttery with a hint of sweetness, Havarti cheese is a Danish delight. Its creamy texture and mild flavor make it perfect for melting or snacking.", Strength = "Mild", Price = 10.49m, ImageUrl="havarti.png" },
                new Cheese { Name = "Colby Jack", Type = "Semi-hard", Description = "Mild and creamy with marbled colors, Colby Jack cheese is a delightful blend of Colby and Monterey Jack. It's great for snacking, melting, or sandwiches.", Strength = "Mild", Price = 9.49m, ImageUrl="colby jack.png" },
                new Cheese { Name = "Gruyère", Type = "Hard", Description = "Rich and nutty with a hint of sweetness, Gruyère cheese is a Swiss classic. Its complex flavor profile makes it ideal for fondue, quiches, and gratins.", Strength = "Strong", Price = 17.49m, ImageUrl="gruyere.png" },
                new Cheese { Name = "Camembert", Type = "Soft", Description = "Creamy and mushroomy, Camembert cheese is a French favorite. Its velvety texture and rich flavor make it perfect for spreading on bread or crackers.", Strength = "Medium", Price = 16.99m, ImageUrl="camembert.png" },
                new Cheese { Name = "Roquefort", Type = "Blue", Description = "Sharp and tangy with blue mold veins, Roquefort cheese is a French classic. Its bold flavor adds depth to salads, dressings, and sauces.", Strength = "Strong", Price = 18.99m, ImageUrl="roquefort.png" },
                new Cheese { Name = "Monterey Jack", Type = "Semi-hard", Description = "Mild and buttery, Monterey Jack cheese is a versatile option for sandwiches, quesadillas, and snacking. Its smooth texture melts beautifully when heated.", Strength = "Mild", Price = 9.99m, ImageUrl="monterey jack.png" },
                new Cheese { Name = "Gorgonzola", Type = "Blue", Description = "Bold and creamy with blue mold veins, Gorgonzola cheese is an Italian classic. Its intense flavor makes it perfect for salads, pasta dishes, and pairing with fruits.", Strength = "Strong", Price = 19.99m, ImageUrl="gorgonzola.png" },
                new Cheese { Name = "Edam", Type = "Semi-hard", Description = "Mild and slightly salty, Edam cheese is a Dutch delight. Its smooth texture and buttery flavor make it a great addition to cheese platters and sandwiches.", Strength = "Mild", Price = 12.49m, ImageUrl="edam.png" },
                new Cheese { Name = "Muenster", Type = "Semi-soft", Description = "Mild and tangy with an orange rind, Muenster cheese is a German favorite. Its creamy texture and subtle flavor make it perfect for melting on sandwiches.", Strength = "Mild", Price = 10.99m, ImageUrl="muenster.png" },
                new Cheese { Name = "Fontina", Type = "Semi-soft", Description = "Buttery and nutty, Fontina cheese is an Italian classic. Its smooth texture and rich flavor make it ideal for melting into sauces, fondues, and grilled cheese sandwiches.", Strength = "Mild", Price = 14.49m, ImageUrl="fontina.png" },
                new Cheese { Name = "Pepper Jack", Type = "Semi-hard", Description = "Mild and creamy with spicy jalapeno peppers, Pepper Jack cheese adds a kick to sandwiches, burgers, and nachos. Its smooth texture balances the heat perfectly.", Strength = "Mild", Price = 11.49m, ImageUrl="pepper jack.png" },
            ];
        }
    }
}