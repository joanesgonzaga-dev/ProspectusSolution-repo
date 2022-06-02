using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prospectus.Data;
using Prospectus.Models;

namespace Prospectus.Controllers
{
    [Authorize]
    public class ProspectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProspectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prospects
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Prospects.Include(p => p.Indicador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Prospects/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prospect = await _context.Prospects
                .Include(p=>p.Endereco)
                .Include(p => p.Indicador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prospect == null)
            {
                return NotFound();
            }

            return View(prospect);
        }

        // GET: Prospects/Create
        public IActionResult Create()
        {
            ViewData["IndicadorId"] = new SelectList(_context.Indicadores, "Id", "Nome");
            //ViewData["EnderecoId"] = new SelectList(_context.Indicadores, "Id", "Logradouro");
            return View();
        }

        // POST: Prospects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Prospect prospect)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prospect);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IndicadorId"] = new SelectList(_context.Indicadores, "Id", "Nome", prospect.IndicadorId);
            //ViewData["EnderecoId"] = new SelectList(_context.Indicadores, "Id", "Logradouro");
            return View(prospect);
        }

        // GET: Prospects/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prospect = await _context.Prospects.Include(p => p.Endereco).Where(p => p.Id == id).FirstAsync(); // FindAsync(id);
            //var prospect = await _context.Prospects.FindAsync(id);
            if (prospect == null)
            {
                return NotFound();
            }
            ViewData["IndicadorId"] = new SelectList(_context.Indicadores, "Id", "Nome", prospect.IndicadorId);
            return View(prospect);
        }

        // POST: Prospects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Prospect prospect)
        {
            if (id != prospect.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prospect);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProspectExists(prospect.Id))
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
            ViewData["IndicadorId"] = new SelectList(_context.Indicadores, "Id", "Nome", prospect.IndicadorId);
            return View(prospect);
        }

        // GET: Prospects/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prospect = await _context.Prospects
                .Include(p => p.Indicador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prospect == null)
            {
                return NotFound();
            }

            return View(prospect);
        }

        // POST: Prospects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var prospect = await _context.Prospects.FindAsync(id);
            _context.Prospects.Remove(prospect);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProspectExists(Guid id)
        {
            return _context.Prospects.Any(e => e.Id == id);
        }
    }
}
