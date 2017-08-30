namespace TrabalhoBackEnd.Entidades
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HorarioInicial = c.DateTime(nullable: false),
                        HorarioFinal = c.DateTime(nullable: false),
                        Disciplina_Id = c.Int(),
                        Laboratorio_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplinas", t => t.Disciplina_Id)
                .ForeignKey("dbo.Laboratorios", t => t.Laboratorio_Id)
                .Index(t => t.Disciplina_Id)
                .Index(t => t.Laboratorio_Id);
            
            CreateTable(
                "dbo.Disciplinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Laboratorios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamentoes", "Laboratorio_Id", "dbo.Laboratorios");
            DropForeignKey("dbo.Agendamentoes", "Disciplina_Id", "dbo.Disciplinas");
            DropIndex("dbo.Agendamentoes", new[] { "Laboratorio_Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Disciplina_Id" });
            DropTable("dbo.Laboratorios");
            DropTable("dbo.Disciplinas");
            DropTable("dbo.Agendamentoes");
        }
    }
}
