using UnityEngine;
using System.Collections;

public class FloatingSprite2 : MonoBehaviour {

	public float Speed;
	public float MaxHeight;
	public float MinHeight;

	void Update() {
		this.transform.localPosition += new Vector3(Speed * Time.deltaTime, 0, 0);
		Vector3 curr = this.transform.localPosition;
		if (Speed > 0) {
			if (curr.x > 640) {
				curr.x = -640;
				curr.y = Random.Range(MinHeight, MaxHeight);
				this.transform.localPosition = curr;
			}
		} else {
			if (curr.x < -640) {
				curr.x = 640;
				curr.y = Random.Range(MinHeight, MaxHeight);
				this.transform.localPosition = curr;
			}
		}
	}

}
