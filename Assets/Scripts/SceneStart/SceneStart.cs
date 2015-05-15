using UnityEngine;
using System.Collections;

public class SceneStart : MonoBehaviour {
	
	public void OnClickStart()
	{
		Debug.Log ("Click Start");
		//change GameScene1
		Application.LoadLevel (1);
	}
	public void OnClickEnd()
	{
		Debug.Log ("Click End");
		//EXIT GAME
		Application.Quit();
	}
}
