namespace Pokemon2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitPokemTipo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pokemon", "TipoPokemon_IdTipoPokemon", "dbo.TipoPokemon");
            DropIndex("dbo.Pokemon", new[] { "TipoPokemon_IdTipoPokemon" });
            DropColumn("dbo.Pokemon", "TipoPokemonId");
            RenameColumn(table: "dbo.Pokemon", name: "TipoPokemon_IdTipoPokemon", newName: "TipoPokemonId");
            AlterColumn("dbo.Pokemon", "TipoPokemonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pokemon", "TipoPokemonId");
            AddForeignKey("dbo.Pokemon", "TipoPokemonId", "dbo.TipoPokemon", "IdTipoPokemon", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pokemon", "TipoPokemonId", "dbo.TipoPokemon");
            DropIndex("dbo.Pokemon", new[] { "TipoPokemonId" });
            AlterColumn("dbo.Pokemon", "TipoPokemonId", c => c.Int());
            RenameColumn(table: "dbo.Pokemon", name: "TipoPokemonId", newName: "TipoPokemon_IdTipoPokemon");
            AddColumn("dbo.Pokemon", "TipoPokemonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pokemon", "TipoPokemon_IdTipoPokemon");
            AddForeignKey("dbo.Pokemon", "TipoPokemon_IdTipoPokemon", "dbo.TipoPokemon", "IdTipoPokemon");
        }
    }
}
