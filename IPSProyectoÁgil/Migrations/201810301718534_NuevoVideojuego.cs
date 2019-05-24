namespace IPSProyectoÁgil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevoVideojuego : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videojuegos",
                c => new
                    {
                        identificador = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        creador = c.String(),
                        edad = c.Int(nullable: false),
                        tipo = c.String(),
                        precio = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.identificador);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Videojuegos");
        }
    }
}
