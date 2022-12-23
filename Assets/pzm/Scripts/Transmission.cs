using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmission : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        collision.gameObject.transform.position = target.transform.position;

            if (GameEventSystem.instance.MapGentleman.activeInHierarchy)
        {
            GameEventSystem.instance.MapGentleman.SetActive(false);
            GameEventSystem.instance.MapPastor.SetActive(false);
        }
    }
}
