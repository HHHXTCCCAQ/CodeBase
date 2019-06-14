using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//love you into disease, but no medicine can.
//Created By xxx
public class TestRequest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {

            sendRequest();
        }
	}

    void sendRequest()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();

        data.Add(1, 527);
        data.Add(2, "wpde caq jiushi ai ");
        PhotonEngine.Peer.OpCustom(1, data, true);
    }

}
