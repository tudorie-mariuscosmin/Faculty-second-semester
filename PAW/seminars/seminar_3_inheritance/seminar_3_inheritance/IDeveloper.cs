using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminar_3_inheritance
{
    interface IDeveloper
    {
        //inside iterfaces we can only have properties and methoda not fields;
        string[] Languages { get; set; }


        bool knows(string language);

    }
}
