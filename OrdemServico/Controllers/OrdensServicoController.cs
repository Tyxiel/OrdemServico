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
    public class OrdensServicoController : Controller
    {
        private readonly DBSenaiTechContext _context;

        public OrdensServicoController(DBSenaiTechContext context)
        {
            _context = context;
        }

        // GET: OrdensServico
        public async Task<IActionResult> Index()
        {
            var dBSenaiTechContext = _context.OrdensServicos.Include(o => o.IdClienteNavigation).Include(o => o.IdDefeitoNavigation).Include(o => o.IdEquipamentoNavigation).Include(o => o.IdTecnicoNavigation);
            return View(await dBSenaiTechContext.ToListAsync());
        }

        // GET: OrdensServico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdensServicos == null)
            {
                return NotFound();
            }

            var ordensServico = await _context.OrdensServicos
                .Include(o => o.IdClienteNavigation)
                .Include(o => o.IdDefeitoNavigation)
                .Include(o => o.IdEquipamentoNavigation)
                .Include(o => o.IdTecnicoNavigation)
                .FirstOrDefaultAsync(m => m.IdOrdemServico == id);
            if (ordensServico == null)
            {
                return NotFound();
            }

            return View(ordensServico);
        }

        // GET: OrdensServico/Create
        // GET: OrdensServico/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "NomeCliente");
            ViewData["IdEquipamento"] = new SelectList(_context.Equipamentos, "IdEquipamento", "NomeEquipamento");

            var defeitoEnum = Enum.GetValues(typeof(DefeitoEnum));
            var defeitoList = new List<SelectListItem>();
            foreach (var value in defeitoEnum)
            {
                defeitoList.Add(new SelectListItem { Value = ((int)value).ToString(), Text = value.ToString() });
            }
            ViewData["IdDefeito"] = new SelectList(defeitoList, "Value", "Text");

            var tecnicoEnum = Enum.GetValues(typeof(Tecnico.TecnicoEnum));
            var tecnicoList = new List<SelectListItem>();
            foreach (var value in tecnicoEnum)
            {
                tecnicoList.Add(new SelectListItem { Value = ((int)value).ToString(), Text = value.ToString() });
            }
            ViewData["IdTecnico"] = new SelectList(tecnicoList, "Value", "Text");

            return View();
        }

        // POST: OrdensServico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrdemServico,DataOrdemServico,Servico,ValorTotal,StatusServico,IdEquipamento,IdCliente,IdDefeito,IdTecnico")] OrdensServico ordensServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordensServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "NomeCliente", ordensServico.IdCliente);
            ViewData["IdDefeito"] = new SelectList(_context.Defeitos, "IdDefeito", "Descricao", ordensServico.IdDefeito);
            ViewData["IdEquipamento"] = new SelectList(_context.Equipamentos, "IdEquipamento", "NomeEquipamento", ordensServico.IdEquipamento);
            ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "IdTecnico", "NomeTecnico", ordensServico.IdTecnico);
            return View(ordensServico);
        }

        // GET: OrdensServico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdensServicos == null)
            {
                return NotFound();
            }

            var ordensServico = await _context.OrdensServicos.FindAsync(id);
            if (ordensServico == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "NomeCliente", ordensServico.IdCliente);
            ViewData["IdEquipamento"] = new SelectList(_context.Equipamentos, "IdEquipamento", "NomeEquipamento", ordensServico.IdEquipamento);

            var defeitoEnum = Enum.GetValues(typeof(DefeitoEnum));
            var defeitoList = new List<SelectListItem>();
            foreach (var value in defeitoEnum)
            {
                defeitoList.Add(new SelectListItem { Value = ((int)value).ToString(), Text = value.ToString() });
            }
            ViewData["IdDefeito"] = new SelectList(defeitoList, "Value", "Text", ordensServico.IdDefeito.ToString());

            var tecnicoEnum = Enum.GetValues(typeof(Tecnico.TecnicoEnum));
            var tecnicoList = new List<SelectListItem>();
            foreach (var value in tecnicoEnum)
            {
                tecnicoList.Add(new SelectListItem { Value = ((int)value).ToString(), Text = value.ToString() });
            }
            ViewData["IdTecnico"] = new SelectList(tecnicoList, "Value", "Text", ordensServico.IdTecnico.ToString());

            return View(ordensServico);
        }

        // POST: OrdensServico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrdemServico,DataOrdemServico,Servico,ValorTotal,StatusServico,IdEquipamento,IdCliente,IdDefeito,IdTecnico")] OrdensServico ordensServico)
        {
            if (id != ordensServico.IdOrdemServico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordensServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdensServicoExists(ordensServico.IdOrdemServico))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "NomeCliente", ordensServico.IdCliente);
            ViewData["IdDefeito"] = new SelectList(_context.Defeitos, "IdDefeito", "Descricao", ordensServico.IdDefeito);
            ViewData["IdEquipamento"] = new SelectList(_context.Equipamentos, "IdEquipamento", "NomeEquipamento", ordensServico.IdEquipamento);
            ViewData["IdTecnico"] = new SelectList(_context.Tecnicos, "IdTecnico", "NomeTecnico", ordensServico.IdTecnico);
            return View(ordensServico);
        }

        // GET: OrdensServico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdensServicos == null)
            {
                return NotFound();
            }

            var ordensServico = await _context.OrdensServicos
                .Include(o => o.IdClienteNavigation)
                .Include(o => o.IdDefeitoNavigation)
                .Include(o => o.IdEquipamentoNavigation)
                .Include(o => o.IdTecnicoNavigation)
                .FirstOrDefaultAsync(m => m.IdOrdemServico == id);
            if (ordensServico == null)
            {
                return NotFound();
            }

            return View(ordensServico);
        }

        // POST: OrdensServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdensServicos == null)
            {
                return Problem("Entity set 'DBSenaiTechContext.OrdensServicos'  is null.");
            }
            var ordensServico = await _context.OrdensServicos.FindAsync(id);
            if (ordensServico != null)
            {
                _context.OrdensServicos.Remove(ordensServico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdensServicoExists(int id)
        {
          return (_context.OrdensServicos?.Any(e => e.IdOrdemServico == id)).GetValueOrDefault();
        }
    }
}
