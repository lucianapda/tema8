namespace TrabalhoBackEnd.Entidades
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovasColunas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Disciplinas", "Curso", c => c.String());
            AddColumn("dbo.Laboratorios", "Bloco", c => c.String());
            AddColumn("dbo.Laboratorios", "NumeroSala", c => c.Int(nullable: false));
            AddColumn("dbo.Laboratorios", "QtdMaquinas", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Laboratorios", "QtdMaquinas");
            DropColumn("dbo.Laboratorios", "NumeroSala");
            DropColumn("dbo.Laboratorios", "Bloco");
            DropColumn("dbo.Disciplinas", "Curso");
        }
    }
}
