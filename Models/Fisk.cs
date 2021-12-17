using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digitala_FiskGuiden.Models
{
    public class Fisk
    {
        public int FiskId { get; set; }
        public string Art { get; set; }
        public string Fakta { get; set; }

        public int KlassId { get; set; }
        public Klass Klass { get; set; }
    }
}
