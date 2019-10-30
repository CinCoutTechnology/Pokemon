namespace Pokemon2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ciudad",
                c => new
                    {
                        IdCiudad = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IdCiudad);
            
            CreateTable(
                "dbo.Entrenador",
                c => new
                    {
                        IdEntrenador = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        CiudadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdEntrenador)
                .ForeignKey("dbo.Ciudad", t => t.CiudadId, cascadeDelete: true)
                .Index(t => t.CiudadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entrenador", "CiudadId", "dbo.Ciudad");
            DropIndex("dbo.Entrenador", new[] { "CiudadId" });
            DropTable("dbo.Entrenador");
            DropTable("dbo.Ciudad");
        }
    }
}
