using MinesweeperModel;
using MinesweeperWinForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        private readonly System.Drawing.Image bombPic = System.Drawing.Image.FromFile("../../../Resources/bomb.jpg");
        private readonly System.Drawing.Image flagPic = System.Drawing.Image.FromFile("../../../Resources/flag.jpg");

        int RowCount, ColCount;
        Label[,] buttons;
        IMinesweeperModel model;



        public Form1(IMinesweeperModel m)
        {
            model = m;
            InitializeComponent();
            InitializeComponent2();
        }



        internal void InitializeComponent2(DifficultyLevel level = DifficultyLevel.Medium)
        {

            this.difficultySetter.SelectedIndex = (int)level;
            model.Setup(level);
            Point p = level.GetSize();
            RowCount = p.X;
            ColCount = p.Y;

            this.splitContainer1.Panel2.SuspendLayout();

            this.tableLayoutPanel1.Controls.Clear();



            //create the board
            buttons = new Label[RowCount, ColCount];
            for (int r = 0; r < RowCount; r++)
            {
                for (int c = 0; c < ColCount; c++)
                {
                    buttons[r, c] = new Label();
                    buttons[r, c].Tag = new Point(r, c);
                    buttons[r, c].Dock = DockStyle.Fill;
                    this.tableLayoutPanel1.Controls.Add(buttons[r, c], c, r);
                    buttons[r, c].BorderStyle = BorderStyle.FixedSingle;
                    buttons[r, c].BackColor = Color.FromArgb(169, 215, 81);
                    buttons[r, c].Margin = new Padding(0);
                    buttons[r, c].TextAlign = ContentAlignment.MiddleCenter;
                    buttons[r, c].MouseUp += OnButtonClick;
                }
            }

            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.RowStyles.Clear();
            this.tableLayoutPanel1.ColumnStyles.Clear();


            this.tableLayoutPanel1.ColumnCount = ColCount;

            int remainingWidth = this.splitContainer1.Panel2.Size.Width;
            int remainingCols = ColCount;
            for (int c = 0; c < ColCount; c++)
            {
                int currentCol = remainingWidth / remainingCols;
                this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, currentCol));
                remainingWidth -= currentCol;
                remainingCols--;
            }


            this.tableLayoutPanel1.RowCount = RowCount;

            int remainingHeight = this.splitContainer1.Panel2.Size.Height;
            int remainingRows = RowCount;
            for (int r = 0; r < RowCount; r++)
            {
                int currentRow = remainingHeight / remainingRows;
                this.tableLayoutPanel1.RowStyles.Add(new ColumnStyle(SizeType.Absolute, currentRow));
                remainingHeight -= currentRow;
                remainingRows--;
            }


            this.bombsRemaining.Text = model.GetRemainingBombs().ToString();
            this.splitContainer1.Panel2.ResumeLayout(false);

        }



        private void DifficultySetter_SelectedValueChanged(object sender, EventArgs e)
        {
            InitializeComponent2((DifficultyLevel)difficultySetter.SelectedItem);
        }



        private void OnButtonClick(object sender, MouseEventArgs e)
        {
            Label button = (Label)sender;

            switch (e.Button)
            {
                case MouseButtons.Right:
                    HandelRightClick((Point)button.Tag);
                    break;
                case MouseButtons.Left:
                    HandleLeftClick((Point)button.Tag);
                    break;
            }
        }



        private void HandleLeftClick(Point p)
        {
            List<(int, int, Cell)> changes = model.OpenCell(p.X, p.Y);

            HandelGameOver();//does nothing if game isnt over

            if (changes.Count() >= 1 && !changes[0].Item3.IsBomb)//if we didnt just hit a bomb
            {
                //iterate over changes and apply them
                foreach (var current in changes)
                {
                    buttons[current.Item1, current.Item2].BackColor = Color.FromArgb(228, 194, 159);
                    if (current.Item3.BombCount != 0)
                    {
                        buttons[current.Item1, current.Item2].Text = current.Item3.BombCount.ToString();
                    }
                }
            }
        }


        private void HandelRightClick(Point p)
        {
            if (model.FlagCell(p.X, p.Y))
            {
                buttons[p.X, p.Y].BackgroundImage = flagPic;
                buttons[p.X, p.Y].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
            else
            {
                buttons[p.X, p.Y].BackgroundImage = null;
            }

            bombsRemaining.Text = model.GetRemainingBombs().ToString();
        }


        private void HandelGameOver()
        {
            if (model.GetGameState() == GameState.PLAYER_LOST || model.GetGameState() == GameState.PLAYER_WON)
            {
                RevealAllBombs();
                DisplayEndWindow();
            }
        }


        private void RevealAllBombs()
        {
            for (int r = 0; r < RowCount; r++)
            {
                for (int c = 0; c < ColCount; c++)
                {
                    if (model.GetCell(r, c).IsBomb)
                    {
                        buttons[r, c].BackgroundImage = bombPic;
                        buttons[r, c].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                }
            }
        }


        private void DisplayEndWindow()
        {
            EndForm end = new EndForm(this, model.GetGameState(), (DifficultyLevel)this.difficultySetter.SelectedItem);
            end.Show();
            this.Enabled = false;
        }

    }
}

