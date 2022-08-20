using Microsoft.AspNetCore.Mvc;
using armyTec.Models;
using armyTec.ViewModel;
using armyTec.Repository;

namespace armyTec.Controllers
{
    public class CacherController : Controller
    {
        private ArmyTechTaskContext context;
        private IInvoice invoiceRepo;
        private ICacher cacherRepo;
        private Ibranch branchRepo;
        public CacherController(ArmyTechTaskContext _context, IInvoice _invoiceRepo, ICacher _cacherRepo, Ibranch _branchRepo)
        {
            this.context = _context;
            this.invoiceRepo = _invoiceRepo;
            this.cacherRepo = _cacherRepo;
            this.branchRepo = _branchRepo;
        }
        public IActionResult Index()
        {
            List<CacherVM> cacherVMs = new List<CacherVM>();
            List<Cashier> cashiers = cacherRepo.getAll();
            foreach(Cashier ch in cashiers)
            {
                CacherVM vm = new CacherVM();
                vm.Id=ch.Id;
                vm.CashierName=ch.CashierName;
                vm.BranchName = branchRepo.getById((int)ch.BranchId).BranchName;

                cacherVMs.Add(vm);

            }
            return View(cacherVMs);
        }
        public IActionResult addNewCacher()
        {
            ViewBag.branches = branchRepo.getAll();
            newCacherVM ch = new newCacherVM();
            return View(ch);
        }
        public IActionResult saveNew(newCacherVM ch)
        {
            if (ModelState.IsValid) {
                Cashier cash = new Cashier();
                cash.CashierName = ch.CashierName;
                cash.BranchId = ch.BranchId;
                cacherRepo.add(cash);
                return RedirectToAction("Index");

            }
            else
            {
                return View("addNewCacher",ch);
            }
           

        }
        public IActionResult editCacher(int id)
        {
         Cashier cashier= cacherRepo.getByID(id);
            updateCacherVM cacherVM = new updateCacherVM();
            cacherVM.Id = cashier.Id;
            cacherVM.CashierName=cashier.CashierName;
            cacherVM.BranchId = cashier.BranchId;
            ViewBag.branches = branchRepo.getAll();
            return View(cacherVM);

        }
        public IActionResult saveUpdatedCacher(updateCacherVM cacherVM)
        {
            if (ModelState.IsValid) {
                Cashier ch = new Cashier();
                ch.Id = cacherVM.Id;
                ch.BranchId = cacherVM.BranchId;
                ch.CashierName = cacherVM.CashierName;
                cacherRepo.update(cacherVM.Id, ch);
                return RedirectToAction("Index");
            }
            else
            {
                return View("editCacher", cacherVM);
            }
            
        }

        public IActionResult deleteCacher(int id)
        {
            cacherRepo.delete(id);
            return RedirectToAction("Index");
        }
    }
}
