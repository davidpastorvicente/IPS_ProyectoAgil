namespace IPSProyectoÁgil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevoAudiolibro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audiolibros",
                c => new
                    {
                        Identificador = c.Int(nullable: false, identity: true),
                        titulo = c.String(),
                        autorDoblaje = c.String(),
                        duracion = c.Int(nullable: false),
                        ano = c.Int(nullable: false),
                        tipo = c.String(),
                        precio = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Identificador);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Audiolibros");
        }
    }
}
