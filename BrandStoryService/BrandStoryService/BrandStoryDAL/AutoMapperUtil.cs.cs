using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Data;

namespace BrandStoryDAL
{
    public class AutoMapperUtil
    {
        public AutoMapperUtil()
        {
            Initialize();
        }

        public void Initialize()
        {

        }
        public T2 ConvertTo<T1, T2>(T1 source) where T1 : class
                                                where T2 : class
        {
            T2 response = null;
            if (source is DataTable)
            {
                DataTable dt = source as DataTable;
                response = AutoMapper.Mapper.Map<IDataReader, T2>(dt.CreateDataReader());
            }
            else
            {
                response = AutoMapper.Mapper.Map<T1, T2>(source as T1);
            }
            return response;
        }

        private void InitializeBrand()
        {
            
        }
    }
}
