using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevConfrence
{
    class CompareType : IComparer<Registration>
    {
        public int Compare(Registration x, Registration y)
        {
            if (x.AccessPackageId < y.AccessPackageId)
                return -1;
            else if (x.AccessPackageId == y.AccessPackageId)
                return 0;
            else return 1;
        }
    }
}
