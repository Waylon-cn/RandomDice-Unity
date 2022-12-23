using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStates : MonoBehaviour
{
    public Characterdata_so characterData;
    //��ȡ����
    #region Read from Data_SO    
    public int MaxHP //�������ֵ
    {   
        get{ if (characterData != null) return characterData.maxHP;else return 0;}
        set{characterData.maxHP = value;}
    }

    public int CurrentHP//��ǰ����ֵ
    {   
        get{ if ( characterData != null) return characterData.currentHP;else return 0;}
        set{ characterData.currentHP = value; }
    }

    public int MaxINT//����
    {   
        get{ if (characterData != null) return characterData.maxINT;else return 0;}
        set{ characterData.maxINT = value; }
    }

    public int CurrentINT
    {
        get { if (characterData != null) return characterData.currentINT; else return 0; }
        set { characterData.currentINT = value; }
    }

    public int MaxSQA//����
    {
        get { if (characterData != null) return characterData.maxSQA; else return 0; }
        set { characterData.maxSQA = value; }
    }
    public int CurrentSQA
    {
        get { if (characterData != null) return characterData.currentSQA; else return 0; }
        set { characterData.currentSQA= value; }
    }
    public int MaxPSC //����
    {
        get { if (characterData != null) return characterData.currentPSC; else return 0; }
        set { characterData.maxPSC= value; }
    }
    public int CurrentPSC
    {
        get { if (characterData != null) return characterData.currentPSC; else return 0; }
        set { characterData.currentPSC = value; }
    }
    public int MaxREN//����
    {
        get { if (characterData != null) return characterData.maxREN; else return 0; }
        set { characterData.maxREN = value; }
    }
    public int CurrentREN
    {
        get { if (characterData != null) return characterData.currentREN; else return 0; }
        set { characterData.currentREN = value; }
    }
    public int MaxSP//����
    {
        get { if (characterData != null) return characterData.maxSP; else return 0; }
        set { characterData.currentREN = value; }
    }
    public int CurrentSP
    {
        get { if (characterData != null) return characterData.currentSP; else return 0; }
        set { characterData.currentSP = value; }
    }
    #endregion 
}
