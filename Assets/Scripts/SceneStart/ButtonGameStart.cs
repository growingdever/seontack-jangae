using UnityEngine;
using System.Collections;

public class ButtonGameStart : MonoBehaviour {

	void OnClick() {
		PlayerPrefs.SetInt (PreferenceKeys.KEY_CURRENT_STAGE, 1);
		Application.LoadLevel (1);
	}
}
