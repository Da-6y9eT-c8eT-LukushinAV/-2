using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain
{
    using System;

    public class ConcreteHandlerA : Handler
    {
        public override void HandleRequest(Request request)
        {
            if (request.Type == "TypeA")
            {
                Console.WriteLine("ConcreteHandlerA обработал запрос с данными: " + request.Data);
            }
            else
            {
                NextHandler?.HandleRequest(request);
            }
        }
    }

    public class ConcreteHandlerB : Handler
    {
        public override void HandleRequest(Request request)
        {
            if (request.Type == "TypeB")
            {
                Console.WriteLine("ConcreteHandlerB обработал запрос с данными: " + request.Data);
            }
            else
            {
                NextHandler?.HandleRequest(request);
            }
        }
    }


}
