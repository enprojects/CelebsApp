using CelebsApp.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CelebsApp.Core.Models;
using CelebsApp.Core.DataLayer;

namespace CelebsApp.Core.Repositories.Implementations
{
    public class CelebRepo : ICeleb
    {
        private CelebContext _context;
        public CelebRepo()
        {
            _context = new CelebContext();
        }

        public IEnumerable<Celeb> GetCelebs(Func<Celeb, bool> func = null)
        {
            if (func != null)
            {
                return _context.Celebs.Where(func);
            }

           return _context.Celebs;
        }

        public int AddCeleb(Celeb celeb)
        {
           _context.Celebs.Add(celeb);
           return  Save();
            
        }

        public int DeleteCeleb(Celeb celeb)
        {
            _context.Celebs.Remove(celeb);
            return  Save();

         
        }


        public int Update()
        {
            return Save();
        }


        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}