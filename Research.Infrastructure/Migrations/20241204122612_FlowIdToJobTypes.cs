using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Research.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FlowIdToJobTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FLOW_ID",
                table: "JOBTYPE",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JOBTYPE_FLOW_ID",
                table: "JOBTYPE",
                column: "FLOW_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_JOBTYPE_APPLICANT_FLOW_FLOW_ID",
                table: "JOBTYPE",
                column: "FLOW_ID",
                principalTable: "APPLICANT_FLOW",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JOBTYPE_APPLICANT_FLOW_FLOW_ID",
                table: "JOBTYPE");

            migrationBuilder.DropIndex(
                name: "IX_JOBTYPE_FLOW_ID",
                table: "JOBTYPE");

            migrationBuilder.DropColumn(
                name: "FLOW_ID",
                table: "JOBTYPE");
        }
    }
}
