using System;
using System.Threading.Tasks;
using EfCodeFirstTutorial.Controllers;
using EfCodeFirstTutorial.Models;

namespace EfCodeFirstTutorial
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var cstr1 = new CustomerController();
			var itr1 = new ItemController();

			#region
			//item testing
			//var item1 = new Item
			//{
			//	Name = "playstation",
			//	Price=500m
			//};
			//var item2 = new Item
			//{
			//	Name = "xbox",
			//	Price = 500m
			//};
			//var NewItem = await itr1.Create(item1);
			//NewItem = await itr1.Create(item2);
			var all = await itr1.GetAll();
				foreach (var i in all){ Console.WriteLine($"{ i.Id}|{ i.Price}|{i.Name}"); }
			var pks = await itr1.GetByPk(2);
			Console.WriteLine($"primary key{pks.Id}|{ pks.Price}|{pks.Name}");

			#endregion

			#region
			//customer test. the update statement didnt work well

			//var Tyler3 = new Customer
			//{
			//	Code = "Taj3",
			//	Name = "Tyler",
			//	IsNational = false,
			//	Sales = 10000,
			//	Created = DateTime.Now
			//};

			//var Tyler2 = new Customer
			//{
			//	Code = "Taj2",
			//	Name = "Tyler2",
			//	IsNational = false,
			//	Sales = 10000,
			//	Created = DateTime.Now
			//};
			//var TylerNew = await cstr1.Create(Tyler3);
			//TylerNew = await cstr1.Create(Tyler2);

			//var customers = await cstr1.GetAll();
			//foreach (var c in customers)
			//{
			//	Console.WriteLine($"{c.Id}|{c.Name}|{c.Code}| {c.Sales}");

			//}

			//var sm = await cstr1.GetByPk(1);
			//if (sm == null) { Console.WriteLine("notfound"); }
			//else { Console.WriteLine($"{sm.Name}|{sm.Code}"); }

			//var rTyler = await cstr1.Remove(1);

			//sm = await cstr1.GetByPk(1);

			//sm.Name = "Tylernew";
			//sm= await cstr1.Change(sm);
			//sm = await cstr1.GetByPk(1);
			#endregion
		}
	}
}

