using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FakeCorpAB.Models
{
    public class VacationViewModel
    {
        public int VacationListId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public int FK_EmployeeId { get; set; }
        public int FK_VacationId { get; set; }
        [DisplayName("Vacation Type")]
        public string VacationType { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Status { get; set; }
        [DisplayName("Application Time")]
        public DateTime ApplicationTime { get; set; }
    }
}
