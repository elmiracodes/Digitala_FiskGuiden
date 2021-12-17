using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digitala_FiskGuiden.Models
{
    public class Klass
    {
        public int KlassId { get; set; }

        public string FiskKlass { get; set; }

        public List<Fisk> Fiskar { get; set; }

    }
}
