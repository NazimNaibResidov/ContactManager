using ContactManager.Entitys.Data;
using ContactManager.Services.Core;
using ContactManager.Services.interfaces;
using ContactManager.UnitOf.Core;

namespace ContactManager.Services.Implmnt
{
    public class CVSFildService : BaseService<CSVEntityFild>, ICVSFildService
    {
        public CVSFildService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}