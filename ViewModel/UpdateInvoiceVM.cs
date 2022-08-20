namespace armyTec.ViewModel
{
    public class UpdateInvoiceVM
    {
        public int Id { get; set; }
       
        public string ItemName { get; set; } = null!;
        public double ItemCount { get; set; }
        public double ItemPrice { get; set; }
    }
}
