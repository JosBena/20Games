using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Practice {

	public class GameManager : PersistentData {
		[SerializeField] private PlayerController player;

		[Header("Animator")]
		[SerializeField] private AnimatorManager _animatorManager;
		[SerializeField] private GameObject GameOverSprite;
		[SerializeField, Tooltip("milli*10, secs=milli*1000")] private int fadeoutMicroSeconds = 100;

		[Header("UI")]
		[SerializeField] private Button[] lobbyButtons;
		[SerializeField] private GameObject panel;
		[SerializeField] private TextMeshProUGUI scoreText;

		[Header("Audio")]
		[SerializeField] private AudioPlayer _audioPlayer;
		private float score = 0;

		private SpriteRenderer _spriteRender;

		//saving Loading
		public float Score { get => score; }

		[SerializeField] private TextMeshProUGUI highscoreText;
		public float highscoreScore;
		[SerializeField] private PersistentDataStorage _persistentData;

		public enum GameState { Start, Pause, GameOver, Lobby }

		public GameState pauseState = GameState.Lobby;
		private bool inLobby;

		private void Awake() {
			Screen.SetResolution(800, 600, false);
			_spriteRender = player.GetComponent<SpriteRenderer>();
			_animatorManager.ResetSpriteFromFadeOut(_spriteRender);
			inLobby = true;
		}

		private void OnEnable() {
			player.DeathEvent += GameOver;
			Play();
		}

		private void OnDisable() {
			player.DeathEvent -= GameOver;
		}

		private async void GameOver() {
			await AnimateDeath();
			PauseAndStart(GameState.GameOver);
			if (highscoreScore <= score) _persistentData.Save(this);
		}

		private async UniTask AnimateDeath() {
			_animatorManager.PlayAnimatorAnimation(AnimList.playerAnim, AnimList.playerDeadAnim, 0.25f);
			_audioPlayer.Play(Helper.deathSoundName);
			Time.timeScale = 0f;
			await _animatorManager.FadeOutSpriteRender(_spriteRender, fadeoutMicroSeconds * 10);
			//print("b");
			await UniTask.Delay(200, true);
		}

		public void Restart() {
			score = 0;
			_persistentData.Save(this);
			Play();
		}

		public void Play() {
			_animatorManager.ResetSpriteFromFadeOut(_spriteRender);
			if (_persistentData != null) _persistentData.Load(this); highscoreText.text = $"{highscoreScore}";
			(score, scoreText.text, player.transform.position) = (0, "0", Vector3.zero);
			Pipe[] pipes = FindObjectsOfType<Pipe>();
			foreach (Pipe pipe in pipes) Destroy(pipe.gameObject);
			pauseState = inLobby ? GameState.Lobby : GameState.Start;
			if (pauseState == GameState.Start)
				_animatorManager.PlayAnimatorAnimation(AnimList.playerAnim, AnimList.playerAnimation);
			PauseAndStart(pauseState);
			if (inLobby) inLobby = false;
		}

		public void Quit() => Application.Quit();

		public void IncreaseScore() {
			scoreText.text = $"{++score}";
			_audioPlayer.Play(Helper.coinPickupClipName);
			if (score > highscoreScore) (highscoreScore, highscoreText.text) = (score, $"{score}");
		}

		public void PauseAndStart(GameState state = GameState.Start) {
			pauseState = state;
			(bool buttonState, bool isGameOver, bool LobbyButtons) boolStates = (false, false, false);

			(Time.timeScale, player.enabled, boolStates) = pauseState switch {
				GameState.Start => (1, true, (false, false, false)),
				GameState.Pause => (0, false, (true, false, false)),
				GameState.GameOver => (0, true, (true, true, false)),
				GameState.Lobby => (0, false, (false, false, true)),
				_ => (0, false, (true, false, false))
			};
			foreach (var button in lobbyButtons) button.gameObject.SetActive(boolStates.LobbyButtons);
			panel.SetActive(boolStates.buttonState);
			GameOverSprite.SetActive(boolStates.isGameOver);
		}
	}
}