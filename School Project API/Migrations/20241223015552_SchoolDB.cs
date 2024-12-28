using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School_Project_API.Migrations
{
    /// <inheritdoc />
    public partial class SchoolDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    DepID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AccessCards_CardId",
                        column: x => x.CardId,
                        principalTable: "AccessCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepID",
                        column: x => x.DepID,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccessCards",
                columns: new[] { "Id", "ExpirationDate", "SerialNo" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCAW" },
                    { 2, new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCAX" },
                    { 3, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCBW" },
                    { 4, new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCBX" },
                    { 5, new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCCA" },
                    { 6, new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCCX" },
                    { 7, new DateTime(2025, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCDW" },
                    { 8, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCDX" },
                    { 9, new DateTime(2025, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCDE" },
                    { 10, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCDF" },
                    { 11, new DateTime(2025, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCDG" },
                    { 12, new DateTime(2026, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCDH" },
                    { 13, new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABCDI" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Finance" },
                    { 4, "Marketing" },
                    { 5, "Sales" },
                    { 6, "Operations" },
                    { 7, "Customer Service" },
                    { 8, "Research & Development" },
                    { 9, "Legal" },
                    { 10, "Logistics" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CardId", "DateOfBirth", "DepID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mohmmad", "Shiplak" },
                    { 2, 2, new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ahmad", "Salamat" },
                    { 3, 3, new DateTime(2000, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Fadi", "Bani Younes" },
                    { 4, 4, new DateTime(1990, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Hamza", "haj ali" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CardId",
                table: "Students",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepID",
                table: "Students",
                column: "DepID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudentId",
                table: "StudentSubjects",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_SubjectId",
                table: "StudentSubjects",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "AccessCards");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
