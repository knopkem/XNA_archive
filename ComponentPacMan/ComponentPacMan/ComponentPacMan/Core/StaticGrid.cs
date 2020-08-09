using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ComponentPacMan.Core
{


    /// <summary>
    /// Represents the maze in terms of tiles. Initializes itself from string list.
    /// </summary>
    public class StaticGrid : IGrid
    {
        private readonly List<string> _levelStringList = new List<string>();
        private readonly int _width;
        private readonly int _height;

        private readonly Tile[,] _tileGrid = new Tile[32,32];
        private const int _tileSize = 16; 

        /// <summary>
        /// Creates a new Grid object
        /// </summary>
        public StaticGrid()
        {
            _width = _tileGrid.GetLength(0);
            _height = _tileGrid.GetLength(1);
     
            InitGrid();
            InitializeFromStringList();
         }

        public Tile[,] TileGrid
        {
            get { return _tileGrid; }
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public int TileSize
        {
            get { return _tileSize;}
        }

        public bool IsTileOpen(int i, int j)
        {
            if (i >= Width || i < 0)
                return false;
            if (j >= Height || j < 0)
                return false;

            if (TileGrid[i, j].Type == TileTypes.Open)
                return true;
            return false;
        }

        private void InitGrid()
        {
            for (int j = 0; j < Height; j++)
                for (int i = 0; i < Width; i++)
                {
                    TileGrid[i, j] = new Tile(TileTypes.Closed, false, false, new Point(i, j), _tileSize);
                }
        }

        private void FillStringList()
        {
            _levelStringList.Clear();
            _levelStringList.Add("0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0");
            _levelStringList.Add("0 1 1 1 1 1 1 1 1 1 1 1 1 0 0 1 1 1 1 1 1 1 1 1 1 1 1 0");
            _levelStringList.Add("0 1 0 0 0 0 1 0 0 0 0 0 1 0 0 1 0 0 0 0 0 1 0 0 0 0 1 0");
            _levelStringList.Add("0 3 0 0 0 0 1 0 0 0 0 0 1 0 0 1 0 0 0 0 0 1 0 0 0 0 3 0");
            _levelStringList.Add("0 1 0 0 0 0 1 0 0 0 0 0 1 0 0 1 0 0 0 0 0 1 0 0 0 0 1 0");
            _levelStringList.Add("0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0");
            _levelStringList.Add("0 1 0 0 0 0 1 0 0 1 0 0 0 0 0 0 0 0 1 0 0 1 0 0 0 0 1 0");
            _levelStringList.Add("0 1 0 0 0 0 1 0 0 1 0 0 0 0 0 0 0 0 1 0 0 1 0 0 0 0 1 0");
            _levelStringList.Add("0 1 1 1 1 1 1 0 0 1 1 1 1 0 0 1 1 1 1 0 0 1 1 1 1 1 1 0");
            _levelStringList.Add("0 0 0 0 0 0 1 0 0 0 0 0 1 0 0 1 0 0 0 0 0 1 0 0 0 0 0 0");
            _levelStringList.Add("0 0 0 0 0 0 1 0 0 0 0 0 1 0 0 1 0 0 0 0 0 1 0 0 0 0 0 0");
            _levelStringList.Add("0 0 0 0 0 0 1 0 0 1 1 1 1 1 1 1 1 1 1 0 0 1 0 0 0 0 0 0");
            _levelStringList.Add("0 0 0 0 0 0 1 0 0 1 0 0 0 2 2 0 0 0 1 0 0 1 0 0 0 0 0 0");
            _levelStringList.Add("0 0 0 0 0 0 1 0 0 1 0 2 2 2 2 2 2 0 1 0 0 1 0 0 0 0 0 0");
            _levelStringList.Add("1 1 1 1 1 1 1 1 1 1 0 2 2 2 2 2 2 0 1 1 1 1 1 1 1 1 1 1");
            _levelStringList.Add("0 0 0 0 0 0 1 0 0 1 0 2 2 2 2 2 2 0 1 0 0 1 0 0 0 0 0 0");
            _levelStringList.Add("0 0 0 0 0 0 1 0 0 1 0 0 0 0 0 0 0 0 1 0 0 1 0 0 0 0 0 0");
            _levelStringList.Add("0 0 0 0 0 0 1 0 0 1 1 1 1 1 1 1 1 1 1 0 0 1 0 0 0 0 0 0");
            _levelStringList.Add("0 0 0 0 0 0 1 0 0 1 0 0 0 0 0 0 0 0 1 0 0 1 0 0 0 0 0 0");
            _levelStringList.Add("0 0 0 0 0 0 1 0 0 1 0 0 0 0 0 0 0 0 1 0 0 1 0 0 0 0 0 0");
            _levelStringList.Add("0 1 1 1 1 1 1 1 1 1 1 1 1 0 0 1 1 1 1 1 1 1 1 1 1 1 1 0");
            _levelStringList.Add("0 1 0 0 0 0 1 0 0 0 0 0 1 0 0 1 0 0 0 0 0 1 0 0 0 0 1 0");
            _levelStringList.Add("0 1 0 0 0 0 1 0 0 0 0 0 1 0 0 1 0 0 0 0 0 1 0 0 0 0 1 0");
            _levelStringList.Add("0 3 1 1 0 0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 0 1 1 3 0");
            _levelStringList.Add("0 0 0 1 0 0 1 0 0 1 0 0 0 0 0 0 0 0 1 0 0 1 0 0 1 0 0 0");
            _levelStringList.Add("0 0 0 1 0 0 1 0 0 1 0 0 0 0 0 0 0 0 1 0 0 1 0 0 1 0 0 0");
            _levelStringList.Add("0 1 1 1 1 1 1 0 0 1 1 1 1 0 0 1 1 1 1 0 0 1 1 1 1 1 1 0");
            _levelStringList.Add("0 1 0 0 0 0 0 0 0 0 0 0 1 0 0 1 0 0 0 0 0 0 0 0 0 0 1 0");
            _levelStringList.Add("0 1 0 0 0 0 0 0 0 0 0 0 1 0 0 1 0 0 0 0 0 0 0 0 0 0 1 0");
            _levelStringList.Add("0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0");
            _levelStringList.Add("0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0");
        }

  
        private void InitializeFromStringList()
        {
            FillStringList();

            if (_levelStringList.Count == 0)
                return;

            int lineIndex = 0;
            int charIndex = 0;

            foreach (string line in _levelStringList)
            {
                foreach (char c in line)
                {
                    if (c == '1')
                    {
                        TileGrid[charIndex, lineIndex] = new Tile(TileTypes.Open, true, false,
                                                                  new Point(charIndex, lineIndex), _tileSize);
                    }
                    else if (c == '0')
                    {
                        TileGrid[charIndex, lineIndex] = new Tile(TileTypes.Closed, false, false,
                                                                  new Point(charIndex, lineIndex), _tileSize);
                    }
                    else if (c == '2')
                    {
                        TileGrid[charIndex, lineIndex] = new Tile(TileTypes.Home, false, false,
                                                                  new Point(charIndex, lineIndex), _tileSize);
                    }
                    else if (c == '3')
                    {
                        TileGrid[charIndex, lineIndex] = new Tile(TileTypes.Open, true, true,
                                                                  new Point(charIndex, lineIndex), _tileSize);
                    }
                    if (c != ' ')
                    {
                        charIndex++;
                    }
                }
                charIndex = 0;
                lineIndex++;
            }

            // do corrections
            CorrectTile();
        }

        private void CorrectTile()
        {
            // Now, actually a few open tiles do not contain a crump; such as 
            // the tunnels and around the ghosts' home. 
            for (int i = 0; i < 28; i++)
            {
                if (i != 6 && i != 21)
                {
                    TileGrid[i, 14].HasCrump = false;
                }
            }

            for (int j = 11; j < 20; j++)
            {
                TileGrid[9, j].HasCrump = false;
                TileGrid[18, j].HasCrump = false;
            }

            for (int i = 10; i < 18; i++)
            {
                TileGrid[i, 11].HasCrump = false;
                TileGrid[i, 17].HasCrump = false;
            }

            TileGrid[12, 9].HasCrump = false;
            TileGrid[15, 9].HasCrump = false;
            TileGrid[12, 10].HasCrump = false;
            TileGrid[15, 10].HasCrump = false;
            TileGrid[13, 23].HasCrump = false;
            TileGrid[14, 23].HasCrump = false;
        }


    }

 
}