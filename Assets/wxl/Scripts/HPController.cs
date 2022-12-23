using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //Slider的调用需要引用UI源文件
public class HPController : MonoBehaviour
{
    public Slider hpController;
    //定义一个变量用于存储玩家的精力值
    [SerializeField]public float playerHp;
    // Start is called before the first frame update
    void Start() 
    {
        hpController.value = 1;  //Value的值介于0-1之间，且为浮点数
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (playerHp > 2.0f && FindObjectOfType<PlayerController>() != null)
    //     {
    //         playerHp = FindObjectOfType<PlayerController>().PhysicalStrength / 100.0f;
    //     }
    //     if (Input.GetKeyDown(KeyCode.A))  //如果按下A键，血量就会减少
    //     {
    //         hpController.value = hpController.value - 0.1f * (1.0f / playerHp);
    //     }
    //     else if (Input.GetKeyDown(KeyCode.D))  //按下D键，血量就会增加
    //     {
    //         hpController.value = hpController.value + 0.1f * (1.0f / playerHp);
    //     }
    // }
}