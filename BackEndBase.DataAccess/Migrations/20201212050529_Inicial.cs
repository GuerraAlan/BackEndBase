using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BackendBase.DataAccess.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BackendBase");

            migrationBuilder.CreateTable(
                name: "tb_user",
                schema: "BackendBase",
                columns: table => new
                {
                    id_user = table.Column<Guid>(type: "uuid", nullable: false),
                    nm_user = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    dt_birthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    nr_phone = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    st_email = table.Column<string>(type: "text", nullable: false),
                    hs_password = table.Column<string>(type: "text", nullable: false),
                    CascadeMode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.id_user);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_user",
                schema: "BackendBase");
        }
    }
}