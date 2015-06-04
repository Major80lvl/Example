using UnityEngine;
using System.Collections;

public class T1Sync : MonoBehaviour {
	private Vector3 oldPos;

	private Transform myTransform;
	private NetworkView net;
	void Start () {
		net = this.GetComponent<NetworkView> ();
		if (net.isMine) {
			myTransform = transform;
		} else {
			enabled = false;
		}
	}
	
	void Update () {
		if (Vector3.Distance (oldPos, myTransform.position) >= 0.05) {
			oldPos = myTransform.position;
			net.RPC ("UpdateMove", RPCMode.OthersBuffered, myTransform.position);
		}
	}

	[RPC]
	void UpdateMove (Vector3 newPos) {
		transform.position = newPos;
	}
}
