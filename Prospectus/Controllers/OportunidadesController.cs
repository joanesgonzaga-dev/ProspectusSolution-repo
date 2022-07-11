using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prospectus.Data;
using Prospectus.Models;

namespace Prospectus.Controllers
{
    public class OportunidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OportunidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Oportunidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Oportunidades.ToListAsync());
        }

        // GET: Oportunidades/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oportunidade = await _context.Oportunidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oportunidade == null)
            {
                return NotFound();
            }

            return View(oportunidade);
        }

        // GET: Oportunidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oportunidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao")] Oportunidade oportunidade)
        {
            if (ModelState.IsValid)
            {
                oportunidade.Id = Guid.NewGuid();
                _context.Add(oportunidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oportunidade);
        }

        // GET: Oportunidades/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oportunidade = await _context.Oportunidades.FindAsync(id);
            if (oportunidade == null)
            {
                return NotFound();
            }
            return View(oportunidade);
        }

        // POST: Oportunidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Descricao")] Oportunidade oportunidade)
        {
            if (id != oportunidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oportunidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OportunidadeExists(oportunidade.Id))
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
            return View(oportunidade);
        }

        // GET: Oportunidades/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oportunidade = await _context.Oportunidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oportunidade == null)
            {
                return NotFound();
            }

            return View(oportunidade);
        }

        // POST: Oportunidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var oportunidade = await _context.Oportunidades.FindAsync(id);
            _context.Oportunidades.Remove(oportunidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OportunidadeExists(Guid id)
        {
            return _context.Oportunidades.Any(e => e.Id == id);
        }
    }
}
