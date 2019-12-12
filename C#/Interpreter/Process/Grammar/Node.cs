using interpreter.Process.Utils;
using System;
using System.Collections.Generic;
using interpreter.Process.Grammar;
using interpreter.Tables;

namespace interpreter.Process.Grammar
{
    public class Node
    {
        /// <summary>
        /// Node的类型
        /// </summary>
        public TokenType Type { get; set; }

        #region dl update
        /// <summary>
        /// Node的变量类型
        /// </summary>
        public VarType Typeof { get; set; }
        #endregion

        /// <summary>
        /// Node的值
        /// </summary>
        public String Value { get; set; }

        
        public List<Node> Child{get;set;}

        /// <summary>
        /// 构造方法，适用于构造非终结符节点
        /// </summary>
        /// <param name="iniType">Node的类型</param>
        public Node(TokenType iniType) {
		
		    Type = iniType;
		    Child = new List<Node>();
	    }

        /// <summary>
        /// 构造方法，适用于构造终结符节点
        /// </summary>
        /// <param name="iniType">非终结Node的类型</param>
        /// <param name="iniValue">非终结Node的值</param>
        public Node(TokenType iniType, String iniValue) {
		
		    Type = iniType;
		    Value = iniValue;
		    Child = new List<Node>();
	    }
    }
}
