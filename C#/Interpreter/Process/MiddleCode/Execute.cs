using interpreter.Process.Lexical;
using interpreter.Process.Utils;
using interpreter.ui;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace interpreter.Process.MiddleCode
{
    public class Execute
    {
        private string content;
        private List<Token> temp;
        private List<TempCode> TreeNode;//代码四元式
        private List<Table> tb;//符号表
        public int LEVEL;
        public Execute(String content)
        {
            this.content = content;
            temp = new TokenBuilder(content).getAllTokens();
            TreeNode = new MiddleCode(content).getMiddleCode();
            tb = new MiddleCode(content).getTable();
        }
        /// <summary>
        ///关于控制台
        /// </summary>
        public class Win32
        {
            [DllImport("kernel32.dll")]
            public static extern Boolean AllocConsole();
            [DllImport("kernel32.dll")]
            public static extern Boolean FreeConsole();
        }
        /// <summary>
        /// 查询str对应的Table实体
        /// 查找的算法就是向上找离他最近的那个同名变量，远近由变量的层次决定
        /// 变量的层次在符号表的存储过程中就有所保存
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Table getTableItem(string str, int lev)//通过str值返回一个table实体
        {
            int gap = 10000000;
            int b = -1;
            for (int i = 0; i < tb.Count; ++i)
            {
                if (tb[i].str == str)
                {
                    if (lev - tb[i].lev >= 0 && lev - tb[i].lev < gap)
                    {
                        gap = lev - tb[i].lev;
                        b = i;
                    }
                }
            }
            if (b == -1)
                return null;
            else
                return tb[b];
        }
       /// <summary>
       /// 解释执行
       /// </summary>
        public void Run()
        {
            //清空输出框
            MainFram.outputRichTextBox.Text = "";
            //Win32.AllocConsole();//打开命令行
            for (int i = 0; i < TreeNode.Count; ++i)
            {
                Four_code FC = TreeNode[i].fc;
                LEVEL = TreeNode[i].level;
                switch (FC.op)
                {
                    case "assign":
                        Assign(FC.arg1, FC.arg2);
                        break;
                    case "read":
                        Read(FC.arg1);
                        break;
                    case "write":
                        Write(FC.arg1);
                        break;
                    case "sub":
                        Sub(FC.arg1, FC.arg2, FC.result);
                        break;
                    case "add":
                        Add(FC.arg1, FC.arg2, FC.result);
                        break;
                    case "mul":
                        Mul(FC.arg1, FC.arg2, FC.result);
                        break;
                    case "div":
                        Div(FC.arg1, FC.arg2, FC.result);
                        break;
                    case "<":
                        Less(FC.arg1, FC.arg2, FC.result);
                        break;
                    case ">":
                        More(FC.arg1, FC.arg2, FC.result);
                        break;
                    case "<=":
                        LessE(FC.arg1, FC.arg2, FC.result);
                        break;
                    case ">=":
                        MoreE(FC.arg1, FC.arg2, FC.result);
                        break;
                    case "==":
                        Equal(FC.arg1, FC.arg2, FC.result);
                        break;
                    case "!=":
                        Nequal(FC.arg1, FC.arg2, FC.result);
                        break;
                    case "jumpto":
                        i = Jumpto(FC.result, i, FC.arg1);
                        break;
                    case "jumpat":
                    case "mark1":
                    case "mark3":
                        break;
                    case "mark0":
                        i = JumpToMark(i);
                        break;
                    case "mark2":
                        i = JumpToMark1(i, FC.arg1);
                        break;
                    default:
                        break;
                }
            }
            //Console.WriteLine("请按回车键继续...");
            //Console.ReadLine();
            //Win32.FreeConsole();
        }
        /// <summary>
        /// 跳转--返回一个跳转的目标地址
        /// </summary>
        /// <param name="str"></param>
        public int Jumpto(string str, int start, string str1)
        {
            Table TT1 = getTableItem(str, LEVEL);
            if (TT1.value == "0")
            {
                for (int i = start; i < TreeNode.Count; ++i)
                {
                    if (TreeNode[i].fc.op == "jumpat" && TreeNode[i].fc.arg1 == str1)
                    {
                        return i;
                    }
                }
            }
            return start;
        }
        /// <summary>
        /// 无条件跳转(向下)--返回一个跳转的目标地址
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public int JumpToMark(int start)
        {
            for (int i = start; i < TreeNode.Count; ++i)
            {
                if (TreeNode[i].fc.op == "mark1")
                {
                    return i;
                }
            }
            return start;
        }
        /// <summary>
        /// 无条件跳转(向上)--返回一个跳转的目标地址
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public int JumpToMark1(int start, string str)
        {
            for (int i = start; i >= 0; --i)
            {
                if (TreeNode[i].fc.op == "mark3" && TreeNode[i].fc.arg1 == str)
                {
                    return i;
                }
            }
            return start;
        }
        /// <summary>
        /// 读入
        /// </summary>
        /// <param name="str"></param>
        /// read功能不可用
        public void Read(string str)
        {
            string input = "";
            string pattern1 = @"^[0-9]+$";//整型
            string pattern2 = @"^[0-9]+\.[0-9]+$";//浮点数
            input = Console.ReadLine();
            Table TT = getTableItem(str, LEVEL);
            switch (TT.type)//当前变量的具体类型
            {
                case "int":
                    while (!Regex.IsMatch(input, pattern1))//正则表达式的匹配
                    {
                        Console.WriteLine("Your inout is unvalid,Please reenter:");
                        input = Console.ReadLine();
                    }
                    break;
                case "real":
                    while (!Regex.IsMatch(input, pattern2))
                    {
                        Console.WriteLine("Your inout is unvalid,Please reenter:");
                        input = Console.ReadLine();
                    }
                    break;
                default:
                    break;
            }
            //修改符号表元素的值
            TT.value = input;
        }
        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="str"></param>
        public void Write(string str)
        {
            Table TT = getTableItem(str, LEVEL);
            if (TT == null)
                return;
            //Console.WriteLine(TT.value);//输出value
            if (MainFram.outputRichTextBox.Text == "")
            {
                MainFram.outputRichTextBox.Text = MainFram.outputRichTextBox.Text + TT.value;
            }
            else
            {
                MainFram.outputRichTextBox.Text = MainFram.outputRichTextBox.Text + "\t\n" + TT.value;
            }
        }
        /// <summary>
        /// 此处涉及到强制转化问题-减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Sub(string a, string b, string c)
        {
            Table TT1 = getTableItem(a, LEVEL);
            Table TT2 = getTableItem(b, LEVEL);
            Table TT3 = getTableItem(c, LEVEL);
            //转化成double类型总不会丢失,变量原来的类型不会发生改变
            TT3.value = System.Convert.ToString(System.Convert.ToDouble(TT1.value) - System.Convert.ToDouble(TT2.value));
        }
        /// <summary>
        /// 此处涉及到强制转化问题-加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Add(string a, string b, string c)
        {
            Table TT1 = getTableItem(a, LEVEL);
            Table TT2 = getTableItem(b, LEVEL);
            Table TT3 = getTableItem(c, LEVEL);
            //转化成double类型总不会丢失,变量原来的类型不会发生改变
            TT3.value = System.Convert.ToString(System.Convert.ToDouble(TT1.value) + System.Convert.ToDouble(TT2.value));
        }
        /// <summary>
        /// 乘法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Mul(string a, string b, string c)
        {
            Table TT1 = getTableItem(a, LEVEL);
            Table TT2 = getTableItem(b, LEVEL);
            Table TT3 = getTableItem(c, LEVEL);
            //转化成double类型总不会丢失,变量原来的类型不会发生改变
            TT3.value = System.Convert.ToString(System.Convert.ToDouble(TT1.value) * System.Convert.ToDouble(TT2.value));
        }
        /// <summary>
        /// 除法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Div(string a, string b, string c)
        {
            Table TT1 = getTableItem(a, LEVEL);
            Table TT2 = getTableItem(b, LEVEL);
            Table TT3 = getTableItem(c, LEVEL);
            //转化成double类型总不会丢失,变量原来的类型不会发生改变
            TT3.value = System.Convert.ToString(System.Convert.ToDouble(TT1.value) / System.Convert.ToDouble(TT2.value));
        }
        /// <summary>
        /// 大于等于
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void MoreE(string a, string b, string c)
        {
            Table TT1 = getTableItem(a, LEVEL);
            Table TT2 = getTableItem(b, LEVEL);
            Table TT3 = getTableItem(c, LEVEL);
            //转化成double类型总不会丢失,变量原来的类型不会发生改变
            double temp1 = System.Convert.ToDouble(TT1.value);
            double temp2 = System.Convert.ToDouble(TT2.value);
            if (temp1 >= temp2)
                TT3.value = 1 + "";
            else
                TT3.value = 0 + "";
        }
        /// <summary>
        /// 小于等于
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void LessE(string a, string b, string c)
        {
            Table TT1 = getTableItem(a, LEVEL);
            Table TT2 = getTableItem(b, LEVEL);
            Table TT3 = getTableItem(c, LEVEL);
            //转化成double类型总不会丢失,变量原来的类型不会发生改变
            double temp1 = System.Convert.ToDouble(TT1.value);
            double temp2 = System.Convert.ToDouble(TT2.value);
            if (temp1 <= temp2)
                TT3.value = 1 + "";
            else
                TT3.value = 0 + "";
        }
        /// <summary>
        /// 大于
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void More(string a, string b, string c)
        {
            Table TT1 = getTableItem(a, LEVEL);
            Table TT2 = getTableItem(b, LEVEL);
            Table TT3 = getTableItem(c, LEVEL);
            //转化成double类型总不会丢失,变量原来的类型不会发生改变
            double temp1 = System.Convert.ToDouble(TT1.value);
            double temp2 = System.Convert.ToDouble(TT2.value);
            if (temp1 > temp2)
                TT3.value = 1 + "";
            else
                TT3.value = 0 + "";
        }
        /// <summary>
        /// 小于
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Less(string a, string b, string c)
        {
            Table TT1 = getTableItem(a, LEVEL);
            Table TT2 = getTableItem(b, LEVEL);
            Table TT3 = getTableItem(c, LEVEL);
            //转化成double类型总不会丢失,变量原来的类型不会发生改变
            double temp1 = System.Convert.ToDouble(TT1.value);
            double temp2 = System.Convert.ToDouble(TT2.value);
            if (temp1 < temp2)
                TT3.value = 1 + "";
            else
                TT3.value = 0 + "";
        }

        /// <summary>
        /// 等于
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Equal(string a, string b, string c)
        {
            Table TT1 = getTableItem(a, LEVEL);
            Table TT2 = getTableItem(b, LEVEL);
            Table TT3 = getTableItem(c, LEVEL);
            //转化成double类型总不会丢失,变量原来的类型不会发生改变
            double temp1 = System.Convert.ToDouble(TT1.value);
            double temp2 = System.Convert.ToDouble(TT2.value);
            if (temp1 == temp2)
                TT3.value = 1 + "";
            else
                TT3.value = 0 + "";
        }

        /// <summary>
        /// 不等于
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Nequal(string a, string b, string c)
        {
            Table TT1 = getTableItem(a, LEVEL);
            Table TT2 = getTableItem(b, LEVEL);
            Table TT3 = getTableItem(c, LEVEL);
            //转化成double类型总不会丢失,变量原来的类型不会发生改变
            double temp1 = System.Convert.ToDouble(TT1.value);
            double temp2 = System.Convert.ToDouble(TT2.value);
            if (temp1 != temp2)
                TT3.value = 1 + "";
            else
                TT3.value = 0 + "";
        }
        /// <summary>
        /// 赋值语句
        /// </summary>
        /// 
        public void Assign(string a, string b)
        {
            Table TT1 = getTableItem(a, LEVEL);
            Table TT2 = getTableItem(b, LEVEL);
            if (TT1 == null || TT2 == null)
                return;
            TT2.value = TT1.value;
        }
    }
}
