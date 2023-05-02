using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FakeCorpAB.Models
{
    public class Vacation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VacationId { get; set; }
        [StringLength(50)]
        [DisplayName("Vacation")]
        public string VacationType { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(50)]
        public virtual ICollection<VacationList>? VacationLists { get; set; }
    }
}
