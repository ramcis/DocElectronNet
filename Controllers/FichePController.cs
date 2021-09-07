using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VarDoc;
using VarDoc.Models;

namespace VarDoc.Controllers
{
    public class FichePController : Controller
    {
        private readonly DocDbContext _context;

        public FichePController(DocDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult GetData(int id, int carte)
        {
            var data = (from pat in _context.Patient.ToList()
                        where pat.id_patient.Equals(id)
                        select pat.fiche_patient);
            //ViewBag.FileNo = data.ToString();
            return Json(new { success = true, data });
        }

        [HttpGet("/api/filep")]
        public JsonResult LoadData()
        {
            var files = _context.FichePs.Include(f => f.Patients).Select(x => new {
                fileId = x.id_fiche,
/*                job = x.job,
                anticedent = x.anticedent,
                anticedent_churgical = x.anticedent_churgical,
                anticedent_medical = x.anticedent_medical,*/
                ficheNo = x.ficheNo,
                id_patient = x.id_patient

            }).ToList();
            return Json(files);
        }
        // GET: FicheP
        public async Task<IActionResult> Index()
        {
            var docDbContext = _context.FichePs.Include(f => f.Patients);
            return View(await docDbContext.ToListAsync());
        //    return View();
        }

        // GET: FicheP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ficheP = await _context.FichePs
                .Include(f => f.Patients)
                .FirstOrDefaultAsync(m => m.id_fiche == id);
            if (ficheP == null)
            {
                return NotFound();
            }

            return View(ficheP);
        }

        // GET: FicheP/Create

        public IActionResult Create(int id)
        {
            var ficheP =  _context.Patient
                  .FirstOrDefault(m => m.id_patient == id);
            ViewData["id_patient"] = new SelectList(_context.Patient, "id_patient", "fiche_patient");
            return View(ficheP);
        }

        // POST: FicheP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_fiche,job,anticedent,anticedent_churgical,anticedent_medical,ficheNo,id_patient")] FicheP ficheP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ficheP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_patient"] = new SelectList(_context.Patient, "id_patient", "fiche_patient", ficheP.id_patient);
            return View(ficheP);
        }

        // GET: FicheP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ficheP = await _context.FichePs.FindAsync(id);
            if (ficheP == null)
            {
                return NotFound();
            }
            ViewData["id_patient"] = new SelectList(_context.Patient, "id_patient", "fiche_patient", ficheP.id_patient);
            return View(ficheP);
        }

        // POST: FicheP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_fiche,job,anticedent,anticedent_churgical,anticedent_medical,ficheNo,id_patient")] FicheP ficheP)
        {
            if (id != ficheP.id_fiche)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ficheP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FichePExists(ficheP.id_fiche))
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
            ViewData["id_patient"] = new SelectList(_context.Patient, "id_patient", "fiche_patient", ficheP.id_patient);
            return View(ficheP);
        }

        // GET: FicheP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ficheP = await _context.FichePs
                .Include(f => f.Patients)
                .FirstOrDefaultAsync(m => m.id_fiche == id);
            if (ficheP == null)
            {
                return NotFound();
            }

            return View(ficheP);
        }

        // POST: FicheP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ficheP = await _context.FichePs.FindAsync(id);
            _context.FichePs.Remove(ficheP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FichePExists(int id)
        {
            return _context.FichePs.Any(e => e.id_fiche == id);
        }
    }
}
