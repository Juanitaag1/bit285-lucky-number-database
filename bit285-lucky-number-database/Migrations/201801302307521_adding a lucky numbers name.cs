namespace bit285_lucky_number_database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingaluckynumbersname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LuckyNumbers", "getName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LuckyNumbers", "getName");
        }
    }
}
