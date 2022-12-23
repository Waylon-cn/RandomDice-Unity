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
    [Tooltip("npc����Ԥ��")]
    public GameObject npc1;

    Animator animator;
    GameObject p1;

    [Tooltip("��ʼλ��")]
    public Vector2 position1;

    [Tooltip("��ֹλ��")]
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

        //���Ǵ���������ȥ������ע��
        //animator.SetFloat("Look Y", 1);
        animator.SetFloat("Speed", position2.magnitude);
        p1.transform.localPosition = Vector2.MoveTowards(p1.transform.localPosition, position2, Time.deltaTime);
    }
}
