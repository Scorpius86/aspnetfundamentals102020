﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using NetCore.Fundamentals.Client.Web.Data.Entities;
using System;

namespace NetCore.Fundamentals.Client.Web.Data.Context
{
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> entity)
        {
            entity.ToTable("Comentario");

            entity.Property(e => e.Contenido).IsUnicode(false);

            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Post)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComentarioPost");

            entity.HasOne(d => d.UsuarioIdActualizacionNavigation)
                .WithMany(p => p.ComentarioUsuarioIdActualizacionNavigations)
                .HasForeignKey(d => d.UsuarioIdActualizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComentarioUsuarioActualizacion");

            entity.HasOne(d => d.UsuarioIdCreacionNavigation)
                .WithMany(p => p.ComentarioUsuarioIdCreacionNavigations)
                .HasForeignKey(d => d.UsuarioIdCreacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComentarioUsuarioCreacion");

            entity.HasOne(d => d.UsuarioIdPropietarioNavigation)
                .WithMany(p => p.ComentarioUsuarioIdPropietarioNavigations)
                .HasForeignKey(d => d.UsuarioIdPropietario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComentarioUsuarioPropietario");
        }
    }
}
