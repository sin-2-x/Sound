namespace SoundDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnalyzeSessions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AnalyzeSessionResult_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnalyzeSessionResults", t => t.AnalyzeSessionResult_Id)
                .ForeignKey("dbo.AudioSignals", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.AnalyzeSessionResult_Id);
            
            CreateTable(
                "dbo.AnalyzeSessionResults",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Coords = c.String(),
                        WorkSession_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkSessions", t => t.WorkSession_Id)
                .Index(t => t.WorkSession_Id);
            
            CreateTable(
                "dbo.WorkSessions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TimeStart = c.DateTime(nullable: false),
                        TimeStop = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeviceWorkSessions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Device_Id = c.Guid(),
                        WorkSession_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.Device_Id)
                .ForeignKey("dbo.WorkSessions", t => t.WorkSession_Id)
                .Index(t => t.Device_Id)
                .Index(t => t.WorkSession_Id);
            
            CreateTable(
                "dbo.AudioSignals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SoundFilePath = c.String(),
                        DeviceWorkSession_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeviceWorkSessions", t => t.DeviceWorkSession_Id)
                .Index(t => t.DeviceWorkSession_Id);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnalyzeSessions", "Id", "dbo.AudioSignals");
            DropForeignKey("dbo.AnalyzeSessions", "AnalyzeSessionResult_Id", "dbo.AnalyzeSessionResults");
            DropForeignKey("dbo.DeviceWorkSessions", "WorkSession_Id", "dbo.WorkSessions");
            DropForeignKey("dbo.DeviceWorkSessions", "Device_Id", "dbo.Devices");
            DropForeignKey("dbo.AudioSignals", "DeviceWorkSession_Id", "dbo.DeviceWorkSessions");
            DropForeignKey("dbo.AnalyzeSessionResults", "WorkSession_Id", "dbo.WorkSessions");
            DropIndex("dbo.AudioSignals", new[] { "DeviceWorkSession_Id" });
            DropIndex("dbo.DeviceWorkSessions", new[] { "WorkSession_Id" });
            DropIndex("dbo.DeviceWorkSessions", new[] { "Device_Id" });
            DropIndex("dbo.AnalyzeSessionResults", new[] { "WorkSession_Id" });
            DropIndex("dbo.AnalyzeSessions", new[] { "AnalyzeSessionResult_Id" });
            DropIndex("dbo.AnalyzeSessions", new[] { "Id" });
            DropTable("dbo.Devices");
            DropTable("dbo.AudioSignals");
            DropTable("dbo.DeviceWorkSessions");
            DropTable("dbo.WorkSessions");
            DropTable("dbo.AnalyzeSessionResults");
            DropTable("dbo.AnalyzeSessions");
        }
    }
}
