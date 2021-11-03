using System;
using ProductMicroservice.DBContexts;
using ProductMicroservice.Models;


namespace DevOpsMicroservicesTests
{
    class DBTestDummyDataInitializer
    {
        public DBTestDummyDataInitializer()
        {
        }

        public void Seed(ProductContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Products.AddRange(
                new Product() { Name = "iPhone", Description = "apple phone", CategoryId = 1, Price = 1000 },
                new Product() { Name = "Lenovo", Description = "Lenovo PC", CategoryId = 2, Price = 900 },
                new Product() { Name = "Windows", Description = "Windows OS", CategoryId = 3, Price = 700 }
                );


            context.Categories.AddRange(
            new Category() { Name = "Phone", Description = "Phones" },
            new Category() { Name = "Computer", Description = "Hardware category" },
            new Category() { Name = "Software", Description = "Different kind of software" }
            //new Category() { Id = '1', Name = "Phone", Description = "Phones" },
            //new Category() { Id = '2', Name = "Computer", Description = "Hardware category" },
            //new Category() { Id = '3', Name = "Software", Description = "Different kind of software" }
            );

            context.SaveChanges();
        }
    }
}
