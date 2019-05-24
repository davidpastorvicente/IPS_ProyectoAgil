namespace IPSProyectoÁgil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ViajesExperienciaConUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ViajesExperiencias", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ViajesExperiencias", "UserId");
            AddForeignKey("dbo.ViajesExperiencias", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ViajesExperiencias", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ViajesExperiencias", new[] { "UserId" });
            DropColumn("dbo.ViajesExperiencias", "UserId");
        }
    }
}
