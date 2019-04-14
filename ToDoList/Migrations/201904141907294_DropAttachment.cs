namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropAttachment : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserTasks", "Attachment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserTasks", "Attachment", c => c.String());
        }
    }
}
