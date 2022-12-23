using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseToRoom : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)//�Ӵ�����������RubyController��������Ӵ�����������Ruby
        {
            playerController.MainToRoomToHouse();
        }
    }
}
