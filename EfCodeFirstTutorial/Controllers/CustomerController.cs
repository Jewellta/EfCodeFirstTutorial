using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCodeFirstTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirstTutorial.Controllers
{
	public class CustomerController
	{
		private readonly AppDbContext _context;

		public async Task<IEnumerable<Customer>> GetAll()
		{
			return await _context.Customers.ToListAsync();
		}

		public async Task<Customer> GetByPk(int id)
		{
			return await _context.Customers.FindAsync(id);
		}

		public async Task <Customer> Create (Customer customer)
		{
			if (customer == null){ throw new Exception("cant create customer"); }
			if(customer.Id != 0) { throw new Exception("customer id must be zero"); }
			_context.Customers.Add(customer);
			var rowsAffected = await _context.SaveChangesAsync();
			if(rowsAffected != 1)
			{throw new Exception("create failed");}
			return customer;
		}

		public Change(Customer customer)
		{
			if (customer == null) { throw new Exception("no customer"); }
			_context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		}




			public CustomerController()
			{
				_context = new AppDbContext();
			}
	}
}
