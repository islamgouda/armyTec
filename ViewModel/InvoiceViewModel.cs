using armyTec.Models;
namespace armyTec.ViewModel
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public DateTime Invoicedate { get; set; }
        public virtual List<InvoiceDetail> InvoiceDetails { get; set; }
        public double total { get; set; }
        public string cahserName { get; set; }
        public string BranchName { get; set; }
    }
}
