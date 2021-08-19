using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_SI_Registro_Hotelero.Cammon;
using Proyecto_SI_Registro_Hotelero.Data;
using Proyecto_SI_Registro_Hotelero.Models;

namespace Proyecto_SI_Registro_Hotelero.Controllers
{
    public class ReservaHabitacionsController : Controller
    {
        private readonly PRHoteleroDbContext _context;
        private readonly int RecordsPerPage = 5;

        private Pagination<ReservaHabitacion> PaginationReservaHabitacion;
        public ReservaHabitacionsController(PRHoteleroDbContext context)
        {
            _context = context;
        }

        // GET: ReservaHabitacions
        public async Task<IActionResult> Index(string search, int page = 1)
        {
            int totalRecords = 0;

            if (search == null)
            {
                search = "";
                //var applicationDbContext = _context.ReservaHabitaciones.Include(r => r.Habitacion);
                //return View(await applicationDbContext.ToListAsync());
            }

            //Obtener los registros totales 
            totalRecords = await _context.ReservaHabitaciones.Include(a => a.Habitacion).CountAsync(
                    d => d.ReservaNombre.Contains(search));

            //Obtener la pagina de registros(datos)
            var reservahabi = await _context.ReservaHabitaciones.Include(a => a.Habitacion)
                .Where(d => d.ReservaNombre.Contains(search) ).ToListAsync();

            var reservahabiResult = reservahabi.OrderBy(o => o.ReservaNombre )
                .Skip((page - 1) * RecordsPerPage)
                .Take(RecordsPerPage);

            //Obtener el total de paginas
            var totalPage = (int)Math.Ceiling((double)totalRecords / RecordsPerPage);

            //Instanciar la clase de paginacion
            PaginationReservaHabitacion = new Pagination<ReservaHabitacion>()
            {
                RecordsPerPage = this.RecordsPerPage,
                TotalRecords = totalRecords,
                TotalPage = totalPage,
                CurrentPage = page,
                Search = search,
                Result = reservahabiResult
            };
            return View(PaginationReservaHabitacion);

            //return View(await _context.ReservaHabitaciones.Where
            //     (h => h.ReservaNombre.Contains(search)).ToListAsync());
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
        public async Task<IActionResult> Create(string start,[Bind("ReservaHId,ReservaNombre,ReservaApellido,FechaIngreso,FechasSalida,ClienteId,HabitacionId")] ReservaHabitacion reservaHabitacion)
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
