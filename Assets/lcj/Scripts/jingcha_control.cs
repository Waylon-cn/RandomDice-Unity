using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using Photon.Pun.Demo.PunBasics;

public class jingcha_control : MonoBehaviourPun
{
    public Rigidbody2D rigidbody2d;

    //�����ɫ����ֵ
    [SerializeField] public int PhysicalStrength;
    //�����ɫ����
    [SerializeField] public int intelligence;
    //�����ɫ����
    [SerializeField] public int playerSpeed;
    //�����ɫ����
    [SerializeField] public int reputation;
    public Joystick joystick;
    public int speed = 5;//Player?????

    public Vector2 lookDirection = new Vector2(1, 0);
    public Animator animator;

    public bool canMove = true;

    [Tooltip("��ҵ� UI ����Ԥ��")]
    public GameObject PlayerUiPrefab;

    public GameObject _uiGo;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerUiPrefab != null)
        {
            _uiGo = Instantiate(PlayerUiPrefab) as GameObject;
            _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
            // joystick = _uiGo.GetComponent<DialogSystem>().joystick;
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
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
            return;
        // float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


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
            animator.SetFloat("Speed", move.magnitude); //move?????

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

    // �������л�����ʦ��
    public void MapToMinsterHouse()
    {
        SceneManager.UnloadSceneAsync("MainScene");
        SceneManager.LoadSceneAsync("Pastor's House", LoadSceneMode.Additive);
        Vector2 position = new Vector2((float)-6, (float)-5);
        rigidbody2d.MovePosition(position);
    }
    //��ʦ�ҵ���ʿ����
    public void MainToRoomToHouse()
    {
        SceneManager.UnloadSceneAsync("Pastor's House");
        SceneManager.LoadSceneAsync("Gentleman's Room", LoadSceneMode.Additive);
        Vector2 position = new Vector2((float)-2.5, (float)-0.5);
        rigidbody2d.MovePosition(position);
    }
    //��ʿ�����л�����ʦ��
    public void GentlemanHouseToRoomToHouse()
    {
        SceneManager.UnloadSceneAsync("Gentleman's Room");
        SceneManager.LoadSceneAsync("Pastor's House", LoadSceneMode.Additive);
        Vector2 position = new Vector2((float)-6.2, (float)1.0);
        rigidbody2d.MovePosition(position);
    }
    //���ͼ���ֵܼ�
    public void MapToBrother()
    {
        Vector2 position = new Vector2((float)-35, (float)-28);
        rigidbody2d.MovePosition(position);
    }
    //�ֵܼҵ����ͼ
    public void BrotherToMap()
    {
        Vector2 position = new Vector2((float)-19, (float)-4);
        rigidbody2d.MovePosition(position);
    }
    // ��ʦ�ҵ����ͼ
    public void HouseToMap()
    {
        SceneManager.UnloadSceneAsync("Pastor's House");
        SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
        Vector2 position = new Vector2((float)7.5, (float)2);
        rigidbody2d.MovePosition(position);
    }
    //���ͼ����԰
    public void MapToPastorGarden()
    {
        SceneManager.UnloadSceneAsync("MainScene");
        SceneManager.LoadSceneAsync("Pastor's Garden", LoadSceneMode.Additive);
    }
    // ���ͼ��ð���ߴ�¥
    public void MapToAdventure()
    {
        SceneManager.UnloadSceneAsync("MainScene");
        SceneManager.LoadSceneAsync("Adventurer Building", LoadSceneMode.Additive);
    }
    //���ͼ��������
    // public void MapToCommunicateRoom()
    // {
    //     SceneManager.UnloadSceneAsync("MainScene");
    //     SceneManager.LoadSceneAsync("Communication Room", LoadSceneMode.Additive);
    //     // ����ǵ�һ�ν���ó����������Ի�
    //     if (UILoader.instance.roomState == "Start")
    //     {
    //         UILoader.instance.roomState = "FirstCommunicate";
    //     }
    // }
    // // �����ҵ����ͼ
    // public void CommunicateRoomToMap()
    // {
    //     SceneManager.UnloadSceneAsync("Communication Room");
    //     SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
    //     // ����ǳ��ó����������Ի�
    //     if (UILoader.instance.roomState == "HasCommunicate")
    //     {
    //         UILoader.instance.roomState = "LeaveCommunicate";
    //     }
    // }
    // ���ͼ������
    public void MapToChurch()
    {
        SceneManager.UnloadSceneAsync("MainScene");
        SceneManager.LoadSceneAsync("Church", LoadSceneMode.Additive);
    }
    // ���õ����ͼ
    public void ChurchToMap()
    {
        SceneManager.UnloadSceneAsync("Church");
        SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
    }

    // ���ͼ������
    public void MapToMarket()
    {
        SceneManager.UnloadSceneAsync("MainScene");
        SceneManager.LoadSceneAsync("Market", LoadSceneMode.Additive);
    }
    // ���е����ͼ
    public void MarketToMap()
    {
        SceneManager.UnloadSceneAsync("Market");
        SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
    }
}
