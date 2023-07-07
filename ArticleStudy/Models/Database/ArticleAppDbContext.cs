using Microsoft.EntityFrameworkCore;

namespace ArticleStudy.Models.Database
{
    public class ArticleAppDbContext : DbContext
    {
        public ArticleAppDbContext()
        {
            
        }

        public ArticleAppDbContext(DbContextOptions<ArticleAppDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=123.2.156.21,1433;Database=ArticleApp;User Id=sa1;Password=wegg2650;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().Property(m => m.Created).HasDefaultValueSql("GetDate()");
        }

        public DbSet<Article> Articles { get; set; }

    }
}
