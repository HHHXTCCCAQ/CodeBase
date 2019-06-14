using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using System;
using Common;
//love you into disease, but no medicine can.
//Created By xxx
public class PhotonEngine : MonoBehaviour, IPhotonPeerListener
{

    public static PhotonPeer Peer
    {
        get
        {
            return peer;
        }
    }
    public static PhotonEngine _instance;
    private static PhotonPeer peer;

    public static string username;
    private Dictionary<OperationCode, Request> requestDic = new Dictionary<OperationCode, Request>();
    private Dictionary<EventCode, BaseEvent> eventDic = new Dictionary<EventCode, BaseEvent>();
    public void DebugReturn(DebugLevel level, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnEvent(EventData eventData)
    {
        EventCode code = (EventCode)eventData.Code;
        BaseEvent e = null;
        eventDic.TryGetValue(code, out e);
        Debug.Log(e);
        if (e!=null)
        {
            e.OnEvent(eventData);
        }
    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {
        OperationCode opCpde = (OperationCode)operationResponse.OperationCode;
        Request request = null;
        requestDic.TryGetValue(opCpde, out request);
        if (request != null)
        {
            request.OnOperationResponse(operationResponse);
        }
        else
        {
            Debug.Log("没找到对应的响应处理操作");
        }
    }

    public void OnStatusChanged(StatusCode statusCode)
    {
        Debug.Log(statusCode);
    }

    // Use this for initialization
    void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (_instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        //通过Listender接受服务器端的响应 
        peer = new PhotonPeer(this, ConnectionProtocol.Udp);
        peer.Connect("127.0.0.1:5055", "MyGame");

    }

    // Update is called once per frame
    void Update()
    {

        peer.Service();


    }

    private void OnDestroy()
    {
        if (peer != null && peer.PeerState == PeerStateValue.Connected)
        {
            peer.Disconnect();
        }
    }


    public void AddRequest(Request request)
    {
        requestDic.Add(request.OpCode, request);
    }
    public void RemoveRequest(Request request)
    {
        requestDic.Remove(request.OpCode);
    }
    public void AddEvent(BaseEvent baseEvent)
    {
        eventDic.Add(baseEvent.EvCode, baseEvent);
    }
    public void RemoveEvent(BaseEvent baseEvent)
    {
        eventDic.Remove(baseEvent.EvCode);
    }
}
