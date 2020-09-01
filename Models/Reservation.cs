using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models
{
    public class Reservation
    {
		[Key]
		public int ReservationId { get; set; }

		[Required(ErrorMessage = "This field is required.")]
		[DisplayName("Table")]
		public int TableId { get; set; }

		[Required(ErrorMessage = "This field is required.")]
		[DataType(DataType.Date)]
		[DisplayName("Reserve Date")]
		public DateTime ReserveDate { get; set; }

		public virtual RestaurantTable RestaurantTable { get; set; }
	}
}
