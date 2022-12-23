using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using Photon.Pun.Demo.PunBasics;
using ExitGames.Client.Photon;

public class walk : MonoBehaviour
{
    [Tooltip("npc对象预设")]
    public GameObject npc1;

    Animator animator;
    GameObject p1;

    [Tooltip("初始位置")]
    public Vector2 position1;

    [Tooltip("终止位置")]
    public Vector2 position2;

    // Start is called before the first frame update
    void Start()
    {
        p1 = Instantiate(npc1,position1, Quaternion.identity);
        animator = p1.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("Look X", 1);

        //若是从下往上则去掉下行注释
        //animator.SetFloat("Look Y", 1);
        animator.SetFloat("Speed", position2.magnitude);
        p1.transform.localPosition = Vector2.MoveTowards(p1.transform.localPosition, position2, Time.deltaTime);
    }
}
