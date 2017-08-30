namespace TrabalhoBackEnd.Entidades
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovaColunaStatusAgendamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agendamentoes", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agendamentoes", "Status");
        }
    }
}
