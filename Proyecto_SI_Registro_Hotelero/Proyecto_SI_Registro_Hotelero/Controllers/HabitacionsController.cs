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
    public class HabitacionsController : Controller
    {
        private readonly PRHoteleroDbContext _context;
        private readonly int RecordsPerPage = 5;
      
        private Pagination<Habitacion> PaginationHabitacion;

        public HabitacionsController(PRHoteleroDbContext context)
        {
            _context = context;
        }

        // GET: Habitacions
        public async Task<IActionResult> Index(string search,int page = 1)
        {
            int totalRecords = 0;

            if (search == null)
            {
                search = "";
                //var applicationDbContext = _context.Habitaciones.Include(h => h.EstadoHabitacion).Include(h => h.PisoHabitacion).Include(h => h.TipoHabitacion);
                //return View(await applicationDbContext.ToListAsync());
            }
            //Obtener los registros totales 
            totalRecords = await _context.Habitaciones.Include(a => a.TipoHabitacion).Include(a => a.PisoHabitacion).Include(a => a.EstadoHabitacion).CountAsync(
                    d => d.HabitacionDescripcion.Contains(search));

            //Obtener la pagina de registros(datos)
            var habi= await _context.Habitaciones.Include(a => a.TipoHabitacion).Include(a => a.PisoHabitacion).Include(a => a.EstadoHabitacion)
                .Where(d => d.HabitacionDescripcion.Contains(search)).ToListAsync();

            var habiResult = habi.OrderBy(o => o.HabitacionDescripcion)
                .Skip((page - 1) * RecordsPerPage)
                .Take(RecordsPerPage);

            //Obtener el total de paginas
            var totalPage = (int)Math.Ceiling((double)totalRecords / RecordsPerPage);

            //Instanciar la clase de paginacion
            PaginationHabitacion = new Pagination<Habitacion>()
            {
                RecordsPerPage = this.RecordsPerPage,
                TotalRecords = totalRecords,
                TotalPage = totalPage,
                CurrentPage = page,
                Search = search,
                Result = habiResult
            };
            return View(PaginationHabitacion);

            //return View(await _context.Habitaciones.Where
            //    (h => h.HabitacionDescripcion.Contains(search)).ToListAsync());
        }

        // GET: Habitacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitaciones
                .Include(h => h.EstadoHabitacion)
                .Include(h => h.PisoHabitacion)
                .Include(h => h.TipoHabitacion)
                .FirstOrDefaultAsync(m => m.HabitacionId == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // GET: Habitacions/Create
        public IActionResult Create()
        {
            ViewData["EstadoHId"] = new SelectList(_context.EstadoHabitaciones, "EstadoHId", "Estado");
            ViewData["PisoHId"] = new SelectList(_context.PisoHabitaciones, "PisoHId", "Piso");
            ViewData["TipoHId"] = new SelectList(_context.TipoHabitaciones, "TipoHId", "TipoDescripcion");
            return View();
        }

        // POST: Habitacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HabitacionId,HabitacionNumero,HabitacionDescripcion,HabitacionPrecio,TipoHId,PisoHId,EstadoHId")] Habitacion habitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoHId"] = new SelectList(_context.EstadoHabitaciones, "EstadoHId", "Estado", habitacion.EstadoHId);
            ViewData["PisoHId"] = new SelectList(_context.PisoHabitaciones, "PisoHId", "Piso", habitacion.PisoHId);
            ViewData["TipoHId"] = new SelectList(_context.TipoHabitaciones, "TipoHId", "TipoDescripcion", habitacion.TipoHId);
            return View(habitacion);
        }

        // GET: Habitacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitaciones.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            ViewData["EstadoHId"] = new SelectList(_context.EstadoHabitaciones, "EstadoHId", "Estado", habitacion.EstadoHId);
            ViewData["PisoHId"] = new SelectList(_context.PisoHabitaciones, "PisoHId", "Piso", habitacion.PisoHId);
            ViewData["TipoHId"] = new SelectList(_context.TipoHabitaciones, "TipoHId", "TipoDescripcion", habitacion.TipoHId);
            return View(habitacion);
        }

        // POST: Habitacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HabitacionId,HabitacionNumero,HabitacionDescripcion,HabitacionPrecio,TipoHId,PisoHId,EstadoHId")] Habitacion habitacion)
        {
            if (id != habitacion.HabitacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionExists(habitacion.HabitacionId))
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
            ViewData["EstadoHId"] = new SelectList(_context.EstadoHabitaciones, "EstadoHId", "Estado", habitacion.EstadoHId);
            ViewData["PisoHId"] = new SelectList(_context.PisoHabitaciones, "PisoHId", "Piso", habitacion.PisoHId);
            ViewData["TipoHId"] = new SelectList(_context.TipoHabitaciones, "TipoHId", "TipoDescripcion", habitacion.TipoHId);
            return View(habitacion);
        }

        // GET: Habitacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitaciones
                .Include(h => h.EstadoHabitacion)
                .Include(h => h.PisoHabitacion)
                .Include(h => h.TipoHabitacion)
                .FirstOrDefaultAsync(m => m.HabitacionId == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // POST: Habitacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habitacion = await _context.Habitaciones.FindAsync(id);
            _context.Habitaciones.Remove(habitacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacionExists(int id)
        {
            return _context.Habitaciones.Any(e => e.HabitacionId == id);
        }
    }
}
