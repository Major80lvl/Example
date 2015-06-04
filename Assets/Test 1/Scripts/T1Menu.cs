using UnityEngine;
using UnityEngine.UI;

public class T1Menu : MonoBehaviour {
	public Text ip;
	public Text port;
	public Text countClients;
	public Text yourIP;
	private NetworkView netView;
	private int window = 0;
	public GUISkin skin;
	void Start () {
//		netView = new NetworkView ();
		netView = this.GetComponent<NetworkView> ();
		if (netView == null) {
			Debug.Log ("NetworkView component not founded :(");
		}
	}

	void OnServerInitialized () {
		window = 1;
	}

	void OnConnectedToServer () {
		window = 2;
	}

	void OnDisconnectedFromServer () {
		window = 0;
	}

	void OnPlayerConnected(NetworkPlayer player) {
		//PlayerConnected
	}

	void MyStartServer () {
		Network.InitializeServer (int.Parse (countClients.text), int.Parse (port.text), true);
	}

	void MyStopServer () {
		Network.Disconnect();
		MasterServer.UnregisterHost ();
		window = 0;
	}
	
	void MyConnectToServer () {
		Network.Connect (ip.text, int.Parse (port.text));
	}

	void MyDisconnect () {
		Network.Disconnect ();
		window = 0;
	}
	[RPC]
	void LoadRoom () {
		Application.LoadLevel ("T1Room");
	}
	
	void MyStartRoom () {
		netView.RPC ("LoadRoom", RPCMode.All);
	}

	void OnGUI () {
		yourIP.text = Network.player.ipAddress;
		GUI.skin = skin;
		if (window == 0) {
			if (GUI.Button (new Rect (Screen.width/6f, Screen.height*2/3f, Screen.width/3f, Screen.height/15f), "Start server")) {
				MyStartServer ();
			}
			if (GUI.Button (new Rect (Screen.width/2f, Screen.height*2/3f, Screen.width/3f, Screen.height/15f), "Connect to server")) {
				MyConnectToServer ();
			}
		}
		if (window == 1) {
			if (GUI.Button (new Rect (Screen.width/6f, Screen.height*2/3f, Screen.width/3f, Screen.height/15f), "Stop server")) {
				MyStopServer ();
			}
			if (GUI.Button (new Rect (Screen.width/2f, Screen.height*2/3f, Screen.width/3f, Screen.height/15f), "Start room")) {
				MyStartRoom ();
			}
			GUI.Label (new Rect (Screen.width/3f, Screen.height*2/3f+Screen.height/15f, Screen.width/3f, Screen.height/15f), Network.connections.Length.ToString ());
		}
		if (window == 2) {
			if (GUI.Button (new Rect (Screen.width/3f, Screen.height*2/3f, Screen.width/3f, Screen.height/15f), "Disconnect")) {
				MyDisconnect ();
			}
		}
	}
}
