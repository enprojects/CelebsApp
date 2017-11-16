
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CelebsApp.Core.Models;
using System.IO;
using Newtonsoft.Json;
using Celebs.Core.Data;

namespace Application
{
    public class GenericRepo<T> 
        where T : class
    {

        private readonly FileStreamer<T> streamer;
        public static IList<T> ListOfCeleb;

        public GenericRepo()
        {
            ListOfCeleb = null;// write on streamer util which serialaize string to json 
                               // Check thread safe on save to file 
                               // Change to DataRepoGeneric
                               // Build on top og generic repository services layer
        }
        public IEnumerable<T> Get(Func<T, bool> func = null)
        {
            if (func != null)
            {
                return ListOfCeleb.Where(func);
            }

            return ListOfCeleb;
        }

        public bool Add(T obj)
        {
            ListOfCeleb.Add(obj);
            return  Save();
        }

        public bool Delete(T obj)
        {
            ListOfCeleb.Remove(obj);
            return Save();
        }

        public bool Update(Func<T, bool>  func , T newObj )
        {
            var originCeleb = Get(func)
                        .FirstOrDefault();

            if (originCeleb != null)
            {
                originCeleb = newObj;
                return Save();
            }

            return false;
            
        }


        private bool Save()
        {
            var celebs = JsonConvert.SerializeObject(ListOfCeleb);
            return streamer.WriteToFile(celebs);
        }
    }
}


