using Common;
using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//love you into disease, but no medicine can.
//Created By xxx
public abstract class BaseEvent : MonoBehaviour {

    public EventCode EvCode;
    public abstract void OnEvent(EventData eventData);

    public virtual void Start()
    {
        PhotonEngine._instance.AddEvent(this);
    }
    private void OnDestroy()
    {
        PhotonEngine._instance.RemoveEvent(this);
    }
}
