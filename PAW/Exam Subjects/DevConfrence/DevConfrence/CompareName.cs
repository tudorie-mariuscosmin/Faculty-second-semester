using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevConfrence
{
    class CompareName : IComparer<Registration>
    {
        public int Compare(Registration x, Registration y)
        {
            return(-1* x.CompanyName.CompareTo(y.CompanyName));
        }
    }
}
