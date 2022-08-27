namespace armyTec.ViewModel
{
    public class InHeaderVM
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public DateTime Invoicedate { get; set; }
        public int? CashierId { get; set; }
        public int BranchId { get; set; }
    }
}
