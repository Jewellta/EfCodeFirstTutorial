using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCodeFirstTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirstTutorial.Controllers
{
	public class ItemController
	{
		private readonly AppDbContext _context;

		public async Task <IEnumerable<Item>> GetAll()
		{
			return await _context.Items.ToListAsync();
		}
		public async Task<Item> GetByPk(int id)
		{
			return await _context.Items.FindAsync(id);
		}
		public async Task Change(Item item)
		{
			if (item == null) { throw new Exception("no product"); }
			_context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1)
			{
				throw new Exception("changing too many rows");
			}
			return;
		}

		public async Task<Item> Create(Item item)
		{
			if (item == null) { throw new Exception("null"); }
			_context.Items.Add(item);
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) { throw new Exception("more than one row selected"); }
			return item;
		}

		public async Task<Item> Remove(int id)
		{
			var item = await _context.Items.FindAsync();
			if (item == null) { return null; }
			_context.Items.Remove(item);
			var rowsAffected = await _context.SaveChangesAsync();
			if (rowsAffected != 1) { throw new Exception("remove failed"); }
			return item;
		}

			public ItemController()
		{
			_context = new AppDbContext();
		}
	}
}
