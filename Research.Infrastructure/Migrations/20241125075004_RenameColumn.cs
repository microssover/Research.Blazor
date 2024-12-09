using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Research.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APPLICANT_RECORDS_JOBTYPE_JobTypeID",
                table: "APPLICANT_RECORDS");

            migrationBuilder.RenameColumn(
                name: "NEXT_DEP_ID",
                table: "APPLICANT_FLOW",
                newName: "NEXT_FLOW_ID");

            migrationBuilder.AlterColumn<Guid>(
                name: "JobTypeID",
                table: "APPLICANT_RECORDS",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_APPLICANT_RECORDS_JOBTYPE_JobTypeID",
                table: "APPLICANT_RECORDS",
                column: "JobTypeID",
                principalTable: "JOBTYPE",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APPLICANT_RECORDS_JOBTYPE_JobTypeID",
                table: "APPLICANT_RECORDS");

            migrationBuilder.RenameColumn(
                name: "NEXT_FLOW_ID",
                table: "APPLICANT_FLOW",
                newName: "NEXT_DEP_ID");

            migrationBuilder.AlterColumn<Guid>(
                name: "JobTypeID",
                table: "APPLICANT_RECORDS",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_APPLICANT_RECORDS_JOBTYPE_JobTypeID",
                table: "APPLICANT_RECORDS",
                column: "JobTypeID",
                principalTable: "JOBTYPE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
