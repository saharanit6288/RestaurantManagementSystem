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
    public class ReservationsController : Controller
    {
        private readonly RestaurantContext _context;

        public ReservationsController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            List<RestaurantTable> tables = _context.RestaurantTables.Select(s => s).ToList();
            ViewBag.Tables = tables;


            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,TableId,ReserveDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "RestaurantTables");
            }
            return View(reservation);
        }

        
    }
}
