using UnityEngine;
using System.Collections;

public class Leveling {
	
	private static float[,] _DATA = {
		{0.8f, 0.2f, 0.5f, 0.2f, 0.2f, 0.2f},		//STAGE 1 BOSS
		{0.8f, 0.2f, 0.5f, 0.2f, 0.2f, 0.2f},		//STAGE 2 BOSS
		{0.8f, 0.2f, 0.5f, 0.2f, 0.2f, 0.2f}		//STAGE 3 BOSS
	};	// Space & err Point  
	private static float[] _DATA2 = {
		0.7f,					//STAGE 1 BOSS Ability
		0.8f,					//STAGE 2 BOSS Ability
		0.9f					//STAGE 3 BOSS Ability
	};	// Boss's Ability -> MAXIMUM's value(%)

	public static AbilityData GetMonsterDataByStage(int stage) {
		Debug.Log ("stage : " + stage);
		//return _DATA
		return new AbilityData (Leveling._DATA[stage,0], Leveling._DATA[stage,1], Leveling._DATA[stage,2]
		                        ,Leveling._DATA[stage,3],Leveling._DATA[stage,4],Leveling._DATA[stage,5]);
	}
	public static AbilityData GetMonsterDataByStage2(int stage) {
		//return _DATA2
		return new AbilityData (Leveling._DATA2[stage], Leveling._DATA2[stage], Leveling._DATA2[stage]);
	}
}
