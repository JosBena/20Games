using UnityEngine;
using System.IO;
using System;

namespace Practice {

	public class PersistentDataStorage : MonoBehaviour {
		private string savePath;
		[SerializeField] private GameManager gameManager;

		private void Awake() {
			savePath = Path.Combine(Application.persistentDataPath, "FlappySave");
		}

		public void Save(PersistentData o) {
			using (var writer = new BinaryWriter(File.Open(savePath, FileMode.Create))) {
				o.Save(new DataWriter(writer));
			}
		}

		public void Load(PersistentData o) {
			try {
				using (var reader = new BinaryReader(File.Open(savePath, FileMode.Open))) {
					o.Load(new DataReader(reader)); //saveSingle for floats
				}
			} catch (ArgumentException e) {
				Save(o);
				Debug.Log("test");
				Debug.Log(e.Message);
			}
		}
	}
}