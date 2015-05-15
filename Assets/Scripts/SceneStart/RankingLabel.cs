using UnityEngine;
using System.Collections;

public class RankingLabel : MonoBehaviour {

	void Start() {
		this.GetComponent<UILabel> ().text 
			= string.Format ("{0}층을 넘을 수 있을까?", PlayerPrefs.GetInt(PreferenceKeys.KEY_HIGHEST_STAGE, 1));
	}
}
