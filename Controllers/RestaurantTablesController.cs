using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Controllers
{
    public class RestaurantTablesController : Controller
    {
        private readonly RestaurantContext _context;

        public RestaurantTablesController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: RestaurantTables
        [HttpGet]
        public async Task<IActionResult> Index(int? Size, DateTime? FromDate, DateTime? EndDate)
        {
            IQueryable<TableViewModel> tables =  _context.RestaurantTables.Select(s => new TableViewModel
                                                    {
                                                        TableId = s.TableId,
                                                        Location = s.Location,
                                                        Sits = s.Sits
                                                    });

            if (Size.HasValue)
            {
                tables = tables.Where(s => s.Sits == Size);
            }
            if (FromDate.HasValue || EndDate.HasValue)
            {
                tables = tables
                            .Join(_context.Reservations,
                                    a => a.TableId,
                                    b => b.TableId,
                                    (p, q) => new { rt = p, res = q })
                            .Select(s => new TableViewModel
                            {
                                TableId = s.rt.TableId,
                                Location = s.rt.Location,
                                Sits = s.rt.Sits,
                                ReserveDate = s.res.ReserveDate
                            });

                if (FromDate.HasValue)
                {
                    tables = tables.Where(s => s.ReserveDate >= FromDate);
                }
                if (EndDate.HasValue)
                {
                    tables = tables.Where(s => s.ReserveDate <= EndDate);
                }
            }
            

            return View(await tables.ToListAsync());
        }

       
    }
}
