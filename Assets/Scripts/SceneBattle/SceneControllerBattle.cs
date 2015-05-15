using UnityEngine;
using System.Collections;

public class SceneControllerBattle : MonoBehaviour {

	public GameObject GameObjectPlayer;
	public GameObject GameObjectMonster;
	BattleCharacter _battleCharacterPlayer;
	BattleCharacter _battleCharacterMonster;

	void Start() {
		_battleCharacterPlayer = new BattleCharacter (
			new AbilityData(VariableStorage.Instance.PlayerStats1, 
		                VariableStorage.Instance.PlayerStats2, 
		                VariableStorage.Instance.PlayerStats3));
		_battleCharacterMonster = new BattleCharacter(
			Leveling.GetMonsterDataByStage(
				PlayerPrefs.GetInt (PreferenceKeys.KEY_CURRENT_STAGE, 1)));
	}

	public void OnCollisionBetweenBattleCharacter() {
		print ("damage!");

		float calculatedDamage1 = _battleCharacterPlayer.CalculateDamage (_battleCharacterMonster);
		float calculatedDamage2 = _battleCharacterMonster.CalculateDamage (_battleCharacterPlayer);

		_battleCharacterPlayer.HP -= calculatedDamage2;
		_battleCharacterMonster.HP -= calculatedDamage1;

		if (_battleCharacterPlayer.HP <= 0) {
			OnLose();
		} else if (_battleCharacterMonster.HP <= 0) {
			OnWin();
		}
	}

	public void OnWin() {
		GameObjectPlayer.SetActive (false);
		GameObjectMonster.SetActive (false);

		int highestStage = PlayerPrefs.GetInt (PreferenceKeys.KEY_HIGHEST_STAGE, 1);
		int nextStage = PlayerPrefs.GetInt (PreferenceKeys.KEY_CURRENT_STAGE, 1) + 1;
		if (nextStage > highestStage) {
			PlayerPrefs.SetInt (PreferenceKeys.KEY_HIGHEST_STAGE, nextStage);
		}

		StartCoroutine (StartAnimationWin ());
	}

	public void OnLose() {
		GameObjectPlayer.SetActive (false);
		GameObjectMonster.SetActive (false);

		PlayerPrefs.SetInt (PreferenceKeys.KEY_CURRENT_STAGE, 1);

		StartCoroutine (StartAnimationLose ());
	}

	IEnumerator StartAnimationWin() {
		yield break;
	}

	IEnumerator StartAnimationLose() {
		yield break;
	}

}
