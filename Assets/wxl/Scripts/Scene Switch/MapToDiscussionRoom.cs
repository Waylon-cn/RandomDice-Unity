using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapToDiscussionRoom : MonoBehaviour
{
    public GameObject target;
    [TextArea(1,3)] public string[] FirstComuunicate;
    [TextArea(1,3)] public string[] SecondComuunicate;//��ŶԻ�����
    //��ŵڶ��ν���᳤�칫������

    // private int EnterNum = 0;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)//�Ӵ�����������RubyController��������Ӵ�����������Ruby
        {
            collision.gameObject.GetComponent<PlayerController>().position = "DiscussionRoom";
            // if (EnterNum == 0)
            // {
            //     EnterNum = 1;
            //     collision.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
            //         .ShowDialogue(FirstComuunicate, true);
            // }
            // //�ڶ��ν��뽻���ң��ظ�����ֵ
            // else if(EnterNum == 1)
            // {
            //     EnterNum = 2;
            //     //�˴�����ظ�������Ҿ���ֵ�Ĵ���
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
