/// <summary>
/// Terminal 2048
/// </summary>
using System;

namespace Terminal2048
{
	class MainClass
	{
		public static int[] grid = new int[16];

		public static int[] up1 = {0,4,8,12};
		public static int[] up2 = {1,5,9,13};
		public static int[] up3 = {2,6,10,14};
		public static int[] up4 = {3,7,11,15};

		public static int[] down1 = {12,8,4,0};
		public static int[] down2 = {13,9,5,1};
		public static int[] down3 = {14,10,6,2};
		public static int[] down4 = {15,11,7,3};

		public static int[] left1 = {0,1,2,3};
		public static int[] left2 = {4,5,6,7};
		public static int[] left3 = {8,9,10,11};
		public static int[] left4 = {12,13,14,15};

		public static int[] right1 = {3,2,1,0};
		public static int[] right2 = {7,6,5,4};
		public static int[] right3 = {11,10,9,8};
		public static int[] right4 = {15,14,13,12};

		public static bool didMove = false;
		public static int score = 0;

		public static void Main (string[] args)
		{
			ConsoleKeyInfo keyInfo;

			InitializeGame ();
			//ConsoleKeyInfo key2 = Console.ReadKey ();
			DrawGrid ();

			while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
			{
				switch (keyInfo.Key)
				{
				case ConsoleKey.UpArrow:

					Slide (up1);
					Slide (up2);
					Slide (up3);
					Slide (up4);
					if (didMove) {
						GetNextTile ();
						DrawGrid ();
						didMove = false;
					}
					//Console.Write ("Up");
					break;

				case ConsoleKey.RightArrow:
					Slide (right1);
					Slide (right2);
					Slide (right3);
					Slide (right4);
					if (didMove) {
						GetNextTile ();
						DrawGrid ();
						didMove = false;
					}
					//Console.Write ("Right");
					break;

				case ConsoleKey.DownArrow:
					Slide (down1);
					Slide (down2);
					Slide (down3);
					Slide (down4);
					if (didMove) {
						GetNextTile ();
						DrawGrid ();
						didMove = false;
					}
					//Console.Write ("Down");
					break;

				case ConsoleKey.LeftArrow:
					Slide (left1);
					Slide (left2);
					Slide (left3);
					Slide (left4);
					if (didMove) {
						GetNextTile ();
						DrawGrid ();
						didMove = false;
					}
					//Console.Write ("Left");
					break;

				}
			}


			//ConsoleKeyInfo key = Console.ReadKey ();


		}
		public static void Slide(int[] row){
			RemoveGaps (row);
			CombineTiles (row);
			RemoveGaps (row);

		}

		public static void RemoveGaps(int[] row){
			for (int i = 0; i < 3; i++) {
				for (int x = 0; x < row.Length; x++) {
					if (grid[row [x]] == 0 && x < (row.Length - 1)) {
						if (grid[row [x + 1]] != 0) {
							grid[row [x]] = grid[row [x + 1]];
							grid[row [x + 1]] = 0;
							didMove = true;
						}
					}
				}
			}
		}

		public static void CombineTiles(int[] row){
			for (int i = 0; i < 3; i++) {
				if (grid [row [i]] != 0) {
					if (grid [row [i]] == grid [row [i + 1]]) {

						grid [row [i]] = grid [row [i]] + grid [row [i + 1]];
						score += grid [row [i]];
						grid [row [i + 1]] = 0;

						didMove = true;

					}
				}
			}
		}


		public static void InitializeGame(){

			//initialize grid squares to 0
			for (int i = 0; i < grid.Length; i++) {
				grid [i] = 0;
			}

			//choose two squares and assign a starting value
			GetNextTile ();
			GetNextTile ();
		}

		public static void GetNextTile(){
			//get array of available squares
			int[] availableSquares = new int[0];
			int count = 0;

			for (int i = 0; i < grid.Length; i++) {
				if (grid [i] == 0) {
					Array.Resize(ref availableSquares, count+1);
					availableSquares [count] = i;
					count++;
				}
			}
			if (availableSquares.Length != 0) {
				int nextNumber;
				Random rnd = new Random ();

				//pick a random available square
				int nextsquareIndex = rnd.Next (0, availableSquares.Length);

				//randomly choose a 2 or 4 for the square
				int lottery = rnd.Next (0, 100);
				if (lottery < 75) {
					nextNumber = 2;
				} else {
					nextNumber = 4;
				}

				//assign the square
				grid [availableSquares [nextsquareIndex]] = nextNumber;
			}
		}

		public static void DrawGrid(){
			Console.Clear ();
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine ("----------------------------");

			DrawRow (0, 4);
			DrawRow (4, 8);
			DrawRow (8, 12);
			DrawRow (12, 16);

			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine ("----------------------------");
			Console.WriteLine ("Score: " + score);
			Console.Write ("Up, Down, Left, Right to move. ESC to quit.");

		}

		public static void DrawRow(int start, int stop){
			//string subrow = "";

			for (int i = start; i < stop; i++) {
				if (grid [i] > 0) {
					switch (grid [i]) {
					case 2:
						Console.ForegroundColor = ConsoleColor.DarkYellow;
						Console.Write("███████");
						break;
					case 4:
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write("███████");
						break;
					case 8:
						Console.ForegroundColor = ConsoleColor.DarkGreen;
						Console.Write("███████");
						break;
					case 16:
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("███████");
						break;
					case 32:
						Console.ForegroundColor = ConsoleColor.DarkCyan;
						Console.Write("███████");
						break;
					case 64:
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.Write("███████");
						break;
					case 128:
						Console.ForegroundColor = ConsoleColor.DarkBlue;
						Console.Write("███████");
						break;
					case 256:
						Console.ForegroundColor = ConsoleColor.Blue;
						Console.Write("███████");
						break;
					case 512:
						Console.ForegroundColor = ConsoleColor.DarkMagenta;
						Console.Write("███████");
						break;
					case 1024:
						Console.ForegroundColor = ConsoleColor.Magenta;
						Console.Write("███████");
						break;
					case 2048:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write("███████");
						break;
					}
				} else {
					//subrow += "       ";
					Console.Write("       ");
				}
			}
			Console.Write ("\n");
			//Console.WriteLine (subrow);

			//subrow = "|";
			for (int i = start; i < stop; i++) {
				if (grid [i] > 0) {
					switch (grid [i]) {
					case 2:
						Console.ForegroundColor = ConsoleColor.DarkYellow;
						Console.Write("███2███");
						break;
					case 4:
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write("███4███");
						break;
					case 8:
						Console.ForegroundColor = ConsoleColor.DarkGreen;
						Console.Write("███8███");
						break;
					case 16:
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("██16███");
						break;
					case 32:
						Console.ForegroundColor = ConsoleColor.DarkCyan;
						Console.Write("██32███");
						break;
					case 64:
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.Write("██64███");
						break;
					case 128:
						Console.ForegroundColor = ConsoleColor.DarkBlue;
						Console.Write("██128██");
						break;
					case 256:
						Console.ForegroundColor = ConsoleColor.Blue;
						Console.Write("██256██");
						break;
					case 512:
						Console.ForegroundColor = ConsoleColor.DarkMagenta;
						Console.Write("██512██");
						break;
					case 1024:
						Console.ForegroundColor = ConsoleColor.Magenta;
						Console.Write("█1024██");
						break;
					case 2048:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write("█2048██");
						break;
					}

				} else {
					//subrow += "       ";
					Console.Write("       ");
				}
			}
			Console.Write ("\n");
			//Console.WriteLine (subrow);

			//subrow = "|";
			for (int i = start; i < stop; i++) {
				if (grid [i] > 0) {
					switch (grid [i]) {
					case 2:
						Console.ForegroundColor = ConsoleColor.DarkYellow;
						Console.Write("███████");
						break;
					case 4:
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.Write("███████");
						break;
					case 8:
						Console.ForegroundColor = ConsoleColor.DarkGreen;
						Console.Write("███████");
						break;
					case 16:
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("███████");
						break;
					case 32:
						Console.ForegroundColor = ConsoleColor.DarkCyan;
						Console.Write("███████");
						break;
					case 64:
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.Write("███████");
						break;
					case 128:
						Console.ForegroundColor = ConsoleColor.DarkBlue;
						Console.Write("███████");
						break;
					case 256:
						Console.ForegroundColor = ConsoleColor.Blue;
						Console.Write("███████");
						break;
					case 512:
						Console.ForegroundColor = ConsoleColor.DarkMagenta;
						Console.Write("███████");
						break;
					case 1024:
						Console.ForegroundColor = ConsoleColor.Magenta;
						Console.Write("███████");
						break;
					case 2048:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write("███████");
						break;
					}
				} else {
					Console.Write("       ");
				}
			}
			//Console.WriteLine (subrow);
			Console.Write ("\n");

		}
	}
}