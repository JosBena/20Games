using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour {
	[SerializeField] private Audio[] _audios;

	[SerializeField, Range(0f, 1f)] private float _volume = 0.3f;
	private AudioSource _audioSource;

	private void Awake() {
		_audioSource = GetComponent<AudioSource>();
	}

	public void Play(string name) {
		foreach (var audio in _audios) {
			if (audio.clip.name == name) {
				_audioSource.clip = audio.clip;
				_audioSource.volume = _volume;
				_audioSource.Play();
			}
		}
	}
}