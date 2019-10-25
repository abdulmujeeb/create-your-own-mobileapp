using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPnetCoreWebApi
{
    public class ClassifiedItem
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string Price { get; set; }
        public string ContactNo { get; set; }
        public string ImageURL { get; set; }
        public int  Distance { get; set; }
        public string TypeOfItem { get; set; }
        public string LocationName { get; set; }

    }
}
