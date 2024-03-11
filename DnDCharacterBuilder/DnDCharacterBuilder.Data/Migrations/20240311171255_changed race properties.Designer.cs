﻿// <auto-generated />
using System;
using DnDCharacterBuilder.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DnDCharacterBuilder.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240311171255_changed race properties")]
    partial class changedraceproperties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Alignment")
                        .HasColumnType("int");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ExpPoints")
                        .HasColumnType("int");

                    b.Property<bool>("IsInspired")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RaceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("RaceId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.CharacterAbility", b =>
                {
                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ability")
                        .HasColumnType("int");

                    b.Property<bool>("ProficiencyBonus")
                        .HasColumnType("bit");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "Ability");

                    b.ToTable("CharacterAbilities");
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.CharacterSkillProficiency", b =>
                {
                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CharacterId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CharacterSkillProficiencies");
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HitDie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProficiencyChoiceCount")
                        .HasColumnType("int");

                    b.Property<string>("ProficiencyDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.ClassSavingThrow", b =>
                {
                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ability")
                        .HasColumnType("int");

                    b.HasKey("ClassId", "Ability");

                    b.ToTable("ClassSavingThrows");
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.ClassSkillProficiencieBonus", b =>
                {
                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClassId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("ClassSkillProficiencieBonuses");
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.Race", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AgeInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlignmentInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BonusAbilities")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SizeInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.RaceAbilityBonus", b =>
                {
                    b.Property<Guid>("RaceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ability")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("RaceId", "Ability");

                    b.ToTable("RaceAbilityBonuses");
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RelatedAbility")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.Character", b =>
                {
                    b.HasOne("DnDCharacterBuilder.Domain.Entities.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DnDCharacterBuilder.Domain.Entities.Race", "Race")
                        .WithMany("Characters")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.CharacterAbility", b =>
                {
                    b.HasOne("DnDCharacterBuilder.Domain.Entities.Character", null)
                        .WithMany("CharacterAbilities")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.CharacterSkillProficiency", b =>
                {
                    b.HasOne("DnDCharacterBuilder.Domain.Entities.Character", null)
                        .WithMany("CharacterSkillProficiencies")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DnDCharacterBuilder.Domain.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.ClassSavingThrow", b =>
                {
                    b.HasOne("DnDCharacterBuilder.Domain.Entities.Class", null)
                        .WithMany("ClassSavingThrows")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.ClassSkillProficiencieBonus", b =>
                {
                    b.HasOne("DnDCharacterBuilder.Domain.Entities.Class", null)
                        .WithMany("ClassSkillProficiencieBonus")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DnDCharacterBuilder.Domain.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.RaceAbilityBonus", b =>
                {
                    b.HasOne("DnDCharacterBuilder.Domain.Entities.Race", null)
                        .WithMany("RaceAbilities")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.Character", b =>
                {
                    b.Navigation("CharacterAbilities");

                    b.Navigation("CharacterSkillProficiencies");
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.Class", b =>
                {
                    b.Navigation("ClassSavingThrows");

                    b.Navigation("ClassSkillProficiencieBonus");
                });

            modelBuilder.Entity("DnDCharacterBuilder.Domain.Entities.Race", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("RaceAbilities");
                });
#pragma warning restore 612, 618
        }
    }
}
