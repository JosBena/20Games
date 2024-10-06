using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour {
	[SerializeField] private TextMeshProUGUI _scoreText;
	private int score;
	[SerializeField] private GameObject _playButton, _gameOver;
	[SerializeField] private Player _player;

	private void Awake() {
		Application.targetFrameRate = 60;

		Pause();
	}

	public void Play() {
		score = 0;
		_scoreText.text = score.ToString();

		_playButton.SetActive(false);
		_gameOver.SetActive(false);

		Time.timeScale = 1f;
		_player.enabled = true;

		Pipe[] pipes = FindObjectsOfType<Pipe>();

		foreach (Pipe pipe in pipes) Destroy(pipe.gameObject);
	}

	private void Pause() {
		Time.timeScale = 0f;
		_player.enabled = false;
	}

	public void GameOver() {
		_gameOver.SetActive(true);
		_playButton.SetActive(true);

		Pause();
	}

	public void IncreaseScore() {
		score++;
		_scoreText.text = score.ToString();
	}

	public void Missing() => Debug.LogError("Not Implemented");
}