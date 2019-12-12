using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using interpreter.Process;
using System.IO;
using interpreter.Process.Grammar;
using interpreter.Process.Lexical;
using interpreter.Process.Utils;
using interpreter.Process.MiddleCode;

namespace interpreter.ui
{
    public partial class MainFram : Form
    {
        /// <summary>
        /// 上一次选中文本的开始
        /// </summary>
        private int lastSelStart = 0;


        public MainFram()
        {
            InitializeComponent();
        }

        public static void AddInformation(string str)
        {
            if (processRichTextBox.Text == "")
            {
                processRichTextBox.Text = processRichTextBox.Text + str;
            }
            else
            {
                processRichTextBox.Text = processRichTextBox.Text + "\t\n" + str;
            }
        }
        /// <summary>
        /// 词法分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lexicalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearText();
            AddInformation("开始进行词法分析...");
            if (!inputRichTextBox.Text.Equals(""))
            {
                lexicalRichTextBox.Clear();
                errorListView.Items.Clear();
                string content = inputRichTextBox.Text;
                TokenBuilder tb = new TokenBuilder(content);
                while (tb.hasMoreLines())
                {
                    lexicalRichTextBox.AppendText(tb.getCurrenLineNumber() + ": "
                        + tb.getCurrentLine() + "\n");
                    foreach (Token t in tb.nextTokens())
                    {
                        if (t.GetTokenType() != TokenType.ANNOTATION)
                        {
                            lexicalRichTextBox.AppendText("\t" + t.ToString() + "\n");
                        }
                    }
                }
            }
            //输入程序为空
            else
            {
                MessageBox.Show("请输入程序", "Interpreter",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);            
            }
            inputRichTextBox.Focus();

            AddInformation("词法分析结束...");
            ////存在词法分析错误
            //if (tb.hasLexicalError())
            //{
            //    List<Error> errors = tb.Errors;
            //    for(int i = 0; i < errors.Count; i++)
            //    {
            //        Error error = errors[i];
            //        ListViewItem item = new ListViewItem(new String[]{error.Dec, error.LineNo+"", i+1+""});
            //        errorListView.Items.Add(item);
            //    }
            //}
        }

        /// <summary>
        /// 在语法分析输出box中输出语法分析结果
        /// </summary>
        /// <param name="node"></param>
        /// <param name="spaces"></param>
        private void PrintNode(Node node, String spaces)
        {
            //AddInformation("打印语法分析结果...");
            switch (node.Type)
            {
                case TokenType.PROCEDURE:
                case TokenType.SUBPROGRAM:
                case TokenType.BLOCK:
                case TokenType.CONDITION:
                case TokenType.DECLARATION:
                case TokenType.EXPRESSION:
                case TokenType.FACTOR:
                case TokenType.STATEMENT:
                case TokenType.TERM:
                    //grammarRichTextBox.AppendText(spaces + node.Type + "\n");
                    break;
                default:
                    //grammarRichTextBox.AppendText(String.Format("{0}{1}: {2}\n", spaces, node.Type, node.Value));
                    break;
            }
            if (node.Child != null)
            {
                spaces += "  ";
                foreach (Node subNode in node.Child)
                {
                    PrintNode(subNode, spaces);
                }
            }
            //AddInformation("语法分析结果打印完毕...");
            return;
        }

        /// <summary>
        /// 先进行词法分析，若词法分析无误则进行语法语义分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grammarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearText();
            //输入内容不为空
            AddInformation("开始进行词法分析...");
            if (!inputRichTextBox.Text.Equals(""))
            {
                lexicalRichTextBox.Clear();
                errorListView.Items.Clear();
                string content = inputRichTextBox.Text;
                TokenBuilder tb = new TokenBuilder(content);
                while (tb.hasMoreLines())
                {
                    lexicalRichTextBox.AppendText(tb.getCurrenLineNumber() + ": "
                        + tb.getCurrentLine() + "\n");
                    foreach (Token t in tb.nextTokens())
                    {
                        if (t.GetTokenType() != TokenType.ANNOTATION)
                        {
                            lexicalRichTextBox.AppendText("\t" + t.ToString() + "\n");
                        }
                    }
                }
                AddInformation("词法分析结束...");
                //存在词法分析错误
                if (tb.hasLexicalError())
                {
                    AddInformation("词法分析错误...");
                    MessageBox.Show("程序存在错误, 请先检查", "Interpreter",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    List<Error> errors = tb.Errors;
                    for (int i = 0; i < errors.Count; i++)
                    {
                        Error error = errors[i];
                        ListViewItem item = new ListViewItem(new String[] { error.Dec, error.LineNo + "", i + 1 + "" });
                        errorListView.Items.Add(item);
                    }
                }
                //词法分析不存在错误进行语法分析
                else
                {
                    AddInformation("开始进行语法分析...");
                    //grammarRichTextBox.Clear();
                    GrammerAnalyzer ga = new GrammerAnalyzer(content);
                    Node tree = ga.Analyze();
                    PrintNode(tree, "");
                    //grammarTabPage.Focus();
                    //grammarTabPage.Show();

                    if (ga.HasGrammarError())
                    {
                        AddInformation("存在语法错误等待修改...");
                        List<Error> errors = ga.Errors;
                        for (int i = 0; i < errors.Count; i++)
                        {
                            Error error = errors[i];
                            ListViewItem item = new ListViewItem(new String[] { error.Dec, error.LineNo + "", i + 1 + "" });
                            errorListView.Items.Add(item);
                        }
                    }
                }
            }
            //输入程序为空
            else
            {
                MessageBox.Show("程序存在错误, 请先检查", "Interpreter",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            inputRichTextBox.Focus();
        }

        /// <summary>
        /// 开始执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearText();
            //输入内容不为空
            if (!inputRichTextBox.Text.Equals(""))
            {
                AddInformation("开始进行词法分析...");
                //先进行词法分析
                lexicalRichTextBox.Clear();
                errorListView.Items.Clear();
                string content = inputRichTextBox.Text;
                TokenBuilder tb = new TokenBuilder(content);
                while (tb.hasMoreLines())
                {
                    lexicalRichTextBox.AppendText(tb.getCurrenLineNumber() + ": "
                        + tb.getCurrentLine() + "\n");
                    foreach (Token t in tb.nextTokens())
                    {
                        if (t.GetTokenType() != TokenType.ANNOTATION)
                        {
                            lexicalRichTextBox.AppendText("\t" + t.ToString() + "\n");
                        }
                    }
                }
                AddInformation("词法分析结束...");
                //存在词法分析错误
                if (tb.hasLexicalError())
                {
                    AddInformation("存在词法错误等待修改...");
                    MessageBox.Show("程序存在错误, 请先检查", "Interpreter",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    List<Error> errors = tb.Errors;
                    for (int i = 0; i < errors.Count; i++)
                    {
                        Error error = errors[i];
                        ListViewItem item = new ListViewItem(new String[] { error.Dec, error.LineNo + "", i + 1 + "" });
                        errorListView.Items.Add(item);
                    }
                }
                //词法分析不存在错误进行语法分析
                else
                {
                    AddInformation("开始进行语法分析...");
                    //grammarRichTextBox.Clear();
                    GrammerAnalyzer ga = new GrammerAnalyzer(content);
                    Node tree = ga.Analyze();
                    PrintNode(tree, "");
                    AddInformation("语法分析结束...");
                    if (ga.HasGrammarError())
                    {
                        AddInformation("存在语法错误等待修改...");
                        MessageBox.Show("程序存在错误, 请先检查", "Interpreter",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        List<Error> errors = ga.Errors;
                        for (int i = 0; i < errors.Count; i++)
                        {
                            Error error = errors[i];
                            ListViewItem item = new ListViewItem(new String[] { error.Dec, error.LineNo + "", i + 1 + "" });
                            errorListView.Items.Add(item);
                        }
                    }
                    //当语法分析不存在错误时进行解释执行
                    else
                    {
                        AddInformation("开始解释执行...");
                        intermediateTabPage.Focus();
                        intermediateTabPage.Show();
                        String result = "";
                        intermediateRichTextBox.Clear();
                        AddInformation("中间代码生成中...");
                        List<TempCode> TreeNode = new MiddleCode(content).getMiddleCode();
                        AddInformation("执行...");
                        new Execute(content).Run();
                        for (int i = 0; i < TreeNode.Count; ++i)
                        {
                            result += "(" + TreeNode[i].fc.op + "," + TreeNode[i].fc.arg1 + "," + TreeNode[i].fc.arg2 + ","
                                + TreeNode[i].fc.result + ")" + "\n";
                        }
                        //List<Table> list = new MiddleCode(content).getTable();
                        //for (int i = 0; i < list.Count; ++i)
                        //{
                        //    result += list[i].str + "," + list[i].value + "," + list[i].type + "\n";
                        //}
                        intermediateRichTextBox.Text = result;
                    }
                    AddInformation("执行完毕...");
                }
            }
            //输入程序为空
            else
            {
                MessageBox.Show("程序存在错误, 请先检查", "Interpreter",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            inputRichTextBox.Focus();
        }

        /// <summary>
        /// 双击列表项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void errorListView_DoubleClick(object sender, EventArgs e)
        {
            if (errorListView.SelectedItems.Count != 0)
            {
                int lineNo = Convert.ToInt32(errorListView.SelectedItems[0].SubItems[1].Text);
                int startIndex = inputRichTextBox.GetFirstCharIndexFromLine(lineNo - 1);
                inputRichTextBox.Select(startIndex, inputRichTextBox.Lines[lineNo - 1].Length);
                inputRichTextBox.Focus();
            }
        }

        private string lastOpenFile = Application.ExecutablePath;
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lastStatus = statusLabel.Text;
            statusLabel.Text = "打开文件...";
            string fpath = lastOpenFile;
            openFileDialog.InitialDirectory = fpath.Substring(0, fpath.LastIndexOf('\\'));
            openFileDialog.FileName = "";
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "CMM source files (*.cmm)|*.cmm|All files (*.*)|*.*";
            //openFileDialog.Filter = "source files (*.txt)|*.txt|All files (*.*)|*.*";
            String content = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream input = null;
                try
                {
                    if ((input = openFileDialog.OpenFile()) != null)
                    {

                        StreamReader reader = new StreamReader(input,
                            System.Text.Encoding.GetEncoding("GB2312"));
                        content = reader.ReadToEnd();
                        inputRichTextBox.Text = content;
                        reader.Close();
                        input.Close();
                        statusLabel.Text = "打开文件成功";
                        lastOpenFile = openFileDialog.FileName;
                    }
                }
                catch (Exception)
                {
                    statusLabel.Text = "打开文件失败";
                }
            }
            statusLabel.Text = lastStatus;

            //更新输入richtextbox，关键字着色
            this.inputRichTextBox.Clear();
            this.inputRichTextBox.Text = content;
        }


        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "";
            saveFileDialog.Filter = "CMM source files (*.cmm)|*.cmm|All files (*.*)|*.*";
            //saveFileDialog.Filter = "source files (*.txt)|*.txt|All files (*.*)|*.*";
            Stream myStream = null;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = saveFileDialog.OpenFile()) != null)
                    {
                        // 保存代码至指定文件
                        StreamWriter sr = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("GB2312"));
                        sr.Write(inputRichTextBox.Text);
                        sr.Close();
                        myStream.Close();
                        statusLabel.Text = "文件保存成功";
                    }
                }
                catch (Exception)
                {
                    statusLabel.Text = "文件保存失败";
                }
            }
        }

        
        private void inputRichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            int start = inputRichTextBox.SelectionStart;
            int cur = start;
            int row, col;
            if (cur == lastSelStart)        // 朝后选择文本
            {
                cur += inputRichTextBox.SelectionLength;
            }
            row = inputRichTextBox.GetLineFromCharIndex(cur);
            col = cur - inputRichTextBox.GetFirstCharIndexFromLine(row);
            rowLabel.Text = (row + 1).ToString();
            columnLabel.Text = (col + 1).ToString();
            lastSelStart = start;
        }

        private void inputRichTextBox_TextChanged(object sender, EventArgs e)
        {
            errorListView.Items.Clear();
        }
            
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                inputRichTextBox.Focus();
            }
            return base.ProcessDialogKey(keyData);
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputRichTextBox.Undo();
        }

        private void 重做ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputRichTextBox.Redo();
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputRichTextBox.SelectedText.Length > 0)
            {
                inputRichTextBox.Cut();
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 判断是否选中文本
            if (inputRichTextBox.SelectedText.Equals(""))
                return;
            Clipboard.SetDataObject(inputRichTextBox.SelectedText, true);
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                粘贴ToolStripMenuItem.Enabled = true;
                inputRichTextBox.Paste();
            }
            else
            {
                粘贴ToolStripMenuItem.Enabled = false;
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputRichTextBox.SelectedText.Length > 0)
            {
                inputRichTextBox.SelectedText = "";
            }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputRichTextBox.SelectAll();
        }

        private void 最大化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void 最小化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ClearText()
        {
            lexicalRichTextBox.Text = "";
            intermediateRichTextBox.Text = "";
            outputRichTextBox.Text = "";
            processRichTextBox.Text = "";
        }
    }
}










