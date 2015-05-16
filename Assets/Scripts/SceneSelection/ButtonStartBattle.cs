using UnityEngine;
using System.Collections;

public class ButtonStartBattle : MonoBehaviour {

	public void OnClick() {
		GameObject.Find("SceneController").GetComponent<SceneControllerSelection>().InitPlayerStats ();
		Application.LoadLevel (2);
	}

}
