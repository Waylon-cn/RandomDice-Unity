using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastorToGentleman : MonoBehaviour
{
    public GameObject target;
    public bool isFirst = true;
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)//�Ӵ�����������RubyController��������Ӵ�����������Ruby
        {
            if (isFirst)
            {
                GameEventSystem.instance._target = playerController;
                GameEventSystem.instance.isFirstInGentleman();
            }
            isFirst = false;
            collision.gameObject.transform.position = target.transform.position;
        }
    }
}
