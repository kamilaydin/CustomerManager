using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CustomerManager
{
    public partial class dbCustomerContext : DbContext
    {
        public dbCustomerContext()
        {
        }

        public dbCustomerContext(DbContextOptions<dbCustomerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adress> Adresses { get; set; }
        public virtual DbSet<C> Cs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Customer1> Customers1 { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=1234;Database=dbCustomer;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_Turkey.1254");

            modelBuilder.Entity<Adress>(entity =>
            {
                entity.ToTable("adress");

                entity.Property(e => e.AdressId)
                    .ValueGeneratedNever()
                    .HasColumnName("adress_id");

                entity.Property(e => e.AdressCustomerFk).HasColumnName("adress_customer_fk");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("country");

                entity.Property(e => e.PostalCode).HasColumnName("postal_code");

                entity.Property(e => e.StreetAdress)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("street_adress");

                entity.HasOne(d => d.AdressCustomerFkNavigation)
                    .WithMany(p => p.Adresses)
                    .HasForeignKey(d => d.AdressCustomerFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("adress_adress_customer_fk_fkey");
            });

            modelBuilder.Entity<C>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cs");

                entity.Property(e => e.AdressCustomerFk).HasColumnName("adress_customer_fk");

                entity.Property(e => e.AdressId).HasColumnName("adress_id");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.CName)
                    .HasColumnType("character varying")
                    .HasColumnName("c_name");

                entity.Property(e => e.CSurname)
                    .HasColumnType("character varying")
                    .HasColumnName("c_surname");

                entity.Property(e => e.City)
                    .HasColumnType("character varying")
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasColumnType("character varying")
                    .HasColumnName("country");

                entity.Property(e => e.EMail)
                    .HasColumnType("character varying")
                    .HasColumnName("e-mail");

                entity.Property(e => e.GenderFk)
                    .HasColumnType("character varying")
                    .HasColumnName("gender_fk");

                entity.Property(e => e.PhoneCustomerFk).HasColumnName("phone_customer_fk");

                entity.Property(e => e.PhoneId).HasColumnName("phone_id");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("character varying")
                    .HasColumnName("phone_number");

                entity.Property(e => e.PhoneType)
                    .HasColumnType("character varying")
                    .HasColumnName("phone_type");

                entity.Property(e => e.PostalCode).HasColumnName("postal_code");

                entity.Property(e => e.Ssn)
                    .HasColumnType("character varying")
                    .HasColumnName("ssn");

                entity.Property(e => e.StreetAdress)
                    .HasColumnType("character varying")
                    .HasColumnName("street_adress");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("customer_pkey");

                entity.ToTable("customer");

                entity.Property(e => e.CId)
                    .ValueGeneratedNever()
                    .HasColumnName("c_id");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("c_name");

                entity.Property(e => e.CSurname)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("c_surname");

                entity.Property(e => e.EMail)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("e-mail");

                entity.Property(e => e.GenderFk)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("gender_fk");

                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("ssn");
            });

            modelBuilder.Entity<Customer1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("customers");

                entity.Property(e => e.AdressCustomerFk).HasColumnName("adress_customer_fk");

                entity.Property(e => e.AdressId).HasColumnName("adress_id");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.CName)
                    .HasColumnType("character varying")
                    .HasColumnName("c_name");

                entity.Property(e => e.CSurname)
                    .HasColumnType("character varying")
                    .HasColumnName("c_surname");

                entity.Property(e => e.City)
                    .HasColumnType("character varying")
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasColumnType("character varying")
                    .HasColumnName("country");

                entity.Property(e => e.EMail)
                    .HasColumnType("character varying")
                    .HasColumnName("e-mail");

                entity.Property(e => e.GenderFk)
                    .HasColumnType("character varying")
                    .HasColumnName("gender_fk");

                entity.Property(e => e.PostalCode).HasColumnName("postal_code");

                entity.Property(e => e.Ssn)
                    .HasColumnType("character varying")
                    .HasColumnName("ssn");

                entity.Property(e => e.StreetAdress)
                    .HasColumnType("character varying")
                    .HasColumnName("street_adress");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("phone");

                entity.Property(e => e.PhoneId)
                    .ValueGeneratedNever()
                    .HasColumnName("phone_id");

                entity.Property(e => e.PhoneCustomerFk).HasColumnName("phone_customer_fk");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("phone_number");

                entity.Property(e => e.PhoneType)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("phone_type");

                entity.HasOne(d => d.PhoneCustomerFkNavigation)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.PhoneCustomerFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("phone_phone_customer_fk_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
