using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
	class World
	{
		public string CurrentMap = "W1";
		public int[,] Map = new int[,] {
		{ 1, 1, 1, 1, 1, 1, 1, 0 },
		{ 1, 0, 3, 0, 0, 0, 1, 0 },
		{ 1, 0, 0, 0, 0, 0, 1, 1 },
		{ 1, 0, 0, 2, 0, 0, 0, 9 },
		{ 1, 4, 0, 0, 0, 3, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 0 }
		};

		public int[,] W1 = new int[,] {
		{ 1, 1, 1, 1, 1, 1, 1, 0 },
		{ 1, 0, 3, 0, 0, 0, 1, 0 },
		{ 1, 0, 0, 0, 0, 0, 1, 1 },
		{ 1, 0, 0, 2, 0, 0, 0, 9 },
		{ 1, 4, 0, 0, 0, 3, 1, 1 },
		{ 1, 1, 1, 1, 1, 1, 1, 0 }
		};

		public int[,] W2 = new int[,] {
		{ 0, 1, 1, 1, 1, 1, 1 },
		{ 0, 1, 0, 0, 0, 0, 1 },
		{ 1, 1, 0, 0, 0, 0, 1 },
		{ 9, 0, 0, 2, 0, 0, 1 },
		{ 1, 1, 0, 0, 0, 4, 1 },
		{ 0, 1, 1, 0, 1, 1, 1 },
        { 0, 0, 1, 9, 1, 0, 0 }
		};

        public int[,] W3 = new int[,] {
        { 0, 1, 9, 1, 0, 0, 0 },
        { 1, 1, 0, 1, 1, 1, 1 },
        { 1, 0, 0, 0, 0, 4, 1 },
        { 1, 0, 0, 2, 0, 4, 1 },
        { 1, 0, 0, 0, 0, 4, 1 },
        { 1, 1, 1, 1, 1, 1, 1 }
        };

        public void UpdateMap(int[,] NewMap)
		{
			Map = NewMap;
		}

		public void SetMap(string MapName)
		{
			switch (CurrentMap)
			{
				case "W1":
					W1 = Map;
					break;
				case "W2":
					W2 = Map;
					break;
                case "W3":
                    W3 = Map;
                    break;
			}
			switch (MapName)
			{
				case "W1":
					Map = W1;
					CurrentMap = "W1";
					break;
				case "W2":
					Map = W2;
					CurrentMap = "W2";
					break;
                case "W3":
                    Map = W3;
                    CurrentMap = "W3";
                    break;
			}
		}
	}
}
