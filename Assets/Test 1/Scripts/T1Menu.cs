using UnityEngine;
using UnityEngine.UI;

public class T1Menu : MonoBehaviour {
	public Text ip;
	public Text port;
	public Text countClients;
	private NetworkView netView;

	public void Start () {
		netView = new NetworkView ();
	}

	public void MyStartServer () {
		Network.InitializeServer (int.Parse (countClients.text), int.Parse (port.text), true);
	}

	public void MyStopServer () {
		MasterServer.UnregisterHost ();
		Network.DestroyPlayerObjects (Network.connections[0]);
	}
	
	public void MyConnectToServer () {
		
	}

	public void MyDisconnect () {

	}
}
