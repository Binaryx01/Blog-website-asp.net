using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wlogit.Migrations
{
    /// <inheritdoc />
    public partial class profileUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Tbl_Post");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Post",
                table: "Tbl_Post",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tbl_Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Profile", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Post",
                table: "Tbl_Post");

            migrationBuilder.RenameTable(
                name: "Tbl_Post",
                newName: "Post");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");
        }
    }
}
