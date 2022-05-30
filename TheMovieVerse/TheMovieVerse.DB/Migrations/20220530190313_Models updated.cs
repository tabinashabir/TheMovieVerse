using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMovieVerse.DB.Migrations
{
    public partial class Modelsupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MovieId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actor_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShowSchedule",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketPrice = table.Column<double>(nullable: false),
                    ShowDate = table.Column<string>(nullable: true),
                    TimeSlot = table.Column<string>(nullable: true),
                    MovieId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowSchedule_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieBooking",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    HallId = table.Column<long>(nullable: true),
                    MovieId = table.Column<long>(nullable: true),
                    SeatId = table.Column<long>(nullable: true),
                    ShowScheduleId = table.Column<long>(nullable: true),
                    TheatreId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieBooking_Halls_HallId",
                        column: x => x.HallId,
                        principalTable: "Halls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieBooking_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieBooking_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieBooking_ShowSchedule_ShowScheduleId",
                        column: x => x.ShowScheduleId,
                        principalTable: "ShowSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieBooking_Theatres_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actor_MovieId",
                table: "Actor",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieBooking_HallId",
                table: "MovieBooking",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieBooking_MovieId",
                table: "MovieBooking",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieBooking_SeatId",
                table: "MovieBooking",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieBooking_ShowScheduleId",
                table: "MovieBooking",
                column: "ShowScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieBooking_TheatreId",
                table: "MovieBooking",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowSchedule_MovieId",
                table: "ShowSchedule",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "MovieBooking");

            migrationBuilder.DropTable(
                name: "ShowSchedule");
        }
    }
}
