using CelebsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CelebsApp.Core.Repositories.Interfaces
{
    public interface ICeleb
    {
        IEnumerable<Celeb> GetCelebs(Func<Celeb, bool> func);
        int AddCeleb(Celeb celeb);
        int DeleteCeleb(Celeb celedb);
        int Update();
        
        int Save();

    }
}