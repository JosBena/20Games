using Cysharp.Threading.Tasks;
using UnityEngine;

public class test : MonoBehaviour {

	private async void Start() {
		print('a');
		await UniTask.Delay(1, true);
		print("2");
	}
}