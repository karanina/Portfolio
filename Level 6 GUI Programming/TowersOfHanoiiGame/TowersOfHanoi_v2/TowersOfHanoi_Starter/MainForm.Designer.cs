namespace Towers_of_Hanoi
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnl_Peg1 = new System.Windows.Forms.Panel();
            this.pnl_Peg2 = new System.Windows.Forms.Panel();
            this.pnl_Peg3 = new System.Windows.Forms.Panel();
            this.lbl_Disk4 = new System.Windows.Forms.Label();
            this.lbl_Disk3 = new System.Windows.Forms.Label();
            this.lbl_Disk2 = new System.Windows.Forms.Label();
            this.lbl_Disk1 = new System.Windows.Forms.Label();
            this.lbl_Base = new System.Windows.Forms.Label();
            this.lbl_MovesList = new System.Windows.Forms.Label();
            this.txt_Moves = new System.Windows.Forms.TextBox();
            this.txt_Count = new System.Windows.Forms.TextBox();
            this.lbl_Count = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_CanDropWarning = new System.Windows.Forms.Panel();
            this.btn_CanDropOk = new System.Windows.Forms.Button();
            this.txtCanDropWarning = new System.Windows.Forms.TextBox();
            this.lbl_Warning = new System.Windows.Forms.Label();
            this.pnl_Rules = new System.Windows.Forms.Panel();
            this.txtRules = new System.Windows.Forms.TextBox();
            this.btn_RulesReturn = new System.Windows.Forms.Button();
            this.lblRules = new System.Windows.Forms.Label();
            this.pnl_Welcome = new System.Windows.Forms.Panel();
            this.btn_TargetOK = new System.Windows.Forms.Button();
            this.lbl_Welcome = new System.Windows.Forms.Label();
            this.num_MovesTarget = new System.Windows.Forms.NumericUpDown();
            this.lbl_MovesTarget = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txt_TargetCount = new System.Windows.Forms.TextBox();
            this.lbl_TargetCount = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnl_CanDropWarning.SuspendLayout();
            this.pnl_Rules.SuspendLayout();
            this.pnl_Welcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_MovesTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Peg1
            // 
            this.pnl_Peg1.AllowDrop = true;
            this.pnl_Peg1.BackColor = System.Drawing.Color.Black;
            this.pnl_Peg1.Location = new System.Drawing.Point(161, 150);
            this.pnl_Peg1.Name = "pnl_Peg1";
            this.pnl_Peg1.Size = new System.Drawing.Size(10, 200);
            this.pnl_Peg1.TabIndex = 0;
            this.pnl_Peg1.DragDrop += new System.Windows.Forms.DragEventHandler(this.peg_DragDrop);
            this.pnl_Peg1.DragEnter += new System.Windows.Forms.DragEventHandler(this.peg_DragEnter);
            // 
            // pnl_Peg2
            // 
            this.pnl_Peg2.AllowDrop = true;
            this.pnl_Peg2.BackColor = System.Drawing.Color.Black;
            this.pnl_Peg2.Location = new System.Drawing.Point(381, 150);
            this.pnl_Peg2.Name = "pnl_Peg2";
            this.pnl_Peg2.Size = new System.Drawing.Size(10, 200);
            this.pnl_Peg2.TabIndex = 1;
            this.pnl_Peg2.DragDrop += new System.Windows.Forms.DragEventHandler(this.peg_DragDrop);
            this.pnl_Peg2.DragEnter += new System.Windows.Forms.DragEventHandler(this.peg_DragEnter);
            // 
            // pnl_Peg3
            // 
            this.pnl_Peg3.AllowDrop = true;
            this.pnl_Peg3.BackColor = System.Drawing.Color.Black;
            this.pnl_Peg3.Location = new System.Drawing.Point(601, 150);
            this.pnl_Peg3.Name = "pnl_Peg3";
            this.pnl_Peg3.Size = new System.Drawing.Size(10, 200);
            this.pnl_Peg3.TabIndex = 2;
            this.pnl_Peg3.DragDrop += new System.Windows.Forms.DragEventHandler(this.peg_DragDrop);
            this.pnl_Peg3.DragEnter += new System.Windows.Forms.DragEventHandler(this.peg_DragEnter);
            // 
            // lbl_Disk4
            // 
            this.lbl_Disk4.BackColor = System.Drawing.Color.Blue;
            this.lbl_Disk4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Disk4.Location = new System.Drawing.Point(66, 310);
            this.lbl_Disk4.Name = "lbl_Disk4";
            this.lbl_Disk4.Size = new System.Drawing.Size(200, 40);
            this.lbl_Disk4.TabIndex = 3;
            this.lbl_Disk4.Text = "4";
            this.lbl_Disk4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.anyDisk_MouseDown);
            // 
            // lbl_Disk3
            // 
            this.lbl_Disk3.BackColor = System.Drawing.Color.Yellow;
            this.lbl_Disk3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Disk3.Location = new System.Drawing.Point(86, 270);
            this.lbl_Disk3.Name = "lbl_Disk3";
            this.lbl_Disk3.Size = new System.Drawing.Size(160, 40);
            this.lbl_Disk3.TabIndex = 4;
            this.lbl_Disk3.Text = "3";
            this.lbl_Disk3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.anyDisk_MouseDown);
            // 
            // lbl_Disk2
            // 
            this.lbl_Disk2.BackColor = System.Drawing.Color.Red;
            this.lbl_Disk2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Disk2.Location = new System.Drawing.Point(106, 230);
            this.lbl_Disk2.Name = "lbl_Disk2";
            this.lbl_Disk2.Size = new System.Drawing.Size(120, 40);
            this.lbl_Disk2.TabIndex = 5;
            this.lbl_Disk2.Text = "2";
            this.lbl_Disk2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.anyDisk_MouseDown);
            // 
            // lbl_Disk1
            // 
            this.lbl_Disk1.BackColor = System.Drawing.Color.Lime;
            this.lbl_Disk1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Disk1.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Disk1.ForeColor = System.Drawing.Color.Black;
            this.lbl_Disk1.Location = new System.Drawing.Point(126, 190);
            this.lbl_Disk1.Name = "lbl_Disk1";
            this.lbl_Disk1.Size = new System.Drawing.Size(80, 40);
            this.lbl_Disk1.TabIndex = 6;
            this.lbl_Disk1.Text = "1";
            this.lbl_Disk1.Click += new System.EventHandler(this.lbl_Disk1_Click);
            this.lbl_Disk1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.anyDisk_MouseDown);
            // 
            // lbl_Base
            // 
            this.lbl_Base.BackColor = System.Drawing.Color.SaddleBrown;
            this.lbl_Base.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Base.ForeColor = System.Drawing.Color.White;
            this.lbl_Base.Location = new System.Drawing.Point(46, 350);
            this.lbl_Base.Name = "lbl_Base";
            this.lbl_Base.Size = new System.Drawing.Size(680, 80);
            this.lbl_Base.TabIndex = 9;
            this.lbl_Base.Text = "TOWERS OF HANOI";
            this.lbl_Base.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_MovesList
            // 
            this.lbl_MovesList.AutoSize = true;
            this.lbl_MovesList.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MovesList.Location = new System.Drawing.Point(775, 168);
            this.lbl_MovesList.Name = "lbl_MovesList";
            this.lbl_MovesList.Size = new System.Drawing.Size(112, 20);
            this.lbl_MovesList.TabIndex = 11;
            this.lbl_MovesList.Text = "MOVES MADE:";
            // 
            // txt_Moves
            // 
            this.txt_Moves.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_Moves.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_Moves.Enabled = false;
            this.txt_Moves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Moves.Location = new System.Drawing.Point(779, 191);
            this.txt_Moves.Multiline = true;
            this.txt_Moves.Name = "txt_Moves";
            this.txt_Moves.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Moves.Size = new System.Drawing.Size(211, 240);
            this.txt_Moves.TabIndex = 12;
            // 
            // txt_Count
            // 
            this.txt_Count.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_Count.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_Count.Enabled = false;
            this.txt_Count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Count.Location = new System.Drawing.Point(779, 84);
            this.txt_Count.Name = "txt_Count";
            this.txt_Count.Size = new System.Drawing.Size(211, 20);
            this.txt_Count.TabIndex = 13;
            // 
            // lbl_Count
            // 
            this.lbl_Count.AutoSize = true;
            this.lbl_Count.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Count.Location = new System.Drawing.Point(775, 61);
            this.lbl_Count.Name = "lbl_Count";
            this.lbl_Count.Size = new System.Drawing.Size(156, 20);
            this.lbl_Count.TabIndex = 11;
            this.lbl_Count.Text = "NUMBER OF MOVES:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.rulesToolStripMenuItem,
            this.demoToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.resetGameToolStripMenuItem,
            this.undoMoveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1039, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.rulesToolStripMenuItem.Text = "Rules";
            this.rulesToolStripMenuItem.Click += new System.EventHandler(this.rulesToolStripMenuItem_Click);
            // 
            // demoToolStripMenuItem
            // 
            this.demoToolStripMenuItem.Name = "demoToolStripMenuItem";
            this.demoToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.demoToolStripMenuItem.Text = "Demo";
            this.demoToolStripMenuItem.Click += new System.EventHandler(this.demoToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.saveToolStripMenuItem.Text = "Save Game";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.loadToolStripMenuItem.Text = "Load Game";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // resetGameToolStripMenuItem
            // 
            this.resetGameToolStripMenuItem.Name = "resetGameToolStripMenuItem";
            this.resetGameToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.resetGameToolStripMenuItem.Text = "Reset Game";
            this.resetGameToolStripMenuItem.Click += new System.EventHandler(this.resetGameToolStripMenuItem_Click);
            // 
            // undoMoveToolStripMenuItem
            // 
            this.undoMoveToolStripMenuItem.Name = "undoMoveToolStripMenuItem";
            this.undoMoveToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.undoMoveToolStripMenuItem.Text = "Undo Move";
            this.undoMoveToolStripMenuItem.Click += new System.EventHandler(this.undoMoveToolStripMenuItem_Click);
            // 
            // pnl_CanDropWarning
            // 
            this.pnl_CanDropWarning.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnl_CanDropWarning.Controls.Add(this.btn_CanDropOk);
            this.pnl_CanDropWarning.Controls.Add(this.txtCanDropWarning);
            this.pnl_CanDropWarning.Controls.Add(this.lbl_Warning);
            this.pnl_CanDropWarning.Location = new System.Drawing.Point(287, 130);
            this.pnl_CanDropWarning.Name = "pnl_CanDropWarning";
            this.pnl_CanDropWarning.Size = new System.Drawing.Size(200, 100);
            this.pnl_CanDropWarning.TabIndex = 15;
            this.pnl_CanDropWarning.Visible = false;
            // 
            // btn_CanDropOk
            // 
            this.btn_CanDropOk.Location = new System.Drawing.Point(120, 72);
            this.btn_CanDropOk.Name = "btn_CanDropOk";
            this.btn_CanDropOk.Size = new System.Drawing.Size(75, 23);
            this.btn_CanDropOk.TabIndex = 2;
            this.btn_CanDropOk.Text = "OK";
            this.btn_CanDropOk.UseVisualStyleBackColor = true;
            this.btn_CanDropOk.Click += new System.EventHandler(this.btn_CanDropOk_Click);
            // 
            // txtCanDropWarning
            // 
            this.txtCanDropWarning.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtCanDropWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCanDropWarning.Location = new System.Drawing.Point(13, 25);
            this.txtCanDropWarning.Multiline = true;
            this.txtCanDropWarning.Name = "txtCanDropWarning";
            this.txtCanDropWarning.ReadOnly = true;
            this.txtCanDropWarning.Size = new System.Drawing.Size(178, 55);
            this.txtCanDropWarning.TabIndex = 1;
            this.txtCanDropWarning.Text = "This is an illegal move. \r\nMake sure only a smaller disk \r\nis placed on top.";
            this.txtCanDropWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_Warning
            // 
            this.lbl_Warning.AutoSize = true;
            this.lbl_Warning.BackColor = System.Drawing.Color.Red;
            this.lbl_Warning.ForeColor = System.Drawing.Color.White;
            this.lbl_Warning.Location = new System.Drawing.Point(0, 1);
            this.lbl_Warning.MinimumSize = new System.Drawing.Size(200, 15);
            this.lbl_Warning.Name = "lbl_Warning";
            this.lbl_Warning.Size = new System.Drawing.Size(200, 15);
            this.lbl_Warning.TabIndex = 0;
            this.lbl_Warning.Text = "Warning";
            // 
            // pnl_Rules
            // 
            this.pnl_Rules.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnl_Rules.Controls.Add(this.txtRules);
            this.pnl_Rules.Controls.Add(this.btn_RulesReturn);
            this.pnl_Rules.Controls.Add(this.lblRules);
            this.pnl_Rules.Location = new System.Drawing.Point(265, 81);
            this.pnl_Rules.Name = "pnl_Rules";
            this.pnl_Rules.Size = new System.Drawing.Size(246, 269);
            this.pnl_Rules.TabIndex = 16;
            this.pnl_Rules.Visible = false;
            // 
            // txtRules
            // 
            this.txtRules.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtRules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRules.Location = new System.Drawing.Point(23, 60);
            this.txtRules.Multiline = true;
            this.txtRules.Name = "txtRules";
            this.txtRules.ReadOnly = true;
            this.txtRules.Size = new System.Drawing.Size(200, 155);
            this.txtRules.TabIndex = 1;
            this.txtRules.Text = resources.GetString("txtRules.Text");
            // 
            // btn_RulesReturn
            // 
            this.btn_RulesReturn.Location = new System.Drawing.Point(126, 222);
            this.btn_RulesReturn.Name = "btn_RulesReturn";
            this.btn_RulesReturn.Size = new System.Drawing.Size(97, 23);
            this.btn_RulesReturn.TabIndex = 2;
            this.btn_RulesReturn.Text = "Return To Game";
            this.btn_RulesReturn.UseVisualStyleBackColor = true;
            this.btn_RulesReturn.Click += new System.EventHandler(this.btn_RulesReturn_Click);
            // 
            // lblRules
            // 
            this.lblRules.AutoSize = true;
            this.lblRules.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRules.Location = new System.Drawing.Point(100, 25);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(49, 17);
            this.lblRules.TabIndex = 0;
            this.lblRules.Text = "Rules";
            // 
            // pnl_Welcome
            // 
            this.pnl_Welcome.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnl_Welcome.Controls.Add(this.btn_TargetOK);
            this.pnl_Welcome.Controls.Add(this.lbl_Welcome);
            this.pnl_Welcome.Controls.Add(this.num_MovesTarget);
            this.pnl_Welcome.Controls.Add(this.lbl_MovesTarget);
            this.pnl_Welcome.Location = new System.Drawing.Point(246, 81);
            this.pnl_Welcome.Name = "pnl_Welcome";
            this.pnl_Welcome.Size = new System.Drawing.Size(287, 204);
            this.pnl_Welcome.TabIndex = 3;
            // 
            // btn_TargetOK
            // 
            this.btn_TargetOK.Location = new System.Drawing.Point(164, 153);
            this.btn_TargetOK.Name = "btn_TargetOK";
            this.btn_TargetOK.Size = new System.Drawing.Size(97, 23);
            this.btn_TargetOK.TabIndex = 3;
            this.btn_TargetOK.Text = "OK";
            this.btn_TargetOK.UseVisualStyleBackColor = true;
            this.btn_TargetOK.Click += new System.EventHandler(this.btn_TargetOK_Click);
            // 
            // lbl_Welcome
            // 
            this.lbl_Welcome.AutoSize = true;
            this.lbl_Welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Welcome.Location = new System.Drawing.Point(24, 24);
            this.lbl_Welcome.Name = "lbl_Welcome";
            this.lbl_Welcome.Size = new System.Drawing.Size(229, 18);
            this.lbl_Welcome.TabIndex = 2;
            this.lbl_Welcome.Text = "Welcome to Towers of Hanoi";
            // 
            // num_MovesTarget
            // 
            this.num_MovesTarget.Location = new System.Drawing.Point(116, 107);
            this.num_MovesTarget.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.num_MovesTarget.Name = "num_MovesTarget";
            this.num_MovesTarget.Size = new System.Drawing.Size(45, 20);
            this.num_MovesTarget.TabIndex = 1;
            this.num_MovesTarget.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // lbl_MovesTarget
            // 
            this.lbl_MovesTarget.AutoSize = true;
            this.lbl_MovesTarget.Location = new System.Drawing.Point(26, 67);
            this.lbl_MovesTarget.Name = "lbl_MovesTarget";
            this.lbl_MovesTarget.Size = new System.Drawing.Size(235, 13);
            this.lbl_MovesTarget.TabIndex = 0;
            this.lbl_MovesTarget.Text = "Would you like to set a target number of moves?";
            this.lbl_MovesTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txt_TargetCount
            // 
            this.txt_TargetCount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_TargetCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_TargetCount.Enabled = false;
            this.txt_TargetCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TargetCount.Location = new System.Drawing.Point(779, 136);
            this.txt_TargetCount.Name = "txt_TargetCount";
            this.txt_TargetCount.ReadOnly = true;
            this.txt_TargetCount.Size = new System.Drawing.Size(211, 20);
            this.txt_TargetCount.TabIndex = 18;
            // 
            // lbl_TargetCount
            // 
            this.lbl_TargetCount.AutoSize = true;
            this.lbl_TargetCount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TargetCount.Location = new System.Drawing.Point(775, 113);
            this.lbl_TargetCount.Name = "lbl_TargetCount";
            this.lbl_TargetCount.Size = new System.Drawing.Size(217, 20);
            this.lbl_TargetCount.TabIndex = 17;
            this.lbl_TargetCount.Text = "TARGET NUMBER OF MOVES:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1039, 481);
            this.Controls.Add(this.pnl_Welcome);
            this.Controls.Add(this.pnl_Rules);
            this.Controls.Add(this.txt_TargetCount);
            this.Controls.Add(this.lbl_TargetCount);
            this.Controls.Add(this.pnl_CanDropWarning);
            this.Controls.Add(this.txt_Count);
            this.Controls.Add(this.txt_Moves);
            this.Controls.Add(this.lbl_Count);
            this.Controls.Add(this.lbl_MovesList);
            this.Controls.Add(this.lbl_Base);
            this.Controls.Add(this.lbl_Disk1);
            this.Controls.Add(this.lbl_Disk2);
            this.Controls.Add(this.lbl_Disk3);
            this.Controls.Add(this.lbl_Disk4);
            this.Controls.Add(this.pnl_Peg3);
            this.Controls.Add(this.pnl_Peg2);
            this.Controls.Add(this.pnl_Peg1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Towers of Hanoi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnl_CanDropWarning.ResumeLayout(false);
            this.pnl_CanDropWarning.PerformLayout();
            this.pnl_Rules.ResumeLayout(false);
            this.pnl_Rules.PerformLayout();
            this.pnl_Welcome.ResumeLayout(false);
            this.pnl_Welcome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_MovesTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Peg1;
        private System.Windows.Forms.Panel pnl_Peg2;
        private System.Windows.Forms.Panel pnl_Peg3;
        private System.Windows.Forms.Label lbl_Disk3;
        private System.Windows.Forms.Label lbl_Disk4;
        private System.Windows.Forms.Label lbl_Disk2;
        private System.Windows.Forms.Label lbl_Disk1;
        private System.Windows.Forms.Label lbl_Base;
        private System.Windows.Forms.Label lbl_MovesList;
        private System.Windows.Forms.TextBox txt_Moves;
        private System.Windows.Forms.TextBox txt_Count;
        private System.Windows.Forms.Label lbl_Count;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem demoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetGameToolStripMenuItem;
        private System.Windows.Forms.Panel pnl_CanDropWarning;
        private System.Windows.Forms.Label lbl_Warning;
        private System.Windows.Forms.TextBox txtCanDropWarning;
        private System.Windows.Forms.Button btn_CanDropOk;
        private System.Windows.Forms.Panel pnl_Rules;
        private System.Windows.Forms.Button btn_RulesReturn;
        private System.Windows.Forms.TextBox txtRules;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.ToolStripMenuItem undoMoveToolStripMenuItem;
        private System.Windows.Forms.Panel pnl_Welcome;
        private System.Windows.Forms.Button btn_TargetOK;
        private System.Windows.Forms.Label lbl_Welcome;
        private System.Windows.Forms.NumericUpDown num_MovesTarget;
        private System.Windows.Forms.Label lbl_MovesTarget;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txt_TargetCount;
        private System.Windows.Forms.Label lbl_TargetCount;
    }
}

