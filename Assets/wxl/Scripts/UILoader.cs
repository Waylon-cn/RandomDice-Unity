// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.SceneManagement;
// using UnityEngine;
//
// public class UILoader : MonoBehaviour
// {
//     public static UILoader instance;//MARKER SINGLETON PATTERN 单例模式
//     // 定义一个变量用于判断当前在交流室的状态
//     [SerializeField] public string roomState;
//
//     [SerializeField] private bool hasName;
//
//     [TextArea(1, 3)] public string[] lines;
//     // 第一次进入交流会欢迎对话
//     [TextArea(1, 3)] public string[] linesFirstCommunicate;
//     [TextArea(1, 3)] public string[] linesLeaveCommunicate;
//     //以下均为测试性场景对话
//     //对冒险家协会会长使用心理学成功
//     [TextArea(1, 3)] public string[] PresidentAdventurerPsychologyText;
//     // Start is called before the first frame update
//     private void Awake()
//     {
//         if (instance == null)
//         {
//             instance = this;
//         }
//         else
//         {
//             if (instance != this)
//             {
//                 Destroy(gameObject);
//             }
//         }
//         DontDestroyOnLoad(gameObject);
//     }
//     void Start()
//     {
//         // 如果实例未被创建，则开启UI场景
//         if (DialogSystem.instance == null)
//         {
//             //SceneManager.UnloadSceneAsync("MainScene");
//             SceneManager.LoadSceneAsync("DialogUIScenes", LoadSceneMode.Additive);
//             //SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
//         }
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         // 如果场景是第一次加载交流会场景，即弹窗语句
//         if (roomState == "FirstCommunicate")
//         {
//             DialogSystem.instance.ShowDialogue(linesFirstCommunicate, hasName);
//             roomState = "HasCommunicate";
//         }
//         else if (roomState == "LeaveCommunicate")
//         {
//             DialogSystem.instance.ShowDialogue(linesLeaveCommunicate, hasName);
//             roomState = "None";
//         }
//         else if (roomState == "PresidentAdventurerPsychology" && DialogSystem.instance.isAnotherConversation == false)
//         {
//             DialogSystem.instance.ShowDialogue(PresidentAdventurerPsychologyText, false);
//             roomState = "None";
//         }
//     }
// }
