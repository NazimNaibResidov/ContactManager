using ContactManager.DTO.CVS;
using ContactManager.Entitys.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Facade.Interfaces
{
    public interface ICVSFacade
    {
        IQueryable<CSVEntityFild> GetAll();

        Task Add(CVSData cVSData);

        CSVEntityFild Remvoe(CSVEntityFild cVSFild);

        bool Update(CSVEntityFild cSVFild);
    }
}