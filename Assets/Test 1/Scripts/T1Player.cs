using UnityEngine;
using System.Collections;

public class T1Player : MonoBehaviour {
	NetworkView netView;
	void Start () {
//		netView = new NetworkView ();
		netView = this.GetComponent<NetworkView> ();
		if (netView == null) {
			Debug.Log ("NetworkView component not founded :(");
		}
	}

	void Update () {
		if (netView.isMine) {
			if (Input.GetMouseButton (0)) {
				Vector3 v = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				this.transform.position = new Vector3 (v.x, v.y, 0);
			}
		}
	}
}
