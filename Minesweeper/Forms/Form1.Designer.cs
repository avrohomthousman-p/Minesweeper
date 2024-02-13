using MinesweeperModel;


namespace Minesweeper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bombsRemaining = new System.Windows.Forms.Label();
            this.flag = new System.Windows.Forms.PictureBox();
            this.difficultySetter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flag)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bombsRemaining);
            this.splitContainer1.Panel1.Controls.Add(this.flag);
            this.splitContainer1.Panel1.Controls.Add(this.difficultySetter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(680, 530);
            this.splitContainer1.SplitterDistance = 55;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // bombsRemaining
            // 
            this.bombsRemaining.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(215)))), ((int)(((byte)(81)))));
            this.bombsRemaining.Dock = System.Windows.Forms.DockStyle.Right;
            this.bombsRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bombsRemaining.Location = new System.Drawing.Point(542, 0);
            this.bombsRemaining.Name = "bombsRemaining";
            this.bombsRemaining.Size = new System.Drawing.Size(65, 55);
            this.bombsRemaining.TabIndex = 0;
            // 
            // flag
            // 
            this.flag.Dock = System.Windows.Forms.DockStyle.Right;
            this.flag.Location = new System.Drawing.Point(607, 0);
            this.flag.Name = "flag";
            this.flag.Size = new System.Drawing.Size(73, 55);
            this.flag.Image = flagPic;
            this.flag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flag.TabIndex = 1;
            this.flag.TabStop = false;
            // 
            // difficultySetter
            // 
            this.difficultySetter.Dock = System.Windows.Forms.DockStyle.Left;
            this.difficultySetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficultySetter.FormattingEnabled = true;
            this.difficultySetter.Items.AddRange(new object[] {
            MinesweeperModel.DifficultyLevel.Easy,
            MinesweeperModel.DifficultyLevel.Medium,
            MinesweeperModel.DifficultyLevel.Hard});
            this.difficultySetter.Location = new System.Drawing.Point(0, 0);
            this.difficultySetter.Name = "difficultySetter";
            this.difficultySetter.Size = new System.Drawing.Size(138, 23);
            this.difficultySetter.TabIndex = 2;
            this.difficultySetter.SelectedIndexChanged += DifficultySetter_SelectedValueChanged;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(680, 530);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flag)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox difficultySetter;
        private System.Windows.Forms.Label bombsRemaining;
        private System.Windows.Forms.PictureBox flag;
    }
}


