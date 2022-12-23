using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOffice : MonoBehaviour
{
    public GameObject target;
    [TextArea(1, 3)] public string[] First;
    
    // public static MapToAdventure instance;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)//�Ӵ�����������RubyController��������Ӵ�����������Ruby
        {
            collision.gameObject.GetComponent<PlayerController>().position = "Office";
            if (GameEventSystem.instance.MapToAdventureNum == 1)
            {
                collision.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
                    .ShowDialogue(First, true);
            }
            
        }
        collision.gameObject.transform.position = target.transform.position;
    }
}