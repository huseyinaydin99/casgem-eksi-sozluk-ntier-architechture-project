﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.EntityLayer.Concrete
{
    public class Heading
    {
        
        public int HeadingID { get; set; }

        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }

        public bool HeadingStatus { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public  List<Content> Contents { get; set; }

     
      
    }
}
