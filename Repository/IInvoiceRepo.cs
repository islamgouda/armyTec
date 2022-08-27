using armyTec.Models;

namespace armyTec.Repository
{
    public class IInvoiceRepo : IInvoice
    {
        private ArmyTechTaskContext context;
        public IInvoiceRepo(ArmyTechTaskContext _context)
        {
            this.context = _context;
        }
        public void AddInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            context.InvoiceDetails.Add(invoiceDetail);
            context.SaveChanges();
        }

        public void addInvoiceHeader(InvoiceHeader invoiceHeader)
        {
            context.InvoiceHeaders.Add(invoiceHeader);
            context.SaveChanges();
        }

        public int addInvoiceHeaderAndGetId(InvoiceHeader invoiceHeader)
        {
            context.InvoiceHeaders.Add(invoiceHeader);
            context.SaveChanges();
            return (int)invoiceHeader.Id;
        }

        public void DeleteInvoiceDetail(int invoiceID)
        {
        InvoiceDetail old= context.InvoiceDetails.FirstOrDefault(invoice => invoice.Id == invoiceID);
            context.InvoiceDetails.Remove(old);
            context.SaveChanges();
        }

        public void deleteInvoiceHeader(int invoiceID)
        {
            List<InvoiceDetail> invoiceDetails = this.InvoiceDetails(invoiceID);
            if (invoiceDetails != null) {
                foreach (InvoiceDetail item in invoiceDetails)
                {
                    this.DeleteInvoiceDetail((int)item.Id);
                }
            }
            
          InvoiceHeader old=  context.InvoiceHeaders.FirstOrDefault(head => head.Id == invoiceID);
            context.InvoiceHeaders.Remove(old);
            context.SaveChanges();
        }

        public List<InvoiceHeader> GetAllInvoiceHeader()
        {
           return context.InvoiceHeaders.ToList();
        }

        public InvoiceDetail GetInvoiceDetail(int invoiceID)
        {
            return context.InvoiceDetails.FirstOrDefault(invoice => invoice.Id == invoiceID);
        }

        public InvoiceHeader GetInvoiceHeader(int invoiceID)
        {
         return   context.InvoiceHeaders.FirstOrDefault(invoice => invoice.Id == invoiceID);
        }

        public List<InvoiceDetail> InvoiceDetails(int headerID)
        {
            return context.InvoiceDetails.Where(header=>header.InvoiceHeaderId == headerID).ToList();
        }

        public void UpdateInvoiceDetail(int id, InvoiceDetail invoiceDetail)
        {
          InvoiceDetail old=  context.InvoiceDetails.FirstOrDefault(invoice => invoice.Id == id);
            old.ItemName = invoiceDetail.ItemName;
            old.ItemPrice = invoiceDetail.ItemPrice;
            old.ItemCount = invoiceDetail.ItemCount;
            context.SaveChanges();
        }

        public void updateInvoiceHeader(int invoiceID, InvoiceHeader invoiceHeader)
        {
            InvoiceHeader old = context.InvoiceHeaders.FirstOrDefault(invc => invc.Id == invoiceID);
            old.CustomerName=invoiceHeader.CustomerName;
            
            old.BranchId = invoiceHeader.BranchId;
            old.CashierId = invoiceHeader.CashierId;
            context.SaveChanges();
        }
    }
}
