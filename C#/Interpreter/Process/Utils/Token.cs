using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interpreter.Process.Utils
{
    public class Token {

        /// <summary>
        /// 该token所处的行号
        /// </summary>
        public int LineNum{get;set;}

	    /// <summary>
        /// token的类型
	    /// </summary>
	    public TokenType TokenType{get;set;}

        private string _Token_Value;

        public Token() { }

	    /// <summary>
        /// 相应token类型的值
	    /// </summary>
        public String Token_Value
        {
            get
            {
                switch (this.TokenType)
                {
                    case TokenType.ID:
                        return "id";
                    case TokenType.INTEGER:
                        return "integer";
                    case TokenType.DECIMAL:
                        return "decimal";
                    default:
                        return _Token_Value;
                }
            }
            set { _Token_Value = value; }
        }

        /// <summary>
        /// 注释详细信息
        /// </summary>
        public Annotation Anno { get; set; }
	
	    /// <summary>
        /// 初始化Token的各个字段
	    /// </summary>
        /// <param name="iniType">token类型</param>
        /// <param name="iniValue">各个token类型对应的值</param>
        /// <param name="iniLineNum">该token所处的行号</param>
	    public Token(TokenType iniType, String iniValue, int iniLineNum) 
        {
		    TokenType = iniType;
		    Token_Value = iniValue;
            LineNum = iniLineNum;
	    }

        /// <summary>
        /// 初始化Token的类型，注释内容字段
        /// </summary>
        /// <param name="iniType">类型</param>
        /// <param name="iniAnno">注释</param>
        public Token(TokenType iniType, Annotation iniAnno)
        {
            TokenType = iniType;
            Anno = iniAnno;
        }

	    public override String ToString() {

            StringBuilder buffer = new StringBuilder();
		
		    switch(TokenType) {
		
		        case TokenType.RSERVEED_WORD:
                    buffer.Append(LineNum).Append(": reserved word: ").Append(Token_Value);
			        break;
                case TokenType.ID:
                    buffer.Append(LineNum).Append(": ID: name = ").Append(Token_Value);
			        break;
                case TokenType.INTEGER:
                    buffer.Append(LineNum).Append(": integer: val = ").Append(Token_Value);
			        break;
                case TokenType.DECIMAL:
                    buffer.Append(LineNum).Append(": decimal: val = ").Append(Token_Value);
                    break;
                case TokenType.NUM_OPERATOR:
                    buffer.Append(LineNum).Append(": numeric operator: ").Append(Token_Value);
                    break;
                case TokenType.BOOL_OPERATOR:
                    buffer.Append(LineNum).Append(": boolean operator: ").Append(Token_Value);
                    break;
                case TokenType.ASSIGNMENT:
                    buffer.Append(LineNum).Append(": assign operator: ").Append(Token_Value);
                    break;
                case TokenType.DELIMITER:
                    buffer.Append(LineNum).Append(": delimiter: ").Append(Token_Value);
                    break;
                case TokenType.ERROR:
                    buffer.Append(LineNum).Append(": ").Append(Token_Value).Append(" : error token");
			        break;
		    }
		
		    return buffer.ToString();
	    }

        public TokenType GetTokenType()
        {
            return TokenType;
        }

	    public void SetTokenType(TokenType tokenType) 
        {
		    this.TokenType = tokenType;
	    }

        #region csjupdate
        public string GetValue() 
        {
            return _Token_Value;
	    }

	    public void SetValue(String Value) 
        {
            this._Token_Value = Value;
	    }
        #endregion

        public void SetLineNum(int LineNum)
        {
            this.LineNum = LineNum;
        }

        public int GetLineNum()
        {
            return this.LineNum;
        }

        public class Annotation
        {
            /// <summary>
            /// 注释起始位置
            /// </summary>
            public int Start { get; set; }

            /// <summary>
            /// 注释结束位置
            /// </summary>
            public int End { get; set; }

            /// <summary>
            /// 是否多行注释
            /// </summary>
            public bool isMulti { get; set; }

            public Annotation(int iniS, int iniE,  bool iniMul)
            {
                Start = iniS;
                End = iniE;
                isMulti = iniMul;
            }
        }
    }
}
