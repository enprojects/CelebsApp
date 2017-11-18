using System;
using System.Collections.Generic;

namespace Application.Inetrface

{
    public interface IGenericRepo<T>
    {
        IEnumerable<T> Get(Func<T, bool> func);
        bool Add(T celeb);
        bool Delete(T celedb);
        bool Update();
    }
}