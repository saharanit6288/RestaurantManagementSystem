using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Models
{
    public class TableViewModel
    {
        public int TableId { get; set; }

        [DisplayName("Location")]
        public string Location { get; set; }

        [DisplayName("No. of Sits")]
        public int Sits { get; set; }

        [DisplayName("Reserve Date")]
        public DateTime ReserveDate { get; set; }
    }
}
