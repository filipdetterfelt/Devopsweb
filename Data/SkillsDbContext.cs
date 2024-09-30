using Devopsweb.Models;
using Microsoft.EntityFrameworkCore;

namespace Devopsweb.Data
{
    public class SkillsDbContext : DbContext
    {

        private readonly IConfiguration _configuration;

        public SkillsDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SkillsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<SkillsModel> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SkillsModel>().HasData(
                    new SkillsModel { Id = 1, Title = "MySQL" },
                     new SkillsModel { Id = 2, Title = "HTML" },
                     new SkillsModel { Id = 3, Title = "CSS" },
                     new SkillsModel { Id = 4, Title = "JavaScript" },
                     new SkillsModel { Id = 5, Title = "Java" },
                     new SkillsModel { Id = 6, Title = "Kotlin" },
                     new SkillsModel { Id = 7, Title = "C#" },
                     new SkillsModel { Id = 8, Title = "OOP" },
                     new SkillsModel { Id = 9, Title = "JSON" },
                     new SkillsModel { Id = 10, Title = "JDBC" },
                     new SkillsModel { Id = 11, Title = "Github" },
                     new SkillsModel { Id = 12, Title = "Bootstrap" },
                     new SkillsModel { Id = 13, Title = "Spring boot" },
                     new SkillsModel { Id = 14, Title = "Docker"},
                     new SkillsModel { Id = 15, Title = "Postgres" }                   
                     );
                
        }
        
    }
}

