using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interpreter.Tables
{
    /// <summary>
    /// 表示变量的类
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// 变量名字
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 变量的值
        /// </summary>
        public String Value { get; set; }

        #region dl update
        /// <summary>
        /// 变量的类型
        /// </summary>
        public VarType Typeof { get; set; }
        #endregion

        /// <summary>
        /// 变量声明层
        /// </summary>
        public int LEV { get; set; }


        #region dl update

        /// <summary>
        /// 构造函数，初始化各个字段
        /// </summary>
        /// <param name="iniName">变量名</param>
        /// <param name="iniValue">变量值</param>
        /// <param name="iniType">变量类型</param>
        /// <param name="iniLEV">变量声明层</param>
        public Variable(String iniName, String iniValue, VarType iniType, int iniLEV)
        {
            Name = iniName;
            Value = iniValue;
            Typeof = iniType;
            LEV = iniLEV;
        }

        /// <summary>
        /// 构造函数，初始化各个字段
        /// </summary>
        /// <param name="iniName">变量名</param>
        /// <param name="iniType">变量类型</param>
        /// <param name="iniLEV">变量声明层</param>
        public Variable(String iniName, VarType iniType, int iniLEV)
        {
            Name = iniName;
            Typeof = iniType;
            LEV = iniLEV;
        }
        #endregion

        public enum VaribleType
        {
            /// <summary>
            /// int类型的变量
            /// </summary>
            INT,

            /// <summary>
            /// real类型的变量
            /// </summary>
            REL,

            /// <summary>
            /// int类型的数组
            /// </summary>
            ARR_INT,

            /// <summary>
            /// real类型的数组
            /// </summary>
            ARR_REAL,
        }
    }


    #region dl update
    /// <summary>
    /// 变量的类型int,real, array
    /// </summary>
    public class VarType
    {
        protected VarType()
        { }
        public static VarType INT = new VarType();
        public static VarType REAL = new VarType();
    }

    /// <summary>
    /// 数组类型
    /// </summary>
    public class TArray : VarType
    {
        /// <summary>
        /// 获取数组的类型
        /// </summary>
        public VarType Typeof { get; private set; }
        /// <summary>
        /// 获取或设置数组的长度
        /// </summary>
        public int Len { get; set; }

        /// <summary>
        /// 数组维数
        /// </summary>
        public int Dim { get; private set; }

        /// <summary>
        /// 构建数组(类型)
        /// </summary>
        /// <param name="of">要构建的数组的类型</param>
        /// <param name="len">要构建的数组的长度</param>
        public TArray(VarType of, int len)
            : base()
        {
            //多维数组
            if (of is TArray)
            {

                Dim = (of as TArray).Dim + 1;
            }
            else            // 一维数组
            {
                Dim = 1;
            }

            Typeof = of;
            Len = len;
        }
    }

    #endregion

}
