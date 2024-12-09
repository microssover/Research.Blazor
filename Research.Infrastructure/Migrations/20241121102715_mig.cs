using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Research.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MANAGER",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MANAGER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MANAGER_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DEPARTMENT_MANAGER_MANAGER_ID",
                        column: x => x.MANAGER_ID,
                        principalTable: "MANAGER",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "APPLICANT_FLOW",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NEXT_DEP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DEPARTMENT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPLICANT_FLOW", x => x.ID);
                    table.ForeignKey(
                        name: "FK_APPLICANT_FLOW_DEPARTMENT_DEPARTMENT_ID",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "DEPARTMENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JOBTYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DESC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEPARTMENT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JOBTYPE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JOBTYPE_DEPARTMENT_DEPARTMENT_ID",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "DEPARTMENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APPLICANT_RECORDS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROFILE_IMAGE = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JOB_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    APPLICANT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CURRENT_FLOW_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPLICANT_RECORDS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_APPLICANT_RECORDS_APPLICANT_FLOW_CURRENT_FLOW_ID",
                        column: x => x.CURRENT_FLOW_ID,
                        principalTable: "APPLICANT_FLOW",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_APPLICANT_RECORDS_JOBTYPE_JobTypeID",
                        column: x => x.JobTypeID,
                        principalTable: "JOBTYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "APPLICANT_IMAGES",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    APPLICANT_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PATH = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPLICANT_IMAGES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_APPLICANT_IMAGES_APPLICANT_RECORDS_APPLICANT_ID",
                        column: x => x.APPLICANT_ID,
                        principalTable: "APPLICANT_RECORDS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_APPLICANT_FLOW_DEPARTMENT_ID",
                table: "APPLICANT_FLOW",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_APPLICANT_IMAGES_APPLICANT_ID",
                table: "APPLICANT_IMAGES",
                column: "APPLICANT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_APPLICANT_RECORDS_CURRENT_FLOW_ID",
                table: "APPLICANT_RECORDS",
                column: "CURRENT_FLOW_ID");

            migrationBuilder.CreateIndex(
                name: "IX_APPLICANT_RECORDS_JobTypeID",
                table: "APPLICANT_RECORDS",
                column: "JobTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENT_MANAGER_ID",
                table: "DEPARTMENT",
                column: "MANAGER_ID",
                unique: true,
                filter: "[MANAGER_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JOBTYPE_DEPARTMENT_ID",
                table: "JOBTYPE",
                column: "DEPARTMENT_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APPLICANT_IMAGES");

            migrationBuilder.DropTable(
                name: "APPLICANT_RECORDS");

            migrationBuilder.DropTable(
                name: "APPLICANT_FLOW");

            migrationBuilder.DropTable(
                name: "JOBTYPE");

            migrationBuilder.DropTable(
                name: "DEPARTMENT");

            migrationBuilder.DropTable(
                name: "MANAGER");
        }
    }
}
