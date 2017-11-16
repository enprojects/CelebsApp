using CelebsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CelebsApp.Core.DataLayer
{
    public class CelebContext : DbContext
    {

        public CelebContext() 
            :base("CelebsContext")
        {

        }
        public DbSet<Celeb> Celebs { get; set; }
    }
}