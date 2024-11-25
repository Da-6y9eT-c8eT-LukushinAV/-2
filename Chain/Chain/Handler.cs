using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain
{
    public abstract class Handler
    {
        protected Handler? NextHandler { get; set; }

        public void SetNext(Handler nextHandler)
        {
            NextHandler = nextHandler;
        }

        public abstract void HandleRequest(Request request);
    }


}
