namespace Pokemon2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraMigracion3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Entrenador", "A");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entrenador", "A", c => c.String());
        }
    }
}
