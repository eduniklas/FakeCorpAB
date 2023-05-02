using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FakeCorpAB.Models
{
    public class VacationList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VacationListId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime ApplicationTime { get; set; }
        [ForeignKey("Employees")]
        [DisplayName("Employee")]
        public int FK_EmployeeId { get; set; }
        public virtual Employee Employees { get; set; } //Navigering
        [ForeignKey("Vacations")]
        [DisplayName("Vacation Type")]
        public int FK_VacationId { get; set; }
        public string Status { get; set; }
        public virtual Vacation Vacations { get; set; } //Navigering
    }
}
