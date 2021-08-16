using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_SI_Registro_Hotelero.Data;
using Proyecto_SI_Registro_Hotelero.Models;

namespace Proyecto_SI_Registro_Hotelero.Controllers
{
    public class ReservaHabitacionsController : Controller
    {
        private readonly PRHoteleroDbContext _context;

        public ReservaHabitacionsController(PRHoteleroDbContext context)
        {
            _context = context;
        }

        // GET: ReservaHabitacions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ReservaHabitaciones.Include(r => r.Habitacion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReservaHabitacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaHabitacion = await _context.ReservaHabitaciones
                .Include(r => r.Habitacion)
                .FirstOrDefaultAsync(m => m.ReservaHId == id);
            if (reservaHabitacion == null)
            {
                return NotFound(); 
            }

            return View(reservaHabitacion);
        }

        // GET: ReservaHabitacions/Create
        public IActionResult Create()
        {
            ViewData["HabitacionId"] = new SelectList(_context.Habitaciones, "HabitacionId", "HabitacionNumero");
            return View();
        }

        // POST: ReservaHabitacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservaHId,ReservaNombre,ReservaApellido,FechaIngreso,FechasSalida,ClienteId,HabitacionId")] ReservaHabitacion reservaHabitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaHabitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HabitacionId"] = new SelectList(_context.Habitaciones, "HabitacionId", "HabitacionNumero", reservaHabitacion.HabitacionId);
            return View(reservaHabitacion);
        }

        // GET: ReservaHabitacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaHabitacion = await _context.ReservaHabitaciones.FindAsync(id);
            if (reservaHabitacion == null)
            {
                return NotFound();
            }
            ViewData["HabitacionId"] = new SelectList(_context.Habitaciones, "HabitacionId", "HabitacionNumero", reservaHabitacion.HabitacionId);
            return View(reservaHabitacion);
        }

        // POST: ReservaHabitacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaHId,ReservaNombre,ReservaApellido,FechaIngreso,FechasSalida,ClienteId,HabitacionId")] ReservaHabitacion reservaHabitacion)
        {
            if (id != reservaHabitacion.ReservaHId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaHabitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaHabitacionExists(reservaHabitacion.ReservaHId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HabitacionId"] = new SelectList(_context.Habitaciones, "HabitacionId", "HabitacionNumero", reservaHabitacion.HabitacionId);
            return View(reservaHabitacion);
        }

        // GET: ReservaHabitacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaHabitacion = await _context.ReservaHabitaciones
                .Include(r => r.Habitacion)
                .FirstOrDefaultAsync(m => m.ReservaHId == id);
            if (reservaHabitacion == null)
            {
                return NotFound();
            }

            return View(reservaHabitacion);
        }

        // POST: ReservaHabitacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaHabitacion = await _context.ReservaHabitaciones.FindAsync(id);
            _context.ReservaHabitaciones.Remove(reservaHabitacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaHabitacionExists(int id)
        {
            return _context.ReservaHabitaciones.Any(e => e.ReservaHId == id);
        }
    }
}
