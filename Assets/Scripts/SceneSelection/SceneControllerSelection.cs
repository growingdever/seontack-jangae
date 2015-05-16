using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneControllerSelection : MonoBehaviour {

	public UISprite[] SpriteSeeks;
	public int SeekWidth;
	public float SeekSpeed;
	public UISprite SpriteFloorAura;
	public UILabel LabelRemainingTime;
	public UILabel LabelCritical;
	public int ReadyTime;
	public UISprite ButtonStart;
	public UILabel LabelStage;
	public AudioSource AudioSource;
	public AudioClipEntry[] audioClips;


	int _currAbility = 0;
	IEnumerator _currSeekCoroutine;
	bool _keyDownSpace;

	void Start() {
		StartCoroutine (ChooseNextAbility ());
		SpriteFloorAura.GetComponent<Animator> ().Play ("Idle");

		LabelCritical.text = string.Format ("숙련도 : {0}", PlayerPrefs.GetInt (PreferenceKeys.KEY_NUM_OF_RETRY, 100));
		StartCoroutine (UpdateRemainingTime());

		LabelStage.text = string.Format ("Stage : {0}", PlayerPrefs.GetInt(PreferenceKeys.KEY_CURRENT_STAGE, 0));
	}

	void Update() {
		if (Input.GetKeyUp (KeyCode.Space)) {
			_keyDownSpace = true;
		}
	}

	public void InitPlayerStats() {
		VariableStorage.Instance.PlayerStats1 = 
			(SpriteSeeks[0].transform.localPosition.x + 1.0f * SeekWidth / 2.0f)  / SeekWidth;
		VariableStorage.Instance.PlayerStats2 = 
			(SpriteSeeks[1].transform.localPosition.x + 1.0f * SeekWidth / 2.0f)  / SeekWidth;
		VariableStorage.Instance.PlayerStats3 = 
			(SpriteSeeks[2].transform.localPosition.x + 1.0f * SeekWidth / 2.0f)  / SeekWidth;
	}

	IEnumerator ChooseNextAbility() {
		while (_currAbility < SpriteSeeks.Length) {
			_keyDownSpace = false;
			_currSeekCoroutine = MoveSpriteSeek ();
			yield return StartCoroutine (_currSeekCoroutine);
			_currAbility++;
			PlaySound("chulkuk");
		}

		ButtonStart.GetComponent<Animator> ().enabled = true;
	}
	
	IEnumerator MoveSpriteSeek() {
		UISprite currSpriteSeek = SpriteSeeks [_currAbility];
		float prevY = currSpriteSeek.transform.localPosition.y;
		while (!_keyDownSpace) {
			currSpriteSeek.transform.localPosition += new Vector3(SeekSpeed * Time.deltaTime, 0, 0.0f);
			if( currSpriteSeek.transform.localPosition.x >= (float)SeekWidth / 2 ) {
				currSpriteSeek.transform.localPosition = new Vector3(-1.0f * SeekWidth / 2, prevY, 0.0f);
			}
			yield return new WaitForEndOfFrame();
		}

		InitPlayerStats ();
	}

	IEnumerator UpdateRemainingTime() {
		for( int i = 30; i >= 0; i -- ) {
			LabelRemainingTime.text = string.Format("남은 시간 : {0}", i);
			yield return new WaitForSeconds(1.0f);
		}

		InitPlayerStats ();
		Application.LoadLevel(2);
	}

	void PlaySound(string key) {
		for( int i = 0; i < audioClips.Length; i ++ ) {
			if( audioClips[i].audioName == key ) {
				AudioSource.PlayOneShot(audioClips[i].audioClip);
			}
		}
	}

}
