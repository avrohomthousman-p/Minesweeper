using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace MinesweeperModel
{
    public class Implementation : IMinesweeperModel
    {
        internal Cell[,] board;
        internal Point dimentions;
        internal int totalBombs;
        internal int remainingBombs;
        internal bool firstGuess;
        internal GameState state;



        public bool FlagCell(int row, int col)
        {
            OutOfBoundsCheck(row, col);

            Cell current = board[row, col];
            if(!current.IsRevealed && state == GameState.RUNNING)
            {
                remainingBombs += (current.IsFlagged ? 1 : -1);//adjust the number of remaining bombs
                current.IsFlagged = !current.IsFlagged; //flag or unflag the cell
            }

            return current.IsFlagged;
        }



        public int GetRemainingBombs()
        {
            return remainingBombs;
        }



        public Cell GetCell(int row, int col)
        {
            OutOfBoundsCheck(row, col);
            return new Cell(board[row, col]);
        }




        public int GetTime()
        {
            throw new NotImplementedException();
        }




        public void Setup(DifficultyLevel level)
        {
            state = GameState.RUNNING;
            firstGuess = true;
            dimentions = level.GetSize();
            totalBombs = level.GetBombsCount();
            remainingBombs = totalBombs;
            InitializeBoard();
            PlaceBombs();
        }



        internal void InitializeBoard()
        {
            board = new Cell[dimentions.X, dimentions.Y];

            for (int i = 0; i < dimentions.X; i++)
            {
                for (int j = 0; j < dimentions.Y; j++)
                {
                    board[i, j] = new Cell();
                }
            }
        }




        /// <summary>
        /// This method Places all the bombs on the board in random cells. It does NOT initialize
        /// the bombCounts for any cells.
        /// </summary>
        private void PlaceBombs()
        {
            Random generator = new Random();
            for (int i = 0; i < totalBombs; i++)
            {
                Cell current = board[generator.Next(0, dimentions.X), generator.Next(0, dimentions.Y)];
                if (!current.IsBomb)
                {
                    current.IsBomb = true;
                }
                else
                {
                    i--; //re-do this iteration
                }
            }
        }




        public List<(int, int, Cell)> OpenCell(int row, int col)
        {
            OutOfBoundsCheck(row, col);
            Cell current = board[row, col];
            if (firstGuess)
                HandleFirstGuess(row, col);


            List<(int, int, Cell)> results = new List<(int, int, Cell)>();
            if (!current.IsRevealed && !current.IsFlagged && state == GameState.RUNNING)
            {
                if (current.IsBomb)
                {
                    state = GameState.PLAYER_LOST;
                    current.IsRevealed = true;
                    results.Add((row, col, new Cell(current)));
                    return results;
                }
                else
                {
                    RevealCell(row, col, results);
                    UpdateGameState();
                    return results;
                }
            }
            else
            {
                return results;
            }
        }




        /// <summary>
        /// This method checks to see if the player won by checking the entire board for cells
        /// that have no bomb but are not reveaaled. If no such cells are found, the player won.
        /// </summary>
        private void UpdateGameState()
        {
            for(int i = 0; i < dimentions.X; i++)
            {
                for(int j = 0; j < dimentions.Y; j++)
                {
                    //if it is a empty spot that has not yet been revealed
                    if(!board[i, j].IsRevealed && !board[i, j].IsBomb)
                    {
                        state = GameState.RUNNING;
                        return;
                    }
                }
            }
            state = GameState.PLAYER_WON;
        }



        private void RevealCell(Point p, List<(int, int, Cell)> changedCells)
        {
            RevealCell(p.X, p.Y, changedCells);
        }





        /// <summary>
        /// This method reveals a cell, and checks what its bomb count is. If the bomb count
        /// is zero it makes a recursive call on each adjacent cell to reveal those too.
        /// </summary>
        /// <param name="row">the row of the target cell</param>
        /// <param name="col">the column of the target cell</param>
        /// <param name="changedCells">a list of all cells revealed so far (only as a result of the 
        /// current move).</param>
        private void RevealCell(int row, int col, List<(int, int, Cell)> changedCells)
        {
            //out of bounds check
            if ((row >= board.GetLength(0) || row < 0) || (col >= board.GetLength(1) || col < 0))
            {
                return;//this cell doesnt exist
            }
                

            Cell current = board[row, col];
            if (!current.IsRevealed)
            {
                //corner case: if you flagged a spot that doesnt have a bomb, and that spot is now getting
                //revealed as a result of you clicking on a nearby cell (that has a bomb count of 0),
                //the flag is removed as the cells are revealed. 
                current.IsFlagged = false;


                if (current.BombCount == -1)//if bombCount has not yet been initialized
                {
                    current.BombCount = CountAdjacentBombs(row, col);
                }

                current.IsRevealed = true;
                changedCells.Add((row, col, new Cell(current)));

                if (current.BombCount == 0)
                {
                    //do a recursive call on each adjacent cell
                    foreach(Point p in GetAdjacentTiles(row, col, false))
                    {
                        RevealCell(p, changedCells);
                    }
                }
            }
        }




        internal int CountAdjacentBombs(int row, int col)
        {
            return GetAdjacentTiles(row, col, false)
                .Count(p => IsNotOutOfBounds(p.X, p.Y) && board[p.X, p.Y].IsBomb);
        }




        /// <summary>
        /// This method ensures that the cell at the specified index is not a bomb and has
        /// a bombCount of 0 (which means it has no adjacent bombs either). This should be 
        /// called after the first guess of the game is made, to ensure the first guess isnt a bomb.
        /// </summary>
        /// <param name="col">the column number of the chosen cell</param>
        /// <param name="row">the row number of the chosen cell</param>
        internal void HandleFirstGuess(int row, int col)
        {
            Random generator = new Random();
            HashSet<Point> NoBombsZone = new HashSet<Point>();

            foreach(Point p in GetAdjacentTiles(row, col, true))
            {
                if(IsNotOutOfBounds(p.X, p.Y))
                {
                    NoBombsZone.Add(p);
                }
                
            }


            var haveBombs = NoBombsZone.Where(p => board[p.X, p.Y].IsBomb);
            foreach(Point p in haveBombs)
            {
                MoveBomb(board[p.X, p.Y], NoBombsZone, generator);
            }

            firstGuess = false;
        }



        private bool IsNotOutOfBounds(int row, int col)
        {
            return (row >= 0 && row < dimentions.X && col >= 0 && col < dimentions.Y);
        }




        /// <summary>
        /// This method ensures that the specified cell does not contain a bomb.
        /// If it does, the method moves the bomb to a different cell, but not a 
        /// cell that is part of the set of cells declared to be in the "no-bomb-zone".
        /// </summary>
        /// <param name="target">the cell that needs to be cleared of bombs</param>
        /// <param name="noBombsZone">a set of all cells (declared as x,y coordinates) that are in the
        /// "no-bomb-zone" and cannot have a bomb moved into them.</param>
        /// <param name="generator">a random number generator</param>
        internal void MoveBomb(Cell target, HashSet<Point> noBombsZone, Random generator)
        {
            while (target.IsBomb)
            {
                int x = generator.Next(0, dimentions.X);
                int y = generator.Next(0, dimentions.Y);
                Cell newSpot = board[x, y];
                if (!newSpot.IsBomb && !noBombsZone.Contains(new Point(x, y)))
                {
                    //move the bomb to the new spot
                    newSpot.IsBomb = true;
                    target.IsBomb = false;
                }
            }
        }


        /// <summary>
        /// This method checks if the specified indexes are out of bounds for the (2 dimentional) array of cells.
        /// If they are out of bounds, an exception is thrown.
        /// </summary>
        /// <param name="col">the collumn number</param>
        /// <param name="row">the row number</param>
        private void OutOfBoundsCheck(int row, int col)
        {
            if (row >= board.GetLength(0) || row < 0)
            {
                throw new ArgumentOutOfRangeException($"requested row (row {row}) is out of range." +
                    $" There are only {board.GetLength(0)} rows.");
            }
            else if (col >= board.GetLength(1) || col < 0)
            {
                throw new ArgumentOutOfRangeException($"requested column (column {col}) is out of range." +
                    $" There are only {board.GetLength(1)} columns.");
            }
        }




        public GameState GetGameState()
        {
            return state;
        }




        internal static IEnumerable<Point> GetAdjacentTiles(int row, int col, bool needOriginal)
        {
            if (needOriginal)
            {
                yield return new Point(row, col);
            }
            yield return new Point(row, col+1);
            yield return new Point(row, col-1);
            yield return new Point(row + 1, col+1);
            yield return new Point(row + 1, col);
            yield return new Point(row + 1, col-1);
            yield return new Point(row - 1, col+1);
            yield return new Point(row - 1, col);
            yield return new Point(row - 1, col-1);

        }
    }
}
