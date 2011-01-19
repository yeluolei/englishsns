using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace englishsnsVS10.SystemInterfaces
{
    interface ILoginValidation
    {
        bool validate(string text, string ticket);
    }
}
