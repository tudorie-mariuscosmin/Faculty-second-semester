using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminar_3_inheritance
{
    class Contractor : Person, IDeveloper
    {
        public Contractor(string name, string [] languages) : base(name)
        {
            Languages = languages;
        }

        public string[] Languages { get; set; }

        public bool knows(string language)
        {
            return Languages.Contains(language);
        }
    }
}
