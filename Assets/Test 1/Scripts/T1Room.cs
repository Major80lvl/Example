using UnityEngine;
using System.Collections;

public class T1Room : MonoBehaviour {
	public Transform player;

	void Start () {
		Network.Instantiate (player, this.transform.position, this.transform.rotation, 0);
	}

	void OnDisconnectedFromServer () {
		Application.LoadLevel ("T1Menu");
	}

	void OnPlayerConnected(NetworkPlayer player) {
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}

	void Update () {
		
	}
}
