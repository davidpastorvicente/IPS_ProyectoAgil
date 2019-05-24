namespace IPSProyectoÁgil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class NuevaRevistaLibro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RevistasLibros",
                c => new
                {
                    Identificador = c.Int(nullable: false, identity: true),
                    titulo = c.String(),
                    autor = c.String(),
                    numPaginas = c.Int(nullable: false),
                    anio = c.Int(nullable: false),
                    revista_libro = c.String(),
                    tipo = c.String(),
                    precio = c.Single(nullable: false),
                })
                .PrimaryKey(t => t.Identificador);

        }

        public override void Down()
        {
            DropTable("dbo.RevistasLibros");
        }
    }
}

