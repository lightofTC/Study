using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interpreter.Process.Utils
{
    public class Error
    {
        /// <summary>
        /// 错误的类型，语法错误或者词法错误
        /// </summary>
        public ErrorType Type {get;set;}

        /// <summary>
        /// 出错行号
        /// </summary>
        public int LineNo { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        public string Dec { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="iniErrorType">错误类型</param>
        /// <param name="iniLineNo">出错行号</param>
        /// <param name="iniDec">错误简单描述</param>
        public Error(ErrorType iniErrorType, int iniLineNo, string iniDec)
        {
            Type = iniErrorType;
            LineNo = iniLineNo;
            Dec = iniDec;
        }

        /// <summary>
        /// 描述错误类型的一个类
        /// </summary>
        public enum ErrorType
        {
            /// <summary>
            /// 词法错误
            /// </summary>
            LEXICAL,
            
            /// <summary>
            /// 语法错误
            /// </summary>
            GRAMMAR
        }


    }
}
