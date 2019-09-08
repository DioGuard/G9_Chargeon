using System;
using System.IO;
using System.Xml;

namespace Chargeon {

	// Считывает симовольные изображения или информацию о них
	public static class InfoReader {
		
		// Считывает размер символьного изображения из указ.файла и возвращает кортеж высоты и ширины
		public static (int h, int w) ReadSizeChars(string infoFile, string key) {
			(int h, int w) size = (0, 0);

			XmlDocument doc = new XmlDocument();
			doc.Load(infoFile);
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

		// Считывает символьное изображение из указ.файла и возвращает двумерный массив символов
		public static char[,] ReadChars(string charsFile, (int h, int w) size) {

			StreamReader sr = new StreamReader("images/chars/" + charsFile);

			char[,] chars = new char[size.h, size.w];
			string temp;

			for (int y = 0; y < size.h; y++) {
				temp = sr.ReadLine();

				for (int x = 0; x < size.w; x++)
					chars[y, x] = temp[x];
			}

			sr.Close();

			return chars;
		}

		//
		public static char[,] ReadCharImage(string meta, string key) {
			string typeCharsFile = ".txt";

			(int h, int w) = ReadSizeChars(meta, key);


			return ReadChars(key + typeCharsFile, (h, w));
		}

	}
}

/*

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
		}*/


/*
		public static (int, int, string) ReadInfoImage(string file, string key) {
			(int h, int w, string path) = (0, 0, "");

			XmlDocument doc = new XmlDocument();
			doc.Load(file);
			XmlElement root = doc.DocumentElement;

			foreach (XmlNode node in root) {

				if (node.Attributes.GetNamedItem("name").Value == key) {

					foreach (XmlNode child in node.ChildNodes) {

						if (child.Name == "H")
							h = Convert.ToInt32(child.InnerText);

						if (child.Name == "W")
							w = Convert.ToInt32(child.InnerText);

						if (child.Name == "chars")
							path = child.InnerText;
					}

				}

			}

			return (h, w, path);
		}
*/
