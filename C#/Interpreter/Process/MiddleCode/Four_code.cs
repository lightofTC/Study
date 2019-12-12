using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interpreter.Process.MiddleCode
{
    /// <summary>
    /// 四元式
    /// </summary>
    public class Four_code
    {
        //四元式对应的四个参数
        public string op;
        public string arg1;
        public string arg2;
        public string result;
        public Four_code(string _op, string _arg1, string _arg2, string _result)
        {
            op = _op;
            arg1 = _arg1;
            arg2 = _arg2;
            result = _result;
        }
    }
}
