using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour {
	[SerializeField] private GameObject _prefab;
	[SerializeField] private float spawnRate = 1f, minHeight = -1f, maxHeight = 1f;
	[SerializeField] private bool displayHeights = false;
	private Transform _min, _max;

	private void OnEnable() {
		InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
	}

	private void OnDisable() {
		CancelInvoke(nameof(Spawn));
	}

#if UNITY_EDITOR

	private void OnDrawGizmos() {
		SpawnSpheres(minHeight);
		SpawnSpheres(maxHeight);
	}

	public void SpawnSpheres(float height) {
		if (!displayHeights) return;
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position + new Vector3(0, height), .1f);
	}

#endif

	private void Spawn() {
		GameObject pipes = Instantiate(_prefab, transform.position, Quaternion.identity);
		pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
	}
}