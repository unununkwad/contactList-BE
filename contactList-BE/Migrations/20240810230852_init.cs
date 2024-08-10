using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace contactList_BE.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    SubCategoryID = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contact_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_SubCategory_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "SubCategory",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "służbowy" },
                    { 2, "prywatny" },
                    { 3, "inny" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Password", "UserName" },
                values: new object[] { 1, "$2a$11$xYAtrJMPv.5K/Ij5/LGOaOLvCKuqd2bxGXAtzXwXOtDR90q/YB.lu", "admin" });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "ID", "BirthDate", "CategoryID", "Email", "LastName", "Name", "Password", "PhoneNumber", "SubCategoryID" },
                values: new object[,]
                {
                    { 2, new DateTime(1985, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "damianmendak@gmail.com", "Mendak", "Damian", "0Be9##7[ueEa", "350 736 024", null },
                    { 4, new DateTime(2007, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "lukaszfiliks@gmail.com", "Filiks", "Łukasz", "1[%H7i26j2bc", "522-023-813", null },
                    { 5, new DateTime(1946, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "agnieszkamalarczyk@gmail.com", "Malarczyk", "Agnieszka", "Hn_)6Pxe3=nK", "340423962", null },
                    { 8, new DateTime(1987, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "lenahalas@gmail.com", "Hałas", "Lena", ")%{1nEBiC+jq", "895743201", null }
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "ID", "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "szef" },
                    { 2, 1, "klient" },
                    { 3, 3, "kolega" }
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "ID", "BirthDate", "CategoryID", "Email", "LastName", "Name", "Password", "PhoneNumber", "SubCategoryID" },
                values: new object[,]
                {
                    { 1, new DateTime(1973, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "jakubjastak@gmail.com", "Jastak", "Jakub", "BVzA;,3<W85D", "826171248", 1 },
                    { 3, new DateTime(1995, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "aureliasochocka@gmail.com", "Sochocka", "Aurelia", "F?cU~79:.l1u", "+48930384181", 2 },
                    { 6, new DateTime(1959, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "sabinaprus@gmail.com", "Prus", "Sabina", "k~/V<kg}0l/y", "329361319", 3 },
                    { 7, new DateTime(1981, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "mieczyslawwojtaszczyk@gmail.com", "Wojtaszczyk", "Mieczysław", "/ixj{+xYFe7A", "276108577", 1 },
                    { 9, new DateTime(1988, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "benedyktprzybylski@gmail.com", "Przybylski", "Benedykt", "KQN1_qn]Gm)/", "532330198", 3 },
                    { 10, new DateTime(1962, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "marcelinacwynar@gmail.com", "Cwynar", "Marcelina", "44%BJIqBYPck", "461018986", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CategoryID",
                table: "Contact",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Email",
                table: "Contact",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_SubCategoryID",
                table: "Contact",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryID",
                table: "SubCategory",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
