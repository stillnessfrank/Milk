using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFM.Web.Models
{
    public class ImportOutput
    {
        public List<OmniClass> Result { get; set; }
        public string Log { get; set; }
        public List<OmniClass> ErrorResult { get; set; }
    }
}