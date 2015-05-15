using UnityEngine;
using System.Collections;

public class VariableStorage {

	public float PlayerStats1;
	public float PlayerStats2;
	public float PlayerStats3;


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
