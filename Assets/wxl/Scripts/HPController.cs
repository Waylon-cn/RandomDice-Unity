using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //Slider�ĵ�����Ҫ����UIԴ�ļ�
public class HPController : MonoBehaviour
{
    public Slider hpController;
    //����һ���������ڴ洢��ҵľ���ֵ
    [SerializeField]public float playerHp;
    // Start is called before the first frame update
    void Start() 
    {
        hpController.value = 1;  //Value��ֵ����0-1֮�䣬��Ϊ������
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (playerHp > 2.0f && FindObjectOfType<PlayerController>() != null)
    //     {
    //         playerHp = FindObjectOfType<PlayerController>().PhysicalStrength / 100.0f;
    //     }
    //     if (Input.GetKeyDown(KeyCode.A))  //�������A����Ѫ���ͻ����
    //     {
    //         hpController.value = hpController.value - 0.1f * (1.0f / playerHp);
    //     }
    //     else if (Input.GetKeyDown(KeyCode.D))  //����D����Ѫ���ͻ�����
    //     {
    //         hpController.value = hpController.value + 0.1f * (1.0f / playerHp);
    //     }
    // }
}