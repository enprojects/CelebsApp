using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CelebsApp.Core.Models
{
    public class Celeb
    {
        public int CelebId { get; set; }
        public string CelebName { get; set; }
        public int CelebAge { get; set; }
        public string CelebCountry { get; set; }
    }
}