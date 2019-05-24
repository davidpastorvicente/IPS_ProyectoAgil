namespace IPSProyectoÁgil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevaOpinion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Opiniones",
                c => new
                    {
                        Identificador = c.Int(nullable: false, identity: true),
                        nombre_ocio = c.String(),
                        tipo_ocio = c.String(),
                        voto = c.String(),
                    })
                .PrimaryKey(t => t.Identificador);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Opiniones");
        }
    }
}
