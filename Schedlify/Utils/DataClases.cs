using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedlify.Utils
{
    public class Slot
    {
        public TimeOnly startTime {  get; set; }
        public TimeOnly endTime {  get; set; }
        public int classNumber { get; set; }
        public Slot(TimeOnly _startTime, TimeOnly _endTime, int _classNumber)
        {
            startTime = _startTime;
            endTime = _endTime;
            classNumber = _classNumber;
        }
        public Slot() { }
    }
}
