using System;
using System.IO;
using System.Threading;
using System.Xml;

namespace Chargeon {

	internal class Game {

		private const int W = 140;
		private const int H = 40;

		private const string COMPANY = "[D.G] Darkhouse Games";
		private const string NAME = "Chargeon";
		private const string VERSION = "v.0.1";


		static void Main(string[] args) {
			SetupWindow();
			PrintLogotype();
			//InfoReader.ReadCharImage("images.xml", "logotype");
			//Map map = new Map("map_0.txt");
			//Draw(map);

			//Draw(InfoReader.ReadCharImage("images.xml", "logotype"));

			//while(true) {

			//}

			//Console.ReadKey();

		}

		private static void SetupWindow() {
			Console.Title = NAME + " " + VERSION + " " + COMPANY;

			Console.SetWindowSize(W, H);
			Console.SetBufferSize(W, H);
		}

		private static void PrintLogotype() {

			int time = 200;
			int keep;

			(int h, int w) size_logo = InfoReader.ReadSizeImage("images.xml", "logotype");
			char[,] logo = InfoReader.ReadCharImage("chars/title.txt", size_logo);

			ConsoleColor[] color = { ConsoleColor.Black,
									ConsoleColor.DarkBlue,
									ConsoleColor.DarkCyan,
									ConsoleColor.Cyan,
									ConsoleColor.White
			}; 

			for (int i = 0; i < color.Length * 2; i++) {
				keep = i < color.Length ? i : color.Length * 2 - i - 1;

				Draw(logo, size_logo, color[keep]);
				SimpleDraw(COMPANY, W / 2 - COMPANY.Length / 2, H / 2 + 1, color[keep]);

				Console.CursorLeft = W / 2;
				Thread.Sleep(keep * time);
				Console.Clear();
			}

		}


		public static void SimpleDraw(string str, int left, int top, ConsoleColor color = ConsoleColor.White) {
			Console.SetCursorPosition(left, top);
			Console.ForegroundColor = color;
			Console.WriteLine(COMPANY);
		}

		public static void Draw(char[,] image, (int h, int w) size, ConsoleColor color = ConsoleColor.White) {
			Console.ForegroundColor = color;

			for (int y = 0; y < size.h; y++) {

				Console.SetCursorPosition(W / 2 - size.w / 2, H / 2 - size.h + y);

				for (int x = 0; x < size.w; x++) {
					if (image[y, x] == '█')
						Console.Write('#');
					else
						Console.Write(image[y, x]);
				}

				Console.WriteLine();
			}

		}

		public static void Draw(char[,] image, ConsoleColor color = ConsoleColor.White) {
			Console.ForegroundColor = color;

			for (int y = 0; y < image.Rank; y++) {

				//Console.SetCursorPosition(W / 2 - image.Length / 2, H / 2 - image.Rank + y);

				for (int x = 0; x < image.Length; x++) {
					Console.Write(image[y, x]);
				}

				Console.WriteLine();
			}

		}

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

		}

	}

	internal static class InfoReader {

		public static char[,] ReadCharImage(string file, string key) {

			(int h, int w) = ReadSizeImage(file, key);

			return ReadCharImage("chars/player.txt", (h, w));
		}

		public static string ReadImage(string file, (int h, int w) size) {

			string temp = "";

			XmlDocument doc = new XmlDocument();
			doc.Load(file);
			XmlElement root = doc.DocumentElement;

			foreach (XmlNode node in root) {
					foreach (XmlNode child in node.ChildNodes) {

						if (child.Name == "chars")
							temp = child.InnerText;

					}

			}

			return temp;
		}

		public static char[,] ReadCharImage(string file, (int h, int w) size) {

			StreamReader sr = new StreamReader(file);
			char[,] image = new char[size.h, size.w];
			string temp;

			for (int y = 0; y < size.h; y++) {
				temp = sr.ReadLine();

				for (int x = 0; x < size.w; x++)
					image[y, x] = temp[x];
			}

			sr.Close();

			return image;
		}

		public static (int, int) ReadSizeImage(string file, string key) {
			(int h, int w) size = (0, 0);

			XmlDocument doc = new XmlDocument();
			doc.Load(file);
			XmlElement root = doc.DocumentElement;

			foreach (XmlNode node in root) {

				if (node.Attributes.GetNamedItem("name").Value == key) {

					foreach (XmlNode child in node.ChildNodes) {

						if (child.Name == "H")
							size.h = Convert.ToInt32(child.InnerText);

						if (child.Name == "W")
							size.w = Convert.ToInt32(child.InnerText);
					}

				}

			}

			return size;
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
