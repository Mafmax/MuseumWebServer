namespace MuseumWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameImageDescriptionProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Description", c => c.String());
            DropColumn("dbo.Images", "Desription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Desription", c => c.String());
            DropColumn("dbo.Images", "Description");
        }
    }
}
