using UnityEngine;
using System.Collections;

public class SceneControllerGameOver : MonoBehaviour {

	public UILabel LabelMessage;
	public float TransitionTime;


	public void OnFinishedFadeIn() {
		StartCoroutine (Transition ());
	}

	IEnumerator Transition() {
		yield return new WaitForSeconds (TransitionTime + 2);
		TweenAlpha.Begin (LabelMessage.gameObject, TransitionTime, 0.0f).PlayForward();
		yield return new WaitForSeconds (TransitionTime + 2);
		Application.LoadLevel (0);
	}
	
}
