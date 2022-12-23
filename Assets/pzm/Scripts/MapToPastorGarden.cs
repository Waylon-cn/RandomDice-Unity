using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapToPastorGarden : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)//接触到的物体有RubyController组件，即接触到的物体是Ruby
        {
            playerController.MapToPastorGarden();
        }
    }
}
