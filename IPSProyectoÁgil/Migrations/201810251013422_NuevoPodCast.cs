namespace IPSProyectoÁgil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevoPodCast : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PodCasts",
                c => new
                    {
                        Identificador = c.Int(nullable: false, identity: true),
                        emisora = c.String(),
                        programa = c.String(),
                        participantes = c.Int(nullable: false),
                        duracion = c.Int(nullable: false),
                        fecha = c.Int(nullable: false),
                        tematica = c.String(),
                        precio = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Identificador);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PodCasts");
        }
    }
}
