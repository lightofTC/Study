using interpreter.Process.Lexical;
using interpreter.Process.Utils;
using interpreter.Tables;
using interpreter.ui;
using System;
using System.Collections.Generic;

namespace interpreter.Process.Grammar
{
    /// <summary>
    /// 语法语义分析类,必须保证输入的程序无词法错误
    /// </summary>
    public class GrammerAnalyzer
    {
        /// <summary>
        /// 分析内容
        /// </summary>
        private string content;

        /// <summary>
        /// 不匹配原因
        /// </summary>
        private string reason;

        /// <summary>
        /// 词法分析所得的所有单词
        /// </summary>
        private List<Token> tokens;

        /// <summary>
        /// tokens中当前正在分析的位置
        /// </summary>
        private int cursor;

        /// <summary>
        /// 当前token
        /// </summary>
        private Token currentToken;

        /// <summary>
        /// 当前token的前一个token
        /// </summary>
        private Token previousToken;

        /// <summary>
        /// 程序中的错误
        /// </summary>
        public List<Error> Errors { get; set; }

        //test use 
        private Token flag;
        private String temp;

        /// <summary>
        /// 调用TokenBuilder类的getAllTokens方法初始化 字段tokens，并把字段cursor置为0
        /// </summary>
        /// <param name="content">欲分析的内容</param>
        public GrammerAnalyzer(String content)
        {
            this.content = content;
            MainFram.AddInformation("正在词法分析...");
            TokenBuilder tb = new TokenBuilder(content);
            tokens = new TokenBuilder(content).getAllTokens();
            //词法分析存在错误,将不会进行语法分析
            if (tb.hasLexicalError())
            {
                tokens = new List<Token>();
            }
            //屏蔽注释
            MainFram.AddInformation("正在处理注释...");
            for (int i = 0; i < tokens.Count; i++)
            {
                Token token = (Token)tokens[i];
                if (token.TokenType == TokenType.ANNOTATION)
                {
                    tokens.Remove(token);
                    i--;
                }
            }
            if (tokens.Count == 0)
            {
                tokens.Add(new Token(TokenType.EOF, null));
            }

            Errors = new List<Error>();
            cursor = 0;
            currentToken = tokens[0];
            previousToken = tokens[0];
        }

        /// <summary>
        /// 对当前的输入内容进行语法分析并返回语法分析树
        /// </summary>
        /// <returns>语法分析树</returns>
        public Node Analyze()
        {            
            return Procedure();
        }

        /// <summary>
        /// 程序分析
        /// </summary>
        /// <returns>语法树</returns>
        private Node Procedure()
        {
            MainFram.AddInformation("构建语法分析树，遇到procedure...");
            Node node = new Node(TokenType.PROCEDURE);
            node.Child.Add(SubProgram());
            MatchCheck();
            CombineError();
            return node;
        }

        /// <summary>
        /// 子程序分析
        /// </summary>
        /// <returns>语法树</returns>
        private Node SubProgram()
        {
            MainFram.AddInformation("构建语法分析树，遇到subprocedure...");
            Node node = new Node(TokenType.SUBPROGRAM);
            while (true)
            {
                switch (currentToken.TokenType)
                {
                    case TokenType.EOF:
                        goto labelInSub;
                    default:
                        temp = currentToken.Token_Value;
                        switch (currentToken.Token_Value)
                        {
                            case "{":
                                node.Child.Add(Block());
                                break;
                            case "if":
                            case "read":
                            case "write":
                            case "while":
                            case "int":
                            case "real":
                            case "id":
                                node.Child.Add(Statement());
                                break;
                            //token以全部分析完毕，立即返回
                            case "EOF":
                            case "re-EOF":
                                return node;
                            default:
                                // 异常处理,此处的单词应属于语句的first集合
                                Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum, "语句不应以 "
                                    + currentToken.GetValue()+ " 开头"));
                                MainFram.AddInformation("出现语法错误...");
                                //Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum, "语法错误"));
                                Expect(new String[] { "", "", "", "{", "if", "read", "write", "while", "int", "real", "id" });
                                break;
                        }
                        break;
                }
            }
        labelInSub: return node;
        }

        /// <summary>
        /// 块分析
        /// </summary>
        /// <returns>语法树</returns>
        private Node Block()
        {
            MainFram.AddInformation("构建语法分析树，遇到block...");
            Node node = new Node(TokenType.BLOCK);
            flag = Consume_token("{", node,
                new String[] { "{", "", "", "int", "real", "while", "read", "write", "if", "id", ";" });

            #region csjupdate
            wkLev++;
            #endregion

            while (true)
            {
                temp = currentToken.Token_Value;
                switch (currentToken.Token_Value)
                {
                    case "int":
                    case "real":
                    case "while":
                    case "read":
                    case "write":
                    case "id":
                    case "if":
                        node.Child.Add(Statement());
                        break;
                    case "{":
                        node.Child.Add(Block());
                        break;
                    case "}":
                        goto labelInB;
                    case "EOF":
                    case "re-EOF":
                        return node;
                    default:
                        // 异常处理
                        Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum, "语句不应以 " + currentToken.GetValue()
                                    + " 开头"));
                        MainFram.AddInformation("出现语法错误...");
                        //Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum, "语法错误"));
                        Expect(new String[] { "int", "real", "while", "read", "write", "if", "id", "{" });
                        switch (currentToken.Token_Value)
                        {
                            case "}":
                                goto labelInB;
                            default:
                                break;
                        }
                        break;
                }
            }
        labelInB:
            flag = Consume_token("}", node, new String[] { "}", "int", "real", "while", "read", "write", "if", "id", "{" });
            #region csjupdate
            removeVar(wkLev);
            wkLev--;
            #endregion
            return node;
        }

        /// <summary>
        /// 语句分析
        /// </summary>
        /// <returns>语法树</returns>
        private Node Statement()
        {
            MainFram.AddInformation("构建语法分析树，遇到声明statement...");
            Node node = new Node(TokenType.STATEMENT);

            temp = currentToken.Token_Value;
            switch (currentToken.Token_Value)
            {
                // 声明语句
                case "int":
                case "real":
                    node.Child.Add(Declaration());
                    flag = Consume_token(";", node,
                        new String[] { ";", "int", "real", "while", "read", "write", "if", "id", "{" });
                    break;
                // while语句
                case "while":
                    flag = Consume_token("while", node, new String[] { "while", "", "" });
                    flag = Consume_token("(", node,
                        new String[]{"(", "", "", "integer", "decimal", "id", "(", "*", "/", "+", "-", ">", "<", ">=",
                            "<=", "==", "!=", ")"});

                    #region dl update
                    // typecheck condition().typeof ?= (伪)bool
                    Node b = Condition();
                    if (!typeCheckOnBoolNeeded(b.Typeof))
                    {
                        // error while(后期待伪bool型(数值型),但没有得到期待的结果.
                        Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                            "while缺少布尔类型判断，此处缺少"));
                        MainFram.AddInformation("出现语法错误...");
                        //Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                        //    "语法错误"));
                        b.Typeof = null;
                    }
                    node.Child.Add(b);
                    #endregion

                    flag = Consume_token(")", node,
                        new String[] { ")", "{", "", "int", "real", "while", "read", "write", "if", "id", ";" });
                    node.Child.Add(Block());
                    break;
                // read语句
                case "write":
                    flag = Consume_token("write", node, new String[] { "", "", "" });
                    flag = Consume_token("(", node, new String[] {"(", "", "", "integer", "decimal", "id", "(", "*", "/"
                        ,"+", "-", ")", ";", "", "{", "", "int", "real", "while", "read", 
                        "write", "if"});
                    #region dl update
                    // typecheck expr().typeof ?= int or real 
                    Node e = Expression();
                    if (!numeric(e.Typeof))
                    {
                        // error write后的表达式的类型只能是数值型
                        Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                            "write输出数值型变量，此处非法"));
                        MainFram.AddInformation("出现语法错误...");
                        //Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                        //"语法错误"));

                        e.Typeof = null;
                    }
                    node.Child.Add(e);
                    #endregion

                    flag = Consume_token(")", node, new String[] { ")", ";", "", "{", "int", "real", "while", "read", 
                        "write", "if", "id"});
                    flag = Consume_token(";", node, new String[]{";", "", "", "{", "int", "real", "while", "read",
                        "write", "if", "id"});
                    break;

                // write语句
                case "read":
                    flag = Consume_token("read", node, new String[] { "", "", "" });
                    flag = Consume_token("(", node, new String[]{"(", "id", "", ",", ")", ";", "int", "real", "while", "read", 
                        "write", "if", "id", "}"});
                    flag = Consume_token("id", node, new String[]{"id", ")", ";", "int", "real", "while", "read", "write"
                        , "if","id", "{"});
                    #region dl update
                    // type check, declaration check
                    Variable id = getMRDVar(flag.GetValue(), wkLev);
                    // declaration check
                    if (id == null)
                    {
                        // error 引用未定义的变量
                        Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum,
                            "引用未定义的变量：" + flag.GetValue()));
                        MainFram.AddInformation("出现语法错误...");
                        //Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum,
                        //    "语法错误"));
                    }
                    else
                    {
                        // type check
                        if (!numeric(id.Typeof))
                        {
                            // error 不支持对非数值型的read调用
                            Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                                "不支持对非数值型read调用: " + flag.GetValue()));
                            MainFram.AddInformation("出现语法错误...");
                            //Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                            //"语法错误"));
                        }
                    }
                    #endregion

                    flag = Consume_token(")", node, new String[]{")", ";", "", "int", "real", "while", "read", "write"
                        ,"if", "id", "{"});
                    flag = Consume_token(";", node, new String[]{";", "", "", "int", "real", "while", "read", "write"
                        ,"if", "id", "{"});
                    break;

                // 赋值语句
                case "id":
                    flag = Consume_token("id", node, new String[] { "", "", "" });
                    #region dl
                    VarType ropshould = null;
                    //declare check 
                    Variable lop = getMRDVar(flag.GetValue(), wkLev);
                    if (lop == null)
                    {
                        // error 引用未定义的变量
                        Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                            "引用未定义的变量：" + flag.GetValue()));
                        MainFram.AddInformation("出现语法错误...");
                        //Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                        //    "语法错误"));
                    }
                    else
                    {
                        ropshould = lop.Typeof;
                    }
                    #endregion

                    //数组赋值
                    switch (currentToken.Token_Value)
                    {
                        case "[":
                            #region dl update
                            // typecheck var in table ?typeof  Array
                            if (lop != null)
                            {
                                TArray a = lop.Typeof as TArray;
                                if (a == null)
                                {
                                    // error 表lop为非数值型,这里却试图将其以数组对待赋值
                                    Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                                        "非数值类型不能以数组方式赋值: " + flag.GetValue()));
                                    MainFram.AddInformation("出现语法错误...");
                                    //        Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                                    //"语法错误"));
                                }
                                else
                                {
                                    ropshould = a.Typeof;
                                    if (!numeric(a.Typeof))
                                    {
                                        //忽略此处
                                        // error a的下一维不是基本的数值型
                                    }
                                }
                            }
                            #endregion
                            flag = Consume_token("[", node, new String[] { "", "", "" });
                            flag = Consume_token("integer", node, new String[] { "", "", "" });
                            flag = Consume_token("]", node, new String[] { "", "", "" });
                            break;
                        default:
                            //not array
                            // record type
                            break;
                    }
                    flag = Consume_token("=", node, new String[] {"=", "", "", "integer", "decimal", "id", "(", "*", "/",
                        "+", "-", ";", "{", "", "int", "real", "while", "read", 
                        "write", "if"});

                    #region dl update
                    // checktype p ?兼容 expr().typeof
                    Node ex = Expression();
                    if (flag != null)
                    {
                        if (!typeCheckOnAssign(ropshould, ex.Typeof))
                        {
                            // error 赋值语句左右类型不匹配
                            Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                                "赋值语句左右类型不匹配"));
                            MainFram.AddInformation("出现语法错误...");
                            //Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                            //    "语法错误"));
                        }
                    }
                    else
                    {
                        node.Typeof = ex.Typeof;
                    }
                    node.Child.Add(ex);
                    #endregion

                    flag = Consume_token(";", node, new String[]{";", "", "", "int", "real", "while", "read", "write"
                        , "if","id"});
                    break;

                 //语句
                case "if":
                    flag = Consume_token("if", node, new String[] { "", "", "" });
                    flag = Consume_token("(", node, new String[]{"(", "", "", "integer", "decimal", "integer", "decimal",
                        "id", "(", "*", "/", "+", "-", ">", "<", ">=", "<=", "==", "!=", ")"});

                    #region dl update
                    // typecheck cond().typeof ?is numeric
                    Node ifb = Condition();
                    if (!typeCheckOnBoolNeeded(ifb.Typeof))
                    {
                        // error if(后面期待的是伪bool(数值)型,结果没匹配到(可能是数组型,也可能是后面有错误)
                        Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                            "if后应有布尔类型判断"));
                        MainFram.AddInformation("出现语法错误...");
                        //Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                        //    "语法错误"));

                        ifb.Typeof = null;
                    }
                    node.Child.Add(ifb);
                    #endregion

                    flag = Consume_token(")", node,
                        new String[] { ")", "{", "", "int", "real", "while", "read", "write", "if", ";", "id" });
                    node.Child.Add(Block());
                    switch (currentToken.Token_Value)
                    {
                        case "else":
                            flag = Consume_token("else", node, new String[] { "", "", "" });
                            node.Child.Add(Block());
                            break;
                        default:
                            //if语句后无else语句
                            break;
                    }
                    break;
                //token以全部分析完毕，立即返回
                case "EOF":
                case "re-EOF":
                    return node;
                default:
                    // 不可达
                    break;
            }
            return node;
        }

        /// <summary>
        /// 声明
        /// </summary>
        /// <returns>语法树</returns>
        private Node Declaration()
        {
            MainFram.AddInformation("构建语法分析树，遇到declaration...");
            Node node = new Node(TokenType.DECLARATION);

            #region dl update
            VarType p = null;
            #endregion

            temp = currentToken.Token_Value;
            switch (currentToken.Token_Value)
            {
                case "int":
                    flag = Consume_token("int", node, new String[] { "", "", "" });

                    #region dl update
                    p = VarType.INT;
                    #endregion

                    break;
                case "real":
                    flag = Consume_token("real", node, new String[] { "", "", "" });

                    #region dl update
                    p = VarType.REAL;
                    #endregion

                    break;
                default:
                    //不可达
                    break;
            }

            #region dl update

            do
            {

            #endregion

                flag = Consume_token("id", node, new String[]{"id", ";", "", "int", "real", "if", "while"
                ,"read", "write", "{"});
                temp = currentToken.Token_Value;

                #region dl update
                //检查变量名在同层是否已被使用
                Variable id = null;
                // flag != null 表明语法正确
                if (flag != null)
                {
                    id = getVar(flag.GetValue(), wkLev);
                    if (id != null)
                    {
                        // error 同层已有名为id.Name的变量
                        Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                            "同层已有名为 " + id.Name + " 的变量"));
                        MainFram.AddInformation("出现语法错误...");
                        //Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                        //    "语法错误"));
                    }
                    else
                    {
                        id = new Variable(flag.GetValue(), p, wkLev);
                        //添加到变量表
                        addVar(id);
                    }
                }
                #endregion

                switch (currentToken.Token_Value)
                {
                    case "=":
                        flag = Consume_token("=", node, new String[] { "", "", "" });

                        #region dl update
                        // 检查类型
                        Node expr = Expression();
                        // if(p 不赋值兼容 e.Typeof ){报错} 

                        try
                        {
                            if (!typeCheckOnAssign(id.Typeof, expr.Typeof))
                            {
                                // error 赋值左右操作数类型不兼容
                                Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                                    "赋值语句左右类型不匹配"));
                                MainFram.AddInformation("出现语法错误...");
                                //Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                                //"语法错误"));
                            }
                            else
                            {
                                node.Typeof = expr.Typeof;
                            }
                        }
                        catch(Exception e)
                        {
                            Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum,
                                    "赋值语句左右类型不匹配"));
                        }
                        node.Child.Add(expr);
                        #endregion

                        break;
                    default:
                        //声明语句没用立即初始化，合法
                        break;
                }

                temp = currentToken.Token_Value;
                switch (currentToken.Token_Value)
                {
                    case "[":
                        flag = Consume_token("[", node, new String[] { "", "", "" });
                        flag = Consume_token("integer", node, new String[]{"integer", "]", ";", "int", "real", "if", "while"
                        , "read", "write","id", "{"});

                        #region dl update
                        int len = 0;
                        if (flag != null)
                        {
                            // record array length, need?
                            // len = Convert.ToInt32(flag.GetValue());
                        }
                        //更改p为数组
                        p = new TArray(p, len);
                        id.Typeof = p;
                        #endregion

                        flag = Consume_token("]", node, new String[]{"]", ";", "", "int", "real", "if", "while", "read"
                        , "write", "id", "{"});
                        break;
                    default:
                        //声明语句不是数组声明，合法
                        //不改变p
                        break;
                }

                #region dl update
                if (currentToken.Token_Value.Equals(","))
                {
                    flag = Consume_token(",", node, new String[] { "", "", "" });
                }
                else
                {
                    break;
                }
            } while (true);
                #endregion

            //    //连续多个变量的声明
            //    while (true)
            //    {
            //        temp = currentToken.Token_Value;
            //        switch (currentToken.Token_Value)
            //        {
            //            case ",":
            //                break;
            //            default:
            //                //无连续变量的声明，跳出循环
            //                goto lablel_inD;
            //        }
            //        flag = Consume_token(",", node, new String[] { "", "", "" });
            //        flag = Consume_token("id", node, new String[]{"id", ";", "", "int", "real", "if", "while", "read"
            //            ,"write", "{"});


            //        #region dl update
            //        // 添加变量到变量表
            //        if (flag != null)
            //        {

            //        } 
            //        #endregion
            //        temp = currentToken.Token_Value;
            //        switch (currentToken.Token_Value)
            //        {
            //            case "[":
            //                flag = Consume_token("[", node, new String[] { "", "", "" });
            //                flag = Consume_token("integer", node, new String[]{"integer", "]", ";", "int", "real", "if", "while"
            //                    ,"read", "write","id", "{"});
            //                flag = Consume_token("]", node, new String[]{"]", ";", "", "int", "real", "if", "while", "read"
            //                    , "write", "id", "{"});
            //                break;
            //            default:
            //                //声明语句不是数组声明，合法
            //                break;
            //        }
            //    }
            //lablel_inD:
            return node;
        }

        /// <summary>
        /// 条件分析
        /// </summary>
        /// <returns>语法树</returns>
        private Node Condition()
        {
            MainFram.AddInformation("构建语法分析树，遇到condition...");
            Node node = new Node(TokenType.CONDITION);

            #region dl update
            Node lop = Expression();
            node.Child.Add(lop);
            #endregion

            temp = currentToken.Token_Value;
            switch (currentToken.Token_Value)
            {
                case ">":
                    flag = Consume_token(">", node, new String[] { "", "", "" });
                    break;
                case "<":
                    flag = Consume_token("<", node, new String[] { "", "", "" });
                    break;
                case ">=":
                    flag = Consume_token(">=", node, new String[] { "", "", "" });
                    break;
                case "<=":
                    flag = Consume_token("<=", node, new String[] { "", "", "" });
                    break;
                case "==":
                    flag = Consume_token("==", node, new String[] { "", "", "" });
                    break;
                case "!=":
                    flag = Consume_token("!=", node, new String[] { "", "", "" });
                    break;
                //token以全部分析完毕，立即返回
                case "EOF":
                case "re-EOF":
                    return node;
                //缺少大于等符号
                default:
                    Expect(new String[]{">", "<", "==", "!=", ">=", "<=", ")", 
                        "{", "int", "real", "if", "while", "read", "write", "id"});
                    Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum,
                        currentToken.GetValue() + "应该为布尔运算符"));
                    MainFram.AddInformation("出现语法错误...");
                    //Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum, "语法错误"));
                    break;
            }


            #region dl update
            Node rop = Expression();
            node.Child.Add(rop);
            //type check
            if (typeCheckOnComparison(lop.Typeof, rop.Typeof))
            {
                //能比较,比较的结果为INT型(由于不支持bool型)
                node.Typeof = VarType.INT;
            }
            else
            {
                // error 没有正确的类型
                Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                    "比较运算前后操作数类型不匹配"));
                MainFram.AddInformation("出现语法错误...");
                //Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                //            "语法错误"));
                node.Typeof = null;
            }
            #endregion

            return node;
        }

        /// <summary>
        /// 表达式
        /// </summary>
        /// <returns>语法树</returns>
        private Node Expression()
        {
            MainFram.AddInformation("构建语法分析树，遇到expression...");
            Node node = new Node(TokenType.EXPRESSION);

            #region dl update
            Node lt = Term();
            //type check
            if (flag != null)
            {
                if (!numeric(lt.Typeof))
                {
                    // error 非数值型(也就剩数组类型了)不能 + -运算
                    Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum,
                        "该类型无法进行此项运算"));
                    MainFram.AddInformation("出现语法错误...");
                    //Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum,
                    //        "语法错误"));
                    node.Typeof = null;
                }
                else
                {
                    node.Typeof = lt.Typeof;
                }
            }
            node.Child.Add(lt);
            #endregion

            while (true)
            {
                temp = currentToken.Token_Value;
                switch (currentToken.Token_Value)
                {
                    case "+":
                        flag = Consume_token("+", node, new String[] { "", "", "" });
                        break;
                    case "-":
                        flag = Consume_token("-", node, new String[] { "", "", "" });
                        break;
                    default:
                        goto labelInE;
                }
                #region MyRegion
                //type check 
                Node rt = Term();
                if (flag != null)
                {
                    if (!numeric(rt.Typeof))
                    {
                        // error 非数值型(也就剩数组类型了)不能 + - 运算
                        Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum,
                            "该类型无法进行此项运算"));
                        MainFram.AddInformation("出现语法错误...");
                        //Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum,
                        //    "语法错误"));
                        node.Typeof = null;
                    }
                    else
                    {
                        node.Typeof = maxType(node.Typeof, rt.Typeof);
                    }
                }
                node.Child.Add(rt);
                #endregion

            }
        labelInE:
            return node;
        }

        /// <summary>
        /// 项分析
        /// </summary>
        /// <returns>语法树</returns>
        private Node Term()
        {
            MainFram.AddInformation("构建语法分析树，遇到term...");
            Node node = new Node(TokenType.TERM);

            #region dl update
            Node lf = Factor();
            //type check
            if (flag != null)
            {
                if (!numeric(lf.Typeof))
                {
                    // error 非数值型(也就剩数组类型了)不能 * /运算 a[1.2]
                    Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum,
                            "该类型无法进行此项运算"));
                    MainFram.AddInformation("出现语法错误...");
                    //Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum,
                    //        "语法错误"));
                    node.Typeof = null;
                }
                else
                {
                    node.Typeof = lf.Typeof;
                }
            }
            node.Child.Add(lf);
            #endregion

            while (true)
            {
                temp = currentToken.Token_Value;
                switch (currentToken.Token_Value)
                {
                    case "*":
                        flag = Consume_token("*", node, new String[] { "", "", "" });
                        break;
                    case "/":
                        flag = Consume_token("/", node, new String[] { "", "", "" });
                        break;
                    default:
                        goto labelInT;
                }

                #region MyRegion
                //type check 
                Node rf = Factor();
                if (!numeric(rf.Typeof))
                {
                    // error 非数值型(也就剩数组类型了)不能 * /运算
                    Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                        "该类型无法进行此项运算"));
                    MainFram.AddInformation("出现语法错误...");
                    node.Typeof = null;
                }
                else
                {
                    node.Typeof = maxType(node.Typeof, rf.Typeof);
                }
                node.Child.Add(rf);
                #endregion

            }
        labelInT:
            return node;
        }

        /// <summary>
        /// 因子分析
        /// </summary>
        /// <returns>语法树</returns>
        private Node Factor()
        {
            MainFram.AddInformation("构建语法分析树，遇到factor...");
            Node node = new Node(TokenType.FACTOR);
            temp = currentToken.Token_Value;
            switch (currentToken.Token_Value)
            {
                case "(":
                    flag = Consume_token("(", node, new String[] { "", "", "" });

                    #region dl update
                    Node expr = Expression();
                    node.Typeof = expr.Typeof;
                    node.Child.Add(expr);
                    #endregion

                    flag = Consume_token(")", node, new String[] { ")", "", "" });
                    break;
                case "integer":
                    flag = Consume_token("integer", node, new String[] { "", "", "" });

                    #region dl update
                    node.Typeof = VarType.INT;
                    #endregion

                    break;
                case "decimal":
                    flag = Consume_token("decimal", node, new String[] { "", "", "" });

                    #region dl update
                    node.Typeof = VarType.REAL;
                    #endregion

                    break;
                case "id":
                    flag = Consume_token("id", node, new String[] { "", "", "" });

                    #region dl update
                    Variable id = getMRDVar(flag.GetValue(), this.wkLev);
                    if (id == null)
                    {
                        // error: 访问未定义的变量
                        Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                        "引用未定义的变量：" + flag.GetValue()));
                        MainFram.AddInformation("出现语法错误...");
                        node.Typeof = null;
                    }
                    else
                    {
                        node.Typeof = id.Typeof;
                    }
                    #endregion
                    switch (currentToken.Token_Value)
                    {
                        //数组访问
                        case "[":
                            #region dl update
                            if (id != null)
                            {
                                TArray p = id.Typeof as TArray;
                                if (p == null)
                                {
                                    // error 变量表中id不是数组类型,而尝试进行数组访问
                                    Errors.Add(new Error(Error.ErrorType.GRAMMAR, flag.LineNum,
                                        "变量表中 " + flag.GetValue() + " 不是数组类型,尝试进行数组访问"));
                                    MainFram.AddInformation("出现语法错误...");
                                    node.Typeof = null;
                                }
                                else
                                {
                                    node.Typeof = p.Typeof;
                                }
                            }
                            #endregion
                            flag = Consume_token("[", node, new String[] { "", "", "" });
                            #region dl update
                            if (flag == null)
                                node.Typeof = null;
                            #endregion
                            flag = Consume_token("integer", node, new String[] { "", "", "" });
                            #region dl update
                            if (flag == null)
                                node.Typeof = null;
                            #endregion
                            flag = Consume_token("]", node, new String[] { "", "", "" });
                            #region dl update
                            if (flag == null)
                                node.Typeof = null;
                            #endregion
                            break;
                        default:
                            break;
                    }

                    break;
                //token以全部分析完毕，立即返回
                case "EOF":
                case "re-EOF":
                    return node;
                default:
                    //异常处理
                    Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum,
                        currentToken.Token_Value + " 前 " +
                        "缺少因子"));
                    MainFram.AddInformation("出现语法错误...");
                    //Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum, "语法错误"));
                    Expect(new String[]{")", "integer", "decimal", "(", ";", "int", "real"
                        , "if", "while", "read", "write", "{", "id"});

                    #region dl update
                    node.Typeof = null;
                    #endregion

                    break;
            }
            return node;
        }

        /// <summary>
        /// 将当前token置为期待的权重距离最近的token
        /// </summary>
        /// <param name="expectedWords"></param>
        private void Expect(String[] expectedWords)
        {
            int tempCursor = cursor;
            PriorityIndex nearextIndex = new PriorityIndex(tokens.Count, -1);
            PriorityIndex cursorIndex = new PriorityIndex(cursor, 0);
            foreach (String expectWord in expectedWords)
            {
                while (!currentToken.Token_Value.Equals(expectWord) && currentToken.TokenType != TokenType.EOF)
                {
                    Next();
                }
                cursorIndex.Index = cursor;
                if (currentToken.Token_Value.Equals(expectedWords[0]))
                {
                    cursorIndex.Weight = 3;
                    cursorIndex.Index = cursor;
                }
                else if (currentToken.Token_Value.Equals(expectedWords[1]))
                {
                    cursorIndex.Weight = 2;
                    cursorIndex.Index = cursor;
                }
                else if (currentToken.Token_Value.Equals(expectedWords[2]))
                {
                    cursorIndex.Weight = 1;
                    cursorIndex.Index = cursor;
                }
                //if (cursorIndex.Weight > nearextIndex.Weight)
                //{
                //    nearextIndex = cursorIndex.Clone();
                //}
                //else if (cursorIndex.Weight == nearextIndex.Weight && cursorIndex.Index < nearextIndex.Index)
                //{
                //    nearextIndex = cursorIndex.Clone();
                //}
                if (cursorIndex.Index - cursorIndex.Weight < nearextIndex.Index - nearextIndex.Weight)
                {
                    nearextIndex = cursorIndex.Clone();
                }

                cursor = tempCursor;
                if (cursor < tokens.Count)
                {
                    currentToken = tokens[cursor];
                }
            }

            cursor = nearextIndex.Index;
            if (cursor < tokens.Count)
            {
                currentToken = tokens[cursor];
            }
            else
            {
                currentToken = new Token(TokenType.EOF, "EOF", tokens[tokens.Count - 1].LineNum);
            }
        }

        private Token Consume_token(String needValue, Node node, String[] expectedFollowWords)
        {
            #region dl update
            Token t = null;
            #endregion

            #region cjsupdate
            String supplyValue = currentToken.Token_Value;
            #endregion

            try
            {
                //当前token是所需要的token
                if (supplyValue.Equals(needValue))
                {
                    #region csjupdate
                    supplyValue = currentToken.GetValue();
                    #endregion

                    switch (currentToken.TokenType)
                    {
                        case TokenType.RSERVEED_WORD:
                            node.Child.Add(new Node(TokenType.RSERVEED_WORD, supplyValue));
                            break;
                        case TokenType.ID:
                            node.Child.Add(new Node(TokenType.ID, supplyValue));
                            break;
                        case TokenType.INTEGER:
                            node.Child.Add(new Node(TokenType.INTEGER, supplyValue));
                            break;
                        case TokenType.DECIMAL:
                            node.Child.Add(new Node(TokenType.DECIMAL, supplyValue));
                            break;
                        case TokenType.DELIMITER:
                            node.Child.Add(new Node(TokenType.DELIMITER, supplyValue));
                            break;
                        case TokenType.NUM_OPERATOR:
                            node.Child.Add(new Node(TokenType.NUM_OPERATOR, supplyValue));
                            break;
                        case TokenType.BOOL_OPERATOR:
                            node.Child.Add(new Node(TokenType.BOOL_OPERATOR, supplyValue));
                            break;
                        case TokenType.ASSIGNMENT:
                            node.Child.Add(new Node(TokenType.ASSIGNMENT, supplyValue));
                            break;
                        default:
                            //不可达
                            break;
                    }
                    #region dl update
                    t = currentToken;
                    #endregion
                }
                //下个token不是所需要的token
                else
                {
                    #region csjupdate
                    supplyValue = currentToken.GetValue();
                    #endregion

                    if (currentToken.Token_Value.Equals("EOF") && !currentToken.Token_Value.Equals("re-EOF"))
                    {
                        supplyValue = previousToken.GetValue();
                        Errors.Add(new Error(Error.ErrorType.GRAMMAR, previousToken.LineNum,
                            supplyValue + " 后 " + "需要"+needValue ));
                        MainFram.AddInformation("出现语法错误...");
                        //Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum, "语法错误"));
                    }
                    else if (!currentToken.Token_Value.Equals("re-EOF"))
                    {
                        /***
                        if(needValue==";")
                        {
                            Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum - 1,
                                "应输入：；"));
                        }
                        else
                        {
                        

                        }
                        ***/
                        Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum,
                                supplyValue + " 前 " + "需要"+needValue));
                        MainFram.AddInformation("出现语法错误...");
                        //Errors.Add(new Error(Error.ErrorType.GRAMMAR, currentToken.LineNum, "语法错误"));
                    }

                    if (!currentToken.Token_Value.Equals("EOF") && !currentToken.Token_Value.Equals("re-EOF"))
                    {
                        Expect(expectedFollowWords);
                    }

                    if (!currentToken.Token_Value.Equals(needValue) && !currentToken.Token_Value.Equals("EOF")
                            && !currentToken.Token_Value.Equals("re-EOF"))
                    {
                        cursor--;
                    }
                }
            }
            finally
            {
                //更新currentToken
                Next();
            }

            #region dl update
            return t;
            #endregion
        }

        /**
         * 更新nextToken，使其为当前token的下一个
         */
        private void Next()
        {
            //更新nextToken
            previousToken = currentToken;
            if (++cursor < tokens.Count)
            {

                currentToken = tokens[cursor];
            }
            else
            {
                if (currentToken.Token_Value.Equals("EOF") || currentToken.Token_Value.Equals("re-EOF"))
                {
                    currentToken.Token_Value = "re-EOF";
                }
                else
                {
                    currentToken = new Token(TokenType.EOF, "EOF", currentToken.LineNum);
                }
            }
        }

        /**
         * 返回语法分析过程中的错误
         * @return 语法分析过程中的错误
         */
        public List<Error> GetErrors()
        {
            return this.Errors;
        }

        /// <summary>
        /// 程序语法是否有错
        /// </summary>
        /// <returns>程序语法有错时返回true，无错时返回false</returns>
        public bool HasGrammarError()
        {
            return Errors.Count != 0;
        }

        /// <summary>
        /// 表示带有权重的索引
        /// </summary>
        private class PriorityIndex
        {
            public int Index { get; set; }
            public int Weight { get; set; }

            public PriorityIndex(int iniIndex, int iniWeight)
            {
                Index = iniIndex;
                Weight = iniWeight;
            }

            public PriorityIndex Clone()
            {
                return new PriorityIndex(this.Index, this.Weight);
            }
        }

        #region dl updated

        /// <summary>
        /// 记录当前工作层
        /// </summary>
        private int wkLev = 0;
        /// <summary>
        ///  变量表
        /// </summary>
        private List<Variable> varTable = new List<Variable>();
        /// <summary>
        /// 向变量表中添加条目
        /// </summary>
        /// <param name="id">变量名</param>
        /// <param name="p">变量类型</param>
        /// <param name="lev">变量的层次</param>
        void addVar(string id, VarType p, int lev)
        {
            varTable.Add(new Variable(id, p, lev));
        }
        /// <summary>
        /// 向变量表中添加条目
        /// </summary>
        /// <param name="v">准备添加的变量</param>
        void addVar(Variable v)
        {
            varTable.Add(v);
        }

        #region csjupdate
        /// <summary>
        /// 从变量表中删除层次为lev的变量
        /// </summary>
        /// <param name="lev">需删除变量的层次</param>
        void removeVar(int lev)
        {
            for (int i = 0; i < varTable.Count; i++)
            {
                if (varTable[i].LEV == lev)
                {
                    //移除变量表中与指定层次相同层次的变量
                    varTable.RemoveAt(i);
                    i--;
                }
            }
        }
        #endregion

        /// <summary>
        /// 从变量表中取名为id,层次严格对应lev层的变量,如果没有,返回null
        /// </summary>
        /// <param name="id">变量名</param>
        /// <param name="lev">想要取lev(而不是其他任何层)的变量</param>
        /// <returns>对应Variable或null</returns>
        Variable getVar(string id, int lev)
        {
            foreach (Variable v in varTable)
            {
                if (v.Name.Equals(id) && v.LEV == lev)
                    return v;
            }
            return null;
        }
        /// <summary>
        /// 获取离工作层wkLev最近的位置且已声明的名为id的变量
        /// </summary>
        /// <param name="id">变量名</param>
        /// <param name="wkLev">工作层</param>
        /// <returns>如果找到,返回最近声明(Most Recently Declared)的变量,否则null</returns>
        Variable getMRDVar(string id, int wkLev)
        {
            //
            Variable mrdVar = null;
            int minoffset = int.MaxValue;
            foreach (Variable v in varTable)
            {
                if (v.Name == id)
                {
                    //在wkLev层可以访问到id
                    if (mrdVar != null && wkLev >= v.LEV)
                    {
                        int offset = (wkLev - mrdVar.LEV);
                        // offset < minoffset表明这v要是比在wkLev往上minoffset层更近的变量
                        if (offset < minoffset)
                        {
                            minoffset = offset;
                            mrdVar = v;
                        }
                    }

                    // 第一次访问到名为id的生命周期未在wkLev层结束的变量
                    else if (mrdVar == null && wkLev >= v.LEV)
                    {
                        mrdVar = v;
                    }
                }
            }

            return mrdVar;
            //return (mrp==-1)?null:varTable.ElementAt(mrp);
        }
        /// <summary>
        /// 判断名为id,层次严格对应第lev层的变量是否存在于变量表中
        /// </summary>
        /// <param name="id">变量名</param>
        /// <param name="lev">想要搜索的层次</param>
        /// <returns>true(第lev层有名为id的变量), false(第lev层没有名为id的变量)</returns>
        bool hasVar(string id, int lev)
        {
            foreach (Variable v in varTable)
            {
                if (v.Name.Equals(id) && v.LEV == lev)
                    return true;
            }
            return false;
            // same as     return getVar(id,lev)!=null;
        }


        /// <summary>
        /// 返回p1, p2的"较兼容"的类型(实例),
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>如果都是数组且维数相同返回p1,如果都是VarType.INT返回VarType.INT,如果有一个(p1或p2)是VarType.REAL,
        /// 另一个(p2或p1)是VarType.INT或VarType.REAL返回VarType.REAL(p1或p2),
        /// 否则返回null</returns>
        VarType maxType(VarType p1, VarType p2)
        {

            if (p1 == p2)
            {
                //p1 p2同属INT或同属REAL在此情况
                return p1;
            }

            else if ((p1 is TArray) && (p2 is TArray))
            {
                if ((p1 as TArray).Dim == (p1 as TArray).Dim)
                {
                    return p1;
                }
                else
                {
                    return null;
                }
            }
            else if ((p1 == VarType.REAL && p2 == VarType.INT) || (p1 == VarType.INT && p2 == VarType.REAL))
            {
                return VarType.REAL;
            }
            else if (p1 == VarType.INT && p2 == VarType.INT)
            {
                return VarType.INT;
            }
            return null;
        }

        /// <summary>
        /// 赋值时的类型检查,左右类型正确(兼容)返回true,否则false
        /// </summary>
        /// <param name="left">左操作数的类型</param>
        /// <param name="right">右操作数的类型</param>
        /// <returns></returns>
        bool typeCheckOnAssign(VarType left, VarType right)
        {
            return (numeric(left) && numeric(right) && (maxType(left, right) == left));
        }

        /// <summary>
        /// 比较运算符的左右类型(兼容性)检查
        /// </summary>
        /// <param name="lop"></param>
        /// <param name="rop"></param>
        /// <returns></returns>
        bool typeCheckOnComparison(VarType lop, VarType rop)
        {
            return (numeric(lop) && numeric(rop));
        }

        /// <summary>
        /// 判断p是否是数值类型
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool numeric(VarType p)
        {
            //如果是VarType.INT 或 VarType.REAL返回true,否则false
            return p == VarType.INT || p == VarType.REAL;
        }

        /// <summary>
        /// 检查p是否可以作为(伪)bool型(数值型)
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        bool typeCheckOnBoolNeeded(VarType p)
        {
            return numeric(p);
        }
        #endregion

        /// <summary>
        /// 合并重复错误
        /// </summary>
        void CombineError()
        {
            for (int i = 0; i < Errors.Count; i++)  //外循环是循环的次数
            {
                for (int j = Errors.Count - 1; j > i; j--)  //内循环是 外循环一次比较的次数
                {

                    if (Errors[i].Type == Errors[j].Type&& Errors[i].LineNo == Errors[j].LineNo
                        && Errors[i].Dec == Errors[j].Dec)
                    {
                        Errors.RemoveAt(j);
                    }
                    //去除重复
                }
            }
            //去重后重新排列
            LineCheck();
            //去除第0行bug
            ClearZero();
        }

        /// <summary>
        /// 去除排序产生的第0行错误
        /// </summary>
        void ClearZero()
        {
            for(int i=0;i<Errors.Count;i++)
            {
                //if(er.LineNo==0)
                //{
                //    Errors.Remove(er);
                //}
                if(Errors[i].LineNo==0)
                {
                    Errors.RemoveAt(i);
                }
            }
        }
        ///<summary>
        ///error check 检查；排序
        /// </summary>
        void LineCheck()
        {
            //升序排列
            Errors.Sort((x, y) => (x.LineNo).CompareTo(y.LineNo));
        }

        ///<summary>
        ///bracket match check
        ///</summary>
        void MatchCheck()
        {
            int position = matchBracket(content);
            int j = getLineNum(position);
            //textBox2.Text = "第" + j.ToString() + "行" + reason;
            Errors.Add(new Error(Error.ErrorType.GRAMMAR, j, reason));
        }
        public int matchBracket(string content)
        {
            string position;
            //int[] num = new int[100];
            int i = 0;
            int num = 0;
            //符号是否正确
            if (content == null)
            {
                return 0;
            }
            else
            {
                Stack<char> stack = new Stack<char>();

                for (; i < content.Length; i++)
                {
                    char current = content[i];
                    switch (current)
                    {
                        case '(':
                        case '[':
                        case '{':
                            {
                                num++;
                                stack.Push(current);

                                break;
                            }

                        case ')':
                        case ']':
                        case '}':
                            if (stack.Count <= 0)
                            {

                                position = num.ToString();
                                //reason += "第" + position + "个括号不匹配";
                                reason += "括号不匹配";
                                return num;
                            }
                            else
                            {
                                num++;
                                char top = stack.Peek();
                                if (IsCouple(top, current))
                                {
                                    stack.Pop();
                                }
                                else
                                {
                                    position = num.ToString();
                                    //reason += "第" + position + "个括号顺序有误";
                                    reason += "括号顺序错误";
                                    return num;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                if (stack.Count <= 0)
                    return 0;
                else
                {
                    position = num.ToString();
                    //reason += "第" + position + "个括号不匹配";
                    reason += "括号不匹配";
                    return num;
                }

            }
        }
        static bool IsCouple(char left, char right)
        {
            if (left == '(' && right == ')')
            {
                return true;
            }
            if (left == '[' && right == ']')
            {
                return true;
            }
            if (left == '{' && right == '}')
            {
                return true;
            }
            return false;
        }

        public int getLineNum(int position)
        {
            int num = 0;
            string str = content;
            string[] array = str.Split('\n');
            for (int i = 0; i < array.Length; i++)
            {
                char[] chars = array[i].ToCharArray();
                foreach (char ch in chars)
                {
                    //判断是不是括号
                    if (ch == '(' || ch == '[' || ch == '{' || ch == ')' || ch == ']' || ch == '}')
                    {
                        num++;
                        if (position == num)
                        {
                            return i + 1;
                        }

                    }

                    //如果是括号 num++;
                    //如果position = num
                    //return i;
                }
            }
            return 0;

        }
    }
}
