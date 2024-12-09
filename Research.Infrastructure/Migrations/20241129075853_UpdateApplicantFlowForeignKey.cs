using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Research.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicantFlowForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APPLICANT_RECORDS_APPLICANT_FLOW_CURRENT_FLOW_ID",
                table: "APPLICANT_RECORDS");

            migrationBuilder.AddForeignKey(
                name: "FK_APPLICANT_RECORDS_APPLICANT_FLOW_CURRENT_FLOW_ID",
                table: "APPLICANT_RECORDS",
                column: "CURRENT_FLOW_ID",
                principalTable: "APPLICANT_FLOW",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APPLICANT_RECORDS_APPLICANT_FLOW_CURRENT_FLOW_ID",
                table: "APPLICANT_RECORDS");

            migrationBuilder.AddForeignKey(
                name: "FK_APPLICANT_RECORDS_APPLICANT_FLOW_CURRENT_FLOW_ID",
                table: "APPLICANT_RECORDS",
                column: "CURRENT_FLOW_ID",
                principalTable: "APPLICANT_FLOW",
                principalColumn: "ID");
        }
    }
}
