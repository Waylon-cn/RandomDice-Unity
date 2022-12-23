using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using Photon.Pun.Demo.PunBasics;
public class move : MonoBehaviour
{  
    private Rigidbody2D rigidbody2d;
    public int speed = 5;//Player的速度
    public Joystick joystick;
    private Vector2 lookDirection = new Vector2(1, 0);
    private Animator animator;

    public bool canMove = true;

    public CharacterStates characterstats;
    [Tooltip("玩家的 UI 对象预设")]
    public GameObject PlayerUiPrefab;
    public GameObject _uiGo;

     void Awake()
     {
        characterstats = GetComponent<CharacterStates>();  
     }
    // Start is called before the first frame update
    void Start()
    {
        PhotonView phothonView = GetComponent<PhotonView>();
        if (PlayerUiPrefab != null && phothonView.IsMine)
        {
            _uiGo = Instantiate(PlayerUiPrefab) as GameObject;
            _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
            joystick = _uiGo.GetComponent<Kpui>().joystick;
        }
        else
        {
            Debug.LogWarning("<Color=Red><a>Missing</a></Color> PlayerUiPrefabreference on player Prefab.", this);
        }


        rigidbody2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        CameraWork cameraWork = this.GetComponent<CameraWork>();
        PhotonView photonView = this.GetComponent<PhotonView>();
        if (cameraWork != null)
        {
            if (photonView.IsMine)
            {
                cameraWork.OnStartFollowing();
            }
        }
        else
        {
            Debug.Log("cameraWork is null!");
        }


    }

    // Update is called once per frame
    void Update()
    {
       // if (!photonView.IsMine && PhotonNetwork.IsConnected)
          //  return;
        // float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");
        float h, v;
        h = joystick.Horizontal;
        v = joystick.Vertical;
        float h1 = Input.GetAxis("Horizontal");
        float v1 = Input.GetAxis("Vertical");
        if (h1 == 0 && v1 == 0)
        {

        }
        else
        {
            h = h1;
            v = v1;
        }

        if (canMove)
        {
            Vector2 move = new Vector2(h, v);
            if (!Mathf.Approximately(move.x, 0) || !Mathf.Approximately(move.y, 0))
            {
                lookDirection.Set(move.x, move.y); //lookDirection=move;
                lookDirection.Normalize();
            }

            animator.SetFloat("Look X", lookDirection.x);
            animator.SetFloat("Look Y", lookDirection.y);
            animator.SetFloat("Speed", move.magnitude); //move��ģ��

            Vector2 position = transform.position;
            //position.x = position.x + speed*h*Time.deltaTime;
            //position.y = position.y + speed*v*Time.deltaTime;
            position = position + speed * move * Time.deltaTime;
            rigidbody2d.MovePosition(position);
        }
        else
        {
            rigidbody2d.velocity = Vector2.zero;
        }
    }

    public void MapToMinsterHouse()
    {
        SceneManager.UnloadSceneAsync("MainScene");
        SceneManager.LoadSceneAsync("Pastor's House", LoadSceneMode.Additive);
        Vector2 position = new Vector2((float)-6, (float)-5);
        rigidbody2d.MovePosition(position);
    }
    //牧师家到绅士房间
    public void MainToRoomToHouse()
    {
        SceneManager.UnloadSceneAsync("Pastor's House");
        SceneManager.LoadSceneAsync("Gentleman's Room", LoadSceneMode.Additive);
        Vector2 position = new Vector2((float)-2.5, (float)-0.5);
        rigidbody2d.MovePosition(position);
    }
    //绅士房间切换到牧师家
    public void GentlemanHouseToRoomToHouse()
    {
        SceneManager.UnloadSceneAsync("Gentleman's Room");
        SceneManager.LoadSceneAsync("Pastor's House", LoadSceneMode.Additive);
        Vector2 position = new Vector2((float)-6.2, (float)1.0);
        rigidbody2d.MovePosition(position);
    }
    //大地图到兄弟家
    public void MapToBrother()
    {
        Vector2 position = new Vector2((float)-35, (float)-28);
        rigidbody2d.MovePosition(position);
    }
    //兄弟家到大地图
    public void BrotherToMap()
    {
        Vector2 position = new Vector2((float)-19, (float)-4);
        rigidbody2d.MovePosition(position);
    }
    // 牧师家到大地图
    public void HouseToMap()
    {
        SceneManager.UnloadSceneAsync("Pastor's House");
        SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
        Vector2 position = new Vector2((float)7.5, (float)2);
        rigidbody2d.MovePosition(position);
    }
    //大地图到花园
    public void MapToPastorGarden()
    {
        SceneManager.UnloadSceneAsync("MainScene");
        SceneManager.LoadSceneAsync("Pastor's Garden", LoadSceneMode.Additive);
    }
    // 大地图到冒险者大楼
    public void MapToAdventure()
    {
        SceneManager.UnloadSceneAsync("MainScene");
        SceneManager.LoadSceneAsync("Adventurer Building", LoadSceneMode.Additive);
    }
    //大地图到交流室
    // public void MapToCommunicateRoom()
    // {
    //     SceneManager.UnloadSceneAsync("MainScene");
    //     SceneManager.LoadSceneAsync("Communication Room", LoadSceneMode.Additive);
    //     // 如果是第一次进入该场景，触发对话
    //     if (UILoader.instance.roomState == "Start")
    //     {
    //         UILoader.instance.roomState = "FirstCommunicate";
    //     }
    // }
    // // 交流室到大地图
    // public void CommunicateRoomToMap()
    // {
    //     SceneManager.UnloadSceneAsync("Communication Room");
    //     SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
    //     // 如果是出该场景，触发对话
    //     if (UILoader.instance.roomState == "HasCommunicate")
    //     {
    //         UILoader.instance.roomState = "LeaveCommunicate";
    //     }
    // }
    // 大地图到教堂
    public void MapToChurch()
    {
        SceneManager.UnloadSceneAsync("MainScene");
        SceneManager.LoadSceneAsync("Church", LoadSceneMode.Additive);
    }
    // 教堂到大地图
    public void ChurchToMap()
    {
        SceneManager.UnloadSceneAsync("Church");
        SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
    }

    // 大地图到集市
    public void MapToMarket()
    {
        SceneManager.UnloadSceneAsync("MainScene");
        SceneManager.LoadSceneAsync("Market", LoadSceneMode.Additive);
    }
    // 集市到大地图
    public void MarketToMap()
    {
        SceneManager.UnloadSceneAsync("Market");
        SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
    }
}


