using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interpreter.Process.MiddleCode
{
    public class Table
    {
        public string str;//变量名
        public string value;//变量值
        public string type;//变量类型
        public int lev;//变量的层次，涉及到不同块中的同名变量
        public Table(string _str, string _val, string _type, int _lev)
        {
            str = _str;
            value = _val;
            type = _type;
            lev = _lev;
        }
    }
}
