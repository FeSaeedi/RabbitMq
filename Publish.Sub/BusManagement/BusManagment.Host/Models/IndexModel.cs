using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusManagment.Host.Models
{
    public class IndexModel
    {


        public string Exchange { get; set; }
        public string QeueuName { get; internal set; }
        public string Address { get; internal set; }
        public int TypeId { get; internal set; }
    }
}