using System;
using Hotel.Models.Entities.Web;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
	public class MyContext :DbContext
	{
		public MyContext()
		{
		}
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite("Data Source=data.db");
        public DbSet<FirstBaner> firstBaners { get; set; }
    }
}

