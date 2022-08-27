using armyTec.Models;
namespace armyTec.Repository
{
    public interface ICacher
    {
        public Cashier getByID(int Id);
        public List<Cashier> getAll();
        public void add(Cashier cashier);
        public void update(int id,Cashier cashier);
        public void delete(int id);
        public List<Cashier> getAllByBranchId(int id);

    }
}
