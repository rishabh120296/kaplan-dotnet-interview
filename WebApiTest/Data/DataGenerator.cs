using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiTest.Data
{
    public class DataGenerator
    {
        public static void Initialize( IServiceProvider serviceProvider )
        {
            using var context = new TestDbContext( serviceProvider.GetRequiredService<DbContextOptions<TestDbContext>>() );

            if ( context.Orders.Any() )
            {
                return; // Data was already seeded
            }

            var productId = 1;
            context.Products.AddRange( new Product
                                           {
                                               ProductID = productId++,
                                               Name = "Schweser CFA PremiumPlus Package",
                                               UnitPrice = 1499.00m,
                                           },
                                       new Product
                                           {
                                               ProductID = productId++,
                                               Name = "KPE Essential (Online) - Life & Health (for Iowa)",
                                               UnitPrice = 169.00m,
                                           },
                                       new Product
                                           {
                                               ProductID = productId++,
                                               Name = "KPE Total Access CE - All Lines",
                                               UnitPrice = 59.00m,
                                           }
                                     );
            context.SaveChanges();

            var personId = 1;
            context.Persons.AddRange( new Person { PersonID = personId++, FirstName = "Joe", LastName = "Doe", },
                                      new Person { PersonID = personId++, FirstName = "Melodi", LastName = "Chagolla" },
                                      new Person { PersonID = personId++, FirstName = "Denis", LastName = "Widger" },
                                      new Person { PersonID = 4, FirstName = "Beverley", LastName = "Greaney" },
                                      new Person { PersonID = 5, FirstName = "Starla", LastName = "Penick" },
                                      new Person { PersonID = 6, FirstName = "Euna", LastName = "Ferrer" },
                                      new Person { PersonID = 7, FirstName = "Orval", LastName = "Gleeson" },
                                      new Person { PersonID = 8, FirstName = "Alvaro", LastName = "Losh" },
                                      new Person { PersonID = 9, FirstName = "Chauncey", LastName = "Aquilar" },
                                      new Person { PersonID = 10, FirstName = "Maybelle", LastName = "Stonerock" },
                                      new Person { PersonID = 11, FirstName = "Jared", LastName = "Gunderson" },
                                      new Person { PersonID = 12, FirstName = "Alia", LastName = "Monarrez" },
                                      new Person { PersonID = 13, FirstName = "Winona", LastName = "Avelar" },
                                      new Person { PersonID = 14, FirstName = "Mac", LastName = "Locklin" },
                                      new Person { PersonID = 15, FirstName = "Alina", LastName = "Wragg" },
                                      new Person { PersonID = 16, FirstName = "Jamar", LastName = "Adamo" },
                                      new Person { PersonID = 17, FirstName = "Elna", LastName = "Hodgson" },
                                      new Person { PersonID = 18, FirstName = "Genna", LastName = "Salvaggio" },
                                      new Person { PersonID = 19, FirstName = "Lorraine", LastName = "Ringdahl" },
                                      new Person { PersonID = 20, FirstName = "Margurite", LastName = "Frampton" },
                                      new Person { PersonID = 21, FirstName = "Anna", LastName = "Kyger" },
                                      new Person { PersonID = 22, FirstName = "Dominique", LastName = "Dube" },
                                      new Person { PersonID = 23, FirstName = "Obdulia", LastName = "Silvis" },
                                      new Person { PersonID = 24, FirstName = "Laticia", LastName = "Brathwaite" },
                                      new Person { PersonID = 25, FirstName = "Tashina", LastName = "Mobley" },
                                      new Person { PersonID = 26, FirstName = "Lesley", LastName = "Kimball" },
                                      new Person { PersonID = 27, FirstName = "Jimmie", LastName = "Patten" },
                                      new Person { PersonID = 28, FirstName = "Sol", LastName = "Minarik" },
                                      new Person { PersonID = 29, FirstName = "Denita", LastName = "Sawin" },
                                      new Person { PersonID = 30, FirstName = "Kristal", LastName = "Deleon" },
                                      new Person { PersonID = 31, FirstName = "Flora", LastName = "Bornstein" },
                                      new Person { PersonID = 32, FirstName = "Maurice", LastName = "Cottman" },
                                      new Person { PersonID = 33, FirstName = "Keith", LastName = "Perry" },
                                      new Person { PersonID = 34, FirstName = "Allison", LastName = "Meszaros" },
                                      new Person { PersonID = 35, FirstName = "Asa", LastName = "Sobota" },
                                      new Person { PersonID = 36, FirstName = "Kenna", LastName = "Garabedian" },
                                      new Person { PersonID = 37, FirstName = "Floria", LastName = "Haws" },
                                      new Person { PersonID = 38, FirstName = "Cody", LastName = "Sayers" },
                                      new Person { PersonID = 39, FirstName = "Joane", LastName = "Armand" },
                                      new Person { PersonID = 40, FirstName = "Dayna", LastName = "Moak" },
                                      new Person { PersonID = 41, FirstName = "Sherlyn", LastName = "Oakes" },
                                      new Person { PersonID = 42, FirstName = "Nathanael", LastName = "Sprow" },
                                      new Person { PersonID = 43, FirstName = "Angelena", LastName = "Morra" },
                                      new Person { PersonID = 44, FirstName = "Nicole", LastName = "Helle" },
                                      new Person { PersonID = 45, FirstName = "Maribel", LastName = "Rotunno" },
                                      new Person { PersonID = 46, FirstName = "Ambrose", LastName = "Tobia" },
                                      new Person { PersonID = 47, FirstName = "Darlene", LastName = "Biondo" },
                                      new Person { PersonID = 48, FirstName = "Jenise", LastName = "Barnette" },
                                      new Person { PersonID = 49, FirstName = "Malka", LastName = "Glance" },
                                      new Person { PersonID = 50, FirstName = "Shanta", LastName = "Ohlson" },
                                      new Person { PersonID = 51, FirstName = "Kirsten", LastName = "Wohl" }
                                    );
            context.SaveChanges();

            var orderId = 101;
            foreach ( var person in context.Persons )
            {
                var order = new Order
                                {
                                    OrderID = orderId++,
                                    CreatedAt = DateTime.Now,
                                    Person = person,
                                    OrderingPersonID = person.PersonID
                                };

                short lineNumber = 0;
                foreach ( var product in context.Products )
                {
                    var orderItem = new OrderItem
                                        {
                                            Order = order,
                                            LineNumber = ++lineNumber,
                                            OrderID = order.OrderID,
                                            Price = product.UnitPrice,
                                            Product = product,
                                            ProductID = product.ProductID,
                                            Quantity = 1,
                                            StudentPerson = person,
                                            StudentPersonID = person.PersonID
                                        };

                    order.OrderItems.Add( orderItem );
                    context.OrderItems.Add( orderItem );
                }

                context.Orders.Add( order );
                context.SaveChanges();
            }

            context.SaveChangesAsync();
        }
    }
}
