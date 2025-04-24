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
    public class DefeitoController : Controller
    {
        private readonly DBSenaiTechContext _context;

        public DefeitoController(DBSenaiTechContext context)
        {
            _context = context;
        }

        // GET: Defeito
        public async Task<IActionResult> Index()
        {
              return _context.Defeitos != null ? 
                          View(await _context.Defeitos.ToListAsync()) :
                          Problem("Entity set 'DBSenaiTechContext.Defeitos'  is null.");
        }

        // GET: Defeito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Defeitos == null)
            {
                return NotFound();
            }

            var defeito = await _context.Defeitos
                .FirstOrDefaultAsync(m => m.IdDefeito == id);
            if (defeito == null)
            {
                return NotFound();
            }

            return View(defeito);
        }

        // GET: Defeito/Create
        public IActionResult Create()
        {
            var defeitos = Enum.GetValues(typeof(DefeitoEnum))
                .Cast<DefeitoEnum>()
                .Select(x => new SelectListItem
                {
                    Value = x.ToString(),
                    Text = x.ToString().Replace("NaoLiga", "Não liga")
                        .Replace("TelaAzul", "Tela azul")
                        .Replace("Superaquecimento", "Superaquecimento")
                        .Replace("SemConexaoComInternet", "Sem conexão com a internet")
                        .Replace("ErroAoInicializarOSistema", "Erro ao inicializar o sistema")
                })
                .ToList();

            ViewBag.Defeitos = defeitos;

            return View();
        }

        // POST: Defeito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDefeito,Descricao")] Defeito defeito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(defeito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(defeito);
        }

        // GET: Defeito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Defeitos == null)
            {
                return NotFound();
            }

            var defeito = await _context.Defeitos.FindAsync(id);
            if (defeito == null)
            {
                return NotFound();
            }
            return View(defeito);
        }

        // POST: Defeito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDefeito,Descricao")] Defeito defeito)
        {
            if (id != defeito.IdDefeito)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(defeito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DefeitoExists(defeito.IdDefeito))
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
            return View(defeito);
        }

        // GET: Defeito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Defeitos == null)
            {
                return NotFound();
            }

            var defeito = await _context.Defeitos
                .FirstOrDefaultAsync(m => m.IdDefeito == id);
            if (defeito == null)
            {
                return NotFound();
            }

            return View(defeito);
        }

        // POST: Defeito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Defeitos == null)
            {
                return Problem("Entity set 'DBSenaiTechContext.Defeitos'  is null.");
            }
            var defeito = await _context.Defeitos.FindAsync(id);
            if (defeito != null)
            {
                _context.Defeitos.Remove(defeito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DefeitoExists(int id)
        {
          return (_context.Defeitos?.Any(e => e.IdDefeito == id)).GetValueOrDefault();
        }
    }
}
