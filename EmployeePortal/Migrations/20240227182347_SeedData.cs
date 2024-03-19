using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeePortal.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "IsDeleted", "LastName", "MiddleName", "Mobile", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("391247ed-da6a-481f-a6a0-77b9828b5d21"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob@gmail.com", "Test", false, "Bob", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("de072154-4891-499b-bb19-03466602d3a9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "njg@gmail.com", "Nico", false, "Govindsamy", "Jared", "1010101000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Offerings",
                columns: new[] { "Id", "BusinessUnit", "CreatedDate", "IsDeleted", "PrimaryOffering", "SecondaryOffering", "Tribe", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4775736a-14df-4b6f-b461-ebcf6d0d21a4"), "Finance", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Accounting", "Bookkeeping", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("acc61b6a-49b9-494d-935e-f1f13e4ebed6"), "Auditing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "CBO - Software Engineering", "Application Development", "Levvia Pod", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bb97b777-0514-4ec9-a93b-08e6f7619345"), "Risk", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Compliance", "Regulation Commitee", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedDate", "Description", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0e5250dc-2fae-4862-bb61-73e0f387c2b2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "verbal and written", false, "Communication", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("39817bc9-41c5-4a46-9e53-3771e47ad246"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "stuff", false, "Auditing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ac746bf4-698a-4bd9-80c1-9954256ae2a7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programming language", false, "C#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eaff34a8-0c48-4bdd-a69b-977b0fcce9b9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frontend framework competency", false, "React", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("391247ed-da6a-481f-a6a0-77b9828b5d21"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("de072154-4891-499b-bb19-03466602d3a9"));

            migrationBuilder.DeleteData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("4775736a-14df-4b6f-b461-ebcf6d0d21a4"));

            migrationBuilder.DeleteData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("acc61b6a-49b9-494d-935e-f1f13e4ebed6"));

            migrationBuilder.DeleteData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("bb97b777-0514-4ec9-a93b-08e6f7619345"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("0e5250dc-2fae-4862-bb61-73e0f387c2b2"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("39817bc9-41c5-4a46-9e53-3771e47ad246"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("ac746bf4-698a-4bd9-80c1-9954256ae2a7"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("eaff34a8-0c48-4bdd-a69b-977b0fcce9b9"));
        }
    }
}
