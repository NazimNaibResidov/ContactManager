using ContactManager.DTO.CVS;
using ContactManager.Entitys.Data;
using ContactManager.Facade.Interfaces;
using ContactManager.Services.interfaces;
using ContactManager.UnitOf.Core;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Facade.Implmt
{
    public class CVSFacade : ICVSFacade
    {
        private readonly ICVSFildService _cVSFildService;
        private readonly IUnitOfWork _unitOfWork;

        public CVSFacade(ICVSFildService cVSFildService, IUnitOfWork unitOfWork)
        {
            _cVSFildService = cVSFildService;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(CVSData cVSData)
        {
            //  cVSData.DateofBirth = Convert.ToDateTime(cVSData.DateofBirth.ToString("yyyy dd MM"));
            await _cVSFildService.CreateAsync(cVSData);
            _unitOfWork.Commit();
        }

        public IQueryable<CSVEntityFild> GetAll()

        {
            return _cVSFildService.GetAll()
               
                .AsQueryable();
        }

        public CSVEntityFild Remvoe(CSVEntityFild cVSFild)
        {
            return _cVSFildService.Remvoe(cVSFild);
            _unitOfWork.Commit();
        }

        public bool Update(CSVEntityFild cSVFild)
        {
             _cVSFildService.Update(cSVFild);
            return _unitOfWork.Commit();
        }
    }
}