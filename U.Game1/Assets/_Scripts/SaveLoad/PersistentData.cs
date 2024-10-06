using UnityEngine;

namespace Practice {

	[DisallowMultipleComponent]
	public class PersistentData : MonoBehaviour {
		[SerializeField] private GameManager _gameManager;

		public void Save(DataWriter writer) {
			writer.Write(_gameManager.Score);
		}

		public void Load(DataReader reader) {
			_gameManager.highscoreScore = reader.ReadFLoat();
		}
	}
}