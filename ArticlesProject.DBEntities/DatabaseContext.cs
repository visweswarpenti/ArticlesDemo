using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ArticlesProject.DBEntities
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext()
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
		}

		//public Product usp_getProduct(int ProductId)
		//{
		//	Product product = new Product();
		//	using (var command = this.Database.GetDbConnection().CreateCommand())
		//	{
		//		command.CommandText = "usp_getProduct";
		//		command.CommandType = CommandType.StoredProcedure;
		//		var parameter = new SqlParameter("ProductId", ProductId);

		//		command.Parameters.Add(parameter);
		//		this.Database.OpenConnection();
		//		using (var reader = command.ExecuteReader())
		//		{
		//			while (reader.Read())
		//			{
		//				product.ProductId = reader.GetInt32("ProductId");
		//				product.Name = reader.GetString("Name");
		//				product.Description = reader.GetString("Description");
		//				product.UnitPrice = reader.GetDecimal("UnitPrice");
		//				product.CatId = reader.GetInt32("CatId");
		//			}
		//		}
		//		this.Database.CloseConnection();
		//	}

		//	return product;
		//}

		//public Product fn_getProduct(int ProductId)
		//{
		//	return this.Products.FromSqlRaw<Product>("Select * from fn_getProduct(ProductId)", new SqlParameter("ProductId", ProductId)).FirstOrDefault();
		//}
	}
}
