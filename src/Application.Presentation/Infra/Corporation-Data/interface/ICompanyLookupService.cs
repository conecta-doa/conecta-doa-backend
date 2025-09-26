using System.Threading.Tasks;
using Application.Presentation.Service;

namespace  Application.Presentation.Interfaces
{
    public interface ICompanyLookupService
    {
        
        Task<CompanyInfoViewModel?> GetAsync(string document);
    }
}