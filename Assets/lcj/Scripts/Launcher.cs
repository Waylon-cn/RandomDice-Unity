using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;
using Photon.Pun.Demo.SlotRacer.Utils;
using Unity.VisualScripting;

public class Launcher : MonoBehaviourPunCallbacks
{
    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject kp;
    void Start()
    {  
        //初始化用户设置
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("init!");
    }

    //连接到服务器
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        //创建或者加入房间 设置最大游戏玩家数
        PhotonNetwork.JoinOrCreateRoom("Room", new Photon.Realtime.RoomOptions { MaxPlayers = 4 }, default);
        Debug.Log("Connected!");
    }

    //加入到房间
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("加入到房间：" + PhotonNetwork.CurrentRoom);
        Room room = PhotonNetwork.CurrentRoom;
        Debug.Log("now mumbers:"+ room.PlayerCount);
        // GameEventSystem.instance.roomNum = room.PlayerCount;
        if(room.PlayerCount == 1)
        {
            // kp = PhotonNetwork.Instantiate("KP", new Vector3(-40, -5, 0), Quaternion.identity, 0) as GameObject;
            // GameEventSystem.instance._target = kp.gameObject.GetComponent<PlayerController>();
            // GameEventSystem.instance.Adviser = kp.gameObject.GetComponent<PlayerController>();
            player1 = PhotonNetwork.Instantiate("KP", new Vector3(-40, -5, 0), Quaternion.identity, 0) as GameObject;
            GameEventSystem.instance._target = player1.gameObject.GetComponent<PlayerController>();
            GameEventSystem.instance.Adviser = player1.gameObject.GetComponent<PlayerController>();
            // player1 = PhotonNetwork.Instantiate("Adviser", new Vector3(-40, -5, 0), Quaternion.identity, 0) as GameObject;
            // GameEventSystem.instance._target = player1.gameObject.GetComponent<PlayerController>();
            // GameEventSystem.instance.Adviser = player1.gameObject.GetComponent<PlayerController>();
            // GameEventSystem.instance.Adviser = player1.gameObject.GetComponent<PlayerController>();
        }
        else if(room.PlayerCount == 2)
        {
            player1 = PhotonNetwork.Instantiate("Adviser", new Vector3(-40, -5, 0), Quaternion.identity, 0) as GameObject;
            GameEventSystem.instance._target = player1.gameObject.GetComponent<PlayerController>();
            GameEventSystem.instance.Adviser = player1.gameObject.GetComponent<PlayerController>();
            
            
            // player1.gameObject.GetComponent<PlayerController>().instance.Detective = player2.gameObject.GetComponent<PlayerController>();
            // player2.gameObject.GetComponent<PlayerController>().instance.Adviser = player1.gameObject.GetComponent<PlayerController>();
            //PhotonNetwork.LoadLevel(3);
        }
        else if (room.PlayerCount == 3)
        {
            player2 = PhotonNetwork.Instantiate("Detective", new Vector3(-40, -5, 0), Quaternion.identity, 0) as GameObject;
            GameEventSystem.instance._target = player2.gameObject.GetComponent<PlayerController>();
            
            GameEventSystem.instance.Adviser = player2.gameObject.GetComponent<PlayerController>();
            
            
            // player3.gameObject.GetComponent<PlayerController>().instance.Detective = player2.gameObject.GetComponent<PlayerController>();
            // player3.gameObject.GetComponent<PlayerController>().instance.Adviser = player1.gameObject.GetComponent<PlayerController>();
            // player1.gameObject.GetComponent<PlayerController>().instance.Police = player3.gameObject.GetComponent<PlayerController>();
            // player2.gameObject.GetComponent<PlayerController>().instance.Police = player3.gameObject.GetComponent<PlayerController>();
        }
        else if (room.PlayerCount == 4)
        {
            player3 = PhotonNetwork.Instantiate("Police", new Vector3(-40, -5, 0), Quaternion.identity, 0);
            GameEventSystem.instance._target = player3.gameObject.GetComponent<PlayerController>();
            
            GameEventSystem.instance.Adviser = player3.gameObject.GetComponent<PlayerController>();
        }
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        //加入房间失败，创建房间,设置房间名称和加入的最大玩家数量
        Debug.Log("加入房间失败，创建房间...");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("玩家：" + newPlayer.NickName + "进入房间");
    }

}
