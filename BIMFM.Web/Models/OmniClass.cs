using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFM.Web.Models
{
    public class OmniClass
    {
        public string Num { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int LevelNum { get; set; }
        public List<OmniClass> Children { get; set; }
    }
}