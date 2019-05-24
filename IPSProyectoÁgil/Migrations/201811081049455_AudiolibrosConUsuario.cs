namespace IPSProyectoÁgil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AudiolibrosConUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Audiolibros", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Audiolibros", "UserId");
            AddForeignKey("dbo.Audiolibros", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Audiolibros", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Audiolibros", new[] { "UserId" });
            DropColumn("dbo.Audiolibros", "UserId");
        }
    }
}
