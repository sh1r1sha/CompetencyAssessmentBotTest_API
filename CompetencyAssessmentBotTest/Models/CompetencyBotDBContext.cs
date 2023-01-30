using Microsoft.EntityFrameworkCore;
using System;

namespace CompetencyAssessmentBotTest.Models
{
    public class CompetencyBotDBContext : DbContext
    {
        public CompetencyBotDBContext(DbContextOptions<CompetencyBotDBContext> options)
            : base(options)
        { }
        public DbSet<Suggestions> Suggestions { get; set; }

        
    }
}
