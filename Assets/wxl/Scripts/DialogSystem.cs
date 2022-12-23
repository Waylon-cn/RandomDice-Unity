using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class DialogSystem : MonoBehaviour
{
    public GameObject Dice;
    //跟踪对象
    private PlayerController _target;
    // public static DialogSystem instance;//MARKER SINGLETON PATTERN 单例模式
    //对话内容UI
    public GameObject DialogUI; //对话Panel
    //对话内容
    public TextMeshProUGUI DialogText;
    //交谈UI
    public GameObject ConversationUI;
    //对话者姓名
    public TextMeshProUGUI NameText;
    //交流类型：调查|交谈
    public TextMeshProUGUI interactionType;
    //玩家详情属性UI
    public GameObject InformationUI;
    //角色精力值
    public TextMeshProUGUI physicalStrength;
    //角色智力
    public TextMeshProUGUI intelligence;
    //角色敏捷
    public TextMeshProUGUI playerSpeed;
    //角色声望
    public TextMeshProUGUI reputation;
    //角色当前当前精力值血条
    public Slider sliderHp;
    //摇杆
    public Joystick joystick;
    //问题1
    public GameObject Question1;
    //问题1 text
    [SerializeField] public TextMeshProUGUI QuestionText1;
    //问题2
    public GameObject Question2;
    //问题2 text
    [SerializeField] public TextMeshProUGUI QuestionText2;
    //针对上述问题的回答1
    [TextArea(1,3)] public string[] Rely1;
    //针对上述问题的回答2
    [TextArea(1,3)] public string[] Rely2;
    //针对上述问题的回答2
    [TextArea(1,3)] public string[] Rely;
    [TextArea(1,3)] public string[] DialogTextList; //存放对话内容 前面的特性是为了在Inspector窗口中文字区域显示成三行
    //存放骰子事件的内容
    [TextArea(1,3)] public string[] TextList;
    [SerializeField] private int currentIndex;//对话数组索引

    private bool isScrolling;
    [SerializeField] private float textSpeed;
    // 定义一个变量来判断是否出现谈话内容
    public bool isConversation;
    public bool isEntered = false;

    public bool isEnterConversation = false;
    
    [TextArea(1,3)] public string[] FootList;

    public GameObject temp;
    // Start is called before the first frame update
    void Start()
    {
        DialogUI.SetActive(false);
        ConversationUI.SetActive(false);
        InformationUI.SetActive(false);
        Question1.SetActive(false);
        Question2.SetActive(false);
        Dice.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetTarget(PlayerController target){
        if (target == null) {
            Debug.Log("PlayMakerManager target for Play");
            return;
        }
        // 用于效率的缓存引用
        _target = target;

    }
    public void CloseDialog() //点击Close执行；关闭对话Panel
    {
        DialogUI.SetActive(false);
        isConversation = false;

        _target.canMove = true;
    }

    public void ContinueDialog()    //点击Continue按钮执行；继续下句话
    {
        if (isScrolling == false)
        {
            currentIndex++;
            if (currentIndex < DialogTextList.Length)
            {
                CheckName();
                StartCoroutine(ScrollingText());
                //DialogText.text = DialogTextList[currentIndex];
            }
            else
            {
                CloseDialog();
                // 允许人物移动
                _target.canMove = true;
            }
        }
    }
    // 出现交谈按钮
    public void ShowToConversation(bool CommunicateOrInter)
    {
        if (!CommunicateOrInter)
            interactionType.text = "交谈";
        else
        {
            interactionType.text = "调查";
        }
        ConversationUI.SetActive(true);
    }
    // 出现呼叫按钮
    public void ShowToCall()
    {
        interactionType.text = "呼叫";
        ConversationUI.SetActive(true);
    }
    // 关闭交谈按钮
    public void CloseToConversation()
    {
        ConversationUI.SetActive(false);
    }
    //出现问问题按钮
    public void ShowToAsk()
    {
        Question1.SetActive(true);
        Question2.SetActive(true);
    }
    //关闭问问题按钮
    public void CloseAsk()
    {
        Question1.SetActive(false);
        Question2.SetActive(false);
    }
    //选择了问题1
    public void OnClickedQuestion1()
    {
        CloseAsk();
        //开启谈话内容
        isConversation = true;
        Rely = Rely1;
    }
    //选择了问题2
    public void OnClickedQuestion2()
    {
        CloseAsk();
        //开启谈话内容
        isConversation = true;
        Rely = Rely2;
    }
    //显示问题回答
    public void RelyQuestion(bool name)
    {
        ShowDialogue(Rely, name);
    }
    //点击了交谈事件之后
    public void OnClickedConversation()
    {
        GameEventSystem.instance._target = _target;
        //开启谈话内容
        isConversation = true;
        //关闭交谈按钮
        ConversationUI.SetActive(false);
    }
    //出现对话框
    public void ShowDialogue(string[] _newLines, bool hasName)
    {
        DialogTextList = _newLines;
        currentIndex = 0;
        
        //禁止人物移动
        _target.canMove = false;

        CheckName();
        //DialogText.text = DialogTextList[currentIndex];//一行一行地显示
        StartCoroutine(ScrollingText());
        DialogUI.SetActive(true);
        
        NameText.gameObject.SetActive(hasName);
    }
    //检查对话名字
    private void CheckName()
    {
        if (DialogTextList[currentIndex].StartsWith("n-"))
        {
            NameText.text = DialogTextList[currentIndex].Replace("n-", "");
            currentIndex++;
        }
    }
    //对话一个字一个字出现
    private IEnumerator ScrollingText()
    {
        isScrolling = true;
        DialogText.text = "";
        foreach (char letter in DialogTextList[currentIndex].ToCharArray())
        {
            DialogText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        isScrolling = false;
    }
    //显示玩家详情属性
    public void showInformation()
    {
        var nowHp = sliderHp.value;
        physicalStrength.text =
            String.Format("{0}/{1}", nowHp * _target.MaxPhysicalStrength, _target.MaxPhysicalStrength);
        intelligence.text = String.Format("{0}", _target.intelligence);
        playerSpeed.text = String.Format("{0}", _target.playerSpeed);
        reputation.text = String.Format("{0}", _target.reputation);
        InformationUI.SetActive(true);
    }
    //关闭玩家详情属性
    public void closeInformation()
    {
        InformationUI.SetActive(false);
    }
    //骰子点击事件
    public void OnClickedDice()
    {
        Random rd = new Random();
        TextList[0] = String.Format("你掷出了骰子\n结果：{0}/100", rd.Next(100));
        ShowDialogue(TextList, false);
    }
    //使用技能灵感
    public void OnClickedInspiration()
    {
        if (_target.PhysicalStrength < 10)
        {
            TextList[0] = "精力值不足！！！";
            ShowDialogue(TextList, false);
            return;
        }

        _target.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().sliderHp.value -=
            10.0f / _target.gameObject.GetComponent<PlayerController>().PhysicalStrength;
        _target.PhysicalStrength -= 10;
        Random rd = new Random();
        int rdResult = rd.Next(6);
        //如果成功
        if ((_target.intelligence +
             _target.MaxPhysicalStrength) + 10 * (rdResult) > 160)
        {
            TextList[0] = String.Format("你使用了技能灵感。\n成功条件：智力值加精力值加色子点数乘10大于160。" +
                                        "\n六面色结果结果：{0}/6\n成功！", rdResult);
            ShowDialogue(TextList, false);
            if (GameEventSystem.instance.InspirationFindGuard == 1)
            {
                GameEventSystem.instance._target = _target;
                GameEventSystem.instance.InspirationFindGuard = 2;
            }
        }
        else
        {
            TextList[0] = String.Format("你使用了技能灵感。\n成功条件：智力值加精力值加色子点数乘10大于160。" +
                                        "\n六面色结果结果：{0}/6\n失败！", rdResult);
            ShowDialogue(TextList, false);
        }

    }
    //使用技能心理学
    public void OnClickedPsychology()
    {
        if (_target.PhysicalStrength < 10)
        {
            TextList[0] = "精力值不足！！！";
            ShowDialogue(TextList, false);
            return;
        }
        _target.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().sliderHp.value -=
            10.0f / _target.gameObject.GetComponent<PlayerController>().PhysicalStrength;
        _target.PhysicalStrength -= 10;
        Random rd = new Random();
        int rdResult = rd.Next(6);
        //如果成功
        if ((_target.intelligence +
             _target.MaxPhysicalStrength)  + 10 * (rdResult) > 160)
        {
            TextList[0] = String.Format("你使用了技能心理学\n成功条件：智力值加精力值加色子点数乘10大于160。" +
                                        "\n六面色结果结果：{0}/6\n成功！", rdResult);
            ShowDialogue(TextList, false);
            //如果在办公室且是第一次第一次
            if (_target.position == "Office" && GameEventSystem.instance.MapToAdventureNum == 1)
            {
                GameEventSystem.instance._target = _target;
                GameEventSystem.instance.IsPsychologyAdventure = true;
            }
            //如果是在牧师身边
            if (_target.isAroundPastor)
            {
                GameEventSystem.instance._target = _target;
                GameEventSystem.instance.isAroundPastorPsychology = true;
            }
            //如果是第二次进入办公室
            else if (_target.position == "Office" && GameEventSystem.instance.BlackNPC)
            {
                GameEventSystem.instance._target = _target;
                GameEventSystem.instance.SecondOfficePsychology = true;
            }
            
            // UILoader.instance.roomState = "PresidentAdventurerPsychology";
        }
        else
        {
            TextList[0] = String.Format("你使用了技能心理学\n成功条件：智力值精力值总和乘六面色点数大于160。" +
                                        "\n六面色结果结果：{0}/6\n失败。", rdResult);
            ShowDialogue(TextList, false);
        }
    }
    //使用技能侦查
    public void OnClickedDetection()
    {
        if (_target.PhysicalStrength < 10)
        {
            TextList[0] = "精力值不足！！！";
            ShowDialogue(TextList, false);
            return;
        }
        _target.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().sliderHp.value -=
            10.0f / _target.gameObject.GetComponent<PlayerController>().PhysicalStrength;
        _target.PhysicalStrength -= 10;
        Random rd = new Random();
        int rdResult = rd.Next(6);
        //如果成功
        if ((_target.intelligence +
             _target.MaxPhysicalStrength) + 10 * (rdResult) > 160)
        {
            TextList[0] = String.Format("你使用了技能侦查。\n成功条件：智力值加精力值加色子点数乘10大于160。" +
                                        "\n六面色结果结果：{0}/6\n成功！", rdResult);
            ShowDialogue(TextList, false);
            if (GameEventSystem.instance.BlackNPC && _target.position == "Map")
            {
                GameEventSystem.instance._target = _target;
                GameEventSystem.instance.DetectionFindGuard = true;
            }
        }
        else
        {
            TextList[0] = String.Format("你使用了技能侦查。\n成功条件：智力值加精力值加色子点数乘10大于160。" +
                                        "\n六面色结果结果：{0}/6\n失败！", rdResult);
            ShowDialogue(TextList, false);
        }
    }
    //使用技能现场发现
    public void OnClickedFind()
    {
        if (_target.PhysicalStrength < 10)
        {
            TextList[0] = "精力值不足！！！";
            ShowDialogue(TextList, false);
            return;
            
        }
        _target.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>().sliderHp.value -=
            10.0f / _target.gameObject.GetComponent<PlayerController>().PhysicalStrength;
        _target.PhysicalStrength -= 10;
        Random rd = new Random();
        int rdResult = rd.Next(6);
        //如果成功
        if ((_target.intelligence +
             _target.MaxPhysicalStrength) + 10 * (rdResult) > 160)
        {
            TextList[0] = String.Format("你使用了技能现场发现。\n成功条件：智力值加精力值加色子点数乘10大于160。" +
                                        "\n六面色结果结果：{0}/6\n成功！", rdResult);
            ShowDialogue(TextList, false);
            if (_target.position == "Adventure" && !GameEventSystem.instance.AdventureCamera.activeInHierarchy)
            {
                GameEventSystem.instance._target = _target;
                GameEventSystem.instance.HasCamera = true;
                GameEventSystem.instance.AdventureCamera.SetActive(true);
            }
        }
        else
        {
            TextList[0] = String.Format("你使用了技能现场发现。\n成功条件：智力值加精力值加色子点数乘10大于160。" +
                                        "\n六面色结果结果：{0}/6\n失败！", rdResult);
            ShowDialogue(TextList, false);
        }

    }

    public void OnClickedFoot()
    {
        temp.SetActive(false);
        ShowDialogue(FootList, false);
    }
    
    
}
