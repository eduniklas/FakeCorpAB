using Microsoft.AspNetCore;
using FakeCorpAB.Data;
using FakeCorpAB.Models;
using FakeCorpAB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FakeCorpAB.Controllers
{
    public class VacationListController : Controller
    {
        private readonly IApplyService applyService;
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> usermanager;
        public VacationListController(IApplyService _applyService, ApplicationDbContext _context, UserManager<IdentityUser> _usermanager)
        {
            applyService = _applyService;
            context = _context;
            usermanager = _usermanager;
        }
        [Authorize]
        public async Task<IActionResult> Index(DateTime? fromDate, DateTime? toDate)
        {
            if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
            if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(31);
            if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
            ViewBag.fromDate = fromDate;
            ViewBag.toDate = toDate;
            List<VacationViewModel> list = new List<VacationViewModel>();
            var items = await (from emp in context.Employees
                               join vl in context.VacationLists on emp.EmployeeId equals vl.FK_EmployeeId
                               join v in context.Vacations on vl.FK_VacationId equals v.VacationId
                               where vl.Start >= fromDate & vl.End <= toDate
                               orderby vl.Start
                               select new
                               {
                                   vl.VacationListId,
                                   emp.EmployeeId,
                                   vl.Start,
                                   vl.End,
                                   v.VacationType,
                                   v.Description,
                                   emp.FirstName,
                                   emp.LastName,
                                   vl.ApplicationTime,
                                   vl.Status,
                               }).ToListAsync();
            // konverterar från anonym
            foreach (var item in items)
            {
                VacationViewModel listItem = new VacationViewModel();
                listItem.VacationListId = item.VacationListId;
                listItem.FK_EmployeeId = item.EmployeeId;
                listItem.Start = item.Start;
                listItem.End = item.End;
                listItem.VacationType = item.VacationType;
                listItem.Description = item.Description;
                listItem.FirstName = item.FirstName;
                listItem.LastName = item.LastName;
                listItem.ApplicationTime = item.ApplicationTime;
                listItem.Status = item.Status;
                list.Add(listItem);
            }
            
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VacationViewModel model, [Bind("Start,End,ApplicationTime,FirstName,LastName,VacationType")] VacationList newitem)
        {
            var currentuser = await usermanager.GetUserAsync(User);
            var successful = await applyService.AddItemAsync(model, newitem);
            if (!successful)
            {
                return BadRequest("Could not add vacation");
            }
            return currentuser == null ? RedirectToAction("Create") : (IActionResult)RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.VacationLists == null)
            {
                return NotFound();
            }

            var vacationApply = await context.VacationLists
                .FirstOrDefaultAsync(m => m.VacationListId == id);
            if (vacationApply == null)
            {
                return NotFound();
            }

            return View(vacationApply);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (context.VacationLists== null)
            {
                return Problem("Entity set 'ApplicationDbContext.VacationList'  is null.");
            }
            var vacationApply = await context.VacationLists.FindAsync(id);
            if (vacationApply != null)
            {
                context.VacationLists.Remove(vacationApply);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.VacationLists== null)
            {
                return NotFound();
            }

            var vacatiomApply = await context.VacationLists.FindAsync(id);
            if (vacatiomApply == null)
            {
                return NotFound();
            }
            return View(vacatiomApply);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacationListId,Start,End,ApplicationTime,FK_EmployeeId,FK_VacationId,Status")] VacationList vacationApply)
        {
            if (id != vacationApply.VacationListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(vacationApply);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationApplyExists(vacationApply.VacationListId))
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
            return View(vacationApply);
        }
        private bool VacationApplyExists(int id)
        {
            return (context.VacationLists?.Any(e => e.VacationListId == id)).GetValueOrDefault();
        }
    }
}
