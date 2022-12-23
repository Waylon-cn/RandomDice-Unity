using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutOffice : MonoBehaviour
{
    public bool In = false;
    [TextArea(1,3)] public string[] FirstIn;
    [TextArea(1,3)] public string[] FirstOut;//存放对话内容
    //存放第二次进入会长办公室内容
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.GetComponent<PlayerController>().PlayerRole !=
        //     FindObjectOfType<PlayerController>().PlayerRole)
        //     return;
        In = !In;
        if (In)
        {
            collision.gameObject.GetComponent<PlayerController>().position = "Office";
            if (GameEventSystem.instance.MapToAdventureNum == 1)
            {

                collision.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
                    .ShowDialogue(FirstIn, true);
            }
        }
        else
        {
            collision.gameObject.GetComponent<PlayerController>().position = "Adventure";
            //如果是第一此离开也会有对话
            if (GameEventSystem.instance.MapToAdventureNum == 1)
            {
                collision.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
                    .ShowDialogue(FirstOut, true);
            }
            // //第二次进入交流室，回复精力值
            // if (FindObjectOfType<MapToAdventure>().OutNum == 2)
            // {
            //     //此处加入回复所有玩家精力值的代码
            //     //
            //     //
            //     //
            //     //
            //     Debug.Log("精力回复");
            //
            // }
        }
    }
}
