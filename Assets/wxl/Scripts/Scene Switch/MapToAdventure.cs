using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapToAdventure : MonoBehaviour
{
    public GameObject target;
    
    // public static MapToAdventure instance;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)//�Ӵ�����������RubyController��������Ӵ�����������Ruby
        {
            
            collision.gameObject.GetComponent<PlayerController>().position = "Adventure";
        }
        GameEventSystem.instance.MapToAdventureNum += 1;
        // if (GameEventSystem.instance.Adviser != null)
        //     GameEventSystem.instance.Adviser.instance.MapToAdventureNum += 1;
        // if (GameEventSystem.instance.Detective != null)
        //     GameEventSystem.instance.Detective.instance.MapToAdventureNum += 1;
        // if (GameEventSystem.instance.Police != null)
        //     GameEventSystem.instance.Police.instance.MapToAdventureNum += 1;
        collision.gameObject.transform.position = target.transform.position;
    }
}
