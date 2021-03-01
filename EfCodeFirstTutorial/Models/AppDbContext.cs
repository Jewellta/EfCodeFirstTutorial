using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirstTutorial.Models
{
	public class AppDbContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public AppDbContext(){
		}
		protected override void OnConfiguring(DbContextOptionsBuilder builder) {
			if (!builder.IsConfigured) {
				var connStr = "server=localhost\\sqlexpress;" +
					"database=AppDb1;" +
					"trusted_connection=true;";
				builder.UseSqlServer(connStr);
					}
		}

		protected override void OnModelCreating(ModelBuilder builder){

		}
	}
}
