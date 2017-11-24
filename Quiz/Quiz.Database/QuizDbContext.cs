using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Entities;
using System;

namespace Quiz.Database
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options)
           : this(options, false)
        {
        }

        public QuizDbContext(DbContextOptions<QuizDbContext> options, bool isEnsureDBCreated)
           : base(options)
        {
            if (isEnsureDBCreated)
                Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Quiz");
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuizInstance> QuizInstances { get; set; }
        public DbSet<QuizRun> QuizRuns { get; set; }
        
		public DbSet<QuizRun> QuizTemplates { get; set; }
        
		public DbSet<QuizRun> QuizAnswers { get; set; }
		
        public DbSet<QuizRun> GradingSystems { get; set; }
    }
}
