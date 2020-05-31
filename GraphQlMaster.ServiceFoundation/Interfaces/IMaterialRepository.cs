using GraphQlMaster.ServiceFoundation.Models;
using System.Collections.Generic;

namespace GraphQlMaster.ServiceFoundation.Interfaces
{
    public interface IMaterialRepository
    {
        List<Material> GetMaterials();

        List<Material> GetMaterialsByBrandId(int brandId);
    }
}
