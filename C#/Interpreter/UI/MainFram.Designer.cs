namespace interpreter.ui
{
    partial class MainFram
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重做ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剪切ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lexicalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.窗口WToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最大化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最小化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.srowLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.rowLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.scolumnLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.columnLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.resultTabControl = new System.Windows.Forms.TabControl();
            this.lexicalTabPage = new System.Windows.Forms.TabPage();
            this.lexicalRichTextBox = new System.Windows.Forms.RichTextBox();
            this.intermediateTabPage = new System.Windows.Forms.TabPage();
            this.intermediateRichTextBox = new System.Windows.Forms.RichTextBox();
            this.outputTabPage = new System.Windows.Forms.TabPage();
            this.outputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.horizonSplitContainer = new System.Windows.Forms.SplitContainer();
            this.inputRichTextBox = new interpreter.userDefinedControls.RichTextBoxWithLine();
            this.errorTabControl = new System.Windows.Forms.TabControl();
            this.errorTabPage = new System.Windows.Forms.TabPage();
            this.errorListView = new System.Windows.Forms.ListView();
            this.detailColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lineNoColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.orderColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.procesTabPage = new System.Windows.Forms.TabPage();
            this.processRichTextBox = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripSplitButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.resultTabControl.SuspendLayout();
            this.lexicalTabPage.SuspendLayout();
            this.intermediateTabPage.SuspendLayout();
            this.outputTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horizonSplitContainer)).BeginInit();
            this.horizonSplitContainer.Panel1.SuspendLayout();
            this.horizonSplitContainer.Panel2.SuspendLayout();
            this.horizonSplitContainer.SuspendLayout();
            this.errorTabControl.SuspendLayout();
            this.errorTabPage.SuspendLayout();
            this.procesTabPage.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.runToolStripMenuItem,
            this.窗口WToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(816, 26);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(60, 28);
            this.fileToolStripMenuItem.Text = "文件";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShowShortcutKeys = false;
            this.openToolStripMenuItem.Size = new System.Drawing.Size(134, 34);
            this.openToolStripMenuItem.Text = "打开";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.ShowShortcutKeys = false;
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(134, 34);
            this.saveToolStripMenuItem.Text = "保存";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.撤销ToolStripMenuItem,
            this.重做ToolStripMenuItem,
            this.剪切ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.全选ToolStripMenuItem});
            this.编辑ToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(60, 28);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 撤销ToolStripMenuItem
            // 
            this.撤销ToolStripMenuItem.Name = "撤销ToolStripMenuItem";
            this.撤销ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.撤销ToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
            this.撤销ToolStripMenuItem.Text = "撤销";
            this.撤销ToolStripMenuItem.Click += new System.EventHandler(this.撤销ToolStripMenuItem_Click);
            // 
            // 重做ToolStripMenuItem
            // 
            this.重做ToolStripMenuItem.Name = "重做ToolStripMenuItem";
            this.重做ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.重做ToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
            this.重做ToolStripMenuItem.Text = "重做";
            this.重做ToolStripMenuItem.Click += new System.EventHandler(this.重做ToolStripMenuItem_Click);
            // 
            // 剪切ToolStripMenuItem
            // 
            this.剪切ToolStripMenuItem.Name = "剪切ToolStripMenuItem";
            this.剪切ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.剪切ToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
            this.剪切ToolStripMenuItem.Text = "剪切";
            this.剪切ToolStripMenuItem.Click += new System.EventHandler(this.剪切ToolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            this.粘贴ToolStripMenuItem.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            this.全选ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.全选ToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
            this.全选ToolStripMenuItem.Text = "全选";
            this.全选ToolStripMenuItem.Click += new System.EventHandler(this.全选ToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lexicalToolStripMenuItem,
            this.executeToolStripMenuItem});
            this.runToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(60, 28);
            this.runToolStripMenuItem.Text = "运行";
            // 
            // lexicalToolStripMenuItem
            // 
            this.lexicalToolStripMenuItem.Name = "lexicalToolStripMenuItem";
            this.lexicalToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.lexicalToolStripMenuItem.ShowShortcutKeys = false;
            this.lexicalToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.lexicalToolStripMenuItem.Text = "词法分析";
            this.lexicalToolStripMenuItem.Click += new System.EventHandler(this.lexicalToolStripMenuItem_Click);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.executeToolStripMenuItem.ShowShortcutKeys = false;
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.executeToolStripMenuItem.Text = "开始执行";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // 窗口WToolStripMenuItem
            // 
            this.窗口WToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.最大化ToolStripMenuItem,
            this.最小化ToolStripMenuItem});
            this.窗口WToolStripMenuItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.窗口WToolStripMenuItem.Name = "窗口WToolStripMenuItem";
            this.窗口WToolStripMenuItem.Size = new System.Drawing.Size(60, 28);
            this.窗口WToolStripMenuItem.Text = "窗口";
            // 
            // 最大化ToolStripMenuItem
            // 
            this.最大化ToolStripMenuItem.Name = "最大化ToolStripMenuItem";
            this.最大化ToolStripMenuItem.Size = new System.Drawing.Size(160, 34);
            this.最大化ToolStripMenuItem.Text = "最大化";
            this.最大化ToolStripMenuItem.Click += new System.EventHandler(this.最大化ToolStripMenuItem_Click);
            // 
            // 最小化ToolStripMenuItem
            // 
            this.最小化ToolStripMenuItem.Name = "最小化ToolStripMenuItem";
            this.最小化ToolStripMenuItem.Size = new System.Drawing.Size(160, 34);
            this.最小化ToolStripMenuItem.Text = "最小化";
            this.最小化ToolStripMenuItem.Click += new System.EventHandler(this.最小化ToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.toolStripStatusLabel1,
            this.srowLabel,
            this.rowLabel,
            this.scolumnLabel,
            this.columnLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 524);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(816, 25);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(44, 18);
            this.statusLabel.Text = "就绪";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(705, 18);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // srowLabel
            // 
            this.srowLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.srowLabel.Name = "srowLabel";
            this.srowLabel.Size = new System.Drawing.Size(26, 18);
            this.srowLabel.Text = "行";
            // 
            // rowLabel
            // 
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(0, 18);
            // 
            // scolumnLabel
            // 
            this.scolumnLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scolumnLabel.Name = "scolumnLabel";
            this.scolumnLabel.Size = new System.Drawing.Size(26, 18);
            this.scolumnLabel.Text = "列";
            // 
            // columnLabel
            // 
            this.columnLabel.Name = "columnLabel";
            this.columnLabel.Size = new System.Drawing.Size(0, 18);
            // 
            // resultTabControl
            // 
            this.resultTabControl.Controls.Add(this.lexicalTabPage);
            this.resultTabControl.Controls.Add(this.intermediateTabPage);
            this.resultTabControl.Controls.Add(this.outputTabPage);
            this.resultTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultTabControl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resultTabControl.Location = new System.Drawing.Point(0, 0);
            this.resultTabControl.Margin = new System.Windows.Forms.Padding(2);
            this.resultTabControl.Multiline = true;
            this.resultTabControl.Name = "resultTabControl";
            this.resultTabControl.SelectedIndex = 0;
            this.resultTabControl.Size = new System.Drawing.Size(259, 465);
            this.resultTabControl.TabIndex = 0;
            this.resultTabControl.TabStop = false;
            // 
            // lexicalTabPage
            // 
            this.lexicalTabPage.BackColor = System.Drawing.Color.White;
            this.lexicalTabPage.Controls.Add(this.lexicalRichTextBox);
            this.lexicalTabPage.Location = new System.Drawing.Point(4, 28);
            this.lexicalTabPage.Name = "lexicalTabPage";
            this.lexicalTabPage.Size = new System.Drawing.Size(251, 433);
            this.lexicalTabPage.TabIndex = 0;
            this.lexicalTabPage.Text = "词法分析";
            // 
            // lexicalRichTextBox
            // 
            this.lexicalRichTextBox.BackColor = System.Drawing.Color.White;
            this.lexicalRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lexicalRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lexicalRichTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lexicalRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.lexicalRichTextBox.Name = "lexicalRichTextBox";
            this.lexicalRichTextBox.ReadOnly = true;
            this.lexicalRichTextBox.Size = new System.Drawing.Size(251, 433);
            this.lexicalRichTextBox.TabIndex = 0;
            this.lexicalRichTextBox.TabStop = false;
            this.lexicalRichTextBox.Text = "";
            // 
            // intermediateTabPage
            // 
            this.intermediateTabPage.BackColor = System.Drawing.Color.White;
            this.intermediateTabPage.Controls.Add(this.intermediateRichTextBox);
            this.intermediateTabPage.Location = new System.Drawing.Point(4, 28);
            this.intermediateTabPage.Name = "intermediateTabPage";
            this.intermediateTabPage.Size = new System.Drawing.Size(251, 433);
            this.intermediateTabPage.TabIndex = 2;
            this.intermediateTabPage.Text = "中间代码";
            // 
            // intermediateRichTextBox
            // 
            this.intermediateRichTextBox.BackColor = System.Drawing.Color.White;
            this.intermediateRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.intermediateRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.intermediateRichTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.intermediateRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.intermediateRichTextBox.Name = "intermediateRichTextBox";
            this.intermediateRichTextBox.ReadOnly = true;
            this.intermediateRichTextBox.Size = new System.Drawing.Size(251, 433);
            this.intermediateRichTextBox.TabIndex = 0;
            this.intermediateRichTextBox.TabStop = false;
            this.intermediateRichTextBox.Text = "";
            // 
            // outputTabPage
            // 
            this.outputTabPage.Controls.Add(this.outputRichTextBox);
            this.outputTabPage.Location = new System.Drawing.Point(4, 28);
            this.outputTabPage.Name = "outputTabPage";
            this.outputTabPage.Size = new System.Drawing.Size(251, 433);
            this.outputTabPage.TabIndex = 3;
            this.outputTabPage.Text = "运行结果";
            this.outputTabPage.UseVisualStyleBackColor = true;
            // 
            // outputRichTextBox
            // 
            this.outputRichTextBox.BackColor = System.Drawing.Color.White;
            this.outputRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputRichTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.outputRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.outputRichTextBox.Name = "outputRichTextBox";
            this.outputRichTextBox.ReadOnly = true;
            this.outputRichTextBox.Size = new System.Drawing.Size(251, 433);
            this.outputRichTextBox.TabIndex = 0;
            this.outputRichTextBox.TabStop = false;
            this.outputRichTextBox.Text = "";
            // 
            // horizonSplitContainer
            // 
            this.horizonSplitContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.horizonSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizonSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.horizonSplitContainer.Name = "horizonSplitContainer";
            this.horizonSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // horizonSplitContainer.Panel1
            // 
            this.horizonSplitContainer.Panel1.Controls.Add(this.inputRichTextBox);
            // 
            // horizonSplitContainer.Panel2
            // 
            this.horizonSplitContainer.Panel2.Controls.Add(this.errorTabControl);
            this.horizonSplitContainer.Size = new System.Drawing.Size(553, 465);
            this.horizonSplitContainer.SplitterDistance = 293;
            this.horizonSplitContainer.TabIndex = 0;
            this.horizonSplitContainer.TabStop = false;
            // 
            // inputRichTextBox
            // 
            this.inputRichTextBox.BackColor = System.Drawing.Color.White;
            this.inputRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputRichTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputRichTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.inputRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.inputRichTextBox.Name = "inputRichTextBox";
            this.inputRichTextBox.Size = new System.Drawing.Size(553, 293);
            this.inputRichTextBox.TabIndex = 0;
            this.inputRichTextBox.Text = "";
            this.inputRichTextBox.SelectionChanged += new System.EventHandler(this.inputRichTextBox_SelectionChanged);
            this.inputRichTextBox.TextChanged += new System.EventHandler(this.inputRichTextBox_TextChanged);
            // 
            // errorTabControl
            // 
            this.errorTabControl.Controls.Add(this.errorTabPage);
            this.errorTabControl.Controls.Add(this.procesTabPage);
            this.errorTabControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.errorTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorTabControl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.errorTabControl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.errorTabControl.Location = new System.Drawing.Point(0, 0);
            this.errorTabControl.Name = "errorTabControl";
            this.errorTabControl.SelectedIndex = 0;
            this.errorTabControl.Size = new System.Drawing.Size(553, 168);
            this.errorTabControl.TabIndex = 0;
            this.errorTabControl.TabStop = false;
            // 
            // errorTabPage
            // 
            this.errorTabPage.BackColor = System.Drawing.Color.White;
            this.errorTabPage.Controls.Add(this.errorListView);
            this.errorTabPage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.errorTabPage.Location = new System.Drawing.Point(4, 28);
            this.errorTabPage.Name = "errorTabPage";
            this.errorTabPage.Size = new System.Drawing.Size(545, 136);
            this.errorTabPage.TabIndex = 0;
            this.errorTabPage.Text = "错误列表";
            // 
            // errorListView
            // 
            this.errorListView.BackColor = System.Drawing.Color.White;
            this.errorListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.detailColumnHeader,
            this.lineNoColumnHeader,
            this.orderColumnHeader});
            this.errorListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorListView.ForeColor = System.Drawing.SystemColors.MenuText;
            this.errorListView.HideSelection = false;
            this.errorListView.Location = new System.Drawing.Point(0, 0);
            this.errorListView.Name = "errorListView";
            this.errorListView.Size = new System.Drawing.Size(545, 136);
            this.errorListView.TabIndex = 0;
            this.errorListView.TabStop = false;
            this.errorListView.UseCompatibleStateImageBehavior = false;
            this.errorListView.View = System.Windows.Forms.View.Details;
            this.errorListView.DoubleClick += new System.EventHandler(this.errorListView_DoubleClick);
            // 
            // detailColumnHeader
            // 
            this.detailColumnHeader.DisplayIndex = 1;
            this.detailColumnHeader.Text = "出错说明";
            this.detailColumnHeader.Width = 460;
            // 
            // lineNoColumnHeader
            // 
            this.lineNoColumnHeader.DisplayIndex = 2;
            this.lineNoColumnHeader.Text = "出错行号";
            // 
            // orderColumnHeader
            // 
            this.orderColumnHeader.DisplayIndex = 0;
            this.orderColumnHeader.Text = "";
            this.orderColumnHeader.Width = 39;
            // 
            // procesTabPage
            // 
            this.procesTabPage.Controls.Add(this.processRichTextBox);
            this.procesTabPage.Location = new System.Drawing.Point(4, 28);
            this.procesTabPage.Name = "procesTabPage";
            this.procesTabPage.Size = new System.Drawing.Size(545, 136);
            this.procesTabPage.TabIndex = 1;
            this.procesTabPage.Text = "运行信息";
            this.procesTabPage.UseVisualStyleBackColor = true;
            // 
            // processRichTextBox
            // 
            this.processRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.processRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.processRichTextBox.Name = "processRichTextBox";
            this.processRichTextBox.Size = new System.Drawing.Size(545, 136);
            this.processRichTextBox.TabIndex = 0;
            this.processRichTextBox.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripSplitButton2,
            this.toolStripSplitButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 26);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(816, 33);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 59);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.resultTabControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.horizonSplitContainer);
            this.splitContainer1.Size = new System.Drawing.Size(816, 465);
            this.splitContainer1.SplitterDistance = 259;
            this.splitContainer1.TabIndex = 4;
            // 
            // toolStripSplitButton3
            // 
            this.toolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton3.Image = global::interpreter.Properties.Resources.execute;
            this.toolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton3.Name = "toolStripSplitButton3";
            this.toolStripSplitButton3.Size = new System.Drawing.Size(34, 28);
            this.toolStripSplitButton3.Text = "运行";
            this.toolStripSplitButton3.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.Image = global::interpreter.Properties.Resources.save;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(34, 28);
            this.toolStripSplitButton2.Text = "保存";
            this.toolStripSplitButton2.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = global::interpreter.Properties.Resources.open;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(34, 28);
            this.toolStripSplitButton1.Text = "打开";
            this.toolStripSplitButton1.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // MainFram
            // 
            this.ClientSize = new System.Drawing.Size(816, 549);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainFram";
            this.ShowIcon = false;
            this.Text = "解释器";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.resultTabControl.ResumeLayout(false);
            this.lexicalTabPage.ResumeLayout(false);
            this.intermediateTabPage.ResumeLayout(false);
            this.outputTabPage.ResumeLayout(false);
            this.horizonSplitContainer.Panel1.ResumeLayout(false);
            this.horizonSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.horizonSplitContainer)).EndInit();
            this.horizonSplitContainer.ResumeLayout(false);
            this.errorTabControl.ResumeLayout(false);
            this.errorTabPage.ResumeLayout(false);
            this.procesTabPage.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lexicalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.SplitContainer horizonSplitContainer;
        private userDefinedControls.RichTextBoxWithLine inputRichTextBox;
        private System.Windows.Forms.TabControl resultTabControl;
        private System.Windows.Forms.TabPage lexicalTabPage;
        private System.Windows.Forms.TabPage intermediateTabPage;
        private System.Windows.Forms.TabControl errorTabControl;
        private System.Windows.Forms.TabPage errorTabPage;
        private System.Windows.Forms.ListView errorListView;
        private System.Windows.Forms.RichTextBox intermediateRichTextBox;
        private System.Windows.Forms.ColumnHeader detailColumnHeader;
        private System.Windows.Forms.ColumnHeader lineNoColumnHeader;
        private System.Windows.Forms.ColumnHeader orderColumnHeader;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.RichTextBox lexicalRichTextBox;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 窗口WToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重做ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 剪切ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最大化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最小化ToolStripMenuItem;
        private  System.Windows.Forms.TabPage outputTabPage;
        private System.Windows.Forms.TabPage procesTabPage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel srowLabel;
        private System.Windows.Forms.ToolStripStatusLabel scolumnLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel rowLabel;
        private System.Windows.Forms.ToolStripStatusLabel columnLabel;
        private System.Windows.Forms.ToolStripButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripButton toolStripSplitButton3;
        public System.Windows.Forms.RichTextBox processRichTextBox;
        public System.Windows.Forms.RichTextBox outputRichTextBox;
    }
}

