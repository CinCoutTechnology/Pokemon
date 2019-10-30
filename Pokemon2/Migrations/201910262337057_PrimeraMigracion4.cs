namespace Pokemon2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraMigracion4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RelacionEntradorPokemon",
                c => new
                    {
                        IdRelacion = c.Int(nullable: false, identity: true),
                        EntrenadorId = c.Int(nullable: false),
                        PokemonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRelacion)
                .ForeignKey("dbo.Entrenador", t => t.EntrenadorId, cascadeDelete: true)
                .ForeignKey("dbo.Pokemon", t => t.PokemonId, cascadeDelete: true)
                .Index(t => t.EntrenadorId)
                .Index(t => t.PokemonId);
            
            CreateTable(
                "dbo.Pokemon",
                c => new
                    {
                        IdPokemon = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IdPokemon);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RelacionEntradorPokemon", "PokemonId", "dbo.Pokemon");
            DropForeignKey("dbo.RelacionEntradorPokemon", "EntrenadorId", "dbo.Entrenador");
            DropIndex("dbo.RelacionEntradorPokemon", new[] { "PokemonId" });
            DropIndex("dbo.RelacionEntradorPokemon", new[] { "EntrenadorId" });
            DropTable("dbo.Pokemon");
            DropTable("dbo.RelacionEntradorPokemon");
        }
    }
}
