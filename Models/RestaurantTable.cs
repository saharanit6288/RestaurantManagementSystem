using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models
{
    public class RestaurantTable
    {
		[Key]
		public int TableId { get; set; }

		[Required(ErrorMessage = "This field is required.")]
		[DisplayName("Location")]
		public string Location { get; set; }

		[Required(ErrorMessage = "This field is required.")]
		[DisplayName("No. of Sits")]
		public int Sits { get; set; }

		
	}
}
