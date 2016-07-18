namespace MyClassShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyClassShop.Data.myClassShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyClassShop.Data.myClassShopDbContext context)
        {
            CreateProductCategorySample(context);

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new myClassShopDbContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new myClassShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "tri",
            //    Email = "nguyenvantri.cntt@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "nguyễn văn trí"
            //};

            //manager.Create(user, "123456");
            //if(!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole {Name="Admin" } );
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}
            //var adminUser = manager.FindByEmail("nguyenvantri.cntt@gmail.com");
            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(MyClassShop.Data.myClassShopDbContext context)
        {
            if(context.ProductCategories.Count()==0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() {Name="Điện lạnh",Alias="dien-lanh" },
                new ProductCategory() {Name="Viễn thông",Alias="vien-thong" },
                new ProductCategory() {Name="Mỹ phẩm",Alias="my-pham" }
            };

                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
            
        }
    }
}
