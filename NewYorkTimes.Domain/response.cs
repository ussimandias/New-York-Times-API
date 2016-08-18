using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewYorkTimes.Domain
{
    public class response
    {
        public docs Docs;
    }

    public class docs
    {
        public headline headline;
        public string web_url;
        public DateTime pub_date;
        public string source;
    }
}
