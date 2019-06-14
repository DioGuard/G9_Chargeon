using System;
using System.IO;

namespace Chargeon {
	internal class Map {
		private const char _WALL = '█';
		public readonly int H;
		public readonly int W;

		public char[,] map;

		public GameObject[] go;

		public int WALL {
			get {
				Console.ForegroundColor = ConsoleColor.Red;
				return _WALL;
			}
		}


		public Map(string path) {

			StreamReader sr = new StreamReader(path);

			W = Convert.ToInt32(sr.ReadLine());
			H = Convert.ToInt32(sr.ReadLine());

			map = new char[H, W];

			string temp;

			for (int y = 0; y < H; y++) {
				temp = sr.ReadLine();

				for (int x = 0; x < W; x++) {
					map[y, x] = temp[x];
				}
			}

			go = new GameObject[4];
			go[0] = new Player(1, 1, "Jimbo", '@');
			go[1] = new Chest(9,  5);
			go[2] = new Chest(10, 5);
			go[3] = new Chest(11, 5);

			sr.Close();
		}

		public void DrawGO() {
			for (int y = 0; y < 5; y++) {
				for (int x = 0; x < 20; x++) {
					if (y == 0 || y == 5 || x == 0 || x == 19)
						Console.Write("=");
					else {
						Console.Write(" ");
					}
				}
				Console.WriteLine();
			}
		}

		public char GetCollusionGO(GameObject[] go, int y, int x) {
			foreach(GameObject obj in go) {
				if (obj.pos.x == x && obj.pos.y == y)
					return obj.look;
			}

			return ' ';
		}
	}
	}

/*
	ConsoleKeyInfo key;
	while (!Player.CheckCollusion(Location.finish)) {
		Location.DrawLoc();
		key = Console.ReadKey();

		switch(key.Key) {
			case ConsoleKey.UpArrow:
				Player.Move(-1, 0);
				break;
			case ConsoleKey.DownArrow:
				Player.Move(1, 0);
				break;
			case ConsoleKey.LeftArrow:
				Player.Move(0, -1);
				break;
			case ConsoleKey.RightArrow:
				Player.Move(0, 1);
				break;
		}

		Console.Clear();
	}

private Player CreatePlayer() {
	char look;
	string name;

	Console.Write("Назовите своего персонажа: ");
	name = Console.ReadLine();

	Console.Write("Выберите символ, которым он будет отображаться: ");
	look = (char)Console.Read();

	return new Player(0, 0, name, look);
}

public static void Draw(char sym) => Console.Write(sym);
}

public static (int, int) finish = (9, 17);

	public static void DrawLoc() {
	for (int y = 0; y < H; y++) {
		for (int x = 0; x < W; x++) {
			//if (Player.CheckCollusion(y, x)) {
			//Console.Write(Player.look);
			//Console.Write(" ");
			//} else {
			Console.Write(location[y, x]);
			//Console.Write(location[y, x]);
			//}
		}
		Console.WriteLine();
	}

	//Console.WriteLine($"[{Player.x}][{Player.y}]");
}


public class Player : GameObject {
private int level;

public Player(int x, int y, string name, char image)
	: base(x, y, name, image) {
	level = 1;

}
public static void Move(int dirY, int dirX) {
	if (!CheckInterval(y + dirY, 0, Location.H) || !CheckInterval(x + dirX, 0, Location.W))
		return;

	if (Location.location[y + dirY, x + dirX] != '█') {
		y += dirY;
		x += dirX;
	}
}

public static bool CheckCollusion(int dy, int dx) =>
	(y == dy && x == dx) ? true : false;

public static bool CheckCollusion((int dy, int dx) end) =>
	(y == end.dy && x == end.dx) ? true : false;

private static bool CheckInterval(int num, int min, int max) =>
	(num >= min && num < max) ? true : false;
}
 */
