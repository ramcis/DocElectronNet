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
    public class PatientsController : Controller
    {
        private readonly DocDbContext _context;

        public PatientsController(DocDbContext context)
        {
            _context = context;
        }

        [HttpGet("/api/patients")]
        public JsonResult LoadData()
        {
            var patientsContext = _context.Patient.Select(x => new {
                patientId = x.id_patient,
                firstname = x.prenom_patient,
                lastname = x.nom_patient,
                fathername = x.pere_patient,
                birthdate = x.date_naissance.ToShortDateString(),
                file = x.fiche_patient,
                phone = x.tel_patient,

            }).ToList();
            return Json(patientsContext);
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var patients = await _context.Patient
                .FirstOrDefaultAsync(m => m.id_patient == id);
            if (patients == null)
            {
                return NotFound();
            }

 
            return View(patients);
        }


        public IActionResult Create()
        {
            int count;
            int i = 1;
            string dte = DateTime.Now.Year.ToString();
            string strdte = dte.Substring(2);
            var matches = (from m in _context.Patient
                           where m.fiche_patient.Contains(strdte)
                           select new
                           {
                               ficheNo = m.fiche_patient.Trim()
                           }).Count();
            string mtc = matches.ToString().Trim('"', '{', '=', '"', '}').Replace("ficheNo", "").Replace("=", "").TrimStart();

            count = int.Parse(mtc) + (i++);
            ViewBag.FileNo = (count) + "/" + strdte;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_patient,nom_patient,prenom_patient,pere_patient,tel_patient,fiche_patient,date_naissance")] Patients patients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patients);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patient.FindAsync(id);
            if (patients == null)
            {
                return NotFound();
            }
            return View(patients);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_patient,nom_patient,prenom_patient,pere_patient,tel_patient,fiche_patient,date_naissance")] Patients patients)
        {
            if (id != patients.id_patient)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientsExists(patients.id_patient))
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
            return View(patients);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patient
                .FirstOrDefaultAsync(m => m.id_patient == id);
            if (patients == null)
            {
                return NotFound();
            }

            return View(patients);
        }
        public async Task<IActionResult> DeletePatient(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patient
                .FirstOrDefaultAsync(m => m.id_patient == id);
            if (patients == null)
            {
                return NotFound();
            }
            _context.Patient.Remove(patients); await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patients = await _context.Patient.FindAsync(id);
            _context.Patient.Remove(patients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientsExists(int id)
        {
            return _context.Patient.Any(e => e.id_patient == id);
        }
    }
}
