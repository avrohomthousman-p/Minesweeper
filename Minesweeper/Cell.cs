namespace MinesweeperModel
{
    /// <summary>
    /// Represents a single cell on the board
    /// </summary>
    public class Cell
    {
        public Cell() 
        {
            this.IsBomb = false;
            this.BombCount = -1;
            this.IsFlagged = false;
            this.IsRevealed = false;
        }




        public Cell(Cell template)
        {
            this.IsBomb = template.IsBomb;
            this.BombCount = template.BombCount;
            this.IsFlagged = template.IsFlagged;
            this.IsRevealed = template.IsRevealed;
        }



        public bool IsBomb { get; set; }
        public int BombCount { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsRevealed { get; set; }

    }
}