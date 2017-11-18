
using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace Application.Implemintation
{
    public class GenericRepo<T>
        where T : class
    {
        private static IList<T> genericList;
        public static IList<T> GenericList
        {
            get
            {
                return genericList;
            }

            private set
            {
                genericList = value;
            }

        }

        public GenericRepo()
        {
            genericList = genericList ?? FileStreamer<IList<T>>.GetJsonDataFromFile();

        }
        public IEnumerable<T> Get(Func<T, bool> func = null)
        {
            if (func != null)
            {
                return GenericList.Where(func);
            }

            return GenericList;
        }

        public bool Add(T obj)
        {
            GenericList.Add(obj);
            return Save();
        }

        public bool Remove(Func<T, bool> func )
        {
          var result = GenericList.ToList().FindIndex(ConvertToPredicate(func));
            if (result > -1)
            {
                GenericList.RemoveAt(result);
                return Save();
            }
            return false;
        }

        public bool Update(Func<T, bool> func, T newObj)
        {
            var originCeleb = GenericList.FirstOrDefault(func);
            if (newObj != null)
            {
                var result =  GenericList.ToList().FindIndex(ConvertToPredicate(func));
                if (result > -1)
                {
                    GenericList[result] = newObj;
                }
                
                return Save();
            }

            return false;
        }

        public static Predicate<T> ConvertToPredicate(Func<T, bool> func)
        {
            return new Predicate<T>(func);
        }
        public bool Save()
        {

            return FileStreamer<IList<T>>.SaveJsonObjectToFile(GenericList);
        }
    }
}


