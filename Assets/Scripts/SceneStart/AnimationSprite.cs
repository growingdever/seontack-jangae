using UnityEngine;
using System.Collections;

public class AnimationSprite : MonoBehaviour {

	private float currentFPS = 0f ;
	public float FPS;
	public string[] SpriteName;
	private int _Index = 0;

	void Start(){
		Vector3 pos = transform.position;
		pos.x = 2f;
		transform.position = pos;
	}
	// Update is called once per frame
	void Update () {
		float speed = -0.5f * Time.deltaTime;

		transform.position += new Vector3( speed, 0f, 0f );
		currentFPS += Time.deltaTime;
		if (currentFPS > (FPS/SpriteName.Length)) {
			//Debug.Log("animation on");
			if(_Index >= SpriteName.Length)
				_Index = 0;
			gameObject.GetComponent<UISprite>().spriteName = SpriteName[_Index++];
			currentFPS = 0f;
		}

		//Debug.Log (transform.position.x);
		if (transform.position.x < -2f) {
			Vector3 pos = transform.position;
			pos.x = 2f;
			transform.position = pos;
		}
	}
}
