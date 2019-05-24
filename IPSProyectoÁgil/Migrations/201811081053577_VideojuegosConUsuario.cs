namespace IPSProyectoÁgil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VideojuegosConUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videojuegos", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Videojuegos", "UserId");
            AddForeignKey("dbo.Videojuegos", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videojuegos", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Videojuegos", new[] { "UserId" });
            DropColumn("dbo.Videojuegos", "UserId");
        }
    }
}
