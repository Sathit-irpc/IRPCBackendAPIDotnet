using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<BillOfMaterial> BillOfMaterials { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure relationships
            modelBuilder.Entity<BillOfMaterial>()
                .HasOne(b => b.ParentComponent)
                .WithMany(c => c.ChildBOMs)
                .HasForeignKey(b => b.ParentComponentId)
                .OnDelete(DeleteBehavior.Restrict);
                
            modelBuilder.Entity<BillOfMaterial>()
                .HasOne(b => b.ChildComponent)
                .WithMany(c => c.ParentBOMs)
                .HasForeignKey(b => b.ChildComponentId)
                .OnDelete(DeleteBehavior.Restrict);
                
            modelBuilder.Entity<BillOfMaterial>()
                .HasOne(b => b.Machine)
                .WithMany(m => m.BillOfMaterials)
                .HasForeignKey(b => b.MachineId)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Seed data for UnitOfMeasure
            modelBuilder.Entity<UnitOfMeasure>().HasData(
                new UnitOfMeasure { Id = 1, Name = "Piece", Abbreviation = "pc", CreatedAt = DateTime.UtcNow },
                new UnitOfMeasure { Id = 2, Name = "Kilogram", Abbreviation = "kg", CreatedAt = DateTime.UtcNow },
                new UnitOfMeasure { Id = 3, Name = "Meter", Abbreviation = "m", CreatedAt = DateTime.UtcNow },
                new UnitOfMeasure { Id = 4, Name = "Liter", Abbreviation = "L", CreatedAt = DateTime.UtcNow },
                new UnitOfMeasure { Id = 5, Name = "Millimeter", Abbreviation = "mm", CreatedAt = DateTime.UtcNow },
                new UnitOfMeasure { Id = 6, Name = "Centimeter", Abbreviation = "cm", CreatedAt = DateTime.UtcNow },
                new UnitOfMeasure { Id = 7, Name = "Square Meter", Abbreviation = "m²", CreatedAt = DateTime.UtcNow },
                new UnitOfMeasure { Id = 8, Name = "Cubic Meter", Abbreviation = "m³", CreatedAt = DateTime.UtcNow },
                new UnitOfMeasure { Id = 9, Name = "Set", Abbreviation = "set", CreatedAt = DateTime.UtcNow },
                new UnitOfMeasure { Id = 10, Name = "Roll", Abbreviation = "roll", CreatedAt = DateTime.UtcNow }
            );
            
            // Seed data for Category
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electrical", Description = "Electrical components and parts", CreatedAt = DateTime.UtcNow },
                new Category { Id = 2, Name = "Mechanical", Description = "Mechanical components and parts", CreatedAt = DateTime.UtcNow },
                new Category { Id = 3, Name = "Hydraulic", Description = "Hydraulic components and systems", CreatedAt = DateTime.UtcNow },
                new Category { Id = 4, Name = "Pneumatic", Description = "Pneumatic components and systems", CreatedAt = DateTime.UtcNow },
                new Category { Id = 5, Name = "Electronic", Description = "Electronic components and circuits", CreatedAt = DateTime.UtcNow },
                new Category { Id = 6, Name = "Structural", Description = "Structural components and frames", CreatedAt = DateTime.UtcNow },
                new Category { Id = 7, Name = "Fasteners", Description = "Bolts, nuts, screws and other fasteners", CreatedAt = DateTime.UtcNow },
                new Category { Id = 8, Name = "Bearings", Description = "Ball bearings, roller bearings and bushings", CreatedAt = DateTime.UtcNow },
                new Category { Id = 9, Name = "Seals", Description = "Gaskets, O-rings and sealing components", CreatedAt = DateTime.UtcNow },
                new Category { Id = 10, Name = "Motors", Description = "Electric motors and actuators", CreatedAt = DateTime.UtcNow }
            );
            
            // Seed data for Supplier
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Name = "Thai Industrial Supply Co., Ltd.", ContactPerson = "สมชาย ใจดี", Phone = "02-123-4567", Email = "contact@thaiindustrial.com", Address = "123 ถนนสุขุมวิท กรุงเทพฯ 10110", Notes = "ผู้จัดจำหน่ายอุปกรณ์อุตสาหกรรมรายใหญ่", CreatedAt = DateTime.UtcNow },
                new Supplier { Id = 2, Name = "Bangkok Bearing Co., Ltd.", ContactPerson = "วิชัย รักดี", Phone = "02-234-5678", Email = "sales@bangkokbearing.com", Address = "456 ถนนพระราม 9 กรุงเทพฯ 10320", Notes = "ผู้เชี่ยวชาญด้านแบริ่งและอุปกรณ์ส่งกำลัง", CreatedAt = DateTime.UtcNow },
                new Supplier { Id = 3, Name = "Siam Electric Parts Co., Ltd.", ContactPerson = "นภา แสงทอง", Phone = "02-345-6789", Email = "info@siamelectric.co.th", Address = "789 ถนนเพชรบุรี กรุงเทพฯ 10400", Notes = "จำหน่ายอุปกรณ์ไฟฟ้าและอิเล็กทรอนิกส์", CreatedAt = DateTime.UtcNow },
                new Supplier { Id = 4, Name = "Eastern Hydraulics Ltd.", ContactPerson = "ประสิทธิ์ มั่นคง", Phone = "038-123-456", Email = "sales@easternhydraulics.com", Address = "123 นิคมอุตสาหกรรมอีสเทิร์นซีบอร์ด ระยอง 21140", Notes = "ผู้เชี่ยวชาญระบบไฮดรอลิก", CreatedAt = DateTime.UtcNow },
                new Supplier { Id = 5, Name = "Precision Tools Thailand", ContactPerson = "สุรีย์ พรมมา", Phone = "02-456-7890", Email = "contact@precisiontools.co.th", Address = "101 ถนนบางนา-ตราด กรุงเทพฯ 10260", Notes = "จำหน่ายเครื่องมือความแม่นยำสูง", CreatedAt = DateTime.UtcNow },
                new Supplier { Id = 6, Name = "Northern Pneumatic Systems", ContactPerson = "ภาณุ ภักดี", Phone = "053-234-567", Email = "sales@northernpneumatic.com", Address = "234 ถนนเชียงใหม่-ลำพูน เชียงใหม่ 50000", Notes = "ผู้เชี่ยวชาญระบบนิวเมติก", CreatedAt = DateTime.UtcNow },
                new Supplier { Id = 7, Name = "Thai Automation Parts Co., Ltd.", ContactPerson = "กรรณิการ์ สมใจ", Phone = "02-567-8901", Email = "info@thaiautomation.com", Address = "567 ถนนพระราม 2 กรุงเทพฯ 10150", Notes = "จำหน่ายอุปกรณ์ระบบอัตโนมัติ", CreatedAt = DateTime.UtcNow },
                new Supplier { Id = 8, Name = "Rayong Industrial Supply", ContactPerson = "วิทยา ศรีสุข", Phone = "038-345-678", Email = "contact@rayongindustrial.com", Address = "789 นิคมอุตสาหกรรมมาบตาพุด ระยอง 21150", Notes = "ผู้จัดจำหน่ายในพื้นที่ EEC", CreatedAt = DateTime.UtcNow },
                new Supplier { Id = 9, Name = "Central Seals & Gaskets", ContactPerson = "มานะ รักษ์ดี", Phone = "02-678-9012", Email = "sales@centralseals.co.th", Address = "890 ถนนพัฒนาการ กรุงเทพฯ 10250", Notes = "ผู้เชี่ยวชาญด้านซีลและปะเก็น", CreatedAt = DateTime.UtcNow },
                new Supplier { Id = 10, Name = "Thai Motor Solutions", ContactPerson = "สมศรี ใจเย็น", Phone = "02-789-0123", Email = "info@thaimotors.com", Address = "321 ถนนรัชดาภิเษก กรุงเทพฯ 10400", Notes = "จำหน่ายมอเตอร์และอุปกรณ์ขับเคลื่อน", CreatedAt = DateTime.UtcNow }
            );
            
            // Seed data for Machine
            modelBuilder.Entity<Machine>().HasData(
                new Machine { Id = 1, Name = "เครื่องกลึง CNC รุ่น TL-1500", ModelNumber = "TL-1500", SerialNumber = "TL1500-2023-001", Description = "เครื่องกลึง CNC ความแม่นยำสูง", Manufacturer = "Thai CNC Machines", ManufactureDate = new DateTime(2023, 5, 15), InstallationDate = new DateTime(2023, 6, 20), Location = "แผนกผลิต A", ImageUrl = "/images/machines/tl-1500.jpg", CreatedAt = DateTime.UtcNow },
                new Machine { Id = 2, Name = "เครื่องกัด CNC 5 แกน", ModelNumber = "VM-5X", SerialNumber = "VM5X-2022-042", Description = "เครื่องกัด CNC 5 แกน สำหรับงานซับซ้อน", Manufacturer = "Vertical Milling Co., Ltd.", ManufactureDate = new DateTime(2022, 8, 10), InstallationDate = new DateTime(2022, 9, 15), Location = "แผนกผลิต B", ImageUrl = "/images/machines/vm-5x.jpg", CreatedAt = DateTime.UtcNow },
                new Machine { Id = 3, Name = "เครื่องฉีดพลาสติก 250 ตัน", ModelNumber = "IM-250", SerialNumber = "IM250-2021-103", Description = "เครื่องฉีดพลาสติกขนาด 250 ตัน", Manufacturer = "Thai Injection Systems", ManufactureDate = new DateTime(2021, 3, 20), InstallationDate = new DateTime(2021, 4, 25), Location = "แผนกฉีดพลาสติก", ImageUrl = "/images/machines/im-250.jpg", CreatedAt = DateTime.UtcNow },
                new Machine { Id = 4, Name = "เครื่องเชื่อมอัตโนมัติ", ModelNumber = "RW-200", SerialNumber = "RW200-2023-015", Description = "เครื่องเชื่อมหุ่นยนต์อัตโนมัติ", Manufacturer = "Robotic Welding Co., Ltd.", ManufactureDate = new DateTime(2023, 2, 5), InstallationDate = new DateTime(2023, 3, 10), Location = "แผนกเชื่อม", ImageUrl = "/images/machines/rw-200.jpg", CreatedAt = DateTime.UtcNow },
                new Machine { Id = 5, Name = "เครื่องตัดเลเซอร์", ModelNumber = "LC-3000", SerialNumber = "LC3000-2022-027", Description = "เครื่องตัดเลเซอร์กำลังสูง", Manufacturer = "Laser Cutting Technologies", ManufactureDate = new DateTime(2022, 6, 12), InstallationDate = new DateTime(2022, 7, 20), Location = "แผนกตัดแผ่น", ImageUrl = "/images/machines/lc-3000.jpg", CreatedAt = DateTime.UtcNow },
                new Machine { Id = 6, Name = "เครื่องพับโลหะ CNC", ModelNumber = "PB-120", SerialNumber = "PB120-2021-058", Description = "เครื่องพับโลหะแผ่น CNC", Manufacturer = "Press Brake Systems", ManufactureDate = new DateTime(2021, 9, 8), InstallationDate = new DateTime(2021, 10, 15), Location = "แผนกขึ้นรูป", ImageUrl = "/images/machines/pb-120.jpg", CreatedAt = DateTime.UtcNow },
                new Machine { Id = 7, Name = "เครื่องทดสอบแรงดึง", ModelNumber = "TS-50", SerialNumber = "TS50-2023-007", Description = "เครื่องทดสอบแรงดึงความแม่นยำสูง", Manufacturer = "Testing Equipment Co., Ltd.", ManufactureDate = new DateTime(2023, 1, 15), InstallationDate = new DateTime(2023, 2, 20), Location = "แผนก QC", ImageUrl = "/images/machines/ts-50.jpg", CreatedAt = DateTime.UtcNow },
                new Machine { Id = 8, Name = "เครื่องบรรจุอัตโนมัติ", ModelNumber = "PK-500", SerialNumber = "PK500-2022-031", Description = "เครื่องบรรจุภัณฑ์อัตโนมัติ", Manufacturer = "Packaging Systems", ManufactureDate = new DateTime(2022, 4, 25), InstallationDate = new DateTime(2022, 5, 30), Location = "แผนกบรรจุภัณฑ์", ImageUrl = "/images/machines/pk-500.jpg", CreatedAt = DateTime.UtcNow },
                new Machine { Id = 9, Name = "เครื่องพิมพ์ 3 มิติ", ModelNumber = "3DP-X1", SerialNumber = "3DPX1-2023-022", Description = "เครื่องพิมพ์ 3 มิติสำหรับงานอุตสาหกรรม", Manufacturer = "3D Printing Solutions", ManufactureDate = new DateTime(2023, 3, 10), InstallationDate = new DateTime(2023, 4, 15), Location = "แผนกต้นแบบ", ImageUrl = "/images/machines/3dp-x1.jpg", CreatedAt = DateTime.UtcNow },
                new Machine { Id = 10, Name = "เครื่องวัดขนาด CMM", ModelNumber = "CMM-500", SerialNumber = "CMM500-2022-019", Description = "เครื่องวัดขนาดความแม่นยำสูง", Manufacturer = "Coordinate Measuring Co., Ltd.", ManufactureDate = new DateTime(2022, 7, 5), InstallationDate = new DateTime(2022, 8, 10), Location = "แผนกตรวจสอบ", ImageUrl = "/images/machines/cmm-500.jpg", CreatedAt = DateTime.UtcNow }
            );
            
            // Seed data for Component
            modelBuilder.Entity<Component>().HasData(
                new Component { Id = 1, Name = "มอเตอร์ไฟฟ้า 3 เฟส 5HP", PartNumber = "MTR-3P-5HP", Description = "มอเตอร์ไฟฟ้า 3 เฟส 5 แรงม้า 380V", Price = 12500.00m, LeadTime = 14, MinimumStock = 2, ImageUrl = "/images/components/mtr-3p-5hp.jpg", CategoryId = 10, UnitOfMeasureId = 1, SupplierId = 3, CreatedAt = DateTime.UtcNow },
                new Component { Id = 2, Name = "ลูกปืนตุ๊กตา UCF205", PartNumber = "BRG-UCF205", Description = "ลูกปืนตุ๊กตาเสื้อสี่เหลี่ยม รุ่น UCF205", Price = 850.00m, LeadTime = 7, MinimumStock = 10, ImageUrl = "/images/components/brg-ucf205.jpg", CategoryId = 8, UnitOfMeasureId = 1, SupplierId = 2, CreatedAt = DateTime.UtcNow },
                new Component { Id = 3, Name = "โซลินอยด์วาล์ว 24VDC", PartNumber = "VLV-SL-24DC", Description = "โซลินอยด์วาล์วควบคุมลม 24VDC 1/4 นิ้ว", Price = 1200.00m, LeadTime = 10, MinimumStock = 5, ImageUrl = "/images/components/vlv-sl-24dc.jpg", CategoryId = 4, UnitOfMeasureId = 1, SupplierId = 6, CreatedAt = DateTime.UtcNow },
                new Component { Id = 4, Name = "สายพานไทม์มิ่ง HTD5M", PartNumber = "BLT-HTD5M-25", Description = "สายพานไทม์มิ่ง HTD5M กว้าง 25mm", Price = 450.00m, LeadTime = 5, MinimumStock = 3, ImageUrl = "/images/components/blt-htd5m.jpg", CategoryId = 2, UnitOfMeasureId = 1, SupplierId = 1, CreatedAt = DateTime.UtcNow },
                new Component { Id = 5, Name = "เซ็นเซอร์วัดระยะทาง", PartNumber = "SNS-DIST-01", Description = "เซ็นเซอร์วัดระยะทางแบบเลเซอร์ ระยะ 10-100cm", Price = 2800.00m, LeadTime = 21, MinimumStock = 2, ImageUrl = "/images/components/sns-dist-01.jpg", CategoryId = 5, UnitOfMeasureId = 1, SupplierId = 7, CreatedAt = DateTime.UtcNow },
                new Component { Id = 6, Name = "กระบอกลมพร้อมเซ็นเซอร์", PartNumber = "CYL-32-100", Description = "กระบอกลมขนาด 32mm ระยะชัก 100mm พร้อมเซ็นเซอร์", Price = 3500.00m, LeadTime = 14, MinimumStock = 3, ImageUrl = "/images/components/cyl-32-100.jpg", CategoryId = 4, UnitOfMeasureId = 1, SupplierId = 6, CreatedAt = DateTime.UtcNow },
                new Component { Id = 7, Name = "ชุดควบคุม PLC", PartNumber = "PLC-CP1L", Description = "ชุดควบคุม PLC พร้อมโมดูล I/O", Price = 15000.00m, LeadTime = 30, MinimumStock = 1, ImageUrl = "/images/components/plc-cp1l.jpg", CategoryId = 5, UnitOfMeasureId = 1, SupplierId = 7, CreatedAt = DateTime.UtcNow },
                new Component { Id = 8, Name = "ปั๊มไฮดรอลิก", PartNumber = "PMP-HYD-80", Description = "ปั๊มไฮดรอลิกแรงดันสูง 80 บาร์", Price = 22000.00m, LeadTime = 45, MinimumStock = 1, ImageUrl = "/images/components/pmp-hyd-80.jpg", CategoryId = 3, UnitOfMeasureId = 1, SupplierId = 4, CreatedAt = DateTime.UtcNow },
                new Component { Id = 9, Name = "ชุดซีลไฮดรอลิก", PartNumber = "SEAL-HYD-32", Description = "ชุดซีลไฮดรอลิกสำหรับกระบอกขนาด 32mm", Price = 450.00m, LeadTime = 7, MinimumStock = 10, ImageUrl = "/images/components/seal-hyd-32.jpg", CategoryId = 9, UnitOfMeasureId = 9, SupplierId = 9, CreatedAt = DateTime.UtcNow },
                new Component { Id = 10, Name = "สกรูบอลล์ 1605 ยาว 500mm", PartNumber = "SCW-1605-500", Description = "สกรูบอลล์เกรด C7 ขนาด 16mm พิตช์ 5mm ยาว 500mm", Price = 4500.00m, LeadTime = 21, MinimumStock = 2, ImageUrl = "/images/components/scw-1605-500.jpg", CategoryId = 2, UnitOfMeasureId = 1, SupplierId = 5, CreatedAt = DateTime.UtcNow }
            );
            
            // Seed data for BillOfMaterial
            modelBuilder.Entity<BillOfMaterial>().HasData(
                new BillOfMaterial { Id = 1, MachineId = 1, ParentComponentId = 1, ChildComponentId = 2, Quantity = 2, Notes = "ลูกปืนสำหรับมอเตอร์หลัก", Level = 1, CreatedAt = DateTime.UtcNow },
                new BillOfMaterial { Id = 2, MachineId = 1, ParentComponentId = 1, ChildComponentId = 4, Quantity = 1, Notes = "สายพานขับเคลื่อนหลัก", Level = 1, CreatedAt = DateTime.UtcNow },
                new BillOfMaterial { Id = 3, MachineId = 2, ParentComponentId = 7, ChildComponentId = 5, Quantity = 3, Notes = "เซ็นเซอร์สำหรับระบบควบคุม", Level = 1, CreatedAt = DateTime.UtcNow },
                new BillOfMaterial { Id = 4, MachineId = 3, ParentComponentId = 8, ChildComponentId = 9, Quantity = 4, Notes = "ซีลสำหรับระบบไฮดรอลิก", Level = 1, CreatedAt = DateTime.UtcNow },
                new BillOfMaterial { Id = 5, MachineId = 4, ParentComponentId = 7, ChildComponentId = 3, Quantity = 6, Notes = "วาล์วควบคุมระบบนิวเมติก", Level = 1, CreatedAt = DateTime.UtcNow },
                new BillOfMaterial { Id = 6, MachineId = 5, ParentComponentId = 1, ChildComponentId = 10, Quantity = 2, Notes = "สกรูบอลล์สำหรับระบบเคลื่อนที่", Level = 1, CreatedAt = DateTime.UtcNow },
                new BillOfMaterial { Id = 7, MachineId = 6, ParentComponentId = 8, ChildComponentId = 6, Quantity = 2, Notes = "กระบอกลมสำหรับระบบคีบชิ้นงาน", Level = 1, CreatedAt = DateTime.UtcNow },
                new BillOfMaterial { Id = 8, MachineId = 7, ParentComponentId = 7, ChildComponentId = 5, Quantity = 1, Notes = "เซ็นเซอร์สำหรับระบบวัด", Level = 1, CreatedAt = DateTime.UtcNow },
                new BillOfMaterial { Id = 9, MachineId = 8, ParentComponentId = 1, ChildComponentId = 4, Quantity = 3, Notes = "สายพานลำเลียง", Level = 1, CreatedAt = DateTime.UtcNow },
                new BillOfMaterial { Id = 10, MachineId = 9, ParentComponentId = 7, ChildComponentId = 10, Quantity = 3, Notes = "สกรูบอลล์สำหรับระบบเคลื่อนที่แกน XYZ", Level = 1, CreatedAt = DateTime.UtcNow }
            );
            
            // Seed admin user
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    Id = 1, 
                    Username = "admin", 
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"), 
                    Email = "admin@irpcbom.com", 
                    FullName = "System Administrator", 
                    Role = "Admin", 
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new User 
                { 
                    Id = 2, 
                    Username = "manager", 
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Manager@123"), 
                    Email = "manager@irpcbom.com", 
                    FullName = "System Manager", 
                    Role = "Manager", 
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new User 
                { 
                    Id = 3, 
                    Username = "user", 
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("User@123"), 
                    Email = "user@irpcbom.com", 
                    FullName = "Normal User", 
                    Role = "User", 
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
} 