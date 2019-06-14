using System.IO;
using System.Xml;

namespace Chargeon {
	internal static class InfosReader {

		public static char[,] readCharImage(string file, int h, int w) {

			StreamReader sr = new StreamReader(file);
			char[,] image = new char[h, w];
			string temp;

			for (int y = 0; y < h; y++) {
				temp = sr.ReadLine();

				for (int x = 0; x < w; x++)
					map[y, x] = temp[x];
			}

			sr.Close();

			return image;
		}

		public static (int, int) readSizeImage(string file) {
			XmlDocument doc = new XmlDocument();
			doc.Load(file);
			XmlElement root = doc.DocumentElement;

			foreach (XmlNode node in root) {
				if(node.Atributes.Count > 0) {

				}
			}


			return graphic;
		}


	}
}