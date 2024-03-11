using DnDCharacterBuilder.Data.Entities;
using DnDCharacterBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DnDCharacterBuilder.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterAbility> CharacterAbilities { get; set; }
        public DbSet<CharacterSkillProficiency> CharacterSkillProficiencies { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassSavingThrow> ClassSavingThrows { get; set; }
        public DbSet<ClassSkillProficiencieBonus> ClassSkillProficiencieBonuses { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceAbilityBonus> RaceAbilityBonuses { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SKP-L3694\\SQLEXPRESS;Initial Catalog=DnDDatabase;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSkillProficiency>().HasKey(csp => new { csp.CharacterId, csp.SkillId });
            modelBuilder.Entity<CharacterAbility>().HasKey(ca => new { ca.CharacterId, ca.Ability });
            modelBuilder.Entity<ClassSkillProficiencieBonus>().HasKey(cpb => new { cpb.ClassId, cpb.SkillId });
            modelBuilder.Entity<RaceAbilityBonus>().HasKey(rab => new { rab.RaceId, rab.Ability });
            modelBuilder.Entity<ClassSavingThrow>().HasKey(rab => new { rab.ClassId, rab.Ability });
        }
    }
}
