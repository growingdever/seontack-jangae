using UnityEngine;
using System.Collections;

public class SceneControllerSelection : MonoBehaviour {

	public UISprite[] SpriteSeeks;
	public int SeekWidth;
	public float SeekSpeed;
	public Transform PanelBattleStart;

	int _currAbility = 0;
	IEnumerator _currSeekCoroutine;
	bool _keyDownSpace;

	void Start() {
		StartCoroutine (ChooseNextAbility ());
	}

	void Update() {
		if (Input.GetKeyUp (KeyCode.Space)) {
			_keyDownSpace = true;
		}
	}

	IEnumerator ChooseNextAbility() {
		while (_currAbility < SpriteSeeks.Length) {
			_keyDownSpace = false;
			_currSeekCoroutine = MoveSpriteSeek ();
			yield return StartCoroutine (_currSeekCoroutine);
			_currAbility++;
		}

		StartCoroutine (StartAnimationFinishedSelection ());
	}
	
	IEnumerator MoveSpriteSeek() {
		UISprite currSpriteSeek = SpriteSeeks [_currAbility];
		while (!_keyDownSpace) {
			currSpriteSeek.transform.localPosition += new Vector3(SeekSpeed, 0.0f, 0.0f);
			if( currSpriteSeek.transform.localPosition.x >= (float)SeekWidth / 2 ) {
				currSpriteSeek.transform.localPosition = new Vector3(-1.0f * SeekWidth / 2, 0.0f, 0.0f);
			}
			yield return new WaitForEndOfFrame();
		}
	}

	IEnumerator StartAnimationFinishedSelection() {
		while (true) {
			PanelBattleStart.transform.localPosition += new Vector3(0.0f, -5.0f, 0.0f);
			if( PanelBattleStart.transform.localPosition.y <= 0 ) {
				break;
			}
			yield return new WaitForEndOfFrame();
		}
	}

}
