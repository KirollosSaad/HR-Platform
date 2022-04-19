﻿// <auto-generated />
using System;
using HR.Platform.Domain.Entities;
using HR.Platform.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HR.Platform.Infrastructure.Migrations
{
    [DbContext(typeof(HRDBContext))]
    partial class HRDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HR.Platform.Domain.Entities.Applicant", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedById")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DeletedById")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Summary")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedById")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedAt");

                    b.HasIndex("DeletedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("HR.Platform.Domain.Entities.EvaluationCriteria", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedById")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("CriteriaName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DeletedById")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int?>("Level")
                        .HasMaxLength(50)
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedById")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedAt");

                    b.HasIndex("DeletedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("EvaluationCriteria");
                });

            modelBuilder.Entity("HR.Platform.Domain.Entities.EvaluationGroup", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedById")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DeletedById")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedById")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedAt");

                    b.HasIndex("DeletedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("EvaluationGroup");
                });

            modelBuilder.Entity("HR.Platform.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("ApprovedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ApprovedBy")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedById")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DeletedById")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ExternalProvider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Recruiter>("Recruiter")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedById")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("UserType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("DeletedAt");

                    b.HasIndex("DeletedById");

                    b.HasIndex("UpdatedById");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HR.Platform.Domain.Entities.Applicant", b =>
                {
                    b.HasOne("HR.Platform.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HR.Platform.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HR.Platform.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("HR.Platform.Domain.Entities.EvaluationCriteria", b =>
                {
                    b.HasOne("HR.Platform.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HR.Platform.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HR.Platform.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("HR.Platform.Domain.Entities.EvaluationGroup", b =>
                {
                    b.HasOne("HR.Platform.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HR.Platform.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HR.Platform.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("HR.Platform.Domain.Entities.User", b =>
                {
                    b.HasOne("HR.Platform.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HR.Platform.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("DeletedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("HR.Platform.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.NoAction);
                });
#pragma warning restore 612, 618
        }
    }
}
