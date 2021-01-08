using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Collections.Generic;

namespace MyApi.Models
{
    public class MyContext : DbContext
    {

        public DbSet<DJBox> DJBoxTable { get; set; }

        public DbSet<DJCabinet> DJCabinetTable { get; set; }

        public DbSet<Material> MaterialTable { get; set; }

        public DbSet<MaterialInventory> MaterialInventoryTable { get; set; }

        public DbSet<OperatingRecord> OpenBoxRecordTable { get; set; }

        public DbSet<UserInfoDbM> UserInfoTable { get; set; }

        public DbSet<ZKFinger> ZKFingerTable { get; set; }

        public DbSet<DJFace> DJFaceTable { get; set; }

        public DbSet<Inventory> InventoryTable { get; set; }
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }
        // private string ReadConnectionString()
        // {
        //     Configuration MyConfiguration = ConfigurationManager<>.OpenMappedExeConfiguration(
        //         new ExeConfigurationFileMap() { ExeConfigFilename = "IC.EFCore.dll.config" },
        //         ConfigurationUserLevel.None);
        //
        //     var cs = MyConfiguration.ConnectionStrings.ConnectionStrings["DJSQLSERVER"].ToString();
        //     // string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DJSQLSERVER"].ToString();
        //
        //     return cs;
        // }
        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // {
        //     // options.UseSqlServer(ReadConnectionString());
        //     options.UseSqlServer("Server=127.0.0.1;Database=DJClient_D1123;User Id=sa;Password=123456;");
        //     // options.UseSqlServer("Server=121.40.134.164;Database=DJClient_D1123;User Id=sa;Password=dongjie@1268;");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region DJCabinet Seed

            var djc = new DJCabinet
            {
                id = 1,
                cabinetNo = "001",
                boxCount = 60,
                columnCount = 6,
                rowCount = 10
            };
            modelBuilder.Entity<DJCabinet>().HasData(
                djc
            );

            #endregion

            #region DJBox Seed

            var boxes = new List<DJBox>();
            for (var i = 0; i < 60; i++)
            {
                boxes.Add(
                    new DJBox
                    {
                        id = i + 1,
                        cabinetId = 1,
                        boxId = i + 1,
                        columnNo = i / djc.rowCount + 1,
                        rowNo = i % djc.rowCount + 1,

                        isBind = false,
                        isSnapBind = false,
                        isLongBind = false,
                        isLocked = false,
                        isFree = false,
                        boxType = "专用",
                        bindFeature = null,
                        bindObject = null,
                        bindUserName = null,
                        bindObjectFormat = null,
                        bindObjectProof = null,
                        remarks = null,
                        count = 0
                    });
            }

            modelBuilder.Entity<DJBox>().HasData(
                boxes
            );

            #endregion
        }
    }
}
