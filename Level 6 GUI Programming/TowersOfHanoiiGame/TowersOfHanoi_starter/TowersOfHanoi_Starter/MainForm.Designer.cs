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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnl_Peg1
            // 
            this.pnl_Peg1.AllowDrop = true;
            this.pnl_Peg1.BackColor = System.Drawing.Color.Black;
            this.pnl_Peg1.Location = new System.Drawing.Point(215, 150);
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
            this.pnl_Peg2.Location = new System.Drawing.Point(435, 150);
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
            this.pnl_Peg3.Location = new System.Drawing.Point(655, 150);
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
            this.lbl_Disk4.Location = new System.Drawing.Point(120, 310);
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
            this.lbl_Disk3.Location = new System.Drawing.Point(140, 270);
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
            this.lbl_Disk2.Location = new System.Drawing.Point(160, 230);
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
            this.lbl_Disk1.Location = new System.Drawing.Point(180, 190);
            this.lbl_Disk1.Name = "lbl_Disk1";
            this.lbl_Disk1.Size = new System.Drawing.Size(80, 40);
            this.lbl_Disk1.TabIndex = 6;
            this.lbl_Disk1.Text = "1";
            this.lbl_Disk1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.anyDisk_MouseDown);
            // 
            // lbl_Base
            // 
            this.lbl_Base.BackColor = System.Drawing.Color.SaddleBrown;
            this.lbl_Base.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Base.ForeColor = System.Drawing.Color.White;
            this.lbl_Base.Location = new System.Drawing.Point(100, 350);
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
            this.lbl_MovesList.Location = new System.Drawing.Point(805, 117);
            this.lbl_MovesList.Name = "lbl_MovesList";
            this.lbl_MovesList.Size = new System.Drawing.Size(112, 20);
            this.lbl_MovesList.TabIndex = 11;
            this.lbl_MovesList.Text = "MOVES MADE:";
            // 
            // txt_Moves
            // 
            this.txt_Moves.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_Moves.Enabled = false;
            this.txt_Moves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Moves.Location = new System.Drawing.Point(809, 140);
            this.txt_Moves.Multiline = true;
            this.txt_Moves.Name = "txt_Moves";
            this.txt_Moves.Size = new System.Drawing.Size(118, 290);
            this.txt_Moves.TabIndex = 12;
            // 
            // txt_Count
            // 
            this.txt_Count.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_Count.Enabled = false;
            this.txt_Count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Count.Location = new System.Drawing.Point(809, 84);
            this.txt_Count.Name = "txt_Count";
            this.txt_Count.Size = new System.Drawing.Size(118, 20);
            this.txt_Count.TabIndex = 13;
            // 
            // lbl_Count
            // 
            this.lbl_Count.AutoSize = true;
            this.lbl_Count.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Count.Location = new System.Drawing.Point(805, 61);
            this.lbl_Count.Name = "lbl_Count";
            this.lbl_Count.Size = new System.Drawing.Size(156, 20);
            this.lbl_Count.TabIndex = 11;
            this.lbl_Count.Text = "NUMBER OF MOVES:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(809, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 31);
            this.button1.TabIndex = 14;
            this.button1.Text = "RESET";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 525);
            this.Controls.Add(this.button1);
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
            this.Name = "MainForm";
            this.Text = "Towers of Hanoi";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button button1;
    }
}

