using UnityEngine;
using System.Collections;

public class DelayedDestroy : MonoBehaviour {

	public float LifeTime;

	void Start() {
		StartCoroutine (DelayAndDestory ());
	}

	IEnumerator DelayAndDestory() {
		yield return new WaitForSeconds(LifeTime);
		Destroy (this.gameObject);
	}
}
