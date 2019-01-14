using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    BoardId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    BoardName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.BoardId);
                });

            migrationBuilder.CreateTable(
                name: "RowNodes",
                columns: table => new
                {
                    RowNodeId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    BoardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RowNodes", x => x.RowNodeId);
                    table.ForeignKey(
                        name: "FK_RowNodes_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "BoardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    SelfBoardBoardId = table.Column<int>(nullable: true),
                    OppenentBoardBoardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Boards_OppenentBoardBoardId",
                        column: x => x.OppenentBoardBoardId,
                        principalTable: "Boards",
                        principalColumn: "BoardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Boards_SelfBoardBoardId",
                        column: x => x.SelfBoardBoardId,
                        principalTable: "Boards",
                        principalColumn: "BoardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    NodeId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    NodeValue = table.Column<string>(maxLength: 64, nullable: true),
                    RowNodeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.NodeId);
                    table.ForeignKey(
                        name: "FK_Nodes_RowNodes_RowNodeId",
                        column: x => x.RowNodeId,
                        principalTable: "RowNodes",
                        principalColumn: "RowNodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Player1UserId = table.Column<int>(nullable: true),
                    Player2UserId = table.Column<int>(nullable: true),
                    GameName = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Users_Player1UserId",
                        column: x => x.Player1UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Users_Player2UserId",
                        column: x => x.Player2UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_Player1UserId",
                table: "Games",
                column: "Player1UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Player2UserId",
                table: "Games",
                column: "Player2UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_RowNodeId",
                table: "Nodes",
                column: "RowNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_RowNodes_BoardId",
                table: "RowNodes",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OppenentBoardBoardId",
                table: "Users",
                column: "OppenentBoardBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SelfBoardBoardId",
                table: "Users",
                column: "SelfBoardBoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RowNodes");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
