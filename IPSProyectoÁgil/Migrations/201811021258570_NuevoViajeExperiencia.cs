namespace IPSProyectoÁgil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class NuevoViajeExperiencia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ViajesExperiencias",
                c => new
                {
                    Identificador = c.Int(nullable: false, identity: true),
                    nombre = c.String(),
                    autores = c.String(),
                    destino = c.String(),
                    alojamiento = c.String(),
                    transporte = c.String(),
                    lugarInteres = c.String(),
                    presupuesto = c.Single(nullable: false),
                    duracionVideo = c.Int(nullable: false),
                    precio = c.Single(nullable: false),
                })
                .PrimaryKey(t => t.Identificador);
        }

        public override void Down()
        {
            DropTable("dbo.ViajesExperiencias");
        }
    }
}