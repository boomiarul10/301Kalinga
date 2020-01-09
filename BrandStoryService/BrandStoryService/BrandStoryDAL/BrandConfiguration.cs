using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandStoryDataContracts;
using System.Data;
using System.Data.SqlClient;

namespace BrandStoryDAL
{
    public class BrandConfiguration:IBrandConfiguration 
    {
        public static string BrandStoryConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["BrandStoryConnString"].ToString().Trim();
            }
        }
        SqlHelper objSqlHelper = new SqlHelper();
        public IEnumerable<Brand> ListBrands()
        {
            DataSet dSet = null;
            List<Brand> lstBrands = new List<Brand>();
            
            try
            {
                dSet = objSqlHelper.ExecuteDataset(BrandStoryConnectionString, CommandType.StoredProcedure, "GetAllBrands");
                if (dSet != null && dSet.Tables[0] != null && dSet.Tables[0].Rows != null && dSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dSet.Tables[0].Rows)
                    {
                        var brand = new Brand();
                        brand.Id = Convert.ToInt32(dr["Id"].ToString());
                        brand.Name = dr["Name"].ToString();
                        brand.LocationCoverage  = dr["LocationCoverage"].ToString();
                        brand.Description  = dr["Description"].ToString();
                        brand.CreatedBy  = Convert.ToInt32(dr["CreatedBy"].ToString());
                        brand.CreatedOn = Convert.ToDateTime(dr["CreatedOn"].ToString());
                        brand.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"].ToString());
                        brand.UpdatedOn  = Convert.ToDateTime(dr["UpdatedOn"].ToString());

                        lstBrands.Add(brand);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstBrands;
        }

        public int CreateBrand(Brand brand)
        {
            var res = 0;
            try
            {
                object [] commandParameters = new object[]
                {
                    brand.Name,
                    brand.Description,
                    brand.LocationCoverage,
                    brand.CreatedBy
                };
                res = Convert.ToInt32(objSqlHelper.ExecuteScalar(BrandStoryConnectionString, CommandType.StoredProcedure,"InsertBrand", (SqlParameter[])commandParameters));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public int UpdateBrand(Brand brand)
        {
            var res = 0;
            try
            {
                object[] commandParameters = new object[]
                {
                    brand.Id,
                    brand.Name,
                    brand.Description,
                    brand.LocationCoverage,
                    brand.CreatedBy
                };
                res = Convert.ToInt32(objSqlHelper.ExecuteScalar(BrandStoryConnectionString, CommandType.StoredProcedure, "UpdateBrand", (SqlParameter[])commandParameters));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public int DeleteBrand(int brandID)
        {
            var res = 0;
            try
            {
                object[] commandParameters = new object[]
                {
                    brandID
                };
                res = Convert.ToInt32(objSqlHelper.ExecuteScalar(BrandStoryConnectionString, CommandType.StoredProcedure, "DeleteBrand", (SqlParameter[])commandParameters));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
    }

}
