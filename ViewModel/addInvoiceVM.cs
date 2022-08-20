using System.ComponentModel.DataAnnotations;

namespace armyTec.ViewModel
{
    public class addInvoiceVM
    {
        public int headerId { get; set; }
        [Required]
        public string ItemName { get; set; } = null!;
        [Required]
        public double ItemCount { get; set; }
        [Required]
        
        public double ItemPrice { get; set; }
    }
}
