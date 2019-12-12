using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interpreter.Process.MiddleCode
{
    public class TempCode
    {
        public Four_code fc;
        public int level;
        public TempCode(Four_code _fc, int _lev)
        {
            fc = _fc;
            level = _lev;
        }
    }
}
