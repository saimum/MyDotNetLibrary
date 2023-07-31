using WebCore7_withEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace WebCore7_withEF.Models
{
    public partial class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            //base.OnConfiguring(optionsbuilder);
            //optionsbuilder.UseSqlServer("Server=172.17.9.160;user id=sa;password=asdf@1234;Database=DbBridgingScaleProject;Encrypt=false;TrustServerCertificate=true;");
            optionsbuilder.UseLazyLoadingProxies();
        }

        public virtual DbSet<BaseCompany> BaseCompany { get; set; }
        public virtual DbSet<BridgingScaleBrandModel> BridgingScaleBrandModel { get; set; }
        public virtual DbSet<BridgingScaleMeter> BridgingScaleMeter { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Gate> Gate { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<ClientParty> ClientParty { get; set; }
        public virtual DbSet<UserEntity> UserEntity { get; set; }
        public virtual DbSet<VehicleWeightTransaction> VehicleWeightTransaction { get; set; }
        public virtual DbSet<FirstWeightedVehicle> FirstWeightedVehicle { get; set; }
        public virtual DbSet<VW_VehicleWeightTransaction_Detail> VW_VehicleWeightTransaction_Detail { get; set; }



        public virtual DbSet<TestDivision> TestDivision { get; set; }
        public virtual DbSet<TestDistrict> TestDistrict { get; set; }




        public virtual DbSet<AuditLog> AuditLog { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
