using armyTec.Models;
using armyTec.Repository;
using armyTec.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace armyTec.Controllers
{
    public class invoiceDataController : Controller
    {
        private ArmyTechTaskContext context;
        private IInvoice invoiceRepo;
        private ICacher cacherRepo;
        private Ibranch branchRepo;
        public invoiceDataController(ArmyTechTaskContext _context, IInvoice _invoiceRepo, ICacher _cacherRepo, Ibranch _branchRepo)
        {
            this.context= _context;
            this.invoiceRepo= _invoiceRepo;
            this.cacherRepo= _cacherRepo;
            this.branchRepo= _branchRepo;
        }
        public IActionResult Index()
        {
            List<InvoiceViewModel>invoiceModel=new List<InvoiceViewModel>();
         List<InvoiceHeader> header=   invoiceRepo.GetAllInvoiceHeader();
            foreach(InvoiceHeader inv in header)
            {
                InvoiceViewModel model = new InvoiceViewModel();
                model.Id = (int)inv.Id;
                model.CustomerName = inv.CustomerName;
                model.Invoicedate = inv.Invoicedate;
                model.InvoiceDetails = invoiceRepo.InvoiceDetails((int)model.Id);
                double sum = 0;
                foreach(var item in model.InvoiceDetails)
                {
                    sum += (item.ItemPrice * item.ItemCount);
                }
                model.total = sum;
                int cn = (int)inv.CashierId;
                Cashier ch = cacherRepo.getByID(cn);
                if (ch != null) { model.cahserName = ch.CashierName; }
                else
                {
                    model.cahserName = " ";
                }
                
                model.BranchName = branchRepo.getById(inv.BranchId).BranchName;
                invoiceModel.Add(model);


            }
          //List<InvoiceDetail>inv= context.InvoiceDetails.ToList();

            return View(invoiceModel);
        }
        //[Route("Speaker/{headerID:int}")]
        public IActionResult addInvoiceDetails(int headerID)
        {
            ViewBag.headerID= headerID;
            
            addInvoiceVM inv =new addInvoiceVM();
            inv.headerId= headerID;
            return View(inv);
        }
        public IActionResult addnewinvoice(addInvoiceVM model)
        {
            InvoiceDetail invoice = new InvoiceDetail();
            invoice.InvoiceHeaderId = model.headerId;
            invoice.ItemName=model.ItemName;
            invoice.ItemPrice=model.ItemPrice;
            invoice.ItemCount = model.ItemCount;
            invoiceRepo.AddInvoiceDetail(invoice);
            return RedirectToAction("Index");
        }

        public IActionResult deleteInvoice(int id)
        {
            invoiceRepo.DeleteInvoiceDetail(id);
            return RedirectToAction("Index");
        }
        public IActionResult edit(int id)
        {
          InvoiceDetail inv=  invoiceRepo.GetInvoiceDetail(id);
            UpdateInvoiceVM model=new UpdateInvoiceVM();
            model.Id = (int)inv.Id;
            model.ItemName=inv.ItemName;
            model.ItemPrice=inv.ItemPrice;
            model.ItemCount=inv.ItemCount;
            return View(model);

        }
        public IActionResult update(UpdateInvoiceVM model)
        {
            InvoiceDetail inv =new InvoiceDetail();
            inv.Id= model.Id;
            inv.ItemName= model.ItemName;
            inv.ItemPrice = model.ItemPrice;
            inv.ItemCount=model.ItemCount;
            invoiceRepo.UpdateInvoiceDetail(model.Id, inv);

            return RedirectToAction("Index");

        }

        public IActionResult addNewInvoiceHeader()
        {
            invoiceHeaderVM headerVM=new invoiceHeaderVM();
            ViewBag.branches = branchRepo.getAll();
            ViewBag.cachers = cacherRepo.getAll();
            return View("addNewInvoice",headerVM);
        }
        public IActionResult saveNewInvoice(invoiceHeaderVM headerVM)
        {
           // if (ModelState.IsValid) {
                InvoiceHeader invh = new InvoiceHeader();
                invh.CustomerName = headerVM.CustomerName;
                invh.Invoicedate = headerVM.Invoicedate;
                invh.BranchId = headerVM.BranchId;
                invh.CashierId = headerVM.CashierId;
                int hId = invoiceRepo.addInvoiceHeaderAndGetId(invh);
                foreach (invItem v in headerVM.invItem)
                {
                    InvoiceDetail invoiceDetail = new InvoiceDetail();
                    invoiceDetail.ItemName = v.ItemName;
                    invoiceDetail.ItemCount = v.ItemCount;
                    invoiceDetail.ItemPrice = v.ItemPrice;
                    invoiceDetail.InvoiceHeaderId = hId;
                    invoiceRepo.AddInvoiceDetail(invoiceDetail);
                }
                return RedirectToAction("Index");
         //   }
            //else
            //{
            //    return View("addNewInvoice", headerVM);
            //}
            
        }
        public IActionResult removeIonvoiceHeader(int id)
        {
            invoiceRepo.deleteInvoiceHeader(id);
            return RedirectToAction("Index");
        }
        public IActionResult editIvonicHeader(int id)
        {
            InHeaderVM headerVM = new InHeaderVM();
            InvoiceHeader inv = invoiceRepo.GetInvoiceHeader(id);
            headerVM.Id= (int)inv.Id;
            headerVM.CustomerName = inv.CustomerName;
            headerVM.Invoicedate= inv.Invoicedate;
            headerVM.CashierId= inv.CashierId;
            headerVM.BranchId= inv.BranchId;

            ViewBag.branches = branchRepo.getAll();
            ViewBag.cachers = cacherRepo.getAllByBranchId(inv.BranchId);
            return View(headerVM);
        }
        public IActionResult saveNewInvoiceHeader(InHeaderVM headerVM)
        {
            InvoiceHeader header=new InvoiceHeader();
            header.Id= headerVM.Id;
            header.CustomerName= headerVM.CustomerName;
            header.Invoicedate = header.Invoicedate;
            header.BranchId= headerVM.BranchId;
            header.CashierId= headerVM.CashierId;
            invoiceRepo.updateInvoiceHeader((int)headerVM.Id, header);
            return RedirectToAction("Index");
        }
       public IActionResult getChacherByBranchID(int id)
        {
            List<Cashier> cashiers = cacherRepo.getAllByBranchId(id);
            return Json(cashiers);
        }

    }
}
