namespace IPSProyectoÁgil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PodCastsConUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PodCasts", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.PodCasts", "UserId");
            AddForeignKey("dbo.PodCasts", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PodCasts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.PodCasts", new[] { "UserId" });
            DropColumn("dbo.PodCasts", "UserId");
        }
    }
}
