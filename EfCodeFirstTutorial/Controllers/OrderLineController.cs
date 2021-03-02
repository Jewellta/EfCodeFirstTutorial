using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EfCodeFirstTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirstTutorial.Controllers
{
	class OrderLineController
	{
		private readonly AppDbContext _context;

		public async Task<IEnumerable<OrderLine>> GetAll()
		{
			return await _context.OrderLines.ToListAsync();
		}

		public async Task<OrderLine> GetByPk(int id)
		{
			return await _context.OrderLines.FindAsync(id);
		}

		public async Task Change(OrderLine orderline)
		{
			if (orderline == null) { throw new Exception("no orderline"); }
			_context.Entry(orderline).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1)
			{
				throw new Exception("changing too many rows");
			}
			return;
		}

		public async Task<OrderLine> Create(OrderLine orderline)
		{if(orderline== null) { throw new Exception("null"); }
			_context.OrderLines.Add(orderline);
			var rowsAffected = await _context.SaveChangesAsync();
			if(rowsAffected != 1) { throw new Exception("more than one row selected"); }
			return orderline;
		}

		public async Task <OrderLine> Remove(int id)
		{
			var orderline = await _context.OrderLines.FindAsync();
			if (orderline == null) { return null; }
			_context.OrderLines.Remove(orderline);
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) { throw new Exception("remove failed"); }
			return orderline;

		}






		public OrderLineController()
		{
			_context = new AppDbContext();
		}
	}
}
