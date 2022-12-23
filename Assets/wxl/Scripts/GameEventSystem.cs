using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    //���������ҵĶ���ʵ��
    public PlayerController Adviser;

    public PlayerController Detective;

    public PlayerController Police;
    //��ŷ�������
    public int roomNum;
    
    //һ���Ի���
    [TextArea(1, 3)] public string[] DialogList;
    //���ٶ���
    public PlayerController _target;
    public static GameEventSystem instance;
    //���ͼ��ð�ռ�Э��
    public int MapToAdventureNum = 0;
    //����ͷ
    public GameObject AdventureCamera;
    //�����ҵ����ͼ
    public int DiscussionRoomToMap = 0;

    
    //�Ի᳤ʹ������ѧ
    public bool IsPsychologyAdventure;
    //����ѧ�ɹ��Ļش�
    [TextArea(1, 3)] public string[] PsychologyAdventure;
    
    //�����¼�
    //�Ƿ��ڼ���������NPC�Ի���
    public bool Pedestrian;

    //�Ƿ��ڼ�������ʿ���жԻ�
    public bool Pastor;

    //������NPC�Ƿ��Ѿ�����
    public bool BlackNPC;
    
    //����Ԥ����
    public GameObject GuardPrefab;

    //�Ƿ���鷢�־���
    public bool DetectionFindGuard;
    //�����Ի�����
    [TextArea(1, 3)] public string[] GuardDialog;

    //������ʹ�����
    //�Ƿ���з��־���,-Ϊ��ʼ״̬,1ʹ������飬2��ʹ������У�3�����Ը������Ի�
    public int InspirationFindGuard = 0;
    //��������ͷ
    public GameObject Camera;
    public bool HasCamera;
    [TextArea(1, 3)] public string[] CameraDialog;

    //��鷢��NPC�ĶԻ�����
    [TextArea(1, 3)] public string[] DetectionFindGuardRely;

    //��з���NPC�ĶԻ�����
    [TextArea(1, 3)] public string[] InspirationFindGuardRely;
    
    //�ڶ��ν���칫�ҶԻ��᳤
    public bool SecondOfficePsychology = false;
    [TextArea(1, 3)] public string[] SecondOfficePsychologyList;
    
    //�����ſ�����ѧ��ʦ
    public bool isAroundPastorPsychology;
    [TextArea(1, 3)] public string[] AroundPastorDialog;
    //�����¼�
    //���ħ��֮��
    public bool CheckFoot;
    //������ʯ
    public bool CheckDiamonds;
    //������ʦ
    public GameObject ChurchGentleman;
    // //��ʿ����ʦ���ҵ���Ա��æ
    public bool PastorAndGentleman = true;
    // ��ʦ����ʿʵ��
    public GameObject MapPastor;
    //��ʦ����ʿ�����Ի���
    [TextArea(1, 3)] public string[] PastorAndGentlemanDialog;

    public GameObject MapGentleman;
    // public bool PastorAndGentlemanHelp;
    //��һ�ν���ʦ��
    public bool IsFirstPastorRoom;
    //������
    public bool IsHourse;
    //������ʬ����Ϣ��NPC
    public GameObject AboutLionHunter;
    //��ʨ��ʵ��
    public GameObject LionHunter;
    // ��ʨ�˳���
    public bool IsLionHunter = true;
    // ��ʨ�˶Ի���
    [TextArea(1, 3)] public string[] LionHunterList;
    //�ڶ��η���
    public bool SecondCrime = true; 
    //�ڶ��η�����ʦ�Ի���
    [TextArea(1, 3)] public string[] SecondCrimeDialog;
    //��һ�ν�����ʿ����Ի�
    [TextArea(1, 3)] public string[] FirstGentlemanList;
    //��ʨ�˽���ǰ����
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
        //�Ƿ�ɹ�ʹ������ѧ
        if (IsPsychologyAdventure && _target.canMove)
        {
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(PsychologyAdventure, false);
            IsPsychologyAdventure = false;
        }
        //�������ʿ��NPC�Ի���������ֺ�����
        if (Pedestrian && Pastor && _target.canMove)
        {
            Pedestrian = false;
            Pastor = false;
            BlackNPC = true;
            //��������
            GuardPrefab.SetActive(true);
            // DialogList[0] = "����ע�⵽�������ڸ������ǡ�";
            // _target.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
            //     .ShowDialogue(DialogList, false);
            // if (Adviser != null)
            //     Adviser._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            // if (Detective != null)
            //     Detective._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
            // if (Police != null)
            //     Police._uiGo.GetComponent<DialogSystem>().ShowDialogue(DialogList, false);
        }
        //��������˾���
        else if (DetectionFindGuard && _target.canMove)
        {
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(DetectionFindGuardRely, false);
            DetectionFindGuard = false;
            InspirationFindGuard = 1;
        }
        //��з��־���
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
        //�����������ʯ��ħ��֮��
        if (CheckDiamonds && CheckFoot && _target.canMove && !ChurchGentleman.activeInHierarchy)
        {
            DialogList[0] = "����ע�⵽����ʿ ����������ħ��֮�㷢�����ƺ�û��ע�⵽���ˡ�";
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
        //��һ�γ�������
        if (PastorAndGentleman && DiscussionRoomToMap == 4)
        {
            MapGentleman.SetActive(true);
            MapPastor.SetActive(true);
            // DialogList[0] = "Ī��ī�����׸���˹��ʿ���ֵܽ��������������ǵķ����У����Ǳ������뵽�˺պ���������λ����Ա��������ʦ����������Ա������ˣ�Ī��ī�����׸���˹��ʿ�����Ա�ǳ�������������";
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

        //����ǵ�һ�ν�����ʦ��ǰ
        if (IsFirstPastorRoom)
        {
            DialogList[0] = "��ʿ���Ǹ���ħ�ƵĶ���һ���ǳ����ڻ�԰�еģ����֮�佫�ֵ������ų��˷���";
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
        //������
        if (IsHourse)
        {
            DialogList[0] = "��ʿ���ҵ��ֵ��ǣ����ǰ������͵��ն�˹��ȥ�ˣ�";
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
        //�������������ͷ
        if (HasCamera && _target.canMove)
        {
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(CameraDialog, false);
            HasCamera = false;
        }
        //����ʦ�Ա߳ɹ�ʹ������ѧ
        if (isAroundPastorPsychology && _target.canMove)
        {
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(AroundPastorDialog, false);
            isAroundPastorPsychology = false;
        }
        //��ʨ�˳���
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
        //��ʨ�˻���
        if (DiscussionRoomToMap == 12)
        {
            _target._uiGo.GetComponent<DialogSystem>()
                .ShowDialogue(LastLionHunter, false);
            LionHunter.SetActive(true);
        }
        //�ڶ��η����¼�����
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
    //��һ�ν�����ʿ����
    public void isFirstInGentleman()
    {
        _target._uiGo.GetComponent<DialogSystem>()
            .ShowDialogue(FirstGentlemanList, false);
    }
}
