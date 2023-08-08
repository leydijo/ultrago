using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ultrago.Models.Entity;

public partial class UltragoContext : DbContext
{
    public UltragoContext()
    {
    }

    public UltragoContext(DbContextOptions<UltragoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContactEmergency> ContactEmergencies { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JOHANA\\SQLEXPRESS;Database=ultrago;Integrated Security = true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactEmergency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContactE__3214EC0771EA74FF");

            entity.ToTable("ContactEmergency");

            entity.Property(e => e.FullNames)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneContact)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.ContactEmergencies)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("FK__ContactEm__IdRes__440B1D61");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Guests__3214EC07A0931BB2");

            entity.Property(e => e.DateBirth).HasColumnType("date");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Names)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneContact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TypeDocument)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hotels__3214EC074D4BE5C1");

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Hotels__UserId__46E78A0C");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC07AC4C4972");

            entity.Property(e => e.DateEnd).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.IdGuestNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.IdGuest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__IdGue__412EB0B6");

            entity.HasOne(d => d.IdRoomNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.IdRoom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__IdRoo__403A8C7D");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rooms__3214EC07FCE4F845");

            entity.Property(e => e.CostBase).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LocationRoom)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Taxes).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TypeRoom)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdHotelNavigation).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.IdHotel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rooms__IdHotel__3B75D760");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC076E632324");

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456FD17D568").IsUnique();

            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Profile)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
