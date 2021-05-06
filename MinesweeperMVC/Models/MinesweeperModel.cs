using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperMVC.Models
{
    public class MinesweeperViewModel
    {
    }

    public class MinesweeperModel
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        public int CellCount => Rows * Columns;
        public int BombCount { get; set; }

        public int MoveCount
        {
            get
            {
                return Board.Cast<int>().Count(c => c != 0);
            }
        }

        public MinesweeperModel(int rows, int columns, int bombCount)
        {
            Rows = rows;
            Columns = columns;
            BombCount = bombCount;
            Board = new int[Rows, Columns];
        }

        public int[,] Board;

        public string Display(in int row, in int col)
        {
            switch (Board[row, col])
            {
                case 0: return "_";
                case 1: return "\u2222";
                case 2: return "\u2652";
            }
            return "A";
        }
    }
}
