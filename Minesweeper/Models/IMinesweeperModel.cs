using System;
using System.Collections.Generic;
using System.Drawing;

namespace MinesweeperModel
{
    public interface IMinesweeperModel
    {
        /// <summary>
        /// Opens Cell
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns>List of Points that changed due to this operation. If Bomb, that point will be only returned value</returns>
        List<(int, int, Cell)> OpenCell(int row, int col);




        void Setup(DifficultyLevel level);




        /// <summary>
        /// This method is used to flag a cell that has no flag, or unflag a cell that has a flag.
        /// </summary>
        /// <param name="row">the row of the target cell</param>
        /// <param name="col">the column of the target cell</param>
        /// <returns>true if the cell is now flagged (reguardless of whether or not it was already flagged).</returns>
        bool FlagCell(int row, int col);



        int GetTime(); // In Seconds




        Cell GetCell(int row, int col);




        GameState GetGameState();




        int GetRemainingBombs();
    }

}
