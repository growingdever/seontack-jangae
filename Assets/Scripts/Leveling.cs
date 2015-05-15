using UnityEngine;
using System.Collections;

public class Leveling {
	
	private static float[,] _DATA;	// Space & err Point  
	private static float[] _DATA2;	// Boss's Ability -> MAXIMUM's value(%)

	static Leveling()
	{ 
		_DATA = new float[,]{
			//Struct : HP / ATTACK / DEFENSE Position / HP_ERR / ATTACK_ERR / DEFENSE_ERR
			{0.8f, 0.2f, 0.5f, 0.2f, 0.2f, 0.2f},		//STAGE 1 BOSS
			{0.8f, 0.2f, 0.5f, 0.2f, 0.2f, 0.2f},		//STAGE 2 BOSS
			{0.8f, 0.2f, 0.5f, 0.2f, 0.2f, 0.2f}		//STAGE 3 BOSS
		};
		_DATA2 = new float[]{
			0.7f,					//STAGE 1 BOSS Ability
			0.8f,					//STAGE 2 BOSS Ability
			0.9f					//STAGE 3 BOSS Ability
		};
	}
	public static AbilityData GetMonsterDataByStage(int stage) {
		//return _DATA
		return new AbilityData (_DATA[stage,0], _DATA[stage,1], _DATA[stage,2]);
	}
	public static AbilityData GetMonsterDataByStage2(int stage) {
		//return _DATA2
		return new AbilityData (_DATA2[stage], _DATA2[stage], _DATA2[stage]);
	}
}
