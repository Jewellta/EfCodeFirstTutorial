using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EfCodeFirstTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirstTutorial.Controllers
{
	public class OrderController
	{
		private readonly AppDbContext _context;

		public async Task<IEnumerable<Order>> GetAll()
		{
			return await _context.Orders.ToListAsync();
		}
		public async Task<Order> GetByPk(int id)
		{
			return await _context.Orders.FindAsync(id);
		}
		public async Task Change(Order order)
		{
			if (order == null) { throw new Exception("no order"); }
			_context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1)
			{
				throw new Exception("changing too many rows");
			}
			return;
		}

		public async Task<Order> Create(Order order)
		{
			if (order == null) { throw new Exception("null"); }
			_context.Orders.Add(order);
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) { throw new Exception("more than one row selected"); }
			return order;
		}

		public async Task<Order> Remove(int id)
		{
			var order = await _context.Orders.FindAsync();
			if (order == null) { return null; }
			_context.Orders.Remove(order);
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) { throw new Exception("remove failed"); }
			return order;
		}

		public OrderController()
		{
			_context = new AppDbContext();
		}

	}
}
