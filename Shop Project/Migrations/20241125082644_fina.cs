using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_Project.Migrations
{
    /// <inheritdoc />
    public partial class fina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    C_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.C_id);
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    Cm_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_id = table.Column<int>(type: "int", nullable: false),
                    Cm_description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Cm_reply = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.Cm_id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Cu_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cu_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Cu_ph = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Cu_id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    E_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_id = table.Column<int>(type: "int", nullable: false),
                    E_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    E_ph = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    E_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    E_position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.E_id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Ex_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_id = table.Column<int>(type: "int", nullable: false),
                    Ex_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ex_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ex_amount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Ex_id);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    L_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_id = table.Column<int>(type: "int", nullable: false),
                    S_shopcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    S_Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    S_type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.L_id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    N_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    N_date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.N_id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    O_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_id = table.Column<int>(type: "int", nullable: false),
                    P_id = table.Column<int>(type: "int", nullable: false),
                    O_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    O_quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    O_status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.O_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    P_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_id = table.Column<int>(type: "int", nullable: false),
                    S_id = table.Column<int>(type: "int", nullable: false),
                    P_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    P_price = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.P_id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    R_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_id = table.Column<int>(type: "int", nullable: false),
                    R_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    R_reply = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.R_id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Sl_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_id = table.Column<int>(type: "int", nullable: false),
                    P_id = table.Column<int>(type: "int", nullable: false),
                    Cu_id = table.Column<int>(type: "int", nullable: false),
                    Sl_date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Sl_id);
                });

            migrationBuilder.CreateTable(
                name: "Shop_Details",
                columns: table => new
                {
                    S_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    S_location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S_PH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S_Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop_Details", x => x.S_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Shop_Details");
        }
    }
}
