using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Kpui : MonoBehaviour
{    
    private PlayerController _target;//���ٶ���
    public Joystick joystick;//ң��

    //���1
#region player1data
    //�������
    public TextMeshProUGUI playername1;
    //��ɫ����
    public TextMeshProUGUI HP1;
    //��ɫ����
    public TextMeshProUGUI INT1;
    //��ɫ����
    public TextMeshProUGUI SQA1;
    //��ɫ����
    public TextMeshProUGUI PSC1;
    //��ɫ����
    public TextMeshProUGUI REN1;
    //��ɫ����ֵ
    public TextMeshProUGUI SP1;
    //��ɫ��ǰ��ǰHPѪ��
    public Slider sliderHp1;
    //��ɫ��ǰ��ǰMPѪ��
    public Slider sliderMp1;
    #endregion

    //���2
#region player2data
    //�������
    public TextMeshProUGUI playername2;
    //��ɫ����
    public TextMeshProUGUI HP2;
    //��ɫ����
    public TextMeshProUGUI INT2;
    //��ɫ����
    public TextMeshProUGUI SQA2;
    //��ɫ����
    public TextMeshProUGUI PSC2;
    //��ɫ����
    public TextMeshProUGUI REN2;
    //��ɫ����ֵ
    public TextMeshProUGUI SP2;
    //��ɫ��ǰ��ǰHPѪ��
    public Slider sliderHp2;
    //��ɫ��ǰ��ǰMPѪ��
    public Slider sliderMp2;
    #endregion

    //���3
#region player3data
    //�������
    public TextMeshProUGUI playername3;
    //��ɫ����
    public TextMeshProUGUI HP3;
    //��ɫ����
    public TextMeshProUGUI INT3;
    //��ɫ����
    public TextMeshProUGUI SQA3;
    //��ɫ����
    public TextMeshProUGUI PSC3;
    //��ɫ����
    public TextMeshProUGUI REN3;
    //��ɫ����ֵ
    public TextMeshProUGUI SP3;
    //��ɫ��ǰ��ǰHPѪ��
    public Slider sliderHp3;
    //��ɫ��ǰ��ǰMPѪ��
    public Slider sliderMp3;
    #endregion

    public CharacterStates characterstats1;
    public CharacterStates characterstats2;
    public CharacterStates characterstats3;


    // Start is called before the first frame update
    void Start()
    {

      
    }

    // Update is called once per frame
    void Update()
    {
          updataplayerstate();
    }   
    public void updataplayerstate()


    {
        // sliderHp1.value = characterstats1.CurrentHP;
        sliderMp1.value = characterstats1.CurrentSP;
        HP1.text = characterstats1.MaxHP.ToString()+'/'+characterstats1.CurrentHP.ToString();
        INT1.text = characterstats1.MaxINT.ToString() + '/' + characterstats1.CurrentINT.ToString();
        SQA1.text = characterstats1.MaxSQA.ToString() + '/' + characterstats1.CurrentSQA.ToString();
        PSC1.text = characterstats1.MaxPSC.ToString() + '/' + characterstats1.CurrentPSC.ToString();
        REN1.text = characterstats1.MaxREN.ToString() + '/' + characterstats1.CurrentREN.ToString();
        SP1.text = characterstats1.MaxSP.ToString() + '/' + characterstats1.CurrentSP.ToString();


        // sliderHp2.value = characterstats2.CurrentHP;
        sliderMp2.value = characterstats2.CurrentSP;
        HP2.text = characterstats2.MaxHP.ToString() + '/' + characterstats2.CurrentHP.ToString();
        INT2.text = characterstats2.MaxINT.ToString() + '/' + characterstats2.CurrentINT.ToString();
        SQA2.text = characterstats2.MaxSQA.ToString() + '/' + characterstats2.CurrentSQA.ToString();
        PSC2.text = characterstats2.MaxPSC.ToString() + '/' + characterstats2.CurrentPSC.ToString();
        REN2.text = characterstats2.MaxREN.ToString() + '/' + characterstats2.CurrentREN.ToString();
        SP2.text = characterstats2.MaxSP.ToString() + '/' + characterstats2.CurrentSP.ToString();


        // sliderHp3.value = characterstats3.CurrentHP;
        sliderMp3.value = characterstats3.CurrentSP;
        HP3.text = characterstats3.MaxHP.ToString() + '/' + characterstats3.CurrentHP.ToString();
        INT3.text = characterstats3.MaxINT.ToString() + '/' + characterstats3.CurrentINT.ToString();
        SQA3.text = characterstats3.MaxSQA.ToString() + '/' + characterstats3.CurrentSQA.ToString();
        PSC3.text = characterstats3.MaxPSC.ToString() + '/' + characterstats3.CurrentPSC.ToString();
        REN3.text = characterstats3.MaxREN.ToString() + '/' + characterstats3.CurrentREN.ToString();
        SP3.text = characterstats3.MaxSP.ToString() + '/' + characterstats3.CurrentSP.ToString();

    }
    public void SetTarget(PlayerController target)
    {
        if (target == null)
        {
            Debug.Log("PlayMakerManager target for Play");
            return;
        }
        // ����Ч�ʵĻ�������
        _target = target;

    }

}
