using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace englishsnsVS10.datacontext
{
    partial class explanation 
    {
        partial void OnCreated() {
            this.createdata = DateTime.Now;
            this.modifier = "System";
            this.active = 1;
            this.reference = - 1;
        }

    }
}
