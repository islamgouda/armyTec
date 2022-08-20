using armyTec.Models;

namespace armyTec.Repository
{
    public class branchRepo : Ibranch
    {
        private ArmyTechTaskContext context;
        public branchRepo(ArmyTechTaskContext _context)
        {
            this.context = _context;
        }
        public Branch findByName(string name)
        {
            return context.Branches.FirstOrDefault(branch => branch.BranchName == name);
        }

        public List<Branch> getAll()
        {
            return context.Branches.ToList();
        }

        public Branch getById(int id)
        {
            return context.Branches.FirstOrDefault(branch => branch.Id == id);
        }
    }
}
