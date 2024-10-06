using System;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

namespace Practice {

	public class Player : MonoBehaviour {
		[SerializeField] private float _jumpStrength = 5f;
		private const float _gravity = -9.81f;
		private Vector3 _direction;

		[SerializeField] private Sprite[] _sprite;
		private SpriteRenderer _spriteRenderer;
		//private int _spriteIndex = 0;

		//[SerializeField] private float _animationSpeed = 0.15f;
		[SerializeField] private AnimatorManager _animManageer;
		[SerializeField] private GameManager _gameManager;
		public Action DeathEvent;

		[SerializeField] private float _rotationSPeed = 10f;

		private void Awake() {
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void OnEnable() {
			_direction = Vector3.zero;
			Vector3 pos = transform.position;
			pos.y = 0f;
			transform.position = pos;
		}

		private void Start() {
			AnimateSprite();
		}

		private void Death() {
			//_spriteRenderer.sprite = _sprite[^1];
			DeathEvent?.Invoke();
		}

		private void AnimateSprite() {
			//_spriteIndex++;
			//if (_spriteIndex >= _sprite.Length - 1) _spriteIndex = 0; //-1 because death animation
			//_spriteRenderer.sprite = _sprite[_spriteIndex];
			_animManageer.PlayAnimatorAnimation(AnimList.playerAnim, AnimList.playerAnimation);
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
				_direction = Vector3.up * _jumpStrength;
			}

			if (Input.touchCount > 0) {
				Touch touch = Input.GetTouch(0);
				if (touch.phase == TouchPhase.Began) {
					_direction = Vector3.up * _jumpStrength;
				}
			}

			_direction.y += _gravity * Time.deltaTime;

			transform.position += _direction * Time.deltaTime;
		}

		private void FixedUpdate() {
			transform.rotation = Quaternion.Euler(0, 0, _direction.y * _rotationSPeed);
		}

		private void OnTriggerEnter2D(Collider2D collision) => TagDesider(collision)?.Invoke();

		private Action TagDesider(Collider2D collision) => collision.tag switch {
			"Obstacle" => Death,
			"Scoring" => _gameManager.IncreaseScore,
			_ => () => Debug.Log("Not Implemented")
		};
	}
}