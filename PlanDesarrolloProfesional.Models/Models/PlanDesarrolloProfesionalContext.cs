﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PlanDesarrolloProfesional.Models.Models;

public partial class PlanDesarrolloProfesionalContext : DbContext
{
    public PlanDesarrolloProfesionalContext(DbContextOptions<PlanDesarrolloProfesionalContext> options)
        : base(options)
    {
    }

    public PlanDesarrolloProfesionalContext()
    {
        
    }

    public virtual DbSet<Area> Area { get; set; }

    public virtual DbSet<Bitacora> Bitacora { get; set; }

    public virtual DbSet<CumplimientoRequisito> CumplimientoRequisito { get; set; }

    public virtual DbSet<Jerarquias> Jerarquias { get; set; }

    public virtual DbSet<PlanDesarrolloProfesional> PlanDesarrolloProfesional { get; set; }

    public virtual DbSet<Requisito> Requisito { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Ruta> Ruta { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<UsuarioArea> UsuarioArea { get; set; }

    public virtual DbSet<UsuarioJerarquias> UsuarioJerarquias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(StringConexion.ConexionSQL);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaID).HasName("PK__Area__70B82028E180F69D");
        });

        modelBuilder.Entity<Bitacora>(entity =>
        {
            entity.HasKey(e => e.BitacoraID).HasName("PK__Bitacora__7ACF9B18273158BC");
        });

        modelBuilder.Entity<CumplimientoRequisito>(entity =>
        {
            entity.HasKey(e => e.CumplimientoRequisitoID).HasName("PK__Cumplimi__D59907128681C0E1");

            entity.HasOne(d => d.PlanDesarrollo).WithMany(p => p.CumplimientoRequisito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CumplimientoRequisito_PlanDesarrolloProfesional");

            entity.HasOne(d => d.Requisito).WithMany(p => p.CumplimientoRequisito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cumplimie__Requi__4316F928");
        });

        modelBuilder.Entity<PlanDesarrolloProfesional>(entity =>
        {
            entity.HasKey(e => e.PlanDesarrolloID).HasName("PK__Colabora__899DAA21E52D5EA8");

            entity.HasOne(d => d.Colaborador).WithMany(p => p.PlanDesarrolloProfesional)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlanDesarrolloProfesional_Usuario");
        });

        modelBuilder.Entity<Requisito>(entity =>
        {
            entity.HasKey(e => e.RequisitoID).HasName("PK__Requisit__372DF81ABA00CC13");
        });

        modelBuilder.Entity<Ruta>(entity =>
        {
            entity.HasKey(e => e.RutaID).HasName("PK__Ruta__7B6199EEC886CFDB");

            entity.HasOne(d => d.Area).WithMany(p => p.Ruta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ruta__AreaID__286302EC");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioID).HasName("PK__Colabora__28AA72C1A3F53889");

            entity.HasOne(d => d.Jerarquia).WithMany(p => p.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Jerarquias");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Rol");
        });

        modelBuilder.Entity<UsuarioArea>(entity =>
        {
            entity.HasOne(d => d.Area).WithMany(p => p.UsuarioArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioArea_Area");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioArea_Usuario");
        });

        modelBuilder.Entity<UsuarioJerarquias>(entity =>
        {
            entity.HasOne(d => d.Supervisor).WithMany(p => p.UsuarioJerarquiasSupervisor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioJerarquias_Usuario1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioJerarquiasUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioJerarquias_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}