using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain
{
    public class Request
    {
        public string Type { get; }
        public string Data { get; }

        public Request(string type, string data)
        {
            Type = type;
            Data = data;
        }
    }

}
