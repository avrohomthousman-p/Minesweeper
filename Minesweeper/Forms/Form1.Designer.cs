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
            splitContainer1 = new SplitContainer();
            bombsRemaining = new Label();
            flag = new PictureBox();
            difficultySetter = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)flag).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(bombsRemaining);
            splitContainer1.Panel1.Controls.Add(flag);
            splitContainer1.Panel1.Controls.Add(difficultySetter);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(680, 530);
            splitContainer1.SplitterDistance = 55;
            splitContainer1.TabIndex = 0;
            // 
            // bombsRemaining
            // 
            bombsRemaining.BackColor = Color.FromArgb(169, 215, 81);
            bombsRemaining.Dock = DockStyle.Right;
            bombsRemaining.Font = new Font("Microsoft Sans Serif", 29F);
            bombsRemaining.Location = new Point(542, 0);
            bombsRemaining.Name = "bombsRemaining";
            bombsRemaining.Size = new Size(65, 55);
            bombsRemaining.TabIndex = 0;
            // 
            // flag
            // 
            flag.Dock = DockStyle.Right;
            flag.Location = new Point(607, 0);
            flag.Name = "flag";
            flag.Size = new Size(73, 55);
            flag.SizeMode = PictureBoxSizeMode.StretchImage;
            flag.TabIndex = 1;
            flag.TabStop = false;
            // 
            // difficultySetter
            // 
            difficultySetter.Dock = DockStyle.Left;
            difficultySetter.DropDownStyle = ComboBoxStyle.DropDownList;
            difficultySetter.FormattingEnabled = true;
            difficultySetter.Items.AddRange(new object[] { DifficultyLevel.Easy, DifficultyLevel.Medium, DifficultyLevel.Hard });
            difficultySetter.Location = new Point(0, 0);
            difficultySetter.Name = "difficultySetter";
            difficultySetter.Size = new Size(138, 28);
            difficultySetter.TabIndex = 2;
            difficultySetter.SelectedIndexChanged += DifficultySetter_SelectedValueChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Cursor = Cursors.Hand;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Size = new Size(200, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            ClientSize = new Size(680, 530);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Minesweeper";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)flag).EndInit();
            ResumeLayout(false);
        }



        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox difficultySetter;
        private System.Windows.Forms.Label bombsRemaining;
        private System.Windows.Forms.PictureBox flag;
    }
}


