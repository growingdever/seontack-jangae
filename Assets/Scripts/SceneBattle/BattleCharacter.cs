using UnityEngine;
using System.Collections;

public class BattleCharacter {

	public float HP;
	public AbilityData Ability {
		get;
		private set;
	}

	public BattleCharacter(AbilityData ability) {
		this.Ability = ability;
	}

	public float CalculateDamage(BattleCharacter opponent) {
		//TODO : calculate damage by opponent ability
		return 0;
	}

}
