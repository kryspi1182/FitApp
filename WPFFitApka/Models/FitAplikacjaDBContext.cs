using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FitApka.Models
{
    public partial class FitAplikacjaDBContext : DbContext
    {
        private FitAplikacjaDBContext()
        {
        }

        private FitAplikacjaDBContext(DbContextOptions<FitAplikacjaDBContext> options)
            : base(options)
        {
        }

        private static FitAplikacjaDBContext DBContext = null;
        public static FitAplikacjaDBContext GetDBContext()
        {
            if (DBContext == null)
            {
                DBContext = new FitAplikacjaDBContext();
            }
            return DBContext;
        }
        public virtual DbSet<Cwiczenia> Cwiczenia { get; set; }
        public virtual DbSet<CwiczeniaTrening> CwiczeniaTrening { get; set; }
        public virtual DbSet<ListaZakupow> ListaZakupow { get; set; }
        public virtual DbSet<ListaZakupowProdukty> ListaZakupowProdukty { get; set; }
        public virtual DbSet<Posilki> Posilki { get; set; }
        public virtual DbSet<Produkty> Produkty { get; set; }
        public virtual DbSet<ProduktyPosilki> ProduktyPosilki { get; set; }
        public virtual DbSet<Treningi> Treningi { get; set; }
        public virtual DbSet<Uzytkownik> Uzytkownik { get; set; }
        public virtual DbSet<UzytkownikPosilki> UzytkownikPosilki { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-L9K0VTG;Database=FitAplikacjaDB;User Id=FitAplikacjaAlpha;Password=zaq1@WSX;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cwiczenia>(entity =>
            {
                entity.HasKey(e => e.IdCwiczenia)
                    .HasName("Cwiczenia_PK");

                entity.Property(e => e.IdCwiczenia)
                    .HasColumnName("ID_Cwiczenia")
                    .HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Powtorzenia).HasColumnType("numeric(28, 0)");
            });

            modelBuilder.Entity<CwiczeniaTrening>(entity =>
            {
                entity.HasKey(e => new { e.IdTreningi1, e.IdCwiczenia1 })
                    .HasName("CwiczeniaTrening_PK");

                entity.Property(e => e.IdTreningi1)
                    .HasColumnName("ID_Treningi1")
                    .HasColumnType("numeric(28, 0)");

                entity.Property(e => e.IdCwiczenia1)
                    .HasColumnName("ID_Cwiczenia1")
                    .HasColumnType("numeric(28, 0)");

                entity.HasOne(d => d.IdCwiczenia1Navigation)
                    .WithMany(p => p.CwiczeniaTrening)
                    .HasForeignKey(d => d.IdCwiczenia1)
                    .HasConstraintName("CwiczeniaTrening_Cwiczenia_FK");

                entity.HasOne(d => d.IdTreningi1Navigation)
                    .WithMany(p => p.CwiczeniaTrening)
                    .HasForeignKey(d => d.IdTreningi1)
                    .HasConstraintName("CwiczeniaTrening_Treningi_FK");
            });

            modelBuilder.Entity<ListaZakupow>(entity =>
            {
                entity.HasKey(e => e.IdListaZakupow)
                    .HasName("ListaZakupow_PK");

                entity.Property(e => e.IdListaZakupow)
                    .HasColumnName("ID_ListaZakupow")
                    .HasColumnType("numeric(28, 0)");

                entity.Property(e => e.IdUzytkownik1)
                    .HasColumnName("ID_Uzytkownik1")
                    .HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUzytkownik1Navigation)
                    .WithMany(p => p.ListaZakupow)
                    .HasForeignKey(d => d.IdUzytkownik1)
                    .HasConstraintName("ListaZakupow_Uzytkownik_FK");
            });

            modelBuilder.Entity<ListaZakupowProdukty>(entity =>
            {
                entity.HasKey(e => new { e.IdProdukty1, e.IdListaZakupow1 })
                    .HasName("ListaZakupowProdukty_PK");

                entity.Property(e => e.IdProdukty1)
                    .HasColumnName("ID_Produkty1")
                    .HasColumnType("numeric(28, 0)");

                entity.Property(e => e.IdListaZakupow1)
                    .HasColumnName("ID_ListaZakupow1")
                    .HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Ilosc).HasColumnType("numeric(28, 0)");

                entity.HasOne(d => d.IdListaZakupow1Navigation)
                    .WithMany(p => p.ListaZakupowProdukty)
                    .HasForeignKey(d => d.IdListaZakupow1)
                    .HasConstraintName("ListaZakupowProdukty_ListaZakupow_FK");

                entity.HasOne(d => d.IdProdukty1Navigation)
                    .WithMany(p => p.ListaZakupowProdukty)
                    .HasForeignKey(d => d.IdProdukty1)
                    .HasConstraintName("ListaZakupowProdukty_Produkty_FK");
            });

            modelBuilder.Entity<Posilki>(entity =>
            {
                entity.HasKey(e => e.IdPosilki)
                    .HasName("Posilki_PK");

                entity.Property(e => e.IdPosilki)
                    .HasColumnName("ID_Posilki")
                    .HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Kategoria)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Przepis)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produkty>(entity =>
            {
                entity.HasKey(e => e.IdProdukty)
                    .HasName("Produkty_PK");

                entity.Property(e => e.IdProdukty)
                    .HasColumnName("ID_Produkty")
                    .HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Bialko).HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Blonnik).HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Cukier).HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Kcal).HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sol).HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Tluszcz).HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Weglowodany).HasColumnType("numeric(28, 0)");
            });

            modelBuilder.Entity<ProduktyPosilki>(entity =>
            {
                entity.HasKey(e => new { e.IdPosilki1, e.IdProdukty1 })
                    .HasName("ProduktyPosilki_PK");

                entity.Property(e => e.IdPosilki1)
                    .HasColumnName("ID_Posilki1")
                    .HasColumnType("numeric(28, 0)");

                entity.Property(e => e.IdProdukty1)
                    .HasColumnName("ID_Produkty1")
                    .HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Ilosc).HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Jednostka)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPosilki1Navigation)
                    .WithMany(p => p.ProduktyPosilki)
                    .HasForeignKey(d => d.IdPosilki1)
                    .HasConstraintName("ProduktyPosilki_Posilki_FK");

                entity.HasOne(d => d.IdProdukty1Navigation)
                    .WithMany(p => p.ProduktyPosilki)
                    .HasForeignKey(d => d.IdProdukty1)
                    .HasConstraintName("ProduktyPosilki_Produkty_FK");
            });

            modelBuilder.Entity<Treningi>(entity =>
            {
                entity.HasKey(e => e.IdTreningi)
                    .HasName("Treningi_PK");

                entity.Property(e => e.IdTreningi)
                    .HasColumnName("ID_Treningi")
                    .HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Czas).HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uzytkownik>(entity =>
            {
                entity.HasKey(e => e.IdUzytkownik)
                    .HasName("Uzytkownik_PK");

                entity.Property(e => e.IdUzytkownik)
                    .HasColumnName("ID_Uzytkownik")
                    .HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Cel).HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Plec).HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Waga).HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Wiek).HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Wzrost).HasColumnType("numeric(28, 0)");

                entity.Property(e => e.Aktywnosc).HasColumnType("numeric(28, 2)");
            });

            modelBuilder.Entity<UzytkownikPosilki>(entity =>
            {
                entity.HasKey(e => new { e.Dzien, e.IdUzytkownik1, e.IdPosilki1 })
                    .HasName("UzytkownikPosilki_PK");

                entity.Property(e => e.Dzien).HasColumnType("numeric(28, 0)");

                entity.Property(e => e.IdUzytkownik1)
                    .HasColumnName("ID_Uzytkownik1")
                    .HasColumnType("numeric(28, 0)");

                entity.Property(e => e.IdPosilki1)
                    .HasColumnName("ID_Posilki1")
                    .HasColumnType("numeric(28, 0)");

                entity.HasOne(d => d.IdPosilki1Navigation)
                    .WithMany(p => p.UzytkownikPosilki)
                    .HasForeignKey(d => d.IdPosilki1)
                    .HasConstraintName("UzytkownikPosilki_Posilki_FK");

                entity.HasOne(d => d.IdUzytkownik1Navigation)
                    .WithMany(p => p.UzytkownikPosilki)
                    .HasForeignKey(d => d.IdUzytkownik1)
                    .HasConstraintName("UzytkownikPosilki_Uzytkownik_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
