using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCodeFirstTutorial.Models
{
	public class Customer
	{
		public int Id { get; set; }	//primary key
		[StringLength(10), Required]
		public string Code { get; set; } // must be unique value
		[StringLength(50), Required]
		public string Name { get; set; }
		public bool IsNational { get; set; }	
		[Column(TypeName="decimal(9,2)")]
		public decimal Sales { get; set; }        //default set to zero
		public DateTime Created { get; set; }

		public Customer(){
		}
	}
}
