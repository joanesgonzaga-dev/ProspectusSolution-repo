using Microsoft.EntityFrameworkCore.Migrations;

namespace Prospectus.Data.Migrations
{
    public partial class RenameProspectId_In_Endereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Prospects_EntityId",
                table: "Enderecos");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Enderecos",
                newName: "ProspectId");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_EntityId",
                table: "Enderecos",
                newName: "IX_Enderecos_ProspectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Prospects_ProspectId",
                table: "Enderecos",
                column: "ProspectId",
                principalTable: "Prospects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Prospects_ProspectId",
                table: "Enderecos");

            migrationBuilder.RenameColumn(
                name: "ProspectId",
                table: "Enderecos",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_ProspectId",
                table: "Enderecos",
                newName: "IX_Enderecos_EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Prospects_EntityId",
                table: "Enderecos",
                column: "EntityId",
                principalTable: "Prospects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
