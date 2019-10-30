namespace Pokemon2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoPokemon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoPokemon",
                c => new
                    {
                        IdTipoPokemon = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IdTipoPokemon);
            
            AddColumn("dbo.Pokemon", "TipoPokemonId", c => c.Int(nullable: false));
            AddColumn("dbo.Pokemon", "TipoPokemon_IdTipoPokemon", c => c.Int());
            CreateIndex("dbo.Pokemon", "TipoPokemon_IdTipoPokemon");
            AddForeignKey("dbo.Pokemon", "TipoPokemon_IdTipoPokemon", "dbo.TipoPokemon", "IdTipoPokemon");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pokemon", "TipoPokemon_IdTipoPokemon", "dbo.TipoPokemon");
            DropIndex("dbo.Pokemon", new[] { "TipoPokemon_IdTipoPokemon" });
            DropColumn("dbo.Pokemon", "TipoPokemon_IdTipoPokemon");
            DropColumn("dbo.Pokemon", "TipoPokemonId");
            DropTable("dbo.TipoPokemon");
        }
    }
}
