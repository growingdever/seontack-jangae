using UnityEngine;
using System.Collections;

public class MoveForwardPersistantly : MonoBehaviour {

	public float Speed;
	Rigidbody2D rigidbody2d;
	ConstantForce2D constantForce2d;

	public enum State {
		Normal,
		Collided,
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
				rigidbody2d.AddRelativeForce( new Vector2(0, 100) );
				StartCoroutine( TransitionStateWithDelay(0.5f) );
			}
		}
	}
	
	void Start () {
		rigidbody2d = this.GetComponent<Rigidbody2D> ();
		constantForce2d = this.GetComponent<ConstantForce2D> ();

		CurrentState = State.Normal;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.GetComponent<MoveForwardPersistantly> () != null) {
			CurrentState = State.Collided;
		}
	}
	
	IEnumerator TransitionStateWithDelay(float delay) {
		yield return new WaitForSeconds (delay);
		CurrentState = State.Normal;
	}
}
