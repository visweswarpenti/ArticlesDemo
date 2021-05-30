using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ArticlesProject.DatabaseEntities
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext()
		{
		}

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

		public DbSet<Article> Articles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Reply> Replys { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(@"data source=WINVP185097-Q6E; initial catalog=ArticlesDb;persist security info=True;user id=sa;password=G7oose@1234567;");
			}

			List<Model> rows = null;

			this.LoadStoredProc("dbo.ListAll")
			   .AddParam("limit", 300L)
			   .AddParam("limitOut", out IOutParam<long> limitOut)
			   .Exec(r => rows = r.ToList<Model>());
		}
	}
}
