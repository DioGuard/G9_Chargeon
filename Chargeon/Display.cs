using System;

namespace Chargeon {

	public class Display {

		private readonly int _W;
		private readonly int _H;
		private readonly string _TITLE;

		public int W { get => _W; }
		public int H { get => _H; }
		public string TITLE { get => _TITLE; }


		public Display(int w, int h, string title) {
			_W = w;
			_H = h;
			_TITLE = title;

			SetupDisplay();
		}

		private void SetupDisplay() {
			// Setup title
			Console.Title = TITLE;

			// Setup width and height of window
			Console.SetWindowSize(W, H);
			Console.SetBufferSize(W, H);

			Console.CursorVisible = false;
		}


		public void Clear() => Console.Clear();

		public void DrawString(string str, (int left, int top) offset, ConsoleColor color = ConsoleColor.White) {

			Console.ForegroundColor = color;

			Console.SetCursorPosition(offset.left, offset.top);

			Console.WriteLine(str);

		}

		public void DrawImage(char[,] image, (int left, int top) offset, ConsoleColor color = ConsoleColor.White) {

			Console.ForegroundColor = color;

			for (int y = 0; y < offset.top; y++) {

				Console.SetCursorPosition(offset.left, offset.top + y);

				for (int x = 0; x < offset.left; x++) {
					Console.Write(image[y, x]);
				}

				Console.WriteLine();
			}

		}

		public void DrawImageCenter(char[,] image, ConsoleColor color = ConsoleColor.Cyan) {
			Console.ForegroundColor = color;

			for (int y = 0; y < image.GetLength(0); y++) {

				Console.SetCursorPosition((W - image.GetLength(1)) / 2, (H - image.GetLength(0)) / 2 + y);

				for (int x = 0; x < image.GetLength(1); x++) {
					Console.Write(image[y, x]);
				}

				Console.WriteLine();
			}

		}


	}
}