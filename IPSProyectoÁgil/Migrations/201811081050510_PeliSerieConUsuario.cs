namespace IPSProyectoÁgil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PeliSerieConUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PeliSeries", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.PeliSeries", "UserId");
            AddForeignKey("dbo.PeliSeries", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeliSeries", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.PeliSeries", new[] { "UserId" });
            DropColumn("dbo.PeliSeries", "UserId");
        }
    }
}
