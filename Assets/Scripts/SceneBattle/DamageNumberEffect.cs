using UnityEngine;
using System.Collections;

public class DamageNumberEffect : MonoBehaviour {

	public UILabel LabelNumber;
	public float FloatingSpeed;

	void Start() {

	}

	void Update() {
		this.transform.localPosition += new Vector3 (0, FloatingSpeed * Time.deltaTime, 0);
		FloatingSpeed *= 0.98f;
	}

	public void SetNumber(float number) {
		LabelNumber.text = string.Format ("{0:0}", number);
	}

}
