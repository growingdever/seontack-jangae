using UnityEngine;
using System.Collections;

public class ButtonStartBattle : MonoBehaviour {

	public void OnClick() {
		PlayerPrefs.SetInt (PreferenceKeys.KEY_CURRENT_STAGE, PlayerPrefs.GetInt (PreferenceKeys.KEY_CURRENT_STAGE, 1) + 1);
		Application.LoadLevel ("game2");
	}

}
