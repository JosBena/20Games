using System.IO;
using UnityEngine;

namespace Practice {

	public class DataWriter {
		private BinaryWriter writer;

		public DataWriter(BinaryWriter writer) {
			this.writer = writer;
		}

		public void Write(float value) => writer.Write(value);

		public void Write(int value) => writer.Write(value);
	}
}