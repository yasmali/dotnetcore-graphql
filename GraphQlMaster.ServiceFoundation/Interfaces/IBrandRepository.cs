using GraphQlMaster.ServiceFoundation.Models;
using System.Collections.Generic;

namespace GraphQlMaster.ServiceFoundation.Interfaces
{
    public interface IBrandRepository
    {
        List<Brand> GetBrands();
    }
}
