using UnityEngine;
using System.Collections;

public class VariableStorage {

	public float PlayerStats1 = 0.0f;
	public float PlayerStats2 = 0.0f;
	public float PlayerStats3 = 0.0f;


	private static VariableStorage _instance;
	private VariableStorage() {
	}
	public static VariableStorage Instance {
		get {
			if( _instance == null ) {
				_instance = new VariableStorage();
			}
			return _instance;
		}
	}

}
