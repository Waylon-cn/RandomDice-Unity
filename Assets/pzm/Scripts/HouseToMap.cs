using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseToMap : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)//接触到的物体有RubyController组件，即接触到的物体是Ruby
        {
            playerController.HouseToMap();
        }
    }
}
