
using Application.Models;
using Application.Srvices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CelebsApp.Controllers.ApiControllers
{
    public class ApiCelebsController : ApiController
    {
        private CelebsService service;

        public ApiCelebsController()
        {
            service = new CelebsService();
        }
        public IEnumerable<Celeb> GetSCelebsData()
        { 
            return service.GetCelebsList();
        }


        [HttpPost]
        public ResponseObj Create(Celeb celeb)
        {
            var result = service.CreateCeleb(celeb);
            return new ResponseObj
            {
                Success = result
            };
        }


        [HttpPost]
        public ResponseObj Edit(Celeb celeb)
        { 
            var result = service.EditCeleb(celeb);
            return new ResponseObj {
                Success = true
            };
        }


        [HttpPost]
        public ResponseObj Delete(Celeb celeb)
        {
            var result =  service.DeleteCeleb(celeb);
            return new ResponseObj { Success = result  };
        }
    }
}