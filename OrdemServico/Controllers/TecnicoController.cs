using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrdemServico.Models;

namespace OrdemServico.Controllers
{
    public class TecnicoController : Controller
    {
        private readonly DBSenaiTechContext _context;

        public TecnicoController(DBSenaiTechContext context)
        {
            _context = context;
        }

        // GET: Tecnico
        public async Task<IActionResult> Index()
        {
              return _context.Tecnicos != null ? 
                          View(await _context.Tecnicos.ToListAsync()) :
                          Problem("Entity set 'DBSenaiTechContext.Tecnicos'  is null.");
        }

        // GET: Tecnico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tecnicos == null)
            {
                return NotFound();
            }

            var tecnico = await _context.Tecnicos
                .FirstOrDefaultAsync(m => m.IdTecnico == id);
            if (tecnico == null)
            {
                return NotFound();
            }

            return View(tecnico);
        }

        // GET: Tecnico/Create
        public IActionResult Create()
        {
            var tecnicos = new List<SelectListItem>
        {
            new SelectListItem { Value = "Arthur Dias", Text = "Arthur Dias" },
            new SelectListItem { Value = "Helen Silva", Text = "Helen Silva" },
            new SelectListItem { Value = "Leandro Amaral", Text = "Leandro Amaral" },
            new SelectListItem { Value = "Vinícius Bonfim", Text = "Vinícius Bonfim" },
            new SelectListItem { Value = "Wallace Oliveira", Text = "Wallace Oliveira" }
        };

            ViewBag.Tecnicos = tecnicos;

            return View();
        }

        // POST: Tecnico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTecnico,NomeTecnico")] Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tecnico);
        }

        // GET: Tecnico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tecnicos == null)
            {
                return NotFound();
            }

            var tecnico = await _context.Tecnicos.FindAsync(id);
            if (tecnico == null)
            {
                return NotFound();
            }
            return View(tecnico);
        }

        // POST: Tecnico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTecnico,NomeTecnico")] Tecnico tecnico)
        {
            if (id != tecnico.IdTecnico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnicoExists(tecnico.IdTecnico))
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
            return View(tecnico);
        }

        // GET: Tecnico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tecnicos == null)
            {
                return NotFound();
            }

            var tecnico = await _context.Tecnicos
                .FirstOrDefaultAsync(m => m.IdTecnico == id);
            if (tecnico == null)
            {
                return NotFound();
            }

            return View(tecnico);
        }

        // POST: Tecnico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tecnicos == null)
            {
                return Problem("Entity set 'DBSenaiTechContext.Tecnicos'  is null.");
            }
            var tecnico = await _context.Tecnicos.FindAsync(id);
            if (tecnico != null)
            {
                _context.Tecnicos.Remove(tecnico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicoExists(int id)
        {
          return (_context.Tecnicos?.Any(e => e.IdTecnico == id)).GetValueOrDefault();
        }
    }
}
