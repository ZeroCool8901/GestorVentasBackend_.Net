using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestorVentas_Backend.Models
{
    public partial class GestorVentasContext : DbContext
    {
        public GestorVentasContext()
        {
        }

        public GestorVentasContext(DbContextOptions<GestorVentasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<BankAccount> BankAccounts { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Contractor> Contractors { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433; Database=GestorVentas;User=SA;Password=<Zero2022*.>");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.IdArticle);

                entity.ToTable("Article");

                entity.Property(e => e.IdArticle).HasColumnName("id_article");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brand");

                entity.Property(e => e.Cant).HasColumnName("cant");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.SerialNumber).HasColumnName("serial_number");
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.HasKey(e => e.IdBankAccount);

                entity.ToTable("BankAccount");

                entity.Property(e => e.IdBankAccount).HasColumnName("id_bank_account");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("account_type");

                entity.Property(e => e.IdContractor).HasColumnName("id_contractor");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Number)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("number");

            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient);

                entity.ToTable("Client");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Cel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cel");

                entity.Property(e => e.IdentificationNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("identification_number");

                entity.Property(e => e.IdentificationType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("identification_type");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.HasKey(e => e.IdContractor);

                entity.ToTable("Contractor");

                entity.Property(e => e.IdContractor).HasColumnName("id_contractor");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Cel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cel");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Nit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nit");

            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.IdSale);

                entity.ToTable("Sale");

                entity.Property(e => e.IdSale).HasColumnName("id_sale");

                entity.Property(e => e.Approved)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("approved");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.IdArticle).HasColumnName("id_article");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.IdContractor).HasColumnName("id_contractor");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");


            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.IdService);

                entity.ToTable("Service");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rol");

                entity.Property(e => e.State).HasColumnName("state");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
