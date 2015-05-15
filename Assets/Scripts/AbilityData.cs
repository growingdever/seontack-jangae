using UnityEngine;
using System.Collections;

public class AbilityData {

	public float Ability1 { get; private set; }
	public float Ability2 { get; private set; }
	public float Ability3 { get; private set; }
	public float Error1 { get; private set; }
	public float Error2 { get; private set; }
	public float Error3 { get; private set; }

	public AbilityData(float ability1, float ability2, float ability3) {
		Initialize (ability1, ability2, ability3, 0, 0, 0);
	}

	public AbilityData(float ability1, float ability2, float ability3, float error1, float error2, float error3) {
		Initialize (ability1, ability2, ability3, error1, error2, error3);
	}

	void Initialize(float ability1, float ability2, float ability3, float error1, float error2, float error3) {
		this.Ability1 = ability1;
		this.Ability2 = ability2;
		this.Ability3 = ability3;
		this.Error1 = error1;
		this.Error2 = error2;
		this.Error3 = error3;
	}

}
