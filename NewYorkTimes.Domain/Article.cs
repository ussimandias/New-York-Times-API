using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NewYorkTimes.Domain
{
   
    public class Article
    {       
        public string Headline { get; set; }

        public string ArticleURL { get; set; }
   
        public DateTime PublishDate { get; set; }
   
        public string Source { get; set; }

    }

}
