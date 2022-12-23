using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    //存放三个玩家的对象实例
    public PlayerController Adviser;

    public PlayerController Detective;

    public PlayerController Police;
    //存放房间人数
    public int roomNum;
    
    //一个对话框
    [TextArea(1, 3)] public string[] DialogList;
    //跟踪对象
    public PlayerController _target;
    public static GameEventSystem instance;
    //大地图到冒险家协会
    public int MapToAdventureNum = 0;
    //摄像头
    public GameObject AdventureCamera;
    //交流室到大地图
    public int DiscussionRoomToMap = 0;

    
    //对会长使用心理学
    public bool IsPsychologyAdventure;
    //心理学成功的回答
    [TextArea(1, 3)] public string[] PsychologyAdventure;
    
    //集市事件
    //是否在集市与行人NPC对话过
    public bool Pedestrian;

    //是否在集市与绅士进行对话
    public bool Pastor;

    //黑衣人NPC是否已经出现
    public bool BlackNPC;
    
    //警卫预制体
    public GameObject GuardPrefab;

    //是否侦查发现警卫
    public bool DetectionFindGuard;
    //警卫对话内容
    [TextArea(1, 3)] public string[] GuardDialog;

    //在侦查后使用灵感
    //是否灵感发现警卫,-为初始状态,1使用了侦查，2是使用了灵感，3即可以跟警卫对话
    public int InspirationFindGuard = 0;
    //走廊摄像头
    public GameObject Camera;
    public bool HasCamera;
    [TextArea(1, 3)] public string[] CameraDialog;

    //侦查发现NPC的对话内容
    [TextArea(1, 3)] public string[] DetectionFindGuardRely;

    //灵感发现NPC的对话内容
    [TextArea(1, 3)] public string[] InspirationFindGuardRely;
    
    //第二次进入办公室对话会长
    public bool SecondOfficePsychology = false;
    [TextArea(1, 3)] public string[] SecondOfficePsychologyList;
    
    //教堂门口心理学牧师
    public bool isAroundPastorPsychology;
    [TextArea(1, 3)] public string[] AroundPastorDialog;
    //教堂事件
    //检查魔鬼之足
    public bool CheckFoot;
    //检查大钻石
    public bool CheckDiamonds;
    //教堂牧师
    public GameObject ChurchGentleman;
    // //绅士和牧师来找调查员帮忙
    public bool PastorAndGentleman = true;
    // 牧师和绅士实例
    public GameObject MapPastor;
    //牧师和绅士求助对话框
    [TextArea(1, 3)] public string[] PastorAndGentlemanDialog;

    public GameObject MapGentleman;
    // public bool PastorAndGentlemanHelp;
    //第一次进牧师家
    public bool IsFirstPastorRoom;
    //马车出现
    public bool IsHourse;
    //关于猎尸人信息的NPC
    public GameObject AboutLionHunter;
    //猎狮人实例
    public GameObject LionHunter;
    // 猎狮人出现
    public bool IsLionHunter = true;
    // 猎狮人对话框
    [TextArea(1, 3)] public string[] LionHunterList;
    //第二次犯罪
    public bool SecondCrime = true; 
    //第二次犯罪牧师对话框
    [TextArea(1, 3)] public string[] SecondCrimeDialog;
    //第一次进入绅士房间对话
    [TextArea(1, 3)] public string[] FirstGentlemanList;
    //猎狮人讲述前因后果
    [TextArea(1, 3)] public string[] LastLionHunter;

// Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GuardPrefab.SetActive(false);
        // Camera.SetActive(false);
        ChurchGentleman.SetActive(false);
        LionHunter.SetActive(false);
        AboutLionHunter.SetActive(false);
        MapPastor.SetActive(false);
        MapGentleman.SetActive(false);
        AdventureCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _target = Adviser;
        //是否成功使用心理学
        if (IsPsychologyAdventure && _target.canMove)
        {
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(PsychologyAdventure, false);
            IsPsychologyAdventure = false;
        }
        //如果与绅士和NPC对话过，则出现黑衣人
        if (Pedestrian && Pastor && _target.canMove)
        {
            Pedestrian = false;
            Pastor = false;
            BlackNPC = true;
            //警卫出现
            GuardPrefab.SetActive(true);
            // DialogList[0] = "你们注意到了有人在跟踪你们。";
            // _target.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
            //     .ShowDialogue(DialogList, false);
            // if (Adviser != null)
            //     Adviser._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            // if (Detective != null)
            //     Detective._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            // if (Police != null)
            //     Police._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
        }
        //如果发现了警卫
        else if (DetectionFindGuard && _target.canMove)
        {
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(DetectionFindGuardRely, false);
            DetectionFindGuard = false;
            InspirationFindGuard = 1;
        }
        //灵感发现警卫
        else if (InspirationFindGuard == 2 && _target.canMove)
        {
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(InspirationFindGuardRely, false);
            
            InspirationFindGuard = 3;
        }
        // else if (InspirationFindGuard == 3)
        // {
        //     
        // }

        if (SecondOfficePsychology)
        {
            SecondOfficePsychology = false;
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(SecondOfficePsychologyList, false);
        }
        //如果调查完钻石与魔鬼之足
        if (CheckDiamonds && CheckFoot && _target.canMove && !ChurchGentleman.activeInHierarchy)
        {
            DialogList[0] = "你们注意到了绅士 发现他对着魔鬼之足发呆，似乎没有注意到别人。";
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(DialogList, false);
            // if (Adviser != null)
            //     Adviser._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            // if (Detective != null)
            //     Detective._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            // if (Police != null)
            //     Police._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            // _target.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
            //     .ShowDialogue(DialogList, false);
            ChurchGentleman.SetActive(true);
        }
        //第一次出交流室
        if (PastorAndGentleman && DiscussionRoomToMap == 4)
        {
            MapGentleman.SetActive(true);
            MapPastor.SetActive(true);
            // DialogList[0] = "莫梯墨·特雷根尼斯绅士的兄弟姐妹们死在了他们的房子中！他们报警后想到了赫赫有名的诸位调查员，于是牧师提出请求调查员来调查此，莫梯墨·特雷根尼斯绅士向调查员们陈述了那晚的情况";
            // if (Adviser != null)
            //     Adviser._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            // if (Detective != null)
            //     Detective._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            // if (Police != null)
            //     Police._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(PastorAndGentlemanDialog, true);
            // _target.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
            //     .ShowDialogue(DialogList, false);
            PastorAndGentleman = false;
        }

        //如果是第一次进入牧师家前
        if (IsFirstPastorRoom)
        {
            DialogList[0] = "绅士：那个恶魔似的东西一定是出现在花园中的，顷刻之间将兄弟两人吓成了疯子";
            // if (Adviser != null)
            //     Adviser._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            // if (Detective != null)
            //     Detective._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            // if (Police != null)
            //     Police._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(DialogList, false);
            // _target.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
            //     .ShowDialogue(DialogList, false);
            IsFirstPastorRoom = false;
        }
        //马车出现
        if (IsHourse)
        {
            DialogList[0] = "绅士：我的兄弟们，这是把他们送到赫尔斯顿去了！";
            // if (Adviser != null)
            //     Adviser._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            // if (Detective != null)
            //     Detective._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            // if (Police != null)
            //     Police._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(DialogList, false);
            // _target.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
            //     .ShowDialogue(DialogList, false);
            IsHourse = false;
        }
        //如果发现了摄像头
        if (HasCamera && _target.canMove)
        {
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(CameraDialog, false);
            HasCamera = false;
        }
        //在牧师旁边成功使用心理学
        if (isAroundPastorPsychology && _target.canMove)
        {
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(AroundPastorDialog, false);
            isAroundPastorPsychology = false;
        }
        //猎狮人出现
        if (DiscussionRoomToMap == 8 && IsLionHunter)
        {
            // if (Adviser != null)
            //     Adviser._uiGo.GetComponent<DialogSystem>().ShowDialogue(LionHunterList, false);
            // if (Detective != null)
            //     Detective._uiGo.GetComponent<DialogSystem>().ShowDialogue(LionHunterList, false);
            // if (Police != null)
            //     Police._uiGo.GetComponent<DialogSystem>().ShowDialogue(LionHunterList, false);
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(LionHunterList, true);
            // _target.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
            //     .ShowDialogue(LionHunterList, false);
            LionHunter.SetActive(true);
            AboutLionHunter.SetActive(true);
            IsLionHunter = false;
        }
        //猎狮人回来
        if (DiscussionRoomToMap == 12)
        {
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(LastLionHunter, false);
            LionHunter.SetActive(true);
        }
        //第二次犯罪事件出现
        if (SecondCrime && DiscussionRoomToMap == 3)
        {
            SecondCrime = false;
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(SecondCrimeDialog, false);
            // if (Adviser != null)
            //     Adviser._uiGo.GetComponent<DialogSystem>().ShowDialogue(SecondCrimeDialog, false);
            // if (Detective != null)
            //     Detective._uiGo.GetComponent<DialogSystem>().ShowDialogue(SecondCrimeDialog, false);
            // if (Police != null)
            //     Police._uiGo.GetComponent<DialogSystem>().ShowDialogue(SecondCrimeDialog, false);
            // _target.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
            //     .ShowDialogue(SecondCrimeDialog, false);
        }
        
    }
    //第一次进入绅士房间
    public void isFirstInGentleman()
    {
        _target._uiGo.GetComponent<DialogSystem>()
            .ShowDialogue(FirstGentlemanList, false);
    }
}
