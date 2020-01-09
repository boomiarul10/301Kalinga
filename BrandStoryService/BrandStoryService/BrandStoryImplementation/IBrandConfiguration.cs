using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandStoryDataContracts;

namespace BrandStoryImplementation
{
    public interface  IBrandConfiguration
    {
        IEnumerable<Brand> ListBrands();
        int CreateBrand(Brand brand);
        int UpdateBrand(Brand brand);
        int DeleteBrand(int brandID);
    }
}
