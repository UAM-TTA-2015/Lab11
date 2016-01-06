namespace UamTTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationStructureForBudget3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "Budget_Id", "dbo.Budgets");
            DropForeignKey("dbo.Accounts", "BudgetTemplate_Id", "dbo.BudgetTemplates");
            DropIndex("dbo.Accounts", new[] { "Budget_Id" });
            DropIndex("dbo.Accounts", new[] { "BudgetTemplate_Id" });
            CreateTable(
                "dbo.BudgetAccounts",
                c => new
                    {
                        Budget_Id = c.Int(nullable: false),
                        Account_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Budget_Id, t.Account_Id })
                .ForeignKey("dbo.Budgets", t => t.Budget_Id, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.Account_Id, cascadeDelete: true)
                .Index(t => t.Budget_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.BudgetTemplateAccounts",
                c => new
                    {
                        BudgetTemplate_Id = c.Int(nullable: false),
                        Account_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BudgetTemplate_Id, t.Account_Id })
                .ForeignKey("dbo.BudgetTemplates", t => t.BudgetTemplate_Id, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.Account_Id, cascadeDelete: true)
                .Index(t => t.BudgetTemplate_Id)
                .Index(t => t.Account_Id);
            
            DropColumn("dbo.Accounts", "Budget_Id");
            DropColumn("dbo.Accounts", "BudgetTemplate_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "BudgetTemplate_Id", c => c.Int());
            AddColumn("dbo.Accounts", "Budget_Id", c => c.Int());
            DropForeignKey("dbo.BudgetTemplateAccounts", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.BudgetTemplateAccounts", "BudgetTemplate_Id", "dbo.BudgetTemplates");
            DropForeignKey("dbo.BudgetAccounts", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.BudgetAccounts", "Budget_Id", "dbo.Budgets");
            DropIndex("dbo.BudgetTemplateAccounts", new[] { "Account_Id" });
            DropIndex("dbo.BudgetTemplateAccounts", new[] { "BudgetTemplate_Id" });
            DropIndex("dbo.BudgetAccounts", new[] { "Account_Id" });
            DropIndex("dbo.BudgetAccounts", new[] { "Budget_Id" });
            DropTable("dbo.BudgetTemplateAccounts");
            DropTable("dbo.BudgetAccounts");
            CreateIndex("dbo.Accounts", "BudgetTemplate_Id");
            CreateIndex("dbo.Accounts", "Budget_Id");
            AddForeignKey("dbo.Accounts", "BudgetTemplate_Id", "dbo.BudgetTemplates", "Id");
            AddForeignKey("dbo.Accounts", "Budget_Id", "dbo.Budgets", "Id");
        }
    }
}
