using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Research.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migapplicationflowtitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APPLICANT_FLOW_DEPARTMENT_DEPARTMENT_ID",
                table: "APPLICANT_FLOW");

            migrationBuilder.AlterColumn<Guid>(
                name: "DEPARTMENT_ID",
                table: "APPLICANT_FLOW",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "NAME",
                table: "APPLICANT_FLOW",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_APPLICANT_FLOW_DEPARTMENT_DEPARTMENT_ID",
                table: "APPLICANT_FLOW",
                column: "DEPARTMENT_ID",
                principalTable: "DEPARTMENT",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APPLICANT_FLOW_DEPARTMENT_DEPARTMENT_ID",
                table: "APPLICANT_FLOW");

            migrationBuilder.DropColumn(
                name: "NAME",
                table: "APPLICANT_FLOW");

            migrationBuilder.AlterColumn<Guid>(
                name: "DEPARTMENT_ID",
                table: "APPLICANT_FLOW",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_APPLICANT_FLOW_DEPARTMENT_DEPARTMENT_ID",
                table: "APPLICANT_FLOW",
                column: "DEPARTMENT_ID",
                principalTable: "DEPARTMENT",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
