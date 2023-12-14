using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvantageToRoom_advantageRooms_AdvantageId",
                table: "AdvantageToRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvantageToRoom_hotelRooms_HotelRoomId",
                table: "AdvantageToRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvantageToRoom_hotels_RoomId",
                table: "AdvantageToRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvantageToRoom",
                table: "AdvantageToRoom");

            migrationBuilder.RenameTable(
                name: "AdvantageToRoom",
                newName: "advantageToRs");

            migrationBuilder.RenameIndex(
                name: "IX_AdvantageToRoom_RoomId",
                table: "advantageToRs",
                newName: "IX_advantageToRs_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_AdvantageToRoom_HotelRoomId",
                table: "advantageToRs",
                newName: "IX_advantageToRs_HotelRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_advantageToRs",
                table: "advantageToRs",
                columns: new[] { "AdvantageId", "RoomId" });

            migrationBuilder.AddForeignKey(
                name: "FK_advantageToRs_advantageRooms_AdvantageId",
                table: "advantageToRs",
                column: "AdvantageId",
                principalTable: "advantageRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_advantageToRs_hotelRooms_HotelRoomId",
                table: "advantageToRs",
                column: "HotelRoomId",
                principalTable: "hotelRooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_advantageToRs_hotels_RoomId",
                table: "advantageToRs",
                column: "RoomId",
                principalTable: "hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advantageToRs_advantageRooms_AdvantageId",
                table: "advantageToRs");

            migrationBuilder.DropForeignKey(
                name: "FK_advantageToRs_hotelRooms_HotelRoomId",
                table: "advantageToRs");

            migrationBuilder.DropForeignKey(
                name: "FK_advantageToRs_hotels_RoomId",
                table: "advantageToRs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_advantageToRs",
                table: "advantageToRs");

            migrationBuilder.RenameTable(
                name: "advantageToRs",
                newName: "AdvantageToRoom");

            migrationBuilder.RenameIndex(
                name: "IX_advantageToRs_RoomId",
                table: "AdvantageToRoom",
                newName: "IX_AdvantageToRoom_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_advantageToRs_HotelRoomId",
                table: "AdvantageToRoom",
                newName: "IX_AdvantageToRoom_HotelRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvantageToRoom",
                table: "AdvantageToRoom",
                columns: new[] { "AdvantageId", "RoomId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdvantageToRoom_advantageRooms_AdvantageId",
                table: "AdvantageToRoom",
                column: "AdvantageId",
                principalTable: "advantageRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvantageToRoom_hotelRooms_HotelRoomId",
                table: "AdvantageToRoom",
                column: "HotelRoomId",
                principalTable: "hotelRooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdvantageToRoom_hotels_RoomId",
                table: "AdvantageToRoom",
                column: "RoomId",
                principalTable: "hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
