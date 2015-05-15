using UnityEngine;
using System.Collections;

public class SpriteAnimation : MonoBehaviour {

	public string[] SpriteNames;
	public float Interval;

	UISprite _sprite;
	int _currIndex;
	

	void Start () {
		_sprite = this.GetComponent<UISprite> ();
		StartCoroutine (Animating ());
	}

	IEnumerator Animating() {
		while (true) {
			yield return new WaitForSeconds(Interval);
			_currIndex++;
			_currIndex = _currIndex % SpriteNames.Length;
			_sprite.spriteName = SpriteNames[_currIndex];
		}
	}

}
