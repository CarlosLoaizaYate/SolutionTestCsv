using Microsoft.EntityFrameworkCore;
using TestCsv.Core.Entities;

namespace TestCsv.Infraestructure.Context
{
    public class TestCsvDbContext : DbContext
    {
        public DbSet<UploadFile> UploadFile { get; set; }
        public DbSet<ColumnNameFile> ColumnNameFile { get; set; }
        public DbSet<ColumnValueFile> ColumnValueFile { get; set; }

        public TestCsvDbContext(DbContextOptions<TestCsvDbContext> options) : base(options) { }

    }
}
