using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interpreter.Process.Utils
{
    /// <summary>
    /// 表示有意义的单词的类型的枚举类
    /// </summary>
    public enum TokenType
    {
        #region 终结符类型
        /// <summary>
        /// 保留字
        /// </summary>
        RSERVEED_WORD, 

        /// <summary>
        /// 标识符
        /// </summary>
        ID,

        /// <summary>
        /// 整数
        /// </summary>
        INTEGER,

        /// <summary>
        /// 小数
        /// </summary>
        DECIMAL,

        /*待取消*/
        /// <summary>
        /// 数字
        /// </summary>
        NUM,

        /// <summary>
        /// 算术运算运算符
        /// </summary>
        NUM_OPERATOR,

        /// <summary>
        /// 布尔运算符
        /// </summary>
        BOOL_OPERATOR,

        /// <summary>
        /// 界符
        /// </summary>
        DELIMITER,

        /// <summary>
        /// 赋值符号
        /// </summary>
        ASSIGNMENT,
        #endregion

        /*待取消*/
        SPECIAL_SYMBOL,

        /// <summary>
        /// 错误类型
        /// </summary>
        ERROR,

        /// <summary>
        /// 结束符
        /// </summary>
        EOF, 

        /// <summary>
        /// 注释
        /// </summary>
        ANNOTATION,


        #region 非终结符类型
        /// <summary>
        /// 非终结符类型,表示程序
        /// </summary>
        PROCEDURE,

        /// <summary>
        /// 非终结符类型,表示分程序
        /// </summary>
        SUBPROGRAM,

        /// <summary>
        /// 非终结符类型,表示块
        /// </summary>
        BLOCK,

        /// <summary>
        /// 非终结符类型,表示语句
        /// </summary>
        STATEMENT,

        /// <summary>
        /// 非终结符类型,表示声明
        /// </summary>
        DECLARATION,

        /// <summary>
        /// 非终结符类型,表示条件
        /// </summary>
        CONDITION,

        /// <summary>
        /// 非终结符类型,表示表达式
        /// </summary>
        EXPRESSION,

        /// <summary>
        /// 非终结符类型,表示项
        /// </summary>
        TERM,

        /// <summary>
        /// 非终结符类型,表示因子
        /// </summary>
        FACTOR,
        #endregion
    }
}
