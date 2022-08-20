using armyTec.Models;

namespace armyTec.Repository
{
    public interface Ibranch
    {
        public Branch getById(int id);
        public List<Branch> getAll();
        public Branch findByName(string name);
    }
}
