using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //Slider�ĵ�����Ҫ����UIԴ�ļ�
public class hpcontrol : MonoBehaviour
{
    public Slider HPController;
    public int health;
 
    // Start is called before the first frame update
    void Start()
    {
        HPController.maxValue =100;  
    }

    // Update is called once per frame
    void Update()
    {

        HPController.value = health;
    }
}


