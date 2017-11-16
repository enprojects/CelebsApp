using CelebsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Celebs.Core
{
    public interface IGenericRepo<T>
    {
        IEnumerable<T> Get(Func<Celeb, bool> func);
        bool Add(T celeb);
        bool Delete(T celedb);
        bool Update();
    }
}