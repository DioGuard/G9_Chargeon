namespace Chargeon {
	abstract internal class GameObject {

		public (int x, int y) pos;
		public string name;
		public char look;

		public GameObject(int x, int y, string name, char look) {
			pos.x = x;
			pos.y = y;
			this.name = name;
			this.look = look;
		}
	}
}