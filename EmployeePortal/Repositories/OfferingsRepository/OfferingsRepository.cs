using EmployeePortal.DataContext;
using EmployeePortal.Models;

namespace EmployeePortal.Repositories.OfferingsRepository
{
    public class OfferingsRepository(EmployeeContext employeeContext) : GenericRepository<Offering>(employeeContext), IOfferingRepository
    {
    }
}
