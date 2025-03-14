using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1530), "Electrical components and parts" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1530), "Mechanical components and parts" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1530), "Hydraulic components and systems" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1540), "Pneumatic components and systems" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1540), "Electronic components and circuits" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 6, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1540), "Structural components and frames", false, "Structural", null },
                    { 7, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1540), "Bolts, nuts, screws and other fasteners", false, "Fasteners", null },
                    { 8, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1540), "Ball bearings, roller bearings and bushings", false, "Bearings", null },
                    { 9, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1540), "Gaskets, O-rings and sealing components", false, "Seals", null },
                    { 10, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1540), "Electric motors and actuators", false, "Motors", null }
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "InstallationDate", "IsDeleted", "Location", "ManufactureDate", "Manufacturer", "ModelNumber", "Name", "SerialNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1640), "เครื่องกลึง CNC ความแม่นยำสูง", "/images/machines/tl-1500.jpg", new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "แผนกผลิต A", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thai CNC Machines", "TL-1500", "เครื่องกลึง CNC รุ่น TL-1500", "TL1500-2023-001", null },
                    { 2, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1640), "เครื่องกัด CNC 5 แกน สำหรับงานซับซ้อน", "/images/machines/vm-5x.jpg", new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "แผนกผลิต B", new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vertical Milling Co., Ltd.", "VM-5X", "เครื่องกัด CNC 5 แกน", "VM5X-2022-042", null },
                    { 3, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1650), "เครื่องฉีดพลาสติกขนาด 250 ตัน", "/images/machines/im-250.jpg", new DateTime(2021, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "แผนกฉีดพลาสติก", new DateTime(2021, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thai Injection Systems", "IM-250", "เครื่องฉีดพลาสติก 250 ตัน", "IM250-2021-103", null },
                    { 4, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1650), "เครื่องเชื่อมหุ่นยนต์อัตโนมัติ", "/images/machines/rw-200.jpg", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "แผนกเชื่อม", new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robotic Welding Co., Ltd.", "RW-200", "เครื่องเชื่อมอัตโนมัติ", "RW200-2023-015", null },
                    { 5, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1650), "เครื่องตัดเลเซอร์กำลังสูง", "/images/machines/lc-3000.jpg", new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "แผนกตัดแผ่น", new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laser Cutting Technologies", "LC-3000", "เครื่องตัดเลเซอร์", "LC3000-2022-027", null },
                    { 6, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1650), "เครื่องพับโลหะแผ่น CNC", "/images/machines/pb-120.jpg", new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "แผนกขึ้นรูป", new DateTime(2021, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Press Brake Systems", "PB-120", "เครื่องพับโลหะ CNC", "PB120-2021-058", null },
                    { 7, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1660), "เครื่องทดสอบแรงดึงความแม่นยำสูง", "/images/machines/ts-50.jpg", new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "แผนก QC", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Testing Equipment Co., Ltd.", "TS-50", "เครื่องทดสอบแรงดึง", "TS50-2023-007", null },
                    { 8, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1660), "เครื่องบรรจุภัณฑ์อัตโนมัติ", "/images/machines/pk-500.jpg", new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "แผนกบรรจุภัณฑ์", new DateTime(2022, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Packaging Systems", "PK-500", "เครื่องบรรจุอัตโนมัติ", "PK500-2022-031", null },
                    { 9, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1660), "เครื่องพิมพ์ 3 มิติสำหรับงานอุตสาหกรรม", "/images/machines/3dp-x1.jpg", new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "แผนกต้นแบบ", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "3D Printing Solutions", "3DP-X1", "เครื่องพิมพ์ 3 มิติ", "3DPX1-2023-022", null },
                    { 10, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1670), "เครื่องวัดขนาดความแม่นยำสูง", "/images/machines/cmm-500.jpg", new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "แผนกตรวจสอบ", new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coordinate Measuring Co., Ltd.", "CMM-500", "เครื่องวัดขนาด CMM", "CMM500-2022-019", null }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "ContactPerson", "CreatedAt", "Email", "IsDeleted", "Name", "Notes", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "123 ถนนสุขุมวิท กรุงเทพฯ 10110", "สมชาย ใจดี", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1570), "contact@thaiindustrial.com", false, "Thai Industrial Supply Co., Ltd.", "ผู้จัดจำหน่ายอุปกรณ์อุตสาหกรรมรายใหญ่", "02-123-4567", null },
                    { 2, "456 ถนนพระราม 9 กรุงเทพฯ 10320", "วิชัย รักดี", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1570), "sales@bangkokbearing.com", false, "Bangkok Bearing Co., Ltd.", "ผู้เชี่ยวชาญด้านแบริ่งและอุปกรณ์ส่งกำลัง", "02-234-5678", null },
                    { 3, "789 ถนนเพชรบุรี กรุงเทพฯ 10400", "นภา แสงทอง", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1580), "info@siamelectric.co.th", false, "Siam Electric Parts Co., Ltd.", "จำหน่ายอุปกรณ์ไฟฟ้าและอิเล็กทรอนิกส์", "02-345-6789", null },
                    { 4, "123 นิคมอุตสาหกรรมอีสเทิร์นซีบอร์ด ระยอง 21140", "ประสิทธิ์ มั่นคง", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1580), "sales@easternhydraulics.com", false, "Eastern Hydraulics Ltd.", "ผู้เชี่ยวชาญระบบไฮดรอลิก", "038-123-456", null },
                    { 5, "101 ถนนบางนา-ตราด กรุงเทพฯ 10260", "สุรีย์ พรมมา", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1580), "contact@precisiontools.co.th", false, "Precision Tools Thailand", "จำหน่ายเครื่องมือความแม่นยำสูง", "02-456-7890", null },
                    { 6, "234 ถนนเชียงใหม่-ลำพูน เชียงใหม่ 50000", "ภาณุ ภักดี", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1580), "sales@northernpneumatic.com", false, "Northern Pneumatic Systems", "ผู้เชี่ยวชาญระบบนิวเมติก", "053-234-567", null },
                    { 7, "567 ถนนพระราม 2 กรุงเทพฯ 10150", "กรรณิการ์ สมใจ", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1580), "info@thaiautomation.com", false, "Thai Automation Parts Co., Ltd.", "จำหน่ายอุปกรณ์ระบบอัตโนมัติ", "02-567-8901", null },
                    { 8, "789 นิคมอุตสาหกรรมมาบตาพุด ระยอง 21150", "วิทยา ศรีสุข", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1590), "contact@rayongindustrial.com", false, "Rayong Industrial Supply", "ผู้จัดจำหน่ายในพื้นที่ EEC", "038-345-678", null },
                    { 9, "890 ถนนพัฒนาการ กรุงเทพฯ 10250", "มานะ รักษ์ดี", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1600), "sales@centralseals.co.th", false, "Central Seals & Gaskets", "ผู้เชี่ยวชาญด้านซีลและปะเก็น", "02-678-9012", null },
                    { 10, "321 ถนนรัชดาภิเษก กรุงเทพฯ 10400", "สมศรี ใจเย็น", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1600), "info@thaimotors.com", false, "Thai Motor Solutions", "จำหน่ายมอเตอร์และอุปกรณ์ขับเคลื่อน", "02-789-0123", null }
                });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.InsertData(
                table: "UnitOfMeasures",
                columns: new[] { "Id", "Abbreviation", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 5, "mm", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1420), false, "Millimeter", null },
                    { 6, "cm", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1420), false, "Centimeter", null },
                    { 7, "m²", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1430), false, "Square Meter", null },
                    { 8, "m³", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1430), false, "Cubic Meter", null },
                    { 9, "set", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1430), false, "Set", null },
                    { 10, "roll", new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1430), false, "Roll", null }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImageUrl", "IsDeleted", "LeadTime", "MinimumStock", "Name", "PartNumber", "Price", "SupplierId", "UnitOfMeasureId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1700), "มอเตอร์ไฟฟ้า 3 เฟส 5 แรงม้า 380V", "/images/components/mtr-3p-5hp.jpg", false, 14, 2, "มอเตอร์ไฟฟ้า 3 เฟส 5HP", "MTR-3P-5HP", 12500.00m, 3, 1, null },
                    { 2, 8, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1700), "ลูกปืนตุ๊กตาเสื้อสี่เหลี่ยม รุ่น UCF205", "/images/components/brg-ucf205.jpg", false, 7, 10, "ลูกปืนตุ๊กตา UCF205", "BRG-UCF205", 850.00m, 2, 1, null },
                    { 3, 4, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1700), "โซลินอยด์วาล์วควบคุมลม 24VDC 1/4 นิ้ว", "/images/components/vlv-sl-24dc.jpg", false, 10, 5, "โซลินอยด์วาล์ว 24VDC", "VLV-SL-24DC", 1200.00m, 6, 1, null },
                    { 4, 2, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1710), "สายพานไทม์มิ่ง HTD5M กว้าง 25mm", "/images/components/blt-htd5m.jpg", false, 5, 3, "สายพานไทม์มิ่ง HTD5M", "BLT-HTD5M-25", 450.00m, 1, 1, null },
                    { 5, 5, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1710), "เซ็นเซอร์วัดระยะทางแบบเลเซอร์ ระยะ 10-100cm", "/images/components/sns-dist-01.jpg", false, 21, 2, "เซ็นเซอร์วัดระยะทาง", "SNS-DIST-01", 2800.00m, 7, 1, null },
                    { 6, 4, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1710), "กระบอกลมขนาด 32mm ระยะชัก 100mm พร้อมเซ็นเซอร์", "/images/components/cyl-32-100.jpg", false, 14, 3, "กระบอกลมพร้อมเซ็นเซอร์", "CYL-32-100", 3500.00m, 6, 1, null },
                    { 7, 5, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1720), "ชุดควบคุม PLC พร้อมโมดูล I/O", "/images/components/plc-cp1l.jpg", false, 30, 1, "ชุดควบคุม PLC", "PLC-CP1L", 15000.00m, 7, 1, null },
                    { 8, 3, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1720), "ปั๊มไฮดรอลิกแรงดันสูง 80 บาร์", "/images/components/pmp-hyd-80.jpg", false, 45, 1, "ปั๊มไฮดรอลิก", "PMP-HYD-80", 22000.00m, 4, 1, null },
                    { 9, 9, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1720), "ชุดซีลไฮดรอลิกสำหรับกระบอกขนาด 32mm", "/images/components/seal-hyd-32.jpg", false, 7, 10, "ชุดซีลไฮดรอลิก", "SEAL-HYD-32", 450.00m, 9, 9, null },
                    { 10, 2, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1730), "สกรูบอลล์เกรด C7 ขนาด 16mm พิตช์ 5mm ยาว 500mm", "/images/components/scw-1605-500.jpg", false, 21, 2, "สกรูบอลล์ 1605 ยาว 500mm", "SCW-1605-500", 4500.00m, 5, 1, null }
                });

            migrationBuilder.InsertData(
                table: "BillOfMaterials",
                columns: new[] { "Id", "ChildComponentId", "CreatedAt", "IsDeleted", "Level", "MachineId", "Notes", "ParentComponentId", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1750), false, 1, 1, "ลูกปืนสำหรับมอเตอร์หลัก", 1, 2m, null },
                    { 2, 4, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1760), false, 1, 1, "สายพานขับเคลื่อนหลัก", 1, 1m, null },
                    { 3, 5, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1760), false, 1, 2, "เซ็นเซอร์สำหรับระบบควบคุม", 7, 3m, null },
                    { 4, 9, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1760), false, 1, 3, "ซีลสำหรับระบบไฮดรอลิก", 8, 4m, null },
                    { 5, 3, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1760), false, 1, 4, "วาล์วควบคุมระบบนิวเมติก", 7, 6m, null },
                    { 6, 10, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1770), false, 1, 5, "สกรูบอลล์สำหรับระบบเคลื่อนที่", 1, 2m, null },
                    { 7, 6, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1770), false, 1, 6, "กระบอกลมสำหรับระบบคีบชิ้นงาน", 8, 2m, null },
                    { 8, 5, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1770), false, 1, 7, "เซ็นเซอร์สำหรับระบบวัด", 7, 1m, null },
                    { 9, 4, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1770), false, 1, 8, "สายพานลำเลียง", 1, 3m, null },
                    { 10, 10, new DateTime(2025, 3, 12, 16, 41, 34, 960, DateTimeKind.Utc).AddTicks(1770), false, 1, 9, "สกรูบอลล์สำหรับระบบเคลื่อนที่แกน XYZ", 7, 3m, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 5, 23, 374, DateTimeKind.Utc).AddTicks(3550), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 5, 23, 374, DateTimeKind.Utc).AddTicks(3550), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 5, 23, 374, DateTimeKind.Utc).AddTicks(3550), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 5, 23, 374, DateTimeKind.Utc).AddTicks(3550), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 5, 23, 374, DateTimeKind.Utc).AddTicks(3560), null });

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 5, 23, 374, DateTimeKind.Utc).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 5, 23, 374, DateTimeKind.Utc).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 5, 23, 374, DateTimeKind.Utc).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "UnitOfMeasures",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 12, 16, 5, 23, 374, DateTimeKind.Utc).AddTicks(3410));
        }
    }
}
