using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapToDiscussionRoom : MonoBehaviour
{
    public GameObject target;
    [TextArea(1,3)] public string[] FirstComuunicate;
    [TextArea(1,3)] public string[] SecondComuunicate;//存放对话内容
    //存放第二次进入会长办公室内容

    // private int EnterNum = 0;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)//接触到的物体有RubyController组件，即接触到的物体是Ruby
        {
            collision.gameObject.GetComponent<PlayerController>().position = "DiscussionRoom";
            // if (EnterNum == 0)
            // {
            //     EnterNum = 1;
            //     collision.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
            //         .ShowDialogue(FirstComuunicate, true);
            // }
            // //第二次进入交流室，回复精力值
            // else if(EnterNum == 1)
            // {
            //     EnterNum = 2;
            //     //此处加入回复所有玩家精力值的代码
            //     //
            //     //
            //     //
            //     //
            //     collision.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
            //         .ShowDialogue(SecondComuunicate, true);
            //     
            // }
            
        }
        collision.gameObject.transform.position = target.transform.position;
    }
}
