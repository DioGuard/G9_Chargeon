namespace Chargeon {
	internal class Chest : GameObject {
		public Chest(int x, int y) 
			: base(x, y, "Chest", '■') {

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
