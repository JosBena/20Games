using System.IO;
using UnityEngine;

namespace Practice {

	public class DataReader {
		private BinaryReader reader;

		public DataReader(BinaryReader reader) {
			this.reader = reader;
		}

		public float ReadFLoat() => reader.ReadSingle();

		public int ReadInt() => reader.ReadInt32();
	}
}