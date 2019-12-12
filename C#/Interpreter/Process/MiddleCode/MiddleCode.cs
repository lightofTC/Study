using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using interpreter.Process.Utils;
using interpreter.Process.Lexical;

namespace interpreter.Process.MiddleCode
{
    public class MiddleCode
    {
        private string content;
        private List<Token> temp;
        private List<TempCode> TreeNode;//代码四元式
        private List<Table> tb;//符号表
        public string Word;//当前处理的单词
        public int wordID = 0;//当前链表的位置
        public int varNum = 0;//四元式中中间变量的数目
        public string tempStr;//程序中有一些变量需要保存方便后来使用。。这些变量用tempStr保存
        public int level = 0;//嵌套层次和变量对应的层次
       /// <summary>
       /// 首先过滤掉注释部分
       /// </summary>
       /// <param name="content"></param>
        public MiddleCode(String content)
        {
            this.content = content;
            temp = new TokenBuilder(content).getAllTokens();
            for (int i = 0; i < temp.Count; i++)
            {
                Token token = temp[i];
                if (token.GetTokenType() == TokenType.ANNOTATION)
                {
                    temp.RemoveAt(i);
                    i--;
                }
            }

            TreeNode = new List<TempCode>();
            tb = new List<Table>();
        }
       /// <summary>
        /// 获取单词
       /// </summary>
        public void getNext()
        {
            if (wordID >= 0 && wordID < temp.Count)
            {
                Word = temp[wordID].GetValue();
                wordID++;
            }
        }
       /// <summary>
        /// 算是分析程序的入口
       /// </summary>
        public void judge()
        {
            string TType = "";
            switch (Word)
            {
                case "int":
                    TType = "int";
                    getNext();
                    Declare_ment(TType);
                    break;
                case "real":
                    TType = "real";
                    getNext();
                    Declare_ment(TType);
                    break;
                case "if":
                    If_ment();
                    break;
                case "while":
                    While_ment();
                    break;
                case "write":
                    Write_ment();
                    break;
                case "read":
                    Read_ment();
                    break;
                default:
                    string VAR = Word;
                    if (wordID >= 1 && wordID - 1 < temp.Count && temp[wordID - 1].GetTokenType() == TokenType.ID)
                        Assign_ment();
                    else
                    {
                        return;
                    }
                    break;
            }
        }
        /// <summary>
        /// 启动新的一轮judge
        /// </summary>
        public void start()
        {
            if (Word == ";" || Word == "}")
            {
                if (wordID >= temp.Count)
                    return;
                getNext();
                judge();
            }
        }
        /// <summary>
        /// 因子——Factor
        /// </summary>
        public void Factor()
        {
            if (Word == "(")
            {
                getNext();//跳过左括号(
                Expression();
            }
            else
            {
                if (wordID - 1 >= 0 && wordID - 1 < temp.Count)
                {
                    switch (temp[wordID - 1].GetTokenType())//项的类型（常量还是变量）
                    {
                        case TokenType.INTEGER://整型
                            //TreeNode.Add(new TempCode(new Four_code("const_int", Word, "null", "atTable"), level));
                            TreeNode.Add(new TempCode(new Four_code("const_int", Word, "null", "null"), level));
                            tb.Add(new Table(Word, Word, "int", level));//将常量的变量名和变量值置为一样方便下面的搜索
                            tempStr = Word;
                            break;
                        case TokenType.DECIMAL://浮点型
                            //TreeNode.Add(new TempCode(new Four_code("const_real", Word, "null", "atTable"), level));
                            TreeNode.Add(new TempCode(new Four_code("const_real", Word, "null", "null"), level));
                            tb.Add(new Table(Word, Word, "real", level));
                            tempStr = Word;
                            break;
                        case TokenType.ID://变量(或数组元素形式的变量)
                            string VAR = Word;
                            getNext();
                            int NUM = -1;
                            if (Word == "[")
                            {
                                getNext();
                                NUM = System.Convert.ToInt32(Word);
                                getNext();
                            }
                            else { Word = VAR; wordID--; }
                            if (NUM == -1) tempStr = VAR; else tempStr = VAR + NUM;
                            break;
                        default:
                            break;
                    }
                }
            }
            getNext();
        }
        /// <summary>
        ///项——Item
        /// </summary>
        public void Item()//..
        {
            string Str = "";//保存Item中的Factor//"|"为分隔符
            string Op = "";//保存Item中的操作符
            Factor();
            Str += tempStr + "|";
            Op += Word + "|";
            while (Word == "*" || Word == "/")
            {
                getNext();
                Factor();
                Str += tempStr + "|";
                Op += Word + "|";
            }
            //分割串
            string[] Str1 = Str.Split(new char[] { '|' });
            string[] Op1 = Op.Split(new char[] { '|' });
            int i = 0;
            string result = "";
            while (i < Op1.Length - 2)
            {
                //四个变量对应与四元式中的四个变量
                string var1 = "";
                string var2 = "";
                string type = "";
                result = "Var" + varNum;
                varNum++;
                if (Op1[i] == "*") type = "mul";
                if (Op1[i] == "/") type = "div";
                if (i == 0) var1 = Str1[0]; else var1 = "Var" + (varNum - 2);
                var2 = Str1[i + 1];
                //TreeNode.Add(new TempCode(new Four_code(type, var1, var2, result), level));
                TreeNode.Add(new TempCode(new Four_code(type, var1, var2, result), level));
                //产生新的变量将其加入符号表
                tb.Add(new Table(result, "0", "ID", level));//变量初始化为0
                i++;
            }
            tempStr = result;
            if (result == "")
                tempStr = Str1[0];
        }

        /// <summary>
        /// 表达式--Expression
        /// </summary>
        public void Expression()//..
        {
            string Op = "";//保存表达式中的操作符
            string Str = "";//保存表达式中的Item
            Item();
            Str += tempStr + "|";
            Op += Word + "|";
            while (Word == "+" || Word == "-")
            {
                getNext();
                Item();
                Str += tempStr + "|";
                Op += Word + "|";
            }
            //分割串
            string[] Str1 = Str.Split(new char[] { '|' });
            string[] Op1 = Op.Split(new char[] { '|' });
            string result = "";
            int i = 0;
            while (i < Op1.Length - 2)
            {
                //四个变量对应与四元式中的四个变量
                string var1 = "";
                string var2 = "";
                string type = "";
                result = "Var" + varNum;
                varNum++;
                if (Op1[i] == "-") type = "sub";
                if (Op1[i] == "+") type = "add";
                if (i == 0) var1 = Str1[0]; else var1 = "Var" + (varNum - 2);
                var2 = Str1[i + 1];
                TreeNode.Add(new TempCode(new Four_code(type, var1, var2, result), level));
                //产生新的变量将其加入符号表
                tb.Add(new Table(result, "0", "ID", level));//变量初始化为0
                i++;
            }
            tempStr = result;
            if (result == "")
                tempStr = Str1[0];
        }

        /// <summary>
        /// 条件语句——Relationship
        /// 总共实现全部比较常用的六种操作">""<""!=""=="">="和"<="
        /// </summary>
        public void Relationship()
        {
            Expression();
            string Ex1 = tempStr;//第一个表达式结果存的变量
            string Tmp = Word;//Tmp是比较符号
            getNext();
            Expression();//第二个表达式结果存的变量
            string Ex2 = tempStr;
            switch (Tmp)
            {
                case "<":
                    //Tmp = "Less";
                    Tmp = "<";
                    break;
                case "!=":
                    //Tmp = "NEQ";
                    Tmp = "!=";
                    break;
                case "==":
                    //Tmp = "EQ";
                    Tmp = "==";
                    break;
                case ">=":
                    //Tmp = "MoreE";
                    Tmp = ">=";
                    break;
                case ">":
                    //Tmp = "More";
                    Tmp = ">";
                    break;
                case "<=":
                    //Tmp = "LessE";
                    Tmp = "<=";
                    break;
                default:
                    break;
            }
            TreeNode.Add(new TempCode(new Four_code(Tmp, Ex1, Ex2, "Var" + varNum), level));//将条件表达式的结果放到变量里
            tb.Add(new Table("Var" + varNum, "0", "ID", level));//将新产生的变量放到表中
            tempStr = "Var" + varNum;
            varNum++;
        }
        /// <summary>
        /// 声明语句——Declare_ment
        /// </summary>
        public void Declare_ment(string TType)
        {
            string VAR = Word;
            getNext();
            if (Word == "[")
            {
                //TreeNode.Add(new TempCode(new Four_code("new", VAR, "Array", "atTable"), level));//数组类型的变量
                TreeNode.Add(new TempCode(new Four_code("new", VAR, "Array", "null"), level));//数组类型的变量
                getNext();//跳过括号得到数字
                int NUM = System.Convert.ToInt32(Word);
                for (int i = 0; i < NUM; ++i)
                    tb.Add(new Table(VAR + i, "0", TType, level));//在符号表里面开辟足够的数组用的空间
                getNext();//当前是]
            }
            else if (Word == "=")//声明的同时进行赋值初始化
            {
                getNext();
                //TreeNode.Add(new TempCode(new Four_code("new", VAR, TType, "atTable"), level));
                //TreeNode.Add(new TempCode(new Four_code("const_" + TType, Word, "null", "atTable"), level));
                TreeNode.Add(new TempCode(new Four_code("new", VAR, TType, "null"), level));
                TreeNode.Add(new TempCode(new Four_code("const_" + TType, Word, "null", "null"), level));
                TreeNode.Add(new TempCode(new Four_code("assign", Word, VAR, "null"), level));
                tb.Add(new Table(Word, Word, TType, level));
                tb.Add(new Table(VAR, Word, TType, level));
            }
            else
            {
                TreeNode.Add(new TempCode(new Four_code("new", VAR, TType, "atTable"), level));
                TreeNode.Add(new TempCode(new Four_code("new", VAR, TType, "null"), level));
                //声明的变量加入到符号表
                tb.Add(new Table(VAR, "0", TType, level));//变量在声明的时候默认值是0与现代编译器一致*
                wordID--;
                Word = VAR;
            }
            getNext();
            while (Word == ",")
            {
                getNext();
                Declare_ment(TType);
            }
            start();
        }

        /// <summary>
        /// 赋值语句——Assign_ment
        /// </summary>
        public void Assign_ment()//..
        {
            string Tmp = Word;
            int NUM = -1;
            getNext();
            if (Word == "[")
            {
                getNext();
                NUM = System.Convert.ToInt32(Word);
                getNext();//当前是]
                getNext();//当前是=
            }
            getNext();
            Expression();
            if (NUM == -1)
                TreeNode.Add(new TempCode(new Four_code("assign", tempStr, Tmp, "null"), level));
            else
                TreeNode.Add(new TempCode(new Four_code("assign", tempStr, Tmp + NUM, "null"), level));
            start();
        }
        /// <summary>
        /// 读入——Read_ment
        /// </summary>
        public void Read_ment()//..
        {
            getNext();//跳过左括号（
            getNext();//得到变量名
            string VAR = Word;
            getNext();
            if (Word == "[")
            {
                getNext();
                int NUM = System.Convert.ToInt32(Word);
                TreeNode.Add(new TempCode(new Four_code("read", VAR + NUM, "null", "null"), level));
                getNext();
                getNext();
            }
            else
            {
                TreeNode.Add(new TempCode(new Four_code("read", VAR, "null", "null"), level));
            }
            getNext();//跳过分号;
            start();
        }

        /// <summary>
        /// 输出——Write_ment
        /// </summary>
        public void Write_ment()//..
        {
            getNext();//跳过左括号（
            getNext();
            Expression();
            TreeNode.Add(new TempCode(new Four_code("write", tempStr, "null", "null"), level));
            getNext();//跳过右括号）
            start();
        }

        /// <summary>
        /// if语句——If_ment
        /// </summary>
        public void If_ment()
        {
            getNext();//跳过左括号（
            getNext();
            Relationship();
            level++;
            TreeNode.Add(new TempCode(new Four_code("jumpto", "level" + level, "null", tempStr), level));//tempStr保存条件判断的真假
            getNext();//跳过左大括号{
            getNext();
            judge();//当前Word是}
            TreeNode.Add(new TempCode(new Four_code("mark0", "null", "null", "null"), level));//作为标记当条件语句为真的话一定会走到这里然后跳过else
            TreeNode.Add(new TempCode(new Four_code("jumpat", "level" + level, "null", "null"), level));//else区域即使if语句没有else两个node之间将没有内容不影响结果
            level--;
            getNext();
            if (Word == "else")
            {
                getNext();
                getNext();
                level++;
                judge();
                level--;
                getNext();
            }
            TreeNode.Add(new TempCode(new Four_code("mark1", "null", "null", "null"), level));
            judge();
        }
        /// <summary>
        /// while语句——While_ment
        /// </summary>
        public void While_ment()
        {
            getNext();//跳过左括号（
            getNext();
            TreeNode.Add(new TempCode(new Four_code("mark3", "null", "null", "null"), level));
            Relationship();
            level++;
            TreeNode.Add(new TempCode(new Four_code("jumpto", "level" + level, "null", tempStr), level));//tempStr存放条件判断的真假
            getNext();//跳过右括号）
            getNext();//跳过左大括号{
            judge();
            TreeNode.Add(new TempCode(new Four_code("mark2", "null", "null", "null"), level));
            TreeNode.Add(new TempCode(new Four_code("jumpat", "level" + level, "null", "null"), level));
            level--;
            getNext();//跳过右大括号}
            judge();
        }
        /// <summary>
        /// 返回处理得到的中间代码-四元式
        /// </summary>
        /// <returns></returns>
        public List<TempCode> getMiddleCode()
        {
            getNext();
            judge();
            return TreeNode;
        }
        /// <summary>
        /// 返回处理得到的用于解释执行的符号表
        /// </summary>
        /// <returns></returns>
        public List<Table> getTable()
        {
            getNext();
            judge();
            return tb;
        }
    }
}
