using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Amarinfinancial.Models;

namespace Amarinfinancial.Controllers
{
    public class FinanceController : Controller
    {
        private readonly FinanceContext _context;

        public FinanceController(FinanceContext context)
        {
            _context = context;
        }

        // GET: Finance
        public async Task<IActionResult> Index()
        {
            return View(await _context.Finances.ToListAsync());
        }

        //// GET: Finance/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var finance = await _context.Finances
        //        .FirstOrDefaultAsync(m => m.MembersID == id);
        //    if (finance == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(finance);
        //}

        // GET: Finance/Create
        public IActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new Finance());
            else
                return View(_context.Finances.Find(id));
        }

        // POST: Finance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("MembersID,Members,groups,transactions")] Finance finance)
        {
           
                if (ModelState.IsValid)
                {
                    if (finance.MembersID == 0)
                        _context.Add(finance);
                    else
                        _context.Update(finance);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(finance);
        }
        

        // GET: Finance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finance = await _context.Finances.FindAsync(id);
            if (finance == null)
            {
                return NotFound();
            }
            return View(finance);
        }

        // POST: Finance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
     //   [HttpPost]
      //  [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("MembersID,Members,groups,transactions")] Finance finance)
        //{
        //    if (id != finance.MembersID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(finance);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FinanceExists(finance.MembersID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(finance);
        //}

        // GET: Finance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var finance =await _context.Finances.FindAsync(id);
            _context.Finances.Remove(finance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var finance = await _context.Finances
            //    .FirstOrDefaultAsync(m => m.MembersID == id);
            //if (finance == null)
            //{
            //    return NotFound();
            //}

            //return View(finance);
        }
    }
}

//        // POST: Finance/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var finance = await _context.Finances.FindAsync(id);
//            _context.Finances.Remove(finance);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool FinanceExists(int id)
//        {
//            return _context.Finances.Any(e => e.MembersID == id);
//        }
//    }
//}
