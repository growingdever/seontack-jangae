using UnityEngine;
using System.Collections;

public class MoveForwardPersistantly : MonoBehaviour {

	public SceneControllerBattle SceneController;
	public float Speed;
	public float BounceToSkyForce;
	public float BackMovingTime;
	public float RecrushFactor;
	public GameObject EffectCrash;
	public bool IsEffectCreator;
	Rigidbody2D rigidbody2d;
	ConstantForce2D constantForce2d;

	public enum State {
		Normal,
		Collided,
		Recrush,
	};

	State _currState;
	public State CurrentState {
		get {
			return _currState;
		}
		set {
			_currState = value;
			if( _currState == State.Normal ) {
				constantForce2d.relativeForce = new Vector2 (Speed, 0);
			} else if( _currState == State.Collided ) {
				constantForce2d.relativeForce = new Vector2(-1 * Speed * 0.5f, 0);
				rigidbody2d.AddRelativeForce( new Vector2(0, BounceToSkyForce) );
				if( this.gameObject.activeSelf ) {
					StartCoroutine( TransitionStateWithDelay(BackMovingTime) );
				}
			} else if( _currState == State.Recrush ) {
				constantForce2d.relativeForce = new Vector2(Speed * RecrushFactor, 0);
			}
		}
	}
	
	void Start () {
		rigidbody2d = this.GetComponent<Rigidbody2D> ();
		constantForce2d = this.GetComponent<ConstantForce2D> ();

		CurrentState = State.Normal;
	}

	void Update() {
		this.transform.localRotation = Quaternion.identity;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.GetComponent<MoveForwardPersistantly> () != null) {
			CurrentState = State.Collided;

			if( IsEffectCreator ) {
				Vector3 v1 = this.transform.localPosition;
				Vector3 v2 = collision.collider.transform.localPosition;
				Vector3 newPos = (v2 - v1) / 2.0f;
				newPos.y = this.transform.localPosition.y;

				GameObject clone = Instantiate(EffectCrash.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
				clone.transform.parent = this.transform.parent;
				clone.transform.localPosition = newPos;
				clone.transform.localScale = new Vector3(1, 1, 1);
				clone.transform.localRotation = Quaternion.Euler(0, 180, 0);

				// Tell to SceneController
				SceneController.OnCollisionBetweenBattleCharacter();
			}
		}
	}
	
	IEnumerator TransitionStateWithDelay(float delay) {
		yield return new WaitForSeconds (delay);
		CurrentState = State.Recrush;
	}
}
