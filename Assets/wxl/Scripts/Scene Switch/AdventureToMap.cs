using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureToMap : MonoBehaviour
{
    public GameObject target;

    public int OutNum;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)//�Ӵ�����������RubyController��������Ӵ�����������Ruby
        {
            
            collision.gameObject.GetComponent<PlayerController>().position = "Map";
        }
        OutNum += 1;
        collision.gameObject.transform.position = target.transform.position;
    }
}
