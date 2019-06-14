using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Common.Tools;
//love you into disease, but no medicine can.
//Created By xxx
public class Player : MonoBehaviour
{
    public bool isLocalPlayer = true;
    public string username;
    public GameObject playerPrefab;
    public GameObject player;
    private SnycPositionRequest snycPositionRequest;
    private SyncPlayerRequest syncPlayerRequest;
    private Vector3 lastPosition = Vector3.zero;
    private float moveOffset = 0.1f;

    private Dictionary<string, GameObject> playerDic = new Dictionary<string, GameObject>();
    // Use this for initialization
    void Start()
    {

        snycPositionRequest = GetComponent<SnycPositionRequest>();
        syncPlayerRequest = GetComponent<SyncPlayerRequest>();
        syncPlayerRequest.DefaultRequest();
        player.GetComponent<Renderer>().material.color = Color.green;
        InvokeRepeating("SyncPosition", 3, 0.2f);

    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        player.transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * 4);

    }

    void SyncPosition()
    {
        if (Vector3.Distance(transform.position, lastPosition) > moveOffset)
        {
            lastPosition = player.transform.position;
            snycPositionRequest.position = player.transform.position;
            snycPositionRequest.DefaultRequest();
        }
    }
    public void OnSyncPlayerResponse(List<string> usernameList)
    {
        //创建其他客户端Player
        foreach (string username in usernameList)
        {
            OnNewPlayerEvent(username);
        }
    }

    public void OnNewPlayerEvent(string username)
    {
        GameObject go = Instantiate(playerPrefab);
        playerDic.Add(username, go);
    }
    public void OnSyncPositionEvent(List<PlayerData> playerDataList)
    {
        foreach (PlayerData playerData in playerDataList)
        {
            GameObject go = DictTool.GetValue<string, GameObject>(playerDic, playerData.Username);
            if (go != null)
            {
                Debug.Log("set pos");
                Debug.Log(playerData.Pos.x + "....." + playerData.Pos.y + "....." + playerData.Pos.z + ".....");
                go.transform.position = new Vector3() { x = playerData.Pos.x, y = playerData.Pos.y, z = playerData.Pos.z };
            }

        }
    }
}
