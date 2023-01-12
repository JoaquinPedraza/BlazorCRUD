using System;
using System.Collections.Generic;
using BlazorCRUD.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Data;

public partial class TrabajoFinalContext : DbContext
{
    public TrabajoFinalContext()
    {
    }

    public TrabajoFinalContext(DbContextOptions<TrabajoFinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Condicion> Condicions { get; set; }

    public virtual DbSet<FormaPago> FormaPagos { get; set; }

    public virtual DbSet<Inmueble> Inmuebles { get; set; }

    public virtual DbSet<TipoInmueble> TipoInmuebles { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=TrabajoFinal;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("CLIENTE");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_cliente");
            entity.Property(e => e.CorreoCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo_cliente");
            entity.Property(e => e.DirCliente)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dir_cliente");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_cliente");
            entity.Property(e => e.TelefonoCliente)
                .HasColumnType("numeric(12, 0)")
                .HasColumnName("telefono_cliente");
        });

        modelBuilder.Entity<Condicion>(entity =>
        {
            entity.HasKey(e => e.IdCondicion);

            entity.ToTable("CONDICION");

            entity.Property(e => e.IdCondicion)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_condicion");
            entity.Property(e => e.DescCondicion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("desc_condicion");
        });

        modelBuilder.Entity<FormaPago>(entity =>
        {
            entity.HasKey(e => e.IdFormaPago);

            entity.ToTable("FORMA_PAGO");

            entity.Property(e => e.IdFormaPago)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_forma_pago");
            entity.Property(e => e.DescFormaPago)
                .HasMaxLength(2555)
                .IsUnicode(false)
                .HasColumnName("desc_forma_pago");
        });

        modelBuilder.Entity<Inmueble>(entity =>
        {
            entity.HasKey(e => e.IdInmueble);

            entity.ToTable("INMUEBLE");

            entity.Property(e => e.IdInmueble)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_inmueble");
            entity.Property(e => e.CostoInmueble)
                .HasColumnType("money")
                .HasColumnName("costo_inmueble");
            entity.Property(e => e.DescInmueble)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("desc_inmueble");
            entity.Property(e => e.IdTipoInmueble).HasColumnName("id_tipo_inmueble");
            entity.Property(e => e.UbicInmueble)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ubic_inmueble");

        });

        modelBuilder.Entity<TipoInmueble>(entity =>
        {
            entity.HasKey(e => e.IdTipoInmueble);

            entity.ToTable("TIPO_INMUEBLE");

            entity.Property(e => e.IdTipoInmueble)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_tipo_inmueble");
            entity.Property(e => e.DescInmueble)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("desc_inmueble");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta);

            entity.ToTable("VENTA");

            entity.Property(e => e.IdVenta)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_venta");
            entity.Property(e => e.DescVenta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("desc_venta");
            entity.Property(e => e.FechaVenta)
                .HasColumnType("date")
                .HasColumnName("fecha_venta");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdCondicion).HasColumnName("id_condicion");
            entity.Property(e => e.IdFormaPago).HasColumnName("id_forma_pago");
            entity.Property(e => e.IdInmueble).HasColumnName("id_inmueble");
            entity.Property(e => e.TotalGeneral)
                .HasColumnType("money")
                .HasColumnName("total_general");
            entity.Property(e => e.TotalIva)
                .HasColumnType("money")
                .HasColumnName("total_iva");
            entity.Property(e => e.TotalVenta)
                .HasColumnType("money")
                .HasColumnName("total_venta");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
