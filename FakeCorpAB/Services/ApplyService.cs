using FakeCorpAB.Data;
using FakeCorpAB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace FakeCorpAB.Services
{
    public class ApplyService : IApplyService
    {
        private readonly ApplicationDbContext context;

        public ApplyService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<bool> AddItemAsync(VacationViewModel model, VacationList newItem)
        {
            var vacayid = context.Vacations
                .Where(x => x.VacationType == model.VacationType)
                .SingleOrDefault();
            
            var empid = await context.Employees
                .Where(x => x.FirstName == model.FirstName && x.LastName == model.LastName)
                .FirstOrDefaultAsync();

            newItem.Start = model.Start.Date;
            newItem.End = model.End.Date;
            newItem.ApplicationTime = DateTime.Now;
            newItem.FK_VacationId = vacayid.VacationId;
            newItem.FK_EmployeeId = empid.EmployeeId;
            newItem.Status = "Pending";
            context.Add(newItem);
            var saveResult = await context.SaveChangesAsync();
            return saveResult == 1;
        }
        //public async Task<bool> EditItemAsync(VacationList editItem)
        //{
            
        //    context.Update(editItem);
        //    var saveResult = await context.SaveChangesAsync();
        //    return saveResult == 1;
        //}
        
    }
}
