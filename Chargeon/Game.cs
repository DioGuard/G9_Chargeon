using System;
using System.Threading;

namespace Chargeon {

	public static class Game {

		private const int W = 140;
		private const int H = 40;

		private const string COMPANY = "Darkhouse Games";
		private const string NAME = "Chargeon";
		private const string VERSION = "v.0.1";

		private const string IMAGE_INFO = "images/images.xml";
		private const string MAP_INFO = "images/map.xml";

		private delegate void CurrentScene(Display d);

		private static bool _EXIT = false;
		private static CurrentScene currentScene;


		static CurrentScene CurScene { get => currentScene; set => currentScene = value; }
		public static bool EXIT { get => _EXIT; set => _EXIT = value; }

		static void Main(string[] args) {
			Display d = new Display(W, H, NAME);

			currentScene = StartLogotypeScene;

			while (!EXIT) {
				currentScene(d);
			}


			//SetupWindow();
			//Draw(InfoReader.ReadCharImage(IMAGE_INFO, "logotype"));
			//StartLogotypeScene();
			//StartMainMenu();

			//InfoReader.ReadCharImage(IMAGE_INFO, "player");
			//Map map = new Map("map_0.txt");
			//Draw(map);

			//Console.ReadKey();

		}

		private static void StartLogotypeScene(Display d) {

			int time = 200;
			int keep;

			char[,] logo = InfoReader.ReadCharImage(IMAGE_INFO, "logotype");

			ConsoleColor[] colorAnim = {
				ConsoleColor.Black,
				ConsoleColor.DarkBlue,
				ConsoleColor.DarkCyan,
				ConsoleColor.Cyan,
				ConsoleColor.White
			};


			for (int i = 0; i < colorAnim.Length * 2; i++) {
				keep = i < colorAnim.Length ? i : colorAnim.Length * 2 - i - 1;

				Draw(logo, colorAnim[keep]);
				TextDraw(COMPANY, (W - COMPANY.Length) / 2, (H + logo.GetLength(0)) / 2 + 1, colorAnim[keep]);

				Thread.Sleep(keep * time);
				Console.Clear();
			}

			d.Clear();

			currentScene = StartMainMenu;
		}

		private static void StartMainMenu(Display d) {

			string[] menuChoose = { "Новая игра", "Продолжить", "Настройки", "Выход" };
			int curChoice = 0;
			bool EXIT = false;

			ConsoleKeyInfo key;

			do {

				Console.Clear();

				Draw(InfoReader.ReadCharImage(IMAGE_INFO, "title"));

				for (int i = 0; i < menuChoose.Length; i++)
					TextDraw(menuChoose[i], (W - menuChoose[i].Length) / 2, H / 2 + 5 + i,
								i == curChoice ? ConsoleColor.DarkCyan : ConsoleColor.White);

				//Console.SetCursorPosition((W - menuChoose[curChoose].Length) / 2 - 2, H / 2 + curChoose);

				key = Console.ReadKey();

				switch (key.Key) {

					case ConsoleKey.UpArrow:
						curChoice -= (curChoice > 0) ? 1 : 0;
						break;

					case ConsoleKey.DownArrow:
						curChoice += (curChoice < menuChoose.Length - 1) ? 1 : 0;
						break;

					case ConsoleKey.Enter:
						switch(curChoice) {
							case 0:
								currentScene = StartGameScene;
								break;
							case 1:
								currentScene = StartSettings;
								break;
							default:
								currentScene = StartSettings;
								break;

						}

						EXIT = true;
						break;
				}

			} while (!EXIT);

			d.Clear();
		}

		private static void StartGameScene(Display d) {

			Map map = new Map("map");

			do {
				d.Clear();

				Draw(map.map, (0, 0));

				foreach(GameObject go in map.go) {
					SimpleDraw(go.look, go.pos.x, go.pos.y);

				}

				Thread.Sleep(2000);
			} while (true);

			/*
			ConsoleKeyInfo key;
			while (!Player.CheckCollusion(Location.finish)) {
				Location.DrawLoc();
				key = Console.ReadKey();

				switch (key.Key) {
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
			}*/

		}



		public static void TextDraw(string str, int left, int top, ConsoleColor color = ConsoleColor.White) {
			Console.SetCursorPosition(left, top);
			Console.ForegroundColor = color;
			Console.WriteLine(str);
		}

		public static void SimpleDraw(char str, int left, int top, ConsoleColor color = ConsoleColor.White) {
			Console.SetCursorPosition(left, top);
			Console.ForegroundColor = color;
			Console.WriteLine(str);
		}

		public static void Draw(char[,] image, (int h, int w) size, ConsoleColor color = ConsoleColor.White) {
			Console.ForegroundColor = color;
			Console.SetCursorPosition(0, 0);

			for (int y = 0; y < size.h; y++) {


				for (int x = 0; x < size.w; x++) {
					Console.Write(image[y, x]);
				}

				Console.WriteLine();
			}

		}

		public static void Draw(char[,] image, ConsoleColor color = ConsoleColor.Cyan) {

			for (int y = 0; y < image.GetLength(0); y++) {

				Console.SetCursorPosition((W - image.GetLength(1)) / 2, (H - image.GetLength(0)) / 2 + y);

				for (int x = 0; x < image.GetLength(1); x++) {

					if (image[y, x] == '░')
						Console.ForegroundColor = ConsoleColor.Gray;
					else
						Console.ForegroundColor = color;

					Console.Write(image[y, x]);
				}

				Console.WriteLine();
			}

		}

		public static void StartSettings(Display d) {

			TextDraw("SAS", W / 2, H / 2);
		}

		/*
		public static void Draw(Map m) {
			Console.Clear();

			for (int y = 0; y < m.H; y++) {

				for (int x = 0; x < m.W; x++) {

					if (m.map[y, x] == m.WALL)
						Console.Write(m.map[y, x]);
					//else {
					//Console.Write(m.GetCollusionGO(m.go, y, x));
					//}
				}

				Console.WriteLine();
			}

		}*/

		/*
		private static void SetupWindow() {
			Console.Title = NAME + " " + VERSION;

			Console.SetWindowSize(W, H);
			Console.SetBufferSize(W, H);

			Console.CursorVisible = false;
		}*/
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
