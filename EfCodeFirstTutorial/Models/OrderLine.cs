using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCodeFirstTutorial.Models
{
	public class OrderLine
	{
		public int Id { get; set; }
		[StringLength(30), Required]
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }
		public int ItemId { get; set; }
		public virtual Item Item { get; set; }
		public int Quantity { get; set; }


		public OrderLine()
		{

		}
	}
}
