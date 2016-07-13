namespace MyClassShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDBShop2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ProductCategories", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategories", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Posts", "CreatedBy", c => c.String(maxLength: 256));
            DropColumn("dbo.Products", "CreateBy");
            DropColumn("dbo.ProductCategories", "CreateBy");
            DropColumn("dbo.PostCategories", "CreateBy");
            DropColumn("dbo.Posts", "CreateBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "CreateBy", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategories", "CreateBy", c => c.String(maxLength: 256));
            AddColumn("dbo.ProductCategories", "CreateBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Products", "CreateBy", c => c.String(maxLength: 256));
            DropColumn("dbo.Posts", "CreatedBy");
            DropColumn("dbo.PostCategories", "CreatedBy");
            DropColumn("dbo.ProductCategories", "CreatedBy");
            DropColumn("dbo.Products", "CreatedBy");
        }
    }
}
