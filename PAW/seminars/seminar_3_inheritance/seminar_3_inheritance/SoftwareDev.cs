using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminar_3_inheritance
{
    class SoftwareDev : Employee, IDeveloper
    {
        public string[] Languages { get; set; }

        public SoftwareDev(string name, string [] languages) : base(name)
        {
            Languages = languages;
        }

        public override void abstractMethod()
        {
            Console.WriteLine("software developer - abstract method");
        }


        public override void VirtualMethod()
        {
            Console.WriteLine("*software developer - virtual method*");
        }

        public new void NormalMethod()
        {
            Console.WriteLine("softwaredev method");   
        }

        public bool knows(string language)
        {
            return Languages.Contains(language);
        }
    }
}
