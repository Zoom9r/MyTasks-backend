using Microsoft.EntityFrameworkCore.Migrations;


namespace MyTasksDataBase.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListOfTasksModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTasksModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListOfTasksModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusModels_ListOfTasksModels_ListOfTasksModelId",
                        column: x => x.ListOfTasksModelId,
                        principalTable: "ListOfTasksModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MyTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ListOfTasksModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyTasks_ListOfTasksModels_ListOfTasksModelId",
                        column: x => x.ListOfTasksModelId,
                        principalTable: "ListOfTasksModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyTasks_StatusModels_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyTasks_ListOfTasksModelId",
                table: "MyTasks",
                column: "ListOfTasksId");

            migrationBuilder.CreateIndex(
                name: "IX_MyTasks_StatusId",
                table: "MyTasks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusModels_ListOfTasksModelId",
                table: "StatusModels",
                column: "ListOfTasksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyTasks");

            migrationBuilder.DropTable(
                name: "StatusModels");

            migrationBuilder.DropTable(
                name: "ListOfTasksModels");
        }
    }
}
