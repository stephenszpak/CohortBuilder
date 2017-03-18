namespace CohortBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cohorts",
                c => new
                    {
                        CohortId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CohortId);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        InstructorId = c.Int(nullable: false, identity: true),
                        InstructorFullName = c.String(),
                        Cohort_CohortId = c.Int(),
                    })
                .PrimaryKey(t => t.InstructorId)
                .ForeignKey("dbo.Cohorts", t => t.Cohort_CohortId)
                .Index(t => t.Cohort_CohortId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentFullName = c.String(),
                        Cohort_CohortId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Cohorts", t => t.Cohort_CohortId)
                .Index(t => t.Cohort_CohortId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Cohort_CohortId", "dbo.Cohorts");
            DropForeignKey("dbo.Instructors", "Cohort_CohortId", "dbo.Cohorts");
            DropIndex("dbo.Students", new[] { "Cohort_CohortId" });
            DropIndex("dbo.Instructors", new[] { "Cohort_CohortId" });
            DropTable("dbo.Students");
            DropTable("dbo.Instructors");
            DropTable("dbo.Cohorts");
        }
    }
}
