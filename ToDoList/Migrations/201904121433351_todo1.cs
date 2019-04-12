namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class todo1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        DueData = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Priority = c.Int(nullable: false),
                        Attachment = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTasks", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserTasks", new[] { "User_Id" });
            DropTable("dbo.UserTasks");
        }
    }
}
