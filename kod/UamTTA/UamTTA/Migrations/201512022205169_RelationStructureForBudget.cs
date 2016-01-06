namespace UamTTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationStructureForBudget : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Budget_Id", c => c.Int());
            AddColumn("dbo.Accounts", "BudgetTemplate_Id", c => c.Int());
            AddColumn("dbo.Budgets", "Name", c => c.String());
            AddColumn("dbo.Budgets", "Duration", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "Budget_Id");
            CreateIndex("dbo.Accounts", "BudgetTemplate_Id");
            AddForeignKey("dbo.Accounts", "Budget_Id", "dbo.Budgets", "Id");
            AddForeignKey("dbo.Accounts", "BudgetTemplate_Id", "dbo.BudgetTemplates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "BudgetTemplate_Id", "dbo.BudgetTemplates");
            DropForeignKey("dbo.Accounts", "Budget_Id", "dbo.Budgets");
            DropIndex("dbo.Accounts", new[] { "BudgetTemplate_Id" });
            DropIndex("dbo.Accounts", new[] { "Budget_Id" });
            DropColumn("dbo.Budgets", "Duration");
            DropColumn("dbo.Budgets", "Name");
            DropColumn("dbo.Accounts", "BudgetTemplate_Id");
            DropColumn("dbo.Accounts", "Budget_Id");
        }
    }
}
