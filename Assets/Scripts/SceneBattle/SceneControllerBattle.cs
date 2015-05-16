﻿using UnityEngine;
using System.Collections;

public class SceneControllerBattle : MonoBehaviour {

	public UISprite SpriteBarPlayer;
	public UISprite SpriteBarMonster;
	public float BarWidth;
	public DamageNumberEffect DamageNumberEffect;
	public Transform GameObjectPlayer;
	public Transform GameObjectMonster;
	public Transform TransformResultPanel;
	public UISprite SpriteWin;
	public UISprite SpriteLose;
	public float ResultPanelTransitionTime;
	public AudioSource AudioSource;
	public AudioClipEntry[] audioClips;
	BattleCharacter _battleCharacterPlayer;
	BattleCharacter _battleCharacterMonster;


	void Start() {
		_battleCharacterPlayer = new BattleCharacter (
			new AbilityData(VariableStorage.Instance.PlayerStats1, 
		                VariableStorage.Instance.PlayerStats2, 
		                VariableStorage.Instance.PlayerStats3)
			,
			Leveling.GetMonsterDataByStage(
				PlayerPrefs.GetInt (PreferenceKeys.KEY_CURRENT_STAGE, 1) - 1)
			);
		_battleCharacterMonster = new BattleCharacter(
			Leveling.GetMonsterDataByStage2(
				PlayerPrefs.GetInt (PreferenceKeys.KEY_CURRENT_STAGE, 1) - 1)
			);
		GameObjectMonster.GetComponentInChildren<UISprite> ().spriteName = string.Format ("mon_{0:00}", PlayerPrefs.GetInt (PreferenceKeys.KEY_CURRENT_STAGE, 1));
	}

	public void OnCollisionBetweenBattleCharacter() {
		float calculatedDamage1 = _battleCharacterPlayer.CalculateDamage (_battleCharacterMonster);
		float calculatedDamage2 = _battleCharacterMonster.CalculateDamage (_battleCharacterPlayer);

		int luck = PlayerPrefs.GetInt (PreferenceKeys.KEY_NUM_OF_RETRY, 100);
		float probability = luck * 0.001f;
		float random = Random.Range (0.0f, 100.0f);
		if (probability > random) {
			calculatedDamage1 *= 2;
		}

		_battleCharacterPlayer.HP -= calculatedDamage2;
		_battleCharacterMonster.HP -= calculatedDamage1;

		GameObject go1 = NGUITools.AddChild (GameObjectPlayer.transform.parent.gameObject, DamageNumberEffect.gameObject);
		go1.transform.localPosition = GameObjectPlayer.transform.localPosition;
		go1.GetComponent<DamageNumberEffect> ().SetNumber (calculatedDamage2 + Random.Range(0, 9));

		GameObject go2 = NGUITools.AddChild (GameObjectPlayer.transform.parent.gameObject, DamageNumberEffect.gameObject);
		go2.transform.localPosition = GameObjectMonster.transform.localPosition;
		go2.GetComponent<DamageNumberEffect> ().SetNumber (calculatedDamage1 + Random.Range(0, 9));

		SpriteBarPlayer.width = (int)(1.0 * _battleCharacterPlayer.HP / _battleCharacterPlayer.MaxHP * BarWidth);
		SpriteBarMonster.width = (int)(1.0 * _battleCharacterMonster.HP / _battleCharacterMonster.MaxHP * BarWidth);

		if (_battleCharacterPlayer.HP <= 0) {
			OnLose();
		} else if (_battleCharacterMonster.HP <= 0) {
			OnWin();
		}

		PlaySound ("effect_crush");
	}

	public void OnWin() {
		GameObjectPlayer.gameObject.SetActive (true);
		GameObjectMonster.gameObject.SetActive (false);

		int highestStage = PlayerPrefs.GetInt (PreferenceKeys.KEY_HIGHEST_STAGE, 1);
		int nextStage = PlayerPrefs.GetInt (PreferenceKeys.KEY_CURRENT_STAGE, 1) + 1;
		if (nextStage > highestStage) {
			PlayerPrefs.SetInt (PreferenceKeys.KEY_HIGHEST_STAGE, nextStage);
		}

		StartCoroutine (StartAnimationWin ());
	}

	public void OnLose() {
		GameObjectPlayer.gameObject.SetActive (false);
		GameObjectMonster.gameObject.SetActive (true);

		PlayerPrefs.SetInt (PreferenceKeys.KEY_CURRENT_STAGE, 1);

		StartCoroutine (StartAnimationLose ());
	}

	IEnumerator StartAnimationWin() {
		TransformResultPanel.gameObject.SetActive (true);
		SpriteLose.gameObject.SetActive (false);

		AudioSource.Stop ();
		float length = PlaySound ("effect_win");

		SpriteWin.GetComponent<Animator> ().Play ("Idle");
		yield return new WaitForSeconds (ResultPanelTransitionTime + 2);

		PlayerPrefs.SetInt (PreferenceKeys.KEY_CURRENT_STAGE, PlayerPrefs.GetInt(PreferenceKeys.KEY_CURRENT_STAGE, 1));

		Application.LoadLevel (1);
		yield break;
	}

	IEnumerator StartAnimationLose() {
		TransformResultPanel.gameObject.SetActive (true);
		SpriteWin.gameObject.SetActive (false);

		AudioSource.Stop ();
		float length = PlaySound ("effect_lose");

		SpriteLose.GetComponent<Animator> ().Play ("Idle");
		yield return new WaitForSeconds (length + 2);
		Application.LoadLevel (3);
		yield break;
	}

	float PlaySound(string key) {
		for( int i = 0; i < audioClips.Length; i ++ ) {
			if( audioClips[i].audioName == key ) {
				AudioSource.PlayOneShot(audioClips[i].audioClip);
				return audioClips[i].audioClip.length;
			}
		}

		return 0;
	}

}
