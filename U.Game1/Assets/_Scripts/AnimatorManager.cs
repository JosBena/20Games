using UnityEngine;
using Cysharp.Threading.Tasks;

public class AnimatorManager : MonoBehaviour {
	[SerializeField] private Animator[] animators;
	[SerializeField] private Animation[] animations;

	private void Start() {
	}

	public void PlayAnimatorAnimation(string animatorName, string animationName, float speed = 1f) {
		foreach (var animator in animators) {
			if (animator.name == animatorName) {
				AnimationClip[] animations = animator.runtimeAnimatorController.animationClips;
				foreach (var anim in animations) {
					if (anim.name == animationName) {
						animator.speed = speed;
						animator.Play(animationName);
						return;
					}
				}
				print($"{animationName} does not exit");
				return;
			}
		}
	}

	public async UniTask FadeOutSpriteRender(SpriteRenderer spriteRender, int fadeoutSpeed) {
		Color oldCol = spriteRender.sharedMaterial.color;
		while (oldCol.a > 0) {
			Color newCol = new Color(oldCol.r, oldCol.g, oldCol.b, oldCol.a - 0.01f);
			oldCol.a = newCol.a;
			if (newCol.a <= 0) newCol.a = 0;
			spriteRender.sharedMaterial.color = newCol;
			await UniTask.Delay(fadeoutSpeed, true, cancellationToken: this.GetCancellationTokenOnDestroy());//Problem herer
		}
	}

	public void ResetSpriteFromFadeOut(SpriteRenderer spriteRender) {
		Color oldCol = spriteRender.sharedMaterial.color;
		Color newCol = new Color(oldCol.r, oldCol.g, oldCol.b, 1f);
		spriteRender.sharedMaterial.color = newCol;
	}
}