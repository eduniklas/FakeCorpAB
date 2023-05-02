using FakeCorpAB.Models;

namespace FakeCorpAB.Services
{
    public interface IApplyService
    {
        Task<bool> AddItemAsync(VacationViewModel model, VacationList newItem);
        //Task<bool> EditItemAsync(VacationList editItem);
    }
}
