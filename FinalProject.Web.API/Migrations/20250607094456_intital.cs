using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProject.Web.API.Migrations
{
    /// <inheritdoc />
    public partial class intital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ambulances",
                columns: table => new
                {
                    AmbulanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambulances", x => x.AmbulanceId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HODName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneExtensionNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "DischargedPatients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoomNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    AdmissionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DischargeDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DischargedPatients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "101, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BedType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AadharNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AadharId = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disease = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmissionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InitialDeposit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    roomId = table.Column<int>(type: "int", nullable: false),
                    isDischarged = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Rooms_roomId",
                        column: x => x.roomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ambulances",
                columns: new[] { "AmbulanceId", "DriverName", "MobileNumber", "VehicleNumber", "VehicleType" },
                values: new object[,]
                {
                    { new Guid("1b84996d-e7c2-4c96-aa39-f111eb5304a5"), "Amit Joshi", "9334455667", "UP21 ST 5566", "Normal" },
                    { new Guid("1ce30ccb-f4b4-473a-8222-233a3d27351e"), "Manoj Tiwari", "9001122334", "UP21 MN 6789", "Normal" },
                    { new Guid("1f7fc946-ab0a-4c06-8571-3f022559b218"), "Ravi Kumar", "9876543210", "UP21 AB 1234", "Normal" },
                    { new Guid("4a105e1f-397d-465a-832c-8ecdd9d90bc2"), "Rajeev Ranjan", "9123409876", "UP21 KL 2345", "AdvancedLifeSupport" },
                    { new Guid("4f4ba941-9355-4335-9cc5-a05226aea4cd"), "Sunil Mehra", "9123456789", "UP21 CD 5678", "BasicLifeSupport" },
                    { new Guid("529cdd00-5d9e-475b-af22-e8852ee599ae"), "Anil Sharma", "9012345678", "UP21 EF 9012", "AdvancedLifeSupport" },
                    { new Guid("57d695f7-4cc6-48c6-bd78-1a5bc96b3a53"), "Karan Verma", "9223344556", "UP21 QR 3344", "AdvancedLifeSupport" },
                    { new Guid("6d7af7dd-7b34-4019-8d25-c73217c0da74"), "Vikram Singh", "9988776655", "UP21 GH 3456", "Normal" },
                    { new Guid("841383af-86ff-45e7-ab96-d3b60b1e097f"), "Suresh Yadav", "9876501234", "UP21 IJ 7890", "Neonatal" },
                    { new Guid("9ae9403f-961d-4552-bc15-8f2273639640"), "Deepak Chauhan", "9112233445", "UP21 OP 1122", "BasicLifeSupport" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DeptName", "HODName", "PhoneExtensionNo" },
                values: new object[,]
                {
                    { 1, "Cardiology", "Dr. Anil Mehra", "111" },
                    { 2, "Neurology", "Dr. Seema Verma", "222" },
                    { 3, "Orthopedics", "Dr. Rajesh Khanna", "333" },
                    { 4, "Pediatrics", "Dr. Neha Sharma", "444" },
                    { 5, "General Medicine", "Dr. Vivek Gupta", "555" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "BedType", "IsAvailable", "Price", "RoomNumber" },
                values: new object[,]
                {
                    { 101, "Single", false, 1000m, "A101" },
                    { 102, "Double", true, 2000m, "A102" },
                    { 103, "Single", true, 1500m, "A103" },
                    { 104, "Double", true, 1800m, "A104" },
                    { 105, "Single", true, 1200m, "A105" },
                    { 106, "Double", true, 2100m, "B101" },
                    { 107, "Double", true, 2200m, "B102" },
                    { 108, "Single", true, 1300m, "B103" },
                    { 109, "Single", true, 1700m, "B104" },
                    { 110, "Double", true, 1600m, "B105" },
                    { 111, "Single", true, 1900m, "C101" },
                    { 112, "Double", true, 2000m, "C102" },
                    { 113, "Single", true, 1400m, "C103" },
                    { 114, "Double", true, 2300m, "C104" },
                    { 115, "Double", true, 2500m, "C105" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "AadharNo", "Age", "DepartmentId", "EmailId", "Gender", "MobileNumber", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("048a035c-adc0-4eee-a9c5-ed320cfa4c27"), "901234567890", 39, 4, "nikhil.bansal@hospital.com", "Male", "9445566778", "Dr. Nikhil Bansal", "Child Specialist" },
                    { new Guid("62989037-c514-420a-aaad-0534383cffa3"), "234567890123", 38, 2, "priya.sharma@hospital.com", "Female", "9123456789", "Dr. Priya Sharma", "Neurologist" },
                    { new Guid("64537262-c51a-41c1-9994-06cb1d2d5d78"), "678901234567", 40, 1, "kavita.nair@hospital.com", "Female", "9112233445", "Dr. Kavita Nair", "Cardiology Consultant" },
                    { new Guid("7c8ed9e7-0e96-4b45-91b5-cba7b99a1d0f"), "012345678901", 41, 5, "anuja.desai@hospital.com", "Female", "9556677889", "Dr. Anuja Desai", "General Medicine Consultant" },
                    { new Guid("8a8affcc-c224-4f3b-a49e-6446c9e8329d"), "456789012345", 42, 4, "sneha.verma@hospital.com", "Female", "9988776655", "Dr. Sneha Verma", "Pediatrician" },
                    { new Guid("8f647e4c-f09b-4aa5-90ae-2f16d883b65f"), "890123456789", 44, 3, "meena.joshi@hospital.com", "Female", "9334455667", "Dr. Meena Joshi", "Orthopedic Consultant" },
                    { new Guid("9d911f68-d7e1-40fb-8255-254f23105bc3"), "345678901234", 50, 3, "arvind.patel@hospital.com", "Male", "9012345678", "Dr. Arvind Patel", "Orthopedic Surgeon" },
                    { new Guid("aad9f233-2c61-4dc3-9b45-c5da6815ad7d"), "123456789012", 45, 1, "ramesh.kumar@hospital.com", "Male", "9876543210", "Dr. Ramesh Kumar", "Senior Cardiologist" },
                    { new Guid("d1c1c324-b11c-42b5-9db0-ebea2b566d89"), "567890123456", 47, 5, "manish.gupta@hospital.com", "Male", "9876501234", "Dr. Manish Gupta", "General Physician" },
                    { new Guid("d26f37a7-8ff1-45b5-84e0-61e032de441f"), "789012345678", 36, 2, "rohit.sinha@hospital.com", "Male", "9223344556", "Dr. Rohit Sinha", "Neurosurgeon" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "AadharId", "AdmissionDateTime", "Disease", "FirstName", "Gender", "InitialDeposit", "LastName", "MobileNumber", "Symptoms", "isDischarged", "roomId" },
                values: new object[] { new Guid("c513f843-93ea-4761-9113-3eb19b910122"), "123456789012", new DateTime(2025, 5, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), "Diabetes", "Amit", "Male", 5000m, "Sharma", "9876543210", "Fatigue, frequent urination", false, 115 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_roomId",
                table: "Patients",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomNumber",
                table: "Rooms",
                column: "RoomNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ambulances");

            migrationBuilder.DropTable(
                name: "DischargedPatients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
