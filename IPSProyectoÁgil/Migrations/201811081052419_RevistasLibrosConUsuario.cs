namespace IPSProyectoÁgil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevistasLibrosConUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RevistasLibros", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.RevistasLibros", "UserId");
            AddForeignKey("dbo.RevistasLibros", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RevistasLibros", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.RevistasLibros", new[] { "UserId" });
            DropColumn("dbo.RevistasLibros", "UserId");
        }
    }
}
