using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrandStoryImplementation;
using BrandStoryDataContracts;

namespace BrandStoryWebApi.Controllers
{
    public class BrandConfigController : ApiController
    {
        Brand[] brands = new Brand[]
        {
            new Brand{ Id= 1, Name="Ariel", Description="Washing Powder", LocationCoverage ="NorthRegion of TamilNadu" },
            new Brand{ Id= 2, Name="Gillette", Description="Mens Fashion", LocationCoverage ="SouthRegion of TamilNadu" },
            new Brand{ Id= 3, Name="Tide", Description="Washing Powder", LocationCoverage ="EastRegion of TamilNadu" },
            new Brand{ Id= 4, Name="Downy", Description="Fashion", LocationCoverage ="NorthRegion of TamilNadu" },
            new Brand{ Id= 5, Name="Olay", Description="Women Fashion", LocationCoverage ="EastRegion of TamilNadu" },
        };

        //GET api/BrandConfig
        public HttpResponseMessage Get()
        {
            //IEnumerable<Brand> brands = new BrandConfiguration().ListBrands();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, brands);
            response.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(2)
            };

            return response;
        }

        //GET api/BrandConfig/1
        public IHttpActionResult Get(int id)
        {
            var prod = brands.FirstOrDefault(p => p.Id == id);
            if (prod == null)
                return NotFound();
            return Ok(prod);
        }

        //POST api/BrandConfig
        public HttpResponseMessage Post(Brand brand)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new BrandConfiguration().CreateBrand(brand));
            return response;
        }
        //PUT api/BrandConfig
        public HttpResponseMessage Put(Brand brand)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new BrandConfiguration().UpdateBrand(brand));
            return response;
        }

        //DELETE api/BrandConfig/1
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, new BrandConfiguration().DeleteBrand(id));
            return response;
        }
    }
}
