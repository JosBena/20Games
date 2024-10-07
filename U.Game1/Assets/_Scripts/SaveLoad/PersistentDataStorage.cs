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

#if PLATFORM_WEBGL

		public void Save(PersistentData o) {
			PlayerPrefs.SetFloat("Score", gameManager.Score);
		}

		public void Load(PersistentData o) {
			gameManager.highscoreScore = PlayerPrefs.GetFloat("Score");
		}

#else
		public void Save(PersistentData o) {
			Debug.Log("saving" + o);
			using (var writer = new BinaryWriter(File.Open(savePath, FileMode.Create))) {
				o.Save(new DataWriter(writer));
			}
		}

		public void Load(PersistentData o) {
			try {
				using (var reader = new BinaryReader(File.Open(savePath, FileMode.Open))) {
					o.Load(new DataReader(reader)); //saveSingle for floats
				}
			} catch (FileNotFoundException e) {
				Save(o);
				Debug.Log("creating file due to: " + e.Message);
			}
		}
#endif
	}
}