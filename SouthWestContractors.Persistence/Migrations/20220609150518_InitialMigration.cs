using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SouthWestContractors.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    ContractorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.ContractorId);
                });

            migrationBuilder.CreateTable(
                name: "ContractorCategory",
                columns: table => new
                {
                    ContractorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorCategory", x => new { x.ContractorId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ContractorCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractorCategory_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "ContractorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Galeries",
                columns: table => new
                {
                    GaleryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galeries", x => x.GaleryId);
                    table.ForeignKey(
                        name: "FK_Galeries_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "ContractorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedDate", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Plumbing" },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Woodworking" },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Electrical" },
                    { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tile" }
                });

            migrationBuilder.InsertData(
                table: "Contractors",
                columns: new[] { "ContractorId", "Address", "City", "CreatedDate", "LastModifiedDate", "LastName", "Name", "PhoneNumber", "State", "UserId", "Zipcode" },
                values: new object[,]
                {
                    { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8a"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Egbert", "John", null, null, new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), null },
                    { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Johnson", "Mark", null, null, new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c01"), null },
                    { new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529318"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Romanov", "Mike", null, null, new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"), null }
                });

            migrationBuilder.InsertData(
                table: "ContractorCategory",
                columns: new[] { "CategoryId", "ContractorId" },
                values: new object[,]
                {
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8a") },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00") },
                    { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529318") },
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529318") }
                });

            migrationBuilder.InsertData(
                table: "Galeries",
                columns: new[] { "GaleryId", "ContractorId", "CreatedDate", "Description", "ImageUrl", "LastModifiedDate" },
                values: new object[,]
                {
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dd1"), new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "uno", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg", null },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a2"), new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dos", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg", null },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284a3"), new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tres", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractorCategory_CategoryId",
                table: "ContractorCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Galeries_ContractorId",
                table: "Galeries",
                column: "ContractorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractorCategory");

            migrationBuilder.DropTable(
                name: "Galeries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Contractors");
        }
    }
}
