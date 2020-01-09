using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandStoryDataContracts;
using BrandStoryDAL;

namespace BrandStoryImplementation
{
    public class BrandConfiguration:IBrandConfiguration 
    {
        
        public IEnumerable<Brand> ListBrands()
        {
            try
            {
                return new BrandStoryDAL.BrandConfiguration().ListBrands();            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int CreateBrand(Brand brand)
        {
            try
            {
                return new BrandStoryDAL.BrandConfiguration().CreateBrand(brand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateBrand(Brand brand)
        {
            try
            {
                return new BrandStoryDAL.BrandConfiguration().UpdateBrand(brand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteBrand(int brandID)
        {
            try
            {
                return new BrandStoryDAL.BrandConfiguration().DeleteBrand(brandID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
