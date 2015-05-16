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

		int retry = PlayerPrefs.GetInt (PreferenceKeys.KEY_NUM_OF_RETRY, 100);
		PlayerPrefs.SetInt (PreferenceKeys.KEY_NUM_OF_RETRY, retry + 1);

		Application.LoadLevel (0);
	}
	
}
