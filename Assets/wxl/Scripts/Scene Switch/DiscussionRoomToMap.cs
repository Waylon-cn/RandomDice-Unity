using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscussionRoomToMap : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)//�Ӵ�����������RubyController��������Ӵ�����������Ruby
        {
            collision.gameObject.GetComponent<PlayerController>().position = "Map";
            // if (EnterNum == 0)
            // {
            //     EnterNum = 1;
            // }
            // //�ڶ��ν��뽻���ң��ظ�����ֵ
            // else if(EnterNum == 1)
            // {
            //     EnterNum = 2;
            // }
            // else if (EnterNum == 2)
            // {
            //     EnterNum = 3;
            //     GameEventSystem.instance.PastorAndGentlemanHelp = true;
            // }
            
            collision.gameObject.GetComponent<PlayerController>().PhysicalStrength += 20;
        }
        collision.gameObject.transform.position = target.transform.position;
        // GameEventSystem.instance._target = collision.gameObject.GetComponent<PlayerController>();
        GameEventSystem.instance.DiscussionRoomToMap += 1;
    }
}
