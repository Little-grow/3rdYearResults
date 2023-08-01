using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ThirdYear.Models
{
	public class AppDbContext: DbContext
	{
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=3rdYearResults;Integrated Security=True;Connect Timeout=30;");
            }
        }
    }
}
