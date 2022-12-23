using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Data",menuName ="Character stats/data")]
public class Characterdata_so : ScriptableObject
{

    [Header("Stats Info")]

    public int maxHP;//最大生命值

    public int currentHP;//当前生命值

    public int maxINT;//智力

    public int currentINT;

    public int maxSQA;//敏捷

    public int currentSQA;

    public int maxPSC; //力量

    public int currentPSC;

    public int maxREN;//声望

    public int currentREN;

    public int maxSP;//精力

    public int currentSP;






}
