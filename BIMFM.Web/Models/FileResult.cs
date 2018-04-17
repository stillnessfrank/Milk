using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIMFM.Web.Models
{
    public class FileResult
    {
        public string FileNames { get; set; }
        public string Description { get; set; }
        public string CreatedTimestamp { get; set; }
        public string UpdatedTimestamp { get; set; }
        public string FileLength { get; set; }
        public string ContentTypes { get; set; }
        public string OriginalNames { get; set; }
        public string Status { get; set; }
        public string Msg { get; set; }
    }
}