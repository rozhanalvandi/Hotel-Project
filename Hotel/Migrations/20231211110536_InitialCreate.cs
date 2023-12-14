using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "advantageRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advantageRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "firstBaners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BanerTitle = table.Column<string>(type: "TEXT", nullable: false),
                    BanerButton = table.Column<string>(type: "TEXT", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_firstBaners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    RoomCount = table.Column<int>(type: "INTEGER", nullable: false),
                    StageCount = table.Column<int>(type: "INTEGER", nullable: false),
                    EnteryTime = table.Column<string>(type: "TEXT", nullable: false),
                    ExitTime = table.Column<string>(type: "TEXT", nullable: false),
                    dateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    HotellId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hotels_hotels_HotellId",
                        column: x => x.HotellId,
                        principalTable: "hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hotelAddresses",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    State = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelAddresses", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_hotelAddresses_hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hotelGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImageName = table.Column<string>(type: "TEXT", nullable: false),
                    HotelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hotelGalleries_hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hotelRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    BedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    HotelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hotelRooms_hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "hotelRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    HotelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hotelRules_hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvantageToRoom",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdvantageId = table.Column<int>(type: "INTEGER", nullable: false),
                    HotelRoomId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvantageToRoom", x => new { x.AdvantageId, x.RoomId });
                    table.ForeignKey(
                        name: "FK_AdvantageToRoom_advantageRooms_AdvantageId",
                        column: x => x.AdvantageId,
                        principalTable: "advantageRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvantageToRoom_hotelRooms_HotelRoomId",
                        column: x => x.HotelRoomId,
                        principalTable: "hotelRooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdvantageToRoom_hotels_RoomId",
                        column: x => x.RoomId,
                        principalTable: "hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reserveDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReserveDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Count = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReserve = table.Column<bool>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    HotelRoomId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reserveDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reserveDates_hotelRooms_HotelRoomId",
                        column: x => x.HotelRoomId,
                        principalTable: "hotelRooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_reserveDates_hotels_RoomId",
                        column: x => x.RoomId,
                        principalTable: "hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvantageToRoom_HotelRoomId",
                table: "AdvantageToRoom",
                column: "HotelRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvantageToRoom_RoomId",
                table: "AdvantageToRoom",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_hotelGalleries_HotelId",
                table: "hotelGalleries",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_hotelRooms_HotelId",
                table: "hotelRooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_hotelRules_HotelId",
                table: "hotelRules",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_hotels_HotellId",
                table: "hotels",
                column: "HotellId");

            migrationBuilder.CreateIndex(
                name: "IX_reserveDates_HotelRoomId",
                table: "reserveDates",
                column: "HotelRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_reserveDates_RoomId",
                table: "reserveDates",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvantageToRoom");

            migrationBuilder.DropTable(
                name: "firstBaners");

            migrationBuilder.DropTable(
                name: "hotelAddresses");

            migrationBuilder.DropTable(
                name: "hotelGalleries");

            migrationBuilder.DropTable(
                name: "hotelRules");

            migrationBuilder.DropTable(
                name: "reserveDates");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "advantageRooms");

            migrationBuilder.DropTable(
                name: "hotelRooms");

            migrationBuilder.DropTable(
                name: "hotels");
        }
    }
}
