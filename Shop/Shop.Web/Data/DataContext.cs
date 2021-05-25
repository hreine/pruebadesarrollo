using Microsoft.EntityFrameworkCore;
using Shop.Web.Data.Entities;
using Shop.Web.Models;
namespace Shop.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Data.Entities;
    using System.Data.SqlClient;
    using System.Linq;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Store> Store { get; set; }

        public DbSet<ServiceType> ServiceType { get; set; }

        public DbSet<DocType> DocType { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Country> Countries { get; set; }
        
        public DbSet<City> Cities { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderDetailTemp> OrderDetailTemps { get; set; }


        public DbSet<PartMaster> PartMaster { get; set; }

        public DbSet<InventTrans> InventTrans { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Mechanical> Mechanical { get; set; }

        public DbSet<ServiceHeader> ServiceHeader { get; set; }

        public DbSet<ServiceLine> ServiceLine { get; set; }

        public DbSet<InvoiceHeader> InvoiceHeader { get; set; }

        public DbSet<InvoiceLines> InvoiceLines { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public string GetMySequence(string prefix,int totalwidth)
        {
            string sql;

            SqlParameter result = new SqlParameter("@result", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            if (string.IsNullOrEmpty(prefix))
            {
              sql = "SELECT @result = (NEXT VALUE FOR DefaultSequence)";
            }
            
            sql = $"SELECT @result = (NEXT VALUE FOR {prefix}Sequence)";

            Database.ExecuteSqlCommand(sql, result);

            string sValue = result.Value.ToString();

            return $"{prefix}{sValue.PadLeft(totalwidth, '0')}";
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<IEntity>();
            /*
            modelBuilder.HasSequence<int>("DefaultSequence");
            modelBuilder.HasSequence<int>("ASequence");
            modelBuilder.HasSequence<int>("BSequence");
            modelBuilder.HasSequence<int>("CSequence");
            */
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            /*
            modelBuilder.Entity<Customer>()
                .Property(p => p.Budget)
                .HasColumnType("decimal(18,2)");
            */
            modelBuilder.Entity<PartMaster>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PartMaster>()
                .Property(p => p.MaxPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PartMaster>()
                .Property(p => p.MinPrice)
                .HasColumnType("decimal(18,2)");
            
            var cascadeFKs = modelBuilder.Model
                .G­etEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Shop.Web.Models.CustomerViewModel> CustomerViewModel { get; set; }
              
    }
}
