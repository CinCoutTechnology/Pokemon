namespace Pokemon2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraMigracion2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entrenador", "A", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entrenador", "A");
        }
    }
}
