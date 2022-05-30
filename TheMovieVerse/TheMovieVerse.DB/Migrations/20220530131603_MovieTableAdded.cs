using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMovieVerse.DB.Migrations
{
    public partial class MovieTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Halls_HallId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Theatres_TheatreId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_TheatreId",
                table: "Seats",
                newName: "IX_Seats_TheatreId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_HallId",
                table: "Seats",
                newName: "IX_Seats_HallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTitle = table.Column<string>(maxLength: 150, nullable: true),
                    MovieDirector = table.Column<string>(maxLength: 50, nullable: true),
                    MovieGenre = table.Column<string>(maxLength: 50, nullable: true),
                    MovieRating = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    IsUpcoming = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Theatres_TheatreId",
                table: "Seats",
                column: "TheatreId",
                principalTable: "Theatres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Theatres_TheatreId",
                table: "Seats");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_TheatreId",
                table: "Seat",
                newName: "IX_Seat_TheatreId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_HallId",
                table: "Seat",
                newName: "IX_Seat_HallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Halls_HallId",
                table: "Seat",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Theatres_TheatreId",
                table: "Seat",
                column: "TheatreId",
                principalTable: "Theatres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
