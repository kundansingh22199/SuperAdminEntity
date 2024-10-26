using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperAdminEntity.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlMst",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    pingeneration = table.Column<int>(type: "int", nullable: true),
                    changeprofile = table.Column<int>(type: "int", nullable: true),
                    payout = table.Column<int>(type: "int", nullable: true),
                    awards = table.Column<int>(type: "int", nullable: true),
                    reports = table.Column<int>(type: "int", nullable: true),
                    changepassword = table.Column<int>(type: "int", nullable: true),
                    activate = table.Column<int>(type: "int", nullable: true),
                    news = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlMst", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_DomainMaster",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Connection = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_DomainMaster", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Master_Binary",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inc_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Inc_per = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Inc_fix = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Inc_per_id = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Inc_capping = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Ratio = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CappingType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Package = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Master_Binary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Master_Direct",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inc_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Inc_per = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Inc_fix = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Inc_per_id = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Inc_all_id = table.Column<int>(type: "int", nullable: true),
                    Inc_after_id = table.Column<int>(type: "int", nullable: true),
                    Package = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Master_Direct", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Master_Level",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level_No = table.Column<int>(type: "int", nullable: true),
                    Inc_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Level_per = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Level_fix = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Direct_id_require = table.Column<int>(type: "int", nullable: true),
                    Package = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Master_Level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Master_LevelOnRoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level_No = table.Column<int>(type: "int", nullable: true),
                    Inc_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Level_per = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Level_fix = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Direct_id_require = table.Column<int>(type: "int", nullable: true),
                    Package = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Master_LevelOnRoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Master_Roi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roi_type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    roi_fix = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    roi_per = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    roi_upto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    inc_recuring = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RoiDay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sundayoff = table.Column<bool>(type: "bit", nullable: true),
                    sunday_saturday_off = table.Column<bool>(type: "bit", nullable: true),
                    random = table.Column<bool>(type: "bit", nullable: true),
                    min_per = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    max_per = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Package = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Master_Roi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_PackageMaster",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Package = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_PackageMaster", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserPrefix",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegPrefix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TotalDigit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserPrefix", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlMst");

            migrationBuilder.DropTable(
                name: "Tbl_DomainMaster");

            migrationBuilder.DropTable(
                name: "Tbl_Master_Binary");

            migrationBuilder.DropTable(
                name: "Tbl_Master_Direct");

            migrationBuilder.DropTable(
                name: "Tbl_Master_Level");

            migrationBuilder.DropTable(
                name: "Tbl_Master_LevelOnRoi");

            migrationBuilder.DropTable(
                name: "Tbl_Master_Roi");

            migrationBuilder.DropTable(
                name: "Tbl_PackageMaster");

            migrationBuilder.DropTable(
                name: "Tbl_UserPrefix");
        }
    }
}
