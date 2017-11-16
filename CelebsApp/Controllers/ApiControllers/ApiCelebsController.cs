using CelebsApp.Core.Models;
using CelebsApp.Core.Repositories.Implementations;
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
        private CelebRepo celebRepo;

        public ApiCelebsController()
        {
            celebRepo = new CelebRepo();
        }
        public IEnumerable<Celeb> GetSCelebsData()
        {
            return celebRepo.GetCelebs();
        }


        [HttpPost]
        public ResponseObj Create(Celeb celeb)
        {
            var result = celebRepo.AddCeleb(celeb);
            return new ResponseObj
            {
                Success = result > 0
            };
        }


        [HttpPost]
        public ResponseObj Edit(Celeb celeb)
        {
            var celebEdit = celebRepo
                .GetCelebs(x => x.CelebId == celeb.CelebId)
                .SingleOrDefault();

            celebEdit.CelebName = celeb.CelebName;
            celebEdit.CelebCountry = celeb.CelebCountry;
            celebEdit.CelebAge = celeb.CelebAge;

            var result = celebRepo.Save();

            return new ResponseObj { Success = result > 0 };
        }


        [HttpPost]
        public ResponseObj Delete(Celeb celeb)
        {
            var celebToDelete = celebRepo
                .GetCelebs(x => x.CelebId == celeb.CelebId)
                .SingleOrDefault();

            var result = celebRepo.DeleteCeleb(celebToDelete);

            return new ResponseObj { Success = result > 0 };
        }
    }
}