using Minesweeper;
using MinesweeperModel;


namespace MinesweeperWinForm
{
    public partial class EndForm : Form
    {
        private Form1 parent;
        private DifficultyLevel difficulty;

        public EndForm(Form1 f, GameState state, DifficultyLevel currentDifficulty)
        {
            InitializeComponent();
            this.difficulty = currentDifficulty;


            this.parent = f;
            switch(state)
            {
                case GameState.PLAYER_LOST:
                    button1.Text = "try again";
                    label1.Text = "----";
                    label2.Text = "----";
                    break;
                case GameState.PLAYER_WON:
                    button1.Text = "new game";
                    //we would change the lables here but the score is based on the time which we arent implementing
                    break;
                default:
                    throw new Exception("Illegall Game State");
            }

            button1.MouseClick += ClickButton;
        }

        private void ClickButton(object sender, MouseEventArgs e)
        {
            parent.InitializeComponent2(difficulty);
            parent.Enabled = true;
            this.Dispose();
        }
    }
}
