using System.ComponentModel.DataAnnotations;

namespace armyTec.ViewModel
{
    public class updateCacherVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        
        public string CashierName { get; set; } = null!;
        [Required]
        
        public int BranchId { get; set; }
    }
}
