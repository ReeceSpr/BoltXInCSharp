namespace Lab_Example.Migrations.StoreConfiguration
{
    using Lab_Example.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class StoreConfiguration : DbMigrationsConfiguration<Lab_Example.Models.StoreContext>
    {
        public StoreConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Lab_Example.Models.StoreContext";
        }

        protected override void Seed(Lab_Example.Models.StoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var categories = new List<Category>
            {
                new Category {Name = "Software Apps" },
                new Category {Name = "Software Service" },
                new Category {Name = "Hardware Cable" },
                new Category {Name = "Hardware Dash" },
             };
            categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product {Name = "Receipt Stacker", Description = "Your Receipts In One Place", Price = 2.99M, CategoryID= categories.Single(c=>c.Name == "Software Apps").ID},
                new Product {Name = "Cold Count", Description = "Keep Bad Habbits In Check", Price = 2.99M, CategoryID= categories.Single(c=>c.Name == "Software Apps").ID},
                new Product {Name = "BoltX Web", Description = "Lets Get Your Website Sorted", Price = 49.99M, CategoryID= categories.Single(c=>c.Name == "Software Service").ID},
                new Product {Name = "Dash", Description = "Use Your Phone As A DashCam", Price = 2.99M, CategoryID= categories.Single(c=>c.Name == "Software Apps").ID},
                new Product {Name = "Plantify", Description = "Guide To Your New Garden", Price = 2.99M, CategoryID= categories.Single(c=>c.Name == "Software Apps").ID},
                new Product {Name = "BoltX Cable Pack", Description = "Everything You Need To Get Started", Price = 29.99M, CategoryID= categories.Single(c=>c.Name == "Hardware Cable").ID},
                new Product {Name = "BoltX Lightning Adaptor", Description = "Lightning Adaptor", Price = 5.99M, CategoryID= categories.Single(c=>c.Name == "Hardware Cable").ID},
                new Product {Name = "BoltX Micro Adaptor", Description = "Micro Adaptor", Price = 5.99M, CategoryID= categories.Single(c=>c.Name == "Hardware Cable").ID},
                new Product {Name = "BoltX Type C Adaptor", Description = "Type C Adaptor", Price = 5.99M, CategoryID= categories.Single(c=>c.Name == "Hardware Cable").ID},
                new Product {Name = "BoltX Wall Adaptor", Description = "Wall Plug", Price = 15.99M, CategoryID= categories.Single(c=>c.Name == "Hardware Cable").ID},
                new Product {Name = "BoltX Cable", Description = "Just The Cable", Price = 15.99M, CategoryID= categories.Single(c=>c.Name == "Hardware Cable").ID},
                new Product {Name = "Dash Phone Holder", Description = "Phone Holder For Dash", Price = 19.99M, CategoryID= categories.Single(c=>c.Name == "Hardware Dash").ID},

            };
            products.ForEach(c => context.Products.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order { DeliveryAddress = new Address { AddressLine1="1 Some Street", Town="Town1", Country="Country", PostCode="PostCode" }, TotalPrice=631, UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 1) , DeliveryName="Admin" },
                new Order { DeliveryAddress = new Address { AddressLine1="1 Some Street", Town="Town1", Country="Country", PostCode="PostCode" }, TotalPrice=239, UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 2) , DeliveryName="Admin" },
                new Order { DeliveryAddress = new Address { AddressLine1="1 Some Street", Town="Town1", Country="Country", PostCode="PostCode" }, TotalPrice=239, UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 3) , DeliveryName="Admin" },
                new Order { DeliveryAddress = new Address { AddressLine1="1 Some Street", Town="Town1", Country="County", PostCode="PostCode" }, TotalPrice=631, UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 4) , DeliveryName="Admin" },
                new Order { DeliveryAddress = new Address { AddressLine1="1 Some Street", Town="Town1", Country="Country", PostCode="PostCode" }, TotalPrice=19.49M, UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 5) , DeliveryName="Admin" }
            };
            orders.ForEach(c => context.Orders.AddOrUpdate(o => o.DateCreated, c));
            context.SaveChanges();

            var orderLines = new List<OrderLine>
            {
                new OrderLine { OrderID = 1, ProductID = products.Single( c=> c.Name == "BoltX Cable Pack").ID, ProductName ="BoltX Cable Pack", Quantity =1, UnitPrice=products.Single( c=> c.Name == "BoltX Cable Pack").Price },
                new OrderLine { OrderID = 2, ProductID = products.Single( c=> c.Name == "Dash").ID, ProductName="Dash", Quantity=1, UnitPrice=products.Single( c=> c.Name  =="Dash").Price },
                new OrderLine { OrderID = 3, ProductID = products.Single( c=> c.Name == "BoltX Cable Pack").ID, ProductName ="BoltX Cable Pack", Quantity=1, UnitPrice=products.Single( c=> c.Name == "BoltX Cable Pack").Price },
                new OrderLine { OrderID = 4, ProductID = products.Single( c=> c.Name == "Dash Phone Holder").ID, ProductName ="Dash Phone Holder", Quantity=1, UnitPrice=products.Single( c=> c.Name == "Dash Phone Holder").Price },
                new OrderLine { OrderID = 5, ProductID = products.Single( c=> c.Name == "Plantify").ID, ProductName ="Plantify", Quantity=1, UnitPrice=products.Single( c=> c.Name == "Plantify").Price }
            };
            orderLines.ForEach(c => context.OrderLines.AddOrUpdate(ol => ol.OrderID, c));
            context.SaveChanges();
        }
    }
}
