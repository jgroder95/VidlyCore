using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyCore.Migrations
{
    /// <inheritdoc />
    public partial class PopulateMembershipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT MembershipTypes ON;");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (1, 0, 0, 0, 'Pay as You Go')");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (2, 30, 1, 10, 'Monthly')");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (3, 90, 3, 15, 'Quarterly')");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) VALUES (4, 150, 12, 20, 'Annually')");
            migrationBuilder.Sql("SET IDENTITY_INSERT MembershipTypes OFF;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
