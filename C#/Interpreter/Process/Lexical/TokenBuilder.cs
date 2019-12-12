using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using interpreter.Process.Utils;
using interpreter.ui;

namespace interpreter.Process.Lexical
{
    public class TokenBuilder
    {
        /// <summary>
        /// 保留字
        /// </summary>
        private List<String> keyWords;

        /// <summary>
        /// 用于匹配标识符的正则表达式
        /// </summary>
        private String identifier;

        /// <summary>
        /// 用于匹配整数的正则表达式
        /// </summary>
        private String integer;

        /// <summary>
        /// 用于匹配浮点数的正则表达式
        /// </summary>
        private String decimals;

        /// <summary>
        /// 加减乘除等特殊字符
        /// </summary>
        private List<String> specialSymbol;

        /// <summary>
        /// 占两个字符的特殊字符
        /// </summary>
        private List<String> specialSymbol2;

        /// <summary>
        /// 算数运算符
        /// </summary>
        private List<String> num_operator;

        /// <summary>
        /// bool运算符
        /// </summary>
        private List<String> bool_operator;

        /// <summary>
        /// 界符
        /// </summary>
        private List<String> delimiter;

        /// <summary>
        /// 赋值符号
        /// </summary>
        private String assignment;

        /// <summary>
        /// 多行注释的正则匹配
        /// </summary>
        private String annotation = "/\\*";

        /// <summary>
        /// 单行注释
        /// </summary>
        private String singleline_anno = "//";

        /** 用户输入需分析的字符串 */
        private String content;

        /** 指向该分析的字符的索引 */
        private int cursor;

        /** 当前正分析的行号 */
        private int currentLineNum;

        /** 当前行的内容 */
        private String currentLine;

        /**多行注释结束位置*/
        private int annoEndIndex = -1;

        public List<Error> Errors { get; set; }

        private Token previousToken;

        /// <summary>
        /// 构造方法，初始化content以及其他特殊字符
        /// </summary>
        /// <param name="iniContent">要分析的内容</param>
        public TokenBuilder(String iniContent) {

            content = iniContent.Replace("\t", " ").Trim();         //Trim():去掉代码前后的空格
            //MainFram.AddInformation("正在构建token");

            //添加运算符
		    String[] scTemp = { "+", "-", "*", "/", "=", "<", ">", "!","(", ")", "{",
				    "}", "[", "]", ",", ";" };
		    specialSymbol = new List<String>();
		    foreach (String s in scTemp) {

			    specialSymbol.Add(s);
		    }
            specialSymbol2 = new List<String>();
            specialSymbol2.Add("==");
            specialSymbol2.Add("!=");
            specialSymbol2.Add("<=");
            specialSymbol2.Add(">=");
            specialSymbol2.Add("/*");

            //保留字
            keyWords = new List<String>();
            keyWords.Add("int");
            keyWords.Add("real");
            keyWords.Add("if");
            keyWords.Add("else");
            keyWords.Add("while");
            keyWords.Add("write");
            keyWords.Add("read");
		    //标识符
            identifier = "^[a-zA-Z]+[a-zA-Z_0-9]*[a-zA-z0-9]+$";
            //整数
            integer = "^-?\\d+$";
            //小数
            decimals = "^-?\\d+.\\d+$";
            //算数操作符
            num_operator = new List<String>();
            num_operator.Add("+");
            num_operator.Add("-");
            num_operator.Add("*");
            num_operator.Add("/");
            //bool操作符
            bool_operator = new List<string>();
            bool_operator.Add(">");
            bool_operator.Add(">=");
            bool_operator.Add("==");
            bool_operator.Add("<=");
            bool_operator.Add("<");
            bool_operator.Add("!=");
            //界符
            delimiter = new List<string>();
            delimiter.Add("(");
            delimiter.Add(")");
            delimiter.Add("[");
            delimiter.Add("]");
            delimiter.Add("{");
            delimiter.Add("}");
            delimiter.Add(",");
            delimiter.Add(";");
            //赋值符号
            assignment = "=";

            Errors = new List<Error>();
            previousToken = new Token();
	        }

        /**
         * 返回下一行的所有单词，需先调用<code>hasMoreLines()</code>方法
         * @return 下一行所有单词
         */
        public List<Token> nextTokens(){

		    List<Token> tokens = new List<Token>();
		    String tokenStr = "";

		    while (!(tokenStr = getToken()).Equals("$")) {

                //保留字
                if (keyWords.Contains(tokenStr))
                {
				    tokens.Add(new Token(TokenType.RSERVEED_WORD, tokenStr, currentLineNum));
			    } 
                //标识符
			    else if ((tokenStr.Length > 1 && Regex.Match(tokenStr, identifier).Groups[0].Success)
					    || (tokenStr.Length == 1 && Regex.Match(tokenStr, "^[a-zA-Z]$").Groups[0].Success)) 
                {
				    tokens.Add(new Token(TokenType.ID, tokenStr, currentLineNum));
                    previousToken = new Token(TokenType.ID, tokenStr, currentLineNum);
			    }
                //整数
			    else if (Regex.Match(tokenStr, integer).Groups[0].Success) {

				    tokens.Add(new Token(TokenType.INTEGER, tokenStr, currentLineNum));
                    previousToken = new Token(TokenType.ID, tokenStr, currentLineNum);
			    }
                //小数
                else if (Regex.Match(tokenStr, decimals).Groups[0].Success)
                {
                    tokens.Add(new Token(TokenType.DECIMAL, tokenStr, currentLineNum));
                    previousToken = new Token();
                }
                //算数运算符
                else if (num_operator.Contains(tokenStr))
                {
                    tokens.Add(new Token(TokenType.NUM_OPERATOR, tokenStr, currentLineNum));
                    previousToken = new Token();
                }
                //bool运算符
                else if (bool_operator.Contains(tokenStr))
                {
                    tokens.Add(new Token(TokenType.BOOL_OPERATOR, tokenStr, currentLineNum));
                    previousToken = new Token();
                }
                //界符
                else if (delimiter.Contains(tokenStr))
                {
                    tokens.Add(new Token(TokenType.DELIMITER, tokenStr, currentLineNum));
                    previousToken = new Token();
                }
                //赋值符号
                else if (assignment.Equals(tokenStr))
                {
                    tokens.Add(new Token(TokenType.ASSIGNMENT, tokenStr, currentLineNum));
                    previousToken = new Token();
                }
                /*多行注释处理 */
                else if (Regex.Match(tokenStr, annotation).Groups[0].Success)
                {

                    int index = content.IndexOf("*/", cursor);
                    String _annotation = content.Substring(cursor - 2,
                            (index == -1 ? content.Length : index + 2) - (cursor - 2));
                    /*单行注释*/
                    if (!_annotation.Contains("\n"))
                    {

                        if (index == -1)
                        {
                            tokens.Add(new Token(TokenType.ANNOTATION,
                                new Token.Annotation(cursor - 2, content.Length, true)));
                            previousToken = new Token();
                            cursor = content.Length;
                            return tokens;
                        }
                        else
                        {
                            tokens.Add(new Token(TokenType.ANNOTATION,
                                new Token.Annotation(cursor - 2, index + 2, true)));
                            previousToken = new Token();
                            cursor = index + 2;
                        }
                    }
                    /*多行注释*/
                    else
                    {
                        annoEndIndex = index == -1 ? content.Length : index + 2;
                        tokens.Add(new Token(TokenType.ANNOTATION,
                            new Token.Annotation(cursor - 2, annoEndIndex, true)));
                        previousToken = new Token();
                        cursor = content.IndexOf("\n", cursor) + 1;
                        return tokens;
                    }
                }
                //单行注释
                else if (tokenStr.Equals(singleline_anno))
                {
                    int temp = cursor;
                    cursor = content.IndexOf("\n", cursor) == -1 ? content.Length : content.IndexOf("\n", cursor) + 1;
                    tokens.Add(new Token(TokenType.ANNOTATION,
                        new Token.Annotation(temp - 2, cursor, false)));
                    previousToken = new Token();
                    return tokens;
                }
                //错误类型
                else
                {
                    Errors.Add(new Error(Error.ErrorType.LEXICAL, currentLineNum,
                        "非法输入符号: " + tokenStr));
                    tokens.Add(new Token(TokenType.ERROR, tokenStr, currentLineNum));
                    previousToken = new Token();
                }
		    }

		    return tokens;
	    }

        /**
         * 返回当前正在分析行的内容
         * 
         * @return 当前正在分析行的内容
         */
        public String getCurrentLine()
        {
            return currentLine;
        }

        /**
         * 判断是否还剩下未分析的行
         * 
         * @return 若剩下未分析的行返回true， 否则返回false
         */
        public bool hasMoreLines()
        {
            int i = content.IndexOf('\n', cursor);
            /*存在多行注释*/
            if (annoEndIndex > -1)
            {
                currentLineNum++;
                if (i == -1)
                {
                    currentLine = content.Substring(cursor);
                    cursor = content.Length;
                }
                else
                {
                    currentLine = content.Substring(cursor, i - cursor);
                    cursor = i;
                }

                if (cursor >= annoEndIndex)
                {
                    cursor = annoEndIndex;
                    annoEndIndex = -1;
                }

                return true;
            }

            if (!content.Substring(cursor).Equals(""))
            {
                currentLineNum++;

                if (i == -1)
                {
                    currentLine = content.Substring(cursor);
                }
                else
                {
                    currentLine = content.Substring(cursor, i- cursor);
                }
                return true;
            }
            return false;
        }
        
        /**
         * 返回当前正在分析的行的行号
         * 
         * @return 当前正在分析的行的行号
         */
        public int getCurrenLineNumber()
        {

            return currentLineNum;
        }

        /**
         * 返回content中下个有意义的token
         * 
         * @return content中下个有意义的token
         */
        private String getToken()
        {
            /* 去空格 */
            for (int i = cursor; i < content.Length; i++)
            {
                if (content[i] == ' ')
                {
                    cursor = i + 1;
                }
                else
                    break;
            }

            int start = cursor;
            String result = "";
            bool isNegative = false;
            for (; cursor < content.Length; cursor++)
            {
                /* cursor指向的字符不为换行符 */
                if (content[cursor] != '\n')
                {
                    /* cursor指向的字符不是界符或者空格,继续下个字符的判断 */
                    String temp = content[cursor].ToString();
                    if (!specialSymbol.Contains(content[cursor].ToString()) && content[cursor] != ' ')
                    {
                        result = content.Substring(start, cursor + 1 - start);
                        continue;
                    }
                    /* cursor指向的字符是界符 */
                    else if (content[cursor] != ' ')
                    {
                        /* 起始位置是界符时 */
                        if (specialSymbol.Contains(content[start].ToString()) && !isNegative)
                        {
                            /* cursor下一位置是为界符 */
                            if (cursor + 1 < content.Length && (specialSymbol.Contains(content[cursor + 1].ToString())))
                            {
                                String firstStr = content[start].ToString();
                                String nextStr = content[cursor + 1].ToString();

                                if (firstStr.Equals("=") && nextStr.Equals("=")
                                        || firstStr.Equals("<") && nextStr.Equals("=")
                                        //|| nextStr.Equals(">"))
                                        || firstStr.Equals("!") && nextStr.Equals("=")
                                        || firstStr.Equals(">") && nextStr.Equals("=")
                                        || firstStr.Equals("/") && nextStr.Equals("*")
                                        || firstStr.Equals("/") && nextStr.Equals("/")
                                        )
                                {
                                    cursor += 2;
                                    return content.Substring(start, cursor - start);
                                }

                                return content.Substring(start, ++cursor - start);
                            }
                            //负数
                            else if (previousToken.TokenType != TokenType.INTEGER && previousToken.TokenType != TokenType.ID &&
                                cursor + 1 < content.Length && content[cursor] == '-' && char.IsDigit(content[cursor+1]))
                            {
                                isNegative = true;
                                continue;
                            }
                            /* cursor下一位置不是为界符 */
                            else
                            {
                                result = content.Substring(start, ++cursor - start);
                                /* 去空格 */
                                for (int i = cursor; i < content.Length; i++)
                                {
                                    if (content[i] == ' ')
                                    {
                                        cursor = i + 1;
                                    }
                                    else
                                        break;
                                }
                                return result;
                            }
                        }
                        /* 起始位置不是界符 */
                        else
                        {
                            return content.Substring(start, cursor - start);
                        }
                    }
                    /* cursor指向的字符是空格 */
                    else
                    {
                        /* 去空格 */
                        result = content.Substring(start, cursor-start);
                        for (int i = cursor; i < content.Length; i++)
                        {
                            if (content[i] == ' ')
                            {
                                cursor = i + 1;
                            }
                            else
                                break;
                        }
                        return result;
                    }
                }
                //当前cursor指向换行符"\n"
                else
                {
                    //cursor += 1;
                    if (result.Equals(""))
                    {
                        cursor++;
                        return "$";
                    }
                    else
                    {
                        return result;
                    }
                }
            }

            if (result.Equals(""))
            {
                return "$";
            }
            else
            {
                return result;
            }
        }
        
        /// <summary>
        /// 词法分析时候存在词法错误
        /// </summary>
        /// <returns></returns>
        public bool hasLexicalError()
        {
            return Errors.Count != 0;
        }

        /**
         * 返回输入内容对应的所有单词
         * @return 输入内容对应的所有单词
         */
        public List<Token> getAllTokens() 
        {
		    List<Token> allTokens = new List<Token>();
		
		    while(hasMoreLines()) {
			
			    foreach(Token t in nextTokens()) {
				
				    allTokens.Add(t);
			    }
		    }
		    return allTokens;
	    }
    }
}
