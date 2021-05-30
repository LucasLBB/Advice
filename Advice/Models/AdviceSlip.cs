using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advice.Models
{

    public class ListAdvice
    {
        public AdviceSlip slip { get; set; }
    }

    public class AdviceSlip
    {
        public int id { get; set; }

        public string advice { get; set; }
    }
}
