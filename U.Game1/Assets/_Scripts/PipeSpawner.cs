using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Practice {

	public class PipeSpawner : MonoBehaviour {
		[SerializeField] private GameObject _pipePrefab;
		[SerializeField] private int _timeInBetween = 2;
		[SerializeField] private Transform _maxHeight, _minHeight;

		private void OnEnable() {
			InvokeRepeating(nameof(Spawn), _timeInBetween, _timeInBetween);
		}

		private void OnDisable() {
			CancelInvoke(nameof(Spawn));
		}

		private void Spawn() {
			Vector3 _randomPosition = new Vector3(transform.position.x, Random.Range(_minHeight.position.y, _maxHeight.position.y));
			GameObject pipe = Instantiate(_pipePrefab, _randomPosition, Quaternion.identity);
			pipe.transform.parent = transform;
		}
	}
}