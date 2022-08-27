using System.ComponentModel.DataAnnotations;

namespace armyTec.ViewModel
{
    public class invoiceHeaderVM
    {
       // [Required]
        
        public string CustomerName { get; set; } = null!;
        [Required]
        public DateTime Invoicedate { get; set; }
       // [Required]
        public int? CashierId { get; set; }
       // [Required]
        public int BranchId { get; set; }
       public ICollection<invItem> invItem { get; set; }

        //      public Dictionary<string, string> ItemName { get; set; }
        //    public Dictionary<string, string> ItemCount { get; set; }
        //  public Dictionary<string, string> ItemPrice { get; set; }
    }
}
