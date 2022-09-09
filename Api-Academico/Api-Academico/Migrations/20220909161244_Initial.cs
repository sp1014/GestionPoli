using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Academico.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCourse = table.Column<string>(nullable: true),
                    WeeklyHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodGrade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lounges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameLounge = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lounges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRole = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TypeDoc = table.Column<string>(nullable: true),
                    Doc = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    IdRol = table.Column<int>(nullable: false),
                    RolesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllocationLoads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAllocationLoad = table.Column<DateTime>(nullable: false),
                    IdCourse = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    IdGrade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocationLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllocationLoads_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllocationLoads_Grades_IdGrade",
                        column: x => x.IdGrade,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllocationLoads_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Follow_up_courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFollowUp = table.Column<DateTime>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    IdGrade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follow_up_courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Follow_up_courses_Grades_IdGrade",
                        column: x => x.IdGrade,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Follow_up_courses_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Califications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calification1 = table.Column<int>(nullable: false),
                    Calification2 = table.Column<int>(nullable: false),
                    Calification3 = table.Column<int>(nullable: false),
                    CalificationFinal = table.Column<int>(nullable: false),
                    IdAllocationLoad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Califications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Califications_AllocationLoads_IdAllocationLoad",
                        column: x => x.IdAllocationLoad,
                        principalTable: "AllocationLoads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monday = table.Column<string>(nullable: true),
                    Tuesday = table.Column<string>(nullable: true),
                    Wednesday = table.Column<string>(nullable: true),
                    Thursday = table.Column<string>(nullable: true),
                    Friday = table.Column<int>(nullable: false),
                    IdAllocationLoad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_AllocationLoads_IdAllocationLoad",
                        column: x => x.IdAllocationLoad,
                        principalTable: "AllocationLoads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllocationLoads_IdCourse",
                table: "AllocationLoads",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationLoads_IdGrade",
                table: "AllocationLoads",
                column: "IdGrade");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationLoads_IdUser",
                table: "AllocationLoads",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Califications_IdAllocationLoad",
                table: "Califications",
                column: "IdAllocationLoad");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_up_courses_IdGrade",
                table: "Follow_up_courses",
                column: "IdGrade");

            migrationBuilder.CreateIndex(
                name: "IX_Follow_up_courses_IdUser",
                table: "Follow_up_courses",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_IdAllocationLoad",
                table: "Schedules",
                column: "IdAllocationLoad");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesId",
                table: "Users",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Califications");

            migrationBuilder.DropTable(
                name: "Follow_up_courses");

            migrationBuilder.DropTable(
                name: "Lounges");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "AllocationLoads");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
