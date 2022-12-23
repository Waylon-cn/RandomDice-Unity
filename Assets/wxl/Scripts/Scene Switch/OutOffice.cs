using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOffice : MonoBehaviour
{
    public GameObject target;
    [TextArea(1, 3)] public string[] First;
    
    // public static MapToAdventure instance;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)//接触到的物体有RubyController组件，即接触到的物体是Ruby
        {
            collision.gameObject.GetComponent<PlayerController>().position = "Adventure";
            //如果是第一此离开也会有对话
            if (GameEventSystem.instance.MapToAdventureNum == 4)
            {
                collision.gameObject.GetComponent<PlayerController>()._uiGo.GetComponent<DialogSystem>()
                    .ShowDialogue(First, true);
            }
            
        }
        collision.gameObject.transform.position = target.transform.position;
    }
}
