using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject Thiscamera;

    public GameObject target;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)//�Ӵ�����������RubyController��������Ӵ�����������Ruby
        {
            collision.gameObject.transform.position = target.transform.position;
            Thiscamera.SetActive(false);
            target.GetComponent<TargetTest>().TargetCamera.SetActive(true);
        }
    }
}
