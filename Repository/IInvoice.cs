using armyTec.Models;
namespace armyTec.Repository
{
    public interface IInvoice
    {
        public List<InvoiceDetail> InvoiceDetails(int headerID);
        public InvoiceDetail GetInvoiceDetail(int invoiceID);
        public void AddInvoiceDetail(InvoiceDetail invoiceDetail);
        public void DeleteInvoiceDetail(int invoiceID);
        public void UpdateInvoiceDetail(int id, InvoiceDetail invoiceDetail);
        public InvoiceHeader GetInvoiceHeader(int invoiceID);
        public List<InvoiceHeader> GetAllInvoiceHeader();
        public void addInvoiceHeader(InvoiceHeader invoiceHeader);
        public int addInvoiceHeaderAndGetId(InvoiceHeader invoiceHeader);
        public void deleteInvoiceHeader(int invoiceID);
        public void updateInvoiceHeader(int invoiceID, InvoiceHeader invoiceHeader);
        
    }
}
