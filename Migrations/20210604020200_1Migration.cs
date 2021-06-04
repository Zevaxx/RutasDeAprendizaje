using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RutasDeAprendizaje.Migrations
{
    public partial class _1Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tdisciplines",
                columns: table => new
                {
                    DISCIPLINEID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DISCIPLINENAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.DISCIPLINEID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "tpenalties",
                columns: table => new
                {
                    PENALID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PENALNAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TESTPENALDESCRIPTION = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.PENALID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "troles",
                columns: table => new
                {
                    ROLID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ROLNAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ROLDETAIL = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ROLID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "ttests",
                columns: table => new
                {
                    TESTID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TESTNAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TESTPENALDESCRIPTION = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TESTDIFFICULTYLEVEL = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.TESTID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "tusers",
                columns: table => new
                {
                    USERID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    USERNAME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USERPASSWORD = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USERLOGINSTATUS = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USERCOMUNITYPENALTIES = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.USERID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "truserhaspenalty",
                columns: table => new
                {
                    PENALID = table.Column<int>(type: "int(11)", nullable: false),
                    USERID = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.PENALID, x.USERID })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_TRUSERHASPENALTY",
                        column: x => x.PENALID,
                        principalTable: "tpenalties",
                        principalColumn: "PENALID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRUSERHASPENALTY2",
                        column: x => x.USERID,
                        principalTable: "tusers",
                        principalColumn: "USERID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "truserhaverol",
                columns: table => new
                {
                    ROLID = table.Column<int>(type: "int(11)", nullable: false),
                    USERID = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.ROLID, x.USERID })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_TRUSERHAVEROL",
                        column: x => x.ROLID,
                        principalTable: "troles",
                        principalColumn: "ROLID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRUSERHAVEROL2",
                        column: x => x.USERID,
                        principalTable: "tusers",
                        principalColumn: "USERID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "trusershasdiscipline",
                columns: table => new
                {
                    USERID = table.Column<int>(type: "int(11)", nullable: false),
                    DISCIPLINEID = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.USERID, x.DISCIPLINEID })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_TRUSERSHASDISCIPLINE",
                        column: x => x.USERID,
                        principalTable: "tusers",
                        principalColumn: "USERID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRUSERSHASDISCIPLINE2",
                        column: x => x.DISCIPLINEID,
                        principalTable: "tdisciplines",
                        principalColumn: "DISCIPLINEID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "tcourses",
                columns: table => new
                {
                    COURSEID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    COMID = table.Column<int>(type: "int(11)", nullable: false),
                    COURSENAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    COURSETIMELENGTH = table.Column<int>(type: "int(11)", nullable: false),
                    COURSESCORE = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.COURSEID);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "trcoursehastest",
                columns: table => new
                {
                    TESTID = table.Column<int>(type: "int(11)", nullable: false),
                    COURSEID = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.TESTID, x.COURSEID })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_TRCOURSEHASTEST",
                        column: x => x.TESTID,
                        principalTable: "ttests",
                        principalColumn: "TESTID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRCOURSEHASTEST2",
                        column: x => x.COURSEID,
                        principalTable: "tcourses",
                        principalColumn: "COURSEID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "tlearningroutes",
                columns: table => new
                {
                    ROUTEID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    USERID = table.Column<int>(type: "int(11)", nullable: false),
                    COMID = table.Column<int>(type: "int(11)", nullable: false),
                    ROUTENAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ROUTEDIFICULTLEVEL = table.Column<int>(type: "int(11)", nullable: false),
                    ROUTEDISCIPLINE = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ROUTESCORE = table.Column<int>(type: "int(11)", nullable: true),
                    ROUTEFOLLOWERS = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ROUTEID);
                    table.ForeignKey(
                        name: "FK_TRLEARNINGROUTECREATEDBYUSER",
                        column: x => x.USERID,
                        principalTable: "tusers",
                        principalColumn: "USERID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "tcommunities",
                columns: table => new
                {
                    COMID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    USERID = table.Column<int>(type: "int(11)", nullable: false),
                    ROUTEID = table.Column<int>(type: "int(11)", nullable: true),
                    COURSEID = table.Column<int>(type: "int(11)", nullable: true),
                    COMNAME = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.COMID);
                    table.ForeignKey(
                        name: "FK_TRCOMUNITYHASUSERCREATOR",
                        column: x => x.USERID,
                        principalTable: "tusers",
                        principalColumn: "USERID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRCOURSEHASCOMMUNITY",
                        column: x => x.COURSEID,
                        principalTable: "tcourses",
                        principalColumn: "COURSEID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRLEARNINGROUTESHASCOMUNITY",
                        column: x => x.ROUTEID,
                        principalTable: "tlearningroutes",
                        principalColumn: "ROUTEID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "trcoursesinroute",
                columns: table => new
                {
                    COURSEID = table.Column<int>(type: "int(11)", nullable: false),
                    ROUTEID = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.COURSEID, x.ROUTEID })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_TRCOURSESINROUTE",
                        column: x => x.COURSEID,
                        principalTable: "tcourses",
                        principalColumn: "COURSEID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRCOURSESINROUTE2",
                        column: x => x.ROUTEID,
                        principalTable: "tlearningroutes",
                        principalColumn: "ROUTEID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "trlearningrouteshassuscribers",
                columns: table => new
                {
                    ROUTEID = table.Column<int>(type: "int(11)", nullable: false),
                    USERID = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.ROUTEID, x.USERID })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_TRLEARNINGROUTESHASSUSCRIBERS",
                        column: x => x.ROUTEID,
                        principalTable: "tlearningroutes",
                        principalColumn: "ROUTEID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRLEARNINGROUTESHASSUSCRIBERS2",
                        column: x => x.USERID,
                        principalTable: "tusers",
                        principalColumn: "USERID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "trrouteshasdiscipline",
                columns: table => new
                {
                    ROUTEID = table.Column<int>(type: "int(11)", nullable: false),
                    DISCIPLINEID = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.ROUTEID, x.DISCIPLINEID })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_TRROUTESHASDISCIPLINE",
                        column: x => x.ROUTEID,
                        principalTable: "tlearningroutes",
                        principalColumn: "ROUTEID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRROUTESHASDISCIPLINE2",
                        column: x => x.DISCIPLINEID,
                        principalTable: "tdisciplines",
                        principalColumn: "DISCIPLINEID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateTable(
                name: "tposts",
                columns: table => new
                {
                    POSTID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    COMID = table.Column<int>(type: "int(11)", nullable: false),
                    USERID = table.Column<int>(type: "int(11)", nullable: false),
                    POSTCONTENT = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false, collation: "utf8mb4_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    POSTDATE = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.POSTID);
                    table.ForeignKey(
                        name: "FK_TRCOMMUNITYHASPOST",
                        column: x => x.COMID,
                        principalTable: "tcommunities",
                        principalColumn: "COMID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRUSERHASPOST",
                        column: x => x.USERID,
                        principalTable: "tusers",
                        principalColumn: "USERID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_unicode_ci");

            migrationBuilder.CreateIndex(
                name: "FK_TRCOMUNITYHASUSERCREATOR",
                table: "tcommunities",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "FK_TRCOURSEHASCOMMUNITY",
                table: "tcommunities",
                column: "COURSEID");

            migrationBuilder.CreateIndex(
                name: "FK_TRLEARNINGROUTESHASCOMUNITY",
                table: "tcommunities",
                column: "ROUTEID");

            migrationBuilder.CreateIndex(
                name: "FK_TRCOURSEHASCOMMUNITY2",
                table: "tcourses",
                column: "COMID");

            migrationBuilder.CreateIndex(
                name: "FK_TRLEARNINGROUTECREATEDBYUSER",
                table: "tlearningroutes",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "FK_TRLEARNINGROUTESHASCOMUNITY2",
                table: "tlearningroutes",
                column: "COMID");

            migrationBuilder.CreateIndex(
                name: "FK_TRCOMMUNITYHASPOST",
                table: "tposts",
                column: "COMID");

            migrationBuilder.CreateIndex(
                name: "FK_TRUSERHASPOST",
                table: "tposts",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "FK_TRCOURSEHASTEST2",
                table: "trcoursehastest",
                column: "COURSEID");

            migrationBuilder.CreateIndex(
                name: "FK_TRCOURSESINROUTE2",
                table: "trcoursesinroute",
                column: "ROUTEID");

            migrationBuilder.CreateIndex(
                name: "FK_TRLEARNINGROUTESHASSUSCRIBERS2",
                table: "trlearningrouteshassuscribers",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "FK_TRROUTESHASDISCIPLINE2",
                table: "trrouteshasdiscipline",
                column: "DISCIPLINEID");

            migrationBuilder.CreateIndex(
                name: "FK_TRUSERHASPENALTY2",
                table: "truserhaspenalty",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "FK_TRUSERHAVEROL2",
                table: "truserhaverol",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "FK_TRUSERSHASDISCIPLINE2",
                table: "trusershasdiscipline",
                column: "DISCIPLINEID");

            migrationBuilder.AddForeignKey(
                name: "FK_TRCOURSEHASCOMMUNITY2",
                table: "tcourses",
                column: "COMID",
                principalTable: "tcommunities",
                principalColumn: "COMID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TRLEARNINGROUTESHASCOMUNITY2",
                table: "tlearningroutes",
                column: "COMID",
                principalTable: "tcommunities",
                principalColumn: "COMID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TRCOMUNITYHASUSERCREATOR",
                table: "tcommunities");

            migrationBuilder.DropForeignKey(
                name: "FK_TRLEARNINGROUTECREATEDBYUSER",
                table: "tlearningroutes");

            migrationBuilder.DropForeignKey(
                name: "FK_TRCOURSEHASCOMMUNITY",
                table: "tcommunities");

            migrationBuilder.DropForeignKey(
                name: "FK_TRLEARNINGROUTESHASCOMUNITY",
                table: "tcommunities");

            migrationBuilder.DropTable(
                name: "tposts");

            migrationBuilder.DropTable(
                name: "trcoursehastest");

            migrationBuilder.DropTable(
                name: "trcoursesinroute");

            migrationBuilder.DropTable(
                name: "trlearningrouteshassuscribers");

            migrationBuilder.DropTable(
                name: "trrouteshasdiscipline");

            migrationBuilder.DropTable(
                name: "truserhaspenalty");

            migrationBuilder.DropTable(
                name: "truserhaverol");

            migrationBuilder.DropTable(
                name: "trusershasdiscipline");

            migrationBuilder.DropTable(
                name: "ttests");

            migrationBuilder.DropTable(
                name: "tpenalties");

            migrationBuilder.DropTable(
                name: "troles");

            migrationBuilder.DropTable(
                name: "tdisciplines");

            migrationBuilder.DropTable(
                name: "tusers");

            migrationBuilder.DropTable(
                name: "tcourses");

            migrationBuilder.DropTable(
                name: "tlearningroutes");

            migrationBuilder.DropTable(
                name: "tcommunities");
        }
    }
}
