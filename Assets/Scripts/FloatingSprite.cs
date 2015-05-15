using UnityEngine;
using System.Collections;

public class FloatingSprite : MonoBehaviour {

	public float Speed;

	void Start() {

	}

	void Update() {
		this.transform.localPosition += new Vector3(Speed * Time.deltaTime, 0, 0);
		Vector3 curr = this.transform.localPosition;
		if (Speed > 0) {
			if (curr.x > 640) {
				curr.x = -640;
				curr.y = Random.Range(-320.0f, 320.0f);
				this.transform.localPosition = curr;
			}
		} else {
			if (curr.x < -640) {
				curr.x = 640;
				curr.y = Random.Range(-320.0f, 320.0f);
				this.transform.localPosition = curr;
			}
		}

		this.transform.Rotate (new Vector3 (0, 0, 10.0f * Time.deltaTime));
	}

}
