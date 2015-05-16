using UnityEngine;
using System.Collections;

public class BattleCharacter {

	public float MaxHP;
	public float HP;		//charater HP
	public float ATTACK;	//charater Damage
	public float DEFENSE;	//charater Armer

	// 주인공의 능력을 계산하기 위한 BattleCharacter 생성자1
	public BattleCharacter(AbilityData ability, AbilityData opponent) {
		this.MaxHP = this.HP = 3000f * Calculate_F(opponent.Ability1, ability.Ability1, opponent.Error1);
		this.ATTACK = 500f * Calculate_F(opponent.Ability2, ability.Ability2, opponent.Error2);
		this.DEFENSE = 300f * Calculate_F(opponent.Ability3, ability.Ability3, opponent.Error3);
	}
	// 몬스터의 능력을 계산하기 위한 BattleCharacter 생성자2
	public BattleCharacter(AbilityData Diffuse) {
		this.MaxHP = this.HP = 3000f * Diffuse.Ability1;
		this.ATTACK = 500f * Diffuse.Ability2;
		this.DEFENSE = 300f * Diffuse.Ability3;
	}

	/* 	Calculate_F()
		1. 목표위치와 선택위치의 차이를 계산하여 절대적인 수치(0f ~1f)의 값을 반환한다.
		2. 에러포함값을 고려한다.
	 */
	private float Calculate_F(float opponentAbility, float playerAbility, float playerError){

		float VALUE = Mathf.Abs (opponentAbility - playerAbility);
		float _F;

		if (VALUE == 0f)
			_F = 1.0f;
		else if (VALUE < playerError)// Error2 VALUE is smaller than 0.3f
			_F = 1.0f - VALUE;
		else
			_F = 0.7f;

		return _F;
	}
	// 데미지를 계산한다.
	public float CalculateDamage(BattleCharacter opponent) {

		//TYPE 1 : ATTACK - DEFNSE (must be ATTACK > DEFENSE)
		return (opponent.ATTACK - DEFENSE);
		//TYPE 2 : (TYPE 1's VALUE)*LUCK;
		//return (opponent.ATTACK - DEFENSE)*LUCK;
	}

}
