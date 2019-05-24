namespace IPSProyectoÁgil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuevaPeliSerie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PeliSeries",
                c => new
                {
                    PeliSerieId = c.Int(nullable: false, identity: true),
                    Titulo = c.String(),
                    CanalProductora = c.String(),
                    Director = c.String(),
                    Actores = c.String(),
                    edadRecomendada = c.Int(nullable: false),
                    PeliOSerie = c.String(),
                    tipo = c.String(),
                    anio = c.Int(nullable: false),
                    precio = c.Single(nullable: false),
                })
                .PrimaryKey(t => t.PeliSerieId);
        }
        
        public override void Down()
        {
            DropTable("dbo.PeliSeries");
        }
    }
}
