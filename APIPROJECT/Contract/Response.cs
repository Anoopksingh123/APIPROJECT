using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPROJECT.Contract
{
    public class Response
    {
        public bool  Ok { get; set; }
        public  string  Message { get; set; }
        public int Status { get; set; }
        public string Token { get; set; }
        public dynamic data { get; set; }
    }
}
