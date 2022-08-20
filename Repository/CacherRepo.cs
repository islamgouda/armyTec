using armyTec.Models;

namespace armyTec.Repository
{
    public class CacherRepo : ICacher
    {
        private ArmyTechTaskContext context;
        public CacherRepo(ArmyTechTaskContext _context)
        {
            this.context = _context;
        }
        public void add(Cashier cashier)
        {
            context.Cashiers.Add(cashier);
            context.SaveChanges();
        }

        public void delete(int id)
        {
            Cashier ch=context.Cashiers.FirstOrDefault(cash=>cash.Id==id);
            context.Cashiers.Remove(ch);
            context.SaveChanges();
        }

        public List<Cashier> getAll()
        {
            return context.Cashiers.ToList();
        }

        public Cashier getByID(int Id)
        {
            return context.Cashiers.FirstOrDefault(cash => cash.Id == Id);
        }

        public void update(int id,Cashier cashier)
        {
            Cashier old=context.Cashiers.FirstOrDefault(cash => cash.Id == id);
            old.CashierName = cashier.CashierName;
            old.BranchId=cashier.BranchId;
           context.SaveChanges();
        }
    }
}
