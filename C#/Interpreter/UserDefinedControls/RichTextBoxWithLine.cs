using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using interpreter.Process.Utils;
using interpreter.Process.Lexical;

namespace interpreter.userDefinedControls
{
    public class RichTextBoxWithLine : RichTextBox
    {
        private Panel lineNumPanel;
        /// <summary>
        /// 记录原内容的行数
        /// </summary>
        private int oldLineNum;
        /// <summary>
        /// 记录原内容
        /// </summary>
        private string oldContent;
        /// <summary>
        /// 记录原有保留字的数目
        /// </summary>
        private int oldReservedWordNum;
        /// <summary>
        /// 记录原有注释数目
        /// </summary>
        private int oldAnnoNum;
        /// <summary>
        /// 上一个输入的字符
        /// </summary>
        private string previousC = "";

        public RichTextBoxWithLine()
            : base()
        {
            InitializeLineBox();
        }

        private void InitializeLineBox()
        {
            lineNumPanel = new Panel();
            lineNumPanel.Name = "LineNumPanel";
            lineNumPanel.Width = 30;
            lineNumPanel.Dock = DockStyle.Left;
            lineNumPanel.Font = this.Font;
            lineNumPanel.ForeColor = Color.Green;
            lineNumPanel.BackColor = Color.FromArgb(0xf2, 0xf2, 0xf2);
            lineNumPanel.TabStop = false;
            lineNumPanel.BorderStyle = BorderStyle.None;
            this.SelectionIndent = 31;
            this.Controls.Add(lineNumPanel);
        }

        public void UpdateLineNo()
        {
            //获得当前坐标信息
            Point p = new Point(40, 0);
            int crntFirstIndex = this.GetCharIndexFromPosition(p);
            int crntFirstLine = this.GetLineFromCharIndex(crntFirstIndex);
            Point crntFirstPos = this.GetPositionFromCharIndex(crntFirstIndex);
            //
            p.Y += this.ClientRectangle.Height;
            //
            int crntLastIndex = this.GetCharIndexFromPosition(p);
            int crntLastLine = this.GetLineFromCharIndex(crntLastIndex);
            Point crntLastPos = this.GetPositionFromCharIndex(crntLastIndex);
            //
            //
            //准备画图
            Graphics g = this.lineNumPanel.CreateGraphics();
            Font font = new Font(this.Font, this.Font.Style);
            SolidBrush brush = new SolidBrush(Color.Green);
            //
            //
            //画图开始
            //刷新画布
            Rectangle rect = this.lineNumPanel.ClientRectangle;
            brush.Color = this.lineNumPanel.BackColor;
            g.FillRectangle(brush, 0, 0, this.lineNumPanel.ClientRectangle.Width, this.lineNumPanel.ClientRectangle.Height);
            brush.Color = Color.Green;//重置画笔颜色
            //
            //绘制行号
            int lineSpace = 0;
            if (crntFirstLine != crntLastLine)
            {
                lineSpace = (crntLastPos.Y - crntFirstPos.Y) / (crntLastLine - crntFirstLine);
            }
            else
            {
                lineSpace = Convert.ToInt32(this.Font.Size);
            }

            int brushX = this.lineNumPanel.ClientRectangle.Width + 10 - Convert.ToInt32(font.Size * 3);

            if (crntFirstLine >= 100)
            {
                brushX = this.lineNumPanel.ClientRectangle.Width + 5 - Convert.ToInt32(font.Size * 3);
            }

            //int brushY = crntLastPos.Y + Convert.ToInt32(font.Size * 0.21f);
            int brushY = crntLastPos.Y;
            for (int i = crntLastLine; i >= crntFirstLine; i--)
            {
                g.DrawString((i + 1).ToString(), font, brush, brushX, brushY);
                brushY -= lineSpace;
            }
            g.Dispose();
            font.Dispose();
            brush.Dispose();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            //换行更新行号
            if (this.Lines.Length != 0)
            {
                int firstIndex = this.GetFirstCharIndexFromLine(this.Lines.Length - 1);
                int lastIndex = this.Text.Length;
                if (firstIndex + 1 == lastIndex)
                {
                    UpdateLineNo();
                }
            }
            if (this.Lines.Length != oldLineNum)
            {
                UpdateLineNo();
            }
            oldLineNum = this.Lines.Length;

            //保留字，注释着色

            //记录原来选中位置
            int start = this.SelectionStart;
            int length = this.SelectionLength;
            //记录原来的字体
            //Font oldFont = this.Font;

            List<Token> tokens = new TokenBuilder(this.Text).getAllTokens();

            if (isKeyNumChanged(tokens) || isAnnoNumChanged(tokens))
            {
                //清除原有格式
                string tmpContent = this.Text;
                this.Clear();
                this.Text = tmpContent;

                int oldLineNo = -1;
                int oldStartIndex = -1;
                foreach (Token t in tokens)
                {
                    //为关键字着色
                    if (t.GetTokenType() == TokenType.RSERVEED_WORD)
                    {
                        int startIndex = this.GetFirstCharIndexFromLine(t.GetLineNum() - 1);
                        if (t.GetLineNum() - 1 == oldLineNo)
                        {
                            startIndex = Text.IndexOf(t.GetValue(), oldStartIndex + 1);
                        }
                        this.Find(t.GetValue().ToString(), startIndex, RichTextBoxFinds.MatchCase);
                        this.SelectionColor = Color.Blue;
                        oldLineNo = t.GetLineNum()-1;
                        oldStartIndex = startIndex;
                    }

                    //为注释着色
                    if (t.GetTokenType() == TokenType.ANNOTATION)
                    {
                        this.Select(t.Anno.Start, t.Anno.End - t.Anno.Start);
                        this.SelectionColor = Color.Green;
                    }
                }
                //恢复到原来的选中状态
                this.Select(start, length);
                this.SelectionColor = Color.Black;
            }
            //内容变动是否发生在注释内
            if (inArrange(tokens, /*this.SelectionStart == this.Text.Length
                ? this.SelectionStart - 1 : this.SelectionStart*/this.SelectionStart))
            {
                this.SelectionColor = Color.Green;
            }
            else
            {
                this.SelectionColor = Color.Black;
            }
            if (this.Text.Length > 0)
            {
                string tempC = "";
                if (this.SelectionStart > 0)
                {
                    tempC = this.Text.Substring(this.SelectionStart - 1, 1);
                }

                //回车符
                if (tempC.Equals("\n") && inMulArrange(tokens, this.SelectionStart))
                {
                    this.SelectionColor = Color.Green;
                }
                else if (previousC.Equals("/") && (tempC.Equals("/") || tempC.Equals("*")))
                {
                    this.SelectionColor = Color.Green;
                }
                //else if (!previousC.Equals("\n") && inArrange(tokens, this.SelectionStart == this.Text.Length
                // ? this.SelectionStart - 1 : this.SelectionStart))
                //{
                //    this.SelectionColor = Color.Green;
                //}
                //else
                //{
                //    this.SelectionColor = Color.Black;
                //}
                previousC = tempC;
            }

            oldContent = this.Text;
        }

        /// <summary>
        /// 判断保留字数目是否发生改变
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        private bool isKeyNumChanged(List<Token> tokens)
        {
            int idNum = 0;
            foreach (Token t in tokens)
            {
                if (t.GetTokenType() == TokenType.RSERVEED_WORD)
                {
                    idNum++;
                }
            }
            if (idNum == oldReservedWordNum)
            {
                return false;
            }
            oldReservedWordNum = idNum;
            return true;
        }

        /// <summary>
        /// 判断注释数目是否发生变换
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        private bool isAnnoNumChanged(List<Token> tokens)
        {
            int annoNum = 0;
            foreach (Token t in tokens)
            {
                if (t.GetTokenType() == TokenType.ANNOTATION)
                {
                    annoNum++;
                }
            }
            if (annoNum == oldAnnoNum)
            {
                return false;
            }
            oldAnnoNum = annoNum;
            return true;
        }

        /// <summary>
        /// 内容改变的位置是否在注释内
        /// </summary>
        /// <param name="tokens"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        private bool inArrange(List<Token> tokens, int cursor)
        {
            foreach (Token t in tokens)
            {
                if (t.GetTokenType() == TokenType.ANNOTATION)
                {
                    if (cursor >= t.Anno.Start && cursor <= t.Anno.End)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 特别判断是否在多行注释内
        /// </summary>
        /// <param name="tokens"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        private bool inMulArrange(List<Token> tokens, int cursor)
        {
            foreach (Token t in tokens)
            {
                if (t.GetTokenType() == TokenType.ANNOTATION)
                {
                    if (t.Anno.isMulti && cursor >= t.Anno.Start && cursor <= t.Anno.End+1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected override void OnVScroll(EventArgs e)
        {
            UpdateLineNo();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateLineNo();
        }
    }
}
