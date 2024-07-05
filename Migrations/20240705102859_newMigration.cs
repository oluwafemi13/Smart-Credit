using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Credit.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addressees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addressees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeadlineDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgreedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeadlineDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorowerId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeadlineDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payday = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repayments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Borrowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddresseeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borrowers_Addressees_AddresseeId",
                        column: x => x.AddresseeId,
                        principalTable: "Addressees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddresseeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lenders_Addressees_AddresseeId",
                        column: x => x.AddresseeId,
                        principalTable: "Addressees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepaymentId = table.Column<int>(type: "int", nullable: false),
                    DeadLineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_DeadlineDates_DeadLineId",
                        column: x => x.DeadLineId,
                        principalTable: "DeadlineDates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Repayments_RepaymentId",
                        column: x => x.RepaymentId,
                        principalTable: "Repayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanRequestLenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanRequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LenderId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    LoanRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequestLenders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanRequestLenders_Lenders_LenderId",
                        column: x => x.LenderId,
                        principalTable: "Lenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRequestLenders_LoanRequests_LoanRequestId",
                        column: x => x.LoanRequestId,
                        principalTable: "LoanRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Intermediaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddresseeId = table.Column<int>(type: "int", nullable: false),
                    LoanDate = table.Column<int>(type: "int", nullable: true),
                    LoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intermediaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intermediaries_Addressees_AddresseeId",
                        column: x => x.AddresseeId,
                        principalTable: "Addressees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Intermediaries_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LenderBorrowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LenderId = table.Column<int>(type: "int", nullable: true),
                    BorrowerId = table.Column<int>(type: "int", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Percentage = table.Column<float>(type: "real", nullable: false),
                    LoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LenderBorrowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LenderBorrowers_Borrowers_BorrowerId",
                        column: x => x.BorrowerId,
                        principalTable: "Borrowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LenderBorrowers_Lenders_LenderId",
                        column: x => x.LenderId,
                        principalTable: "Lenders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LenderBorrowers_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Borrowers_AddresseeId",
                table: "Borrowers",
                column: "AddresseeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Intermediaries_AddresseeId",
                table: "Intermediaries",
                column: "AddresseeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Intermediaries_LoanId",
                table: "Intermediaries",
                column: "LoanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LenderBorrowers_BorrowerId",
                table: "LenderBorrowers",
                column: "BorrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_LenderBorrowers_LenderId",
                table: "LenderBorrowers",
                column: "LenderId");

            migrationBuilder.CreateIndex(
                name: "IX_LenderBorrowers_LoanId",
                table: "LenderBorrowers",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Lenders_AddresseeId",
                table: "Lenders",
                column: "AddresseeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestLenders_LenderId",
                table: "LoanRequestLenders",
                column: "LenderId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestLenders_LoanRequestId",
                table: "LoanRequestLenders",
                column: "LoanRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_DeadLineId",
                table: "Loans",
                column: "DeadLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_RepaymentId",
                table: "Loans",
                column: "RepaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intermediaries");

            migrationBuilder.DropTable(
                name: "LenderBorrowers");

            migrationBuilder.DropTable(
                name: "LoanRequestLenders");

            migrationBuilder.DropTable(
                name: "Borrowers");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Lenders");

            migrationBuilder.DropTable(
                name: "LoanRequests");

            migrationBuilder.DropTable(
                name: "DeadlineDates");

            migrationBuilder.DropTable(
                name: "Repayments");

            migrationBuilder.DropTable(
                name: "Addressees");
        }
    }
}
