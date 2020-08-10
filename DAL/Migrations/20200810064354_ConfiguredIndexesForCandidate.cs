using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;

namespace DAL.Migrations
{
    public partial class ConfiguredIndexesForCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE NONCLUSTERED INDEX [IX_Index_Candidates] ON [dbo].[Candidates] ([Name] Asc, [Surname] Asc)");
            migrationBuilder.Sql("CREATE NONCLUSTERED INDEX [IX_Index_Contacts] ON [dbo].[Contact] ([Value] Asc)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP INDEX [dbo].[Candidates].[IX_Index_Candidates]");
            migrationBuilder.Sql("DROP INDEX [dbo].[Candidates].[IX_Index_Contacts]");

        }
    }
}
