using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutOffice : MonoBehaviour
{
    public bool In = false;
    [TextArea(1,3)] public string[] FirstIn;
    [TextArea(1,3)] public string[] FirstOut;//��ŶԻ�����
    //��ŵڶ��ν���᳤�칫������
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
            //����ǵ�һ���뿪Ҳ���жԻ�
            if (GameEventSystem.instance.MapToAdventureNum == 1)
            {
                collision.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
                    .ShowDialogue(FirstOut, true);
            }
            // //�ڶ��ν��뽻���ң��ظ�����ֵ
            // if (FindObjectOfType<MapToAdventure>().OutNum == 2)
            // {
            //     //�˴�����ظ�������Ҿ���ֵ�Ĵ���
            //     //
            //     //
            //     //
            //     //
            //     Debug.Log("�����ظ�");
            //
            // }
        }
    }
}
